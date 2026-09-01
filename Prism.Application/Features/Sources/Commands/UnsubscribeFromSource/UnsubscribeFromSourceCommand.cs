using MediatR;

namespace Prism.Application.Features.Sources.Commands.UnsubscribeFromSource
{
    public record UnsubscribeFromSourceCommand(
        Guid UserId,
        Guid SourceId
    ) : IRequest<bool>;
}
