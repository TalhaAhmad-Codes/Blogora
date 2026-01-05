using Blogoria.Data;
using Blogoria.Models.Entities;
using Blogoria.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blogoria.Repositories
{
    public sealed class UserReactionRepository : GeneralRepository<UserReaction>, IUserReactionRepository
    {
        // Constructor
        public UserReactionRepository(BlogoriaDbContext context) : base(context) { }

        // Get user reactions by blog id
        public async Task<IReadOnlyList<UserReaction>> GetByBlogIdAsync(int blogId)
            => await _context.UserReactions
                .Include(r => r.UserId)     // To let frontend know which user had reacted
                .Where(r => r.BlogId == blogId)
                .ToListAsync();

        // Get user reactions by user id
        public async Task<IReadOnlyList<UserReaction>> GetByUserIdAsync(int userId)
            => await _context.UserReactions
                .Include(r => r.BlogId)     // To let frontend know on which blog user had reacted
                .Where(r => r.UserId == userId)
                .ToListAsync();
    }
}
