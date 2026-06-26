using Prism.Application.DTOs.Articles;
using Prism.Domain.Entities;

namespace Prism.Application.Common
{
    public static class ArticleMapper
    {
        public static ArticleResponse ToResponse(Article article, bool isSaved) =>
            new ArticleResponse
            {
                Id = article.Id,
                Title = article.Title,
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
