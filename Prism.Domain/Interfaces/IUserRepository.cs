using Prism.Domain.Entities;

namespace Prism.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(Guid id);
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByUsernameAsync(string username);
        Task<User?> GetByRefreshTokenAsync(string refreshToken);
        Task<bool> ExistsAsync(string email);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
    }
}
