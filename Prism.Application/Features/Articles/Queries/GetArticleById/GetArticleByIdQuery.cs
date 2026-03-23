using MediatR;
using Prism.Application.DTOs.Articles;

namespace Prism.Application.Features.Articles.Queries.GetArticleById
{
    public record GetArticleByIdQuery(
        Guid ArticleId,
        Guid UserId
    ) : IRequest<ArticleDetailResponse>;
}
