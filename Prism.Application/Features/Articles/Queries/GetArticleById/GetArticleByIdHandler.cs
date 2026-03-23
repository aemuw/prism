using MediatR;
using Prism.Application.DTOs.Articles;
using Prism.Application.Exceptions;
using Prism.Domain.Interfaces;

namespace Prism.Application.Features.Articles.Queries.GetArticleById
{
    public class GetArticleByIdHandler : IRequestHandler<GetArticleByIdQuery, ArticleDetailResponse>
    {
        private readonly IArticleRepository _articleRepository;
        private readonly ISavedArticleRepository _savedArticleRepository;

        public GetArticleByIdHandler(IArticleRepository articleRepository, ISavedArticleRepository savedArticleRepository)
        {
            _articleRepository = articleRepository;
            _savedArticleRepository = savedArticleRepository;
        }

        public async Task<ArticleDetailResponse> Handle(GetArticleByIdQuery query, CancellationToken cancellationToken)
        {
            var article = await _articleRepository.GetByIdAsync(query.ArticleId);

            if (article is null)
                throw new NotFoundException("Статтю не знайдено");

            var isSaved = await _savedArticleRepository.ExistsAsync(query.UserId, query.ArticleId);

            return new ArticleDetailResponse
            {
                Id = article.Id,
                Title = article.Title,
                Body = article.Body,
                AiSummary = article.AiSummary,
                Url = article.Url,
                Author = article.Author,
                SourceName = article.Source?.Name ?? string.Empty,
                PublishedAt = article.PublishedAt,
                Tags = article.Tags.Select(t => t.Name).ToList(),
                IsSaved = isSaved
            };
        }
    }
}