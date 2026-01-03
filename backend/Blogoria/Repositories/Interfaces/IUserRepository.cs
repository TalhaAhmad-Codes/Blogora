using Blogoria.Models.Entities;

namespace Blogoria.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(int id);
        Task<User?> GetByEmailAsync(string email);
        Task<bool> ExistsByEmailAsync(string email);

        Task<IEnumerable<User>> GetAllAsync();
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task RemoveAsync(User user);
    }
}
