using MediatR;
using Prism.Application.Exceptions;
using Prism.Domain.Entities;
using Prism.Domain.Interfaces;

namespace Prism.Application.Features.Articles.Commands.SaveArticle
{
    public class SaveArticleHandler : IRequestHandler<SaveArticleCommand, bool>
    {
        private readonly IArticleRepository _articleRepository;
        private readonly ISavedArticleRepository _savedArticleRepository;

        public SaveArticleHandler(
            IArticleRepository articleRepository,
            ISavedArticleRepository savedArticleRepository)
        {
            _articleRepository = articleRepository;
            _savedArticleRepository = savedArticleRepository;
        }

        public async Task<bool> Handle(
            SaveArticleCommand command, CancellationToken cancellationToken)
        {
            var article = await _articleRepository.GetByIdAsync(command.ArticleId);

            if (article is null)
                throw new NotFoundException("Статтю не знайдено");

            var alreadySaved = await _savedArticleRepository
                .ExistsAsync(command.UserId, command.ArticleId);

            if (alreadySaved)
                throw new ValidationException("Стаття вже збережена");

            var savedArticle = new SavedArticle(command.UserId, command.ArticleId);
            await _savedArticleRepository.AddAsync(savedArticle);

            return true;
        }
    }
}
