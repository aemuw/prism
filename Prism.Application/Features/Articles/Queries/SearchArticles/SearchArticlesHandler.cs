using MediatR;
using Prism.Application.Common;
using Prism.Application.DTOs.Articles;
using Prism.Domain.Interfaces;

namespace Prism.Application.Features.Articles.Queries.SearchArticles
{
    public class SearchArticlesHandler
        : IRequestHandler<SearchArticlesQuery, PagedResponse<ArticleResponse>>
    {
        private readonly IArticleRepository _articleRepository;
        private readonly ISavedArticleRepository _savedArticleRepository;

        public SearchArticlesHandler(
            IArticleRepository articleRepository,
            ISavedArticleRepository savedArticleRepository)
        {
            _articleRepository = articleRepository;
            _savedArticleRepository = savedArticleRepository;
        }

        public async Task<PagedResponse<ArticleResponse>> Handle(
            SearchArticlesQuery query, CancellationToken cancellationToken)
        {
            var articles = await _articleRepository
                .SearchAsync(query.SearchQuery, query.Page, query.PageSize);

            var saved = await _savedArticleRepository
                .GetByUserIdAsync(query.UserId);

            var savedIds = saved.Select(s => s.ArticleId).ToHashSet();

            var items = articles
                .Select(a => ArticleMapper.ToResponse(a, savedIds.Contains(a.Id)))
                .ToList();

            return new PagedResponse<ArticleResponse>
            {
                Items = items,
                TotalCount = articles.Count,
                Page = query.Page,
                PageSize = query.PageSize
            };
        }
    }
}
