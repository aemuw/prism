using Prism.Domain.Entities;

namespace Prism.Domain.Interfaces
{
    public interface IArticleRepository
    {
        Task<Article?> GetByIdAsync(Guid id);
        Task AddAsync(Article article);
        Task<bool> ExistsAsync(string url);
        Task<IReadOnlyList<Article>> GetPendingForAiAsync();
        Task<IReadOnlyList<Article>> GetFeedAsync(Guid userId, int page, int pageSize);
        Task<IReadOnlyList<Article>> SearchAsync(string query, int page, int pageSize);
        Task<IReadOnlyList<Article>> GetByTagAsync(string tagSlug, int page, int pageSize);
        Task<IReadOnlyList<Article>> GetBySourceAsync(Guid sourceId, int page, int pageSize);
    }
}
