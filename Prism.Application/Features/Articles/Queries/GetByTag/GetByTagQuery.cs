using MediatR;
using Prism.Application.Common;
using Prism.Application.DTOs.Articles;

namespace Prism.Application.Features.Articles.Queries.GetByTag
{
    public record GetByTagQuery(
        Guid UserId,
        string TagSlug,
        int Page,
        int PageSize
    ) : IRequest<PagedResponse<ArticleResponse>>;
}
