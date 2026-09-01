using MediatR;

namespace Prism.Application.Features.Users.Commands.BlockUser
{
    public record BlockUserCommand(Guid UserId) : IRequest<bool>;
}
