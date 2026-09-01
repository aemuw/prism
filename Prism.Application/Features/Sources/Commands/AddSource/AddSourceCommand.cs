using MediatR;
using Prism.Domain.Enums;

namespace Prism.Application.Features.Sources.Commands.AddSource
{
    public record AddSourceCommand(
        string Name,
        string Url,
        SourceType Type,
        Guid AddedByUserId
    ) : IRequest<Guid>;
}
