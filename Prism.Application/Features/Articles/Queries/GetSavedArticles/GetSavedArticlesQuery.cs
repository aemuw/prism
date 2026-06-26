using MediatR;
using Prism.Application.Common;
using Prism.Application.DTOs.Articles;

namespace Prism.Application.Features.Articles.Queries.GetSavedArticles
{
    public record GetSavedArticlesQuery(
        Guid UserId,
        int Page,
        int PageSize
    ) : IRequest<PagedResponse<ArticleResponse>>;
}
