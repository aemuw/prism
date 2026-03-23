using MediatR;
using Prism.Application.Common;
using Prism.Application.DTOs.Articles;

namespace Prism.Application.Features.Articles.Queries.GetFeed
{
    public record GetFeedQuery(
        Guid UserId,
        int Page,
        int PageSize
    ) : IRequest<PagedResponse<ArticleResponse>>;
}
