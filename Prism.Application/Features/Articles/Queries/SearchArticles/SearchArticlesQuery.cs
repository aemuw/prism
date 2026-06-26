using MediatR;
using Prism.Application.Common;
using Prism.Application.DTOs.Articles;

namespace Prism.Application.Features.Articles.Queries.SearchArticles
{
    public record SearchArticlesQuery(
        Guid UserId,
        string SearchQuery,
        int Page,
        int PageSize
    ) : IRequest<PagedResponse<ArticleResponse>>;
}
