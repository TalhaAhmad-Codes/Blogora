using Blogoria.Models.Entities;

namespace Blogoria.Repositories.Interfaces
{
    public interface IUserReactionRepository
    {
        Task<UserReaction?> GetByIdAsync(int id);
        Task<IReadOnlyList<UserReaction>> GetByBlogIdAsync(int blogId);
        Task<IReadOnlyList<UserReaction>> GetByUserIdAsync(int userId);

        Task AddAsync(UserReaction userReaction);
        Task UpdateAsync(UserReaction userReaction);
        Task RemoveAsync(UserReaction userReaction);
    }
}
