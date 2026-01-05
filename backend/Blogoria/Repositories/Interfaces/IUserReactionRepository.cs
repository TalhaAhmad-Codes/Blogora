using Blogoria.Models.Entities;

namespace Blogoria.Repositories.Interfaces
{
    public interface IUserReactionRepository : IGeneralRepository<UserReaction>
    {
        Task<IReadOnlyList<UserReaction>> GetByBlogIdAsync(int blogId);
        Task<IReadOnlyList<UserReaction>> GetByUserIdAsync(int userId);
    }
}
