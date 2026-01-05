using Blogoria.Data;
using Blogoria.Models.Entities;
using Blogoria.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blogoria.Repositories
{
    public sealed class UserCommentRepository : GeneralRepository<UserComment>, IUserCommentRepository
    {
        // Constructor
        public UserCommentRepository(BlogoriaDbContext context) : base(context) { }

        // Get user comments by blog id
        public async Task<IReadOnlyList<UserComment>> GetByBlogIdAsync(int blogId)
            => await _context.UserComments
                .Include(c => c.UserId)     // To let frontend know which user had commented
                .Where(c => c.BlogId == blogId)
                .ToListAsync();

        // Get user comments by user id
        public async Task<IReadOnlyList<UserComment>> GetByUserIdAsync(int userId)
            => await _context.UserComments
                .Include(r => r.BlogId)     // To let frontend know on which blog user had commented
                .Where(c => c.UserId == userId)
                .ToListAsync();
    }
}
