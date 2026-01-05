using Blogoria.Models.Entities;

namespace Blogoria.Repositories.Interfaces
{
    public interface IUserCommentRepository : IGeneralRepository<UserComment>
    {
        Task<IReadOnlyList<UserComment>> GetByBlogIdAsync(int blogId);
        Task<IReadOnlyList<UserComment>> GetByUserIdAsync(int userId);
    }
}
