using MediatR;
using Prism.Application.DTOs.Auth;
using Prism.Application.Exceptions;
using Prism.Application.Interfaces;
using Prism.Domain.Entities;
using Prism.Domain.Interfaces;

namespace Prism.Application.Features.Auth.Commands.Register
{
    public class RegisterHandler : IRequestHandler<RegisterCommand, AuthResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtService _jwtService;
        private readonly IEmailService _emailService;

        public RegisterHandler(IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtService jwtService, IEmailService emailService)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtService = jwtService;
            _emailService = emailService;
        }

        public async Task<AuthResponse> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            if (await _userRepository.ExistsAsync(command.Email))
                throw new ValidationException("Email вже зайнятий");

            if (await _userRepository.GetByUsernameAsync(command.Username) != null)
                throw new ValidationException("Username вже зайнятий");

            var passwordHash = _passwordHasher.Hash(command.Password);

            var user = new User(command.Username, command.Email, passwordHash);

            var verificationCode = GenerateVerificationCode();
            user.SetVerificationCode(verificationCode, DateTime.UtcNow.AddHours(24));

            await _userRepository.AddAsync(user);

            await _emailService.SendVerificationEmailAsync(user.Email, user.Username, verificationCode);

            var accessToken = _jwtService.GenerateAccessToken(user);
            var refreshToken = _jwtService.GenerateRefreshToken();

            user.SetRefreshToken(refreshToken, DateTime.UtcNow.AddDays(7));

            await _userRepository.UpdateAsync(user);

            return new AuthResponse
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                Email = user.Email,
                Username = user.Username,
                Role = user.Role.ToString()
            };
        }

        private static string GenerateVerificationCode()
            => Random.Shared.Next(100000, 999999).ToString();
    }
}
