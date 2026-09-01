using MediatR;
using Prism.Application.DTOs.Sources;

namespace Prism.Application.Features.Sources.Queries.GetSources
{
    public record GetSourcesQuery(Guid UserId) : IRequest<List<SourceResponse>>;

}
