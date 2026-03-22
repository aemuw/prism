using MediatR;

namespace Prism.Application.Features.Auth.Commands.Logout
{
    public record LogoutCommand(
        Guid UserId
    ) : IRequest<bool>;
}
