using MediatR;

namespace Prism.Application.Features.Articles.Commands.UnsaveArticle.UnsaveArticleCommand
{
    public record UnsaveArticleCommand(
        Guid UserId,
        Guid ArticleId
    ) : IRequest<bool>;
}
