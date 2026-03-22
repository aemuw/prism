using Prism.Domain.Entities;

namespace Prism.Domain.Interfaces
{
    public interface ISavedArticleRepository
    {
        Task<IReadOnlyList<SavedArticle>> GetByUserIdAsyn(Guid userId);
        Task<bool> ExistsAsync(Guid userId, Guid articleId);
        Task AddAsync(SavedArticle savedArticle);
        Task DeleteAsync(Guid userId, Guid articleId);
    }
}
