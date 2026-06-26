using MediatR;
using Prism.Application.Exceptions;
using Prism.Domain.Interfaces;

namespace Prism.Application.Features.Articles.Commands.UnsaveArticle.UnsaveArticleCommand
{
    public class UnsaveArticleHandler
    {
        private readonly ISavedArticleRepository _savedArticleRepository;

        public UnsaveArticleHandler(ISavedArticleRepository savedArticleRepository)
        {
            _savedArticleRepository = savedArticleRepository;
        }

        public async Task<bool> Handle(
            UnsaveArticleCommand command, CancellationToken cancellationToken)
        {
            var exists = await _savedArticleRepository
                .ExistsAsync(command.UserId, command.ArticleId);

            if (!exists)
                throw new NotFoundException("Збереженої статті не знайдено");

            await _savedArticleRepository
                .DeleteAsync(command.UserId, command.ArticleId);

            return true;
        }
    }
}
