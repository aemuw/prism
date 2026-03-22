using MediatR;
using Prism.Application.DTOs.Auth;
using Prism.Application.Exceptions;
using Prism.Application.Interfaces;
using Prism.Domain.Interfaces;

namespace Prism.Application.Features.Auth.Commands.Login
{
    public class LoginHandler : IRequestHandler<LoginCommand, AuthResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtService _jwtService;

        public LoginHandler(IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtService = jwtService;
        }

        public async Task<AuthResponse> Handle(LoginCommand command, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(command.Email);

            if (user is null)
                throw new UnauthorizedException("Email не підтверджений. Перевірте пошту");

            if (!_passwordHasher.Verify(command.Password, user.PasswordHash))
                throw new UnauthorizedException("Невірний email або пароль");

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
    }
}
