using Prism.Domain.Entities;

namespace Prism.Domain.Interfaces
{
    public interface IUserSourceRepository
    {
        Task<IReadOnlyList<UserSource>> GetByUserIdAsync(Guid userId);
        Task<bool> ExistsAsync(Guid userId, Guid sourceId);
        Task AddAsync(UserSource userSource);
        Task DeleteAsync(Guid userId, Guid sourceId);
    }
}
