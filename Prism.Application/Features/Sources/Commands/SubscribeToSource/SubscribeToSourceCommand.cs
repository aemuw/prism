using MediatR;

namespace Prism.Application.Features.Sources.Commands.SubscribeToSource
{
    public record SubscribeToSourceCommand(
        Guid UserId,
        Guid SourceId
    ) : IRequest<bool>;
}
