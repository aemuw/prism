using MediatR;
using Prism.Application.Common;
using Prism.Application.DTOs.Articles;
using Prism.Domain.Interfaces;

namespace Prism.Application.Features.Articles.Queries.GetFeed
{
    public class GetFeedHandler : IRequestHandler<GetFeedQuery, PagedResponse<ArticleResponse>>
    {
        private readonly IArticleRepository _articleRepository;
        private readonly ISavedArticleRepository _savedArticleRepository;

        public GetFeedHandler(IArticleRepository articleRepository, ISavedArticleRepository savedArticleRepository)
        {
            _articleRepository = articleRepository;
            _savedArticleRepository = savedArticleRepository;
        }

        public async Task<PagedResponse<ArticleResponse>> Handle(GetFeedQuery query, CancellationToken cancellationToken)
        {
            var articles = await _articleRepository.GetFeedAsync(query.UserId, query.Page, query.PageSize);

            var totalCount = articles.Count;

            var savedArticleIds = await _savedArticleRepository.GetByUserIdAsync(query.UserId);

            var savedIds = savedArticleIds.Select(s => s.ArticleId).ToHashSet();

            var items = articles
                .Select(a => ArticleMapper.ToResponse(a, savedIds.Contains(a.Id)))
                .ToList();

            return new PagedResponse<ArticleResponse>
            {
                Items = items,
                TotalCount = totalCount,
                Page = query.Page,
                PageSize = query.PageSize
            };
        }
    }
}
