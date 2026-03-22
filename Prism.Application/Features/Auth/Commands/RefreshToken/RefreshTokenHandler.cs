using MediatR;
using Prism.Application.DTOs.Auth;
using Prism.Application.Exceptions;
using Prism.Application.Interfaces;
using Prism.Domain.Interfaces;

namespace Prism.Application.Features.Auth.Commands.RefreshToken
{
    public class RefreshTokenHandler : IRequestHandler<RefreshTokenCommand, AuthResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;

        public RefreshTokenHandler(IUserRepository userRepository, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        public async Task<AuthResponse> Handle(RefreshTokenCommand command, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByRefreshTokenAsync(command.RefreshToken);

            if (user is null)
                throw new UnauthorizedException("Невалідний refresh token");

            if (user.RefreshTokenExpiry < DateTime.UtcNow)
                throw new UnauthorizedException("Refresh token прострочений");

            var newAccessToken = _jwtService.GenerateAccessToken(user);
            var newRefreshToken = _jwtService.GenerateRefreshToken();

            user.SetRefreshToken(newRefreshToken, DateTime.UtcNow.AddDays(7));
            await _userRepository.UpdateAsync(user);

            return new AuthResponse
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken,
                Email = user.Email,
                Username = user.Username,
                Role = user.Role.ToString()
            };
        }
    }
}
