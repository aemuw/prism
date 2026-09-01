using MediatR;

namespace Prism.Application.Features.Sources.Commands.DeleteSource
{
    public record DeleteSourceCommand(Guid SourceId) : IRequest<bool>;
}
