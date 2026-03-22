using Prism.Domain.Entities;

namespace Prism.Domain.Interfaces
{
    public interface ISourceRepository
    {
        Task<Source?> GetByIdAsync(Guid id);
        Task<Source?> GetByUrlASync(string url);
        Task<IReadOnlyList<Source>> GetActiveAsync();
        Task<IReadOnlyList<Source>> SearchAsync(string query);
        Task<bool> ExistsAsync(string url);
        Task AddAsync(Source source);
        Task UpdateAsync(Source source);
    }
}
