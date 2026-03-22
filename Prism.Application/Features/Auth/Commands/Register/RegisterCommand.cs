using MediatR;
using Prism.Application.DTOs.Auth;

namespace Prism.Application.Features.Auth.Commands.Register
{
    public record RegisterCommand(
        string Username,
        string Email,
        string Password
    ) : IRequest<AuthResponse>;
}
