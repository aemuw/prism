using Prism.Domain.Entities;

namespace Prism.Domain.Interfaces
{
    public interface ISavedArticleRepository
    {
        Task<IReadOnlyList<SavedArticle>> GetByUserIdAsync(Guid userId);
        Task<(IReadOnlyList<SavedArticle> Items, int TotalCount)> GetPagedByUserIdAsync(Guid userId, int page, int pageSize);
        Task<bool> ExistsAsync(Guid userId, Guid articleId);
        Task AddAsync(SavedArticle savedArticle);
        Task DeleteAsync(Guid userId, Guid articleId);
    }
}
