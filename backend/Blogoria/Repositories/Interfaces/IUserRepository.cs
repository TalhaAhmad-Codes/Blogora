using Blogoria.Models.Entities;

namespace Blogoria.Repositories.Interfaces
{
    public interface IUserRepository : IGeneralRepository<User>
    {
        Task<User?> GetByEmailAsync(string email);
        Task<bool> ExistsByEmailAsync(string email);
    }
}
