using Blogoria.Models.Entities;

namespace Blogoria.Repositories.Interfaces
{
    public interface IUserCommentRepository
    {
        Task<UserComment?> GetByIdAsync(int id);
        Task<IReadOnlyList<UserComment>> GetByBlogIdAsync(int blogId);
        Task<IReadOnlyList<UserComment>> GetByUserIdAsync(int userId);

        Task AddAsync(UserComment userComment);
        Task UpdateAsync(UserComment userComment);
        Task RemoveAsync(UserComment userComment);
    }
}
