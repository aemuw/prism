using MediatR;
using Prism.Application.DTOs.Auth;

namespace Prism.Application.Features.Auth.Commands.RefreshToken
{
    public record RefreshTokenCommand(
        string RefreshToken
    ) : IRequest<AuthResponse>;
}
