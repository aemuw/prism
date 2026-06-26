using MediatR;

namespace Prism.Application.Features.Articles.Commands.SaveArticle
{
    public record SaveArticleCommand(
        Guid UserId,
        Guid ArticleId
    ) : IRequest<bool>;
}
