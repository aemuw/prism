using MediatR;
using Prism.Application.Common;
using Prism.Application.DTOs;
using Prism.Application.DTOs.Articles;
using Prism.Domain.Interfaces;

namespace Prism.Application.Features.Articles.Queries.GetSavedArticles
{
    public class GetSavedArticlesHandler
        : IRequestHandler<GetSavedArticlesQuery, PagedResponse<ArticleResponse>>
    {
        private readonly ISavedArticleRepository _savedArticleRepository;

        public GetSavedArticlesHandler(ISavedArticleRepository savedArticleRepository)
        {
            _savedArticleRepository = savedArticleRepository;
        }

        public async Task<PagedResponse<ArticleResponse>> Handle(
            GetSavedArticlesQuery query, CancellationToken cancellationToken)
        {
            var (saved, totalCount) = await _savedArticleRepository
                .GetPagedByUserIdAsync(query.UserId, query.Page, query.PageSize);

            var items = saved
                .Select(s => ArticleMapper.ToResponse(s.Article!, isSaved: true))
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
