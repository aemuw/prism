using Prism.Domain.Entities;

namespace Prism.Domain.Interfaces
{
    public interface ITagRepository
    {
        Task<Tag?> GetBySlugAsync(string slug);
        Task<IReadOnlyList<Tag>> GetAllAsync();
        Task<Tag?> GetByIdAsync(Guid id);
        Task AddAsync(Tag tag);
        Task<bool> ExistsAsync(string slug);
    }
}
