using MediatR;
using Prism.Application.DTOs.Auth;

namespace Prism.Application.Features.Auth.Commands.Login
{
    public record LoginCommand(
        string Email,
        string Password
    ) : IRequest<AuthResponse>;
}
