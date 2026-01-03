using Blogoria.Data;
using Blogoria.Models.Entities;
using Blogoria.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blogoria.Repositories
{
    public class UserCommentRepository : IUserCommentRepository
    {
        private readonly BlogoriaDbContext _context;

        // Constructor
        public UserCommentRepository(BlogoriaDbContext context) => _context = context;

        // Get user comment by id
        public async Task<UserComment?> GetByIdAsync(int id)
            => await _context.UserComments
                .Include(c => c.BlogId)     // To let frontend know on which blog the user had commented
                .Include(c => c.UserId)     // To let frontend know which user had commented
                .FirstOrDefaultAsync(c => c.Id == c.Id);

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

        // Add a user comment
        public async Task AddAsync(UserComment userComment)
        {
            _context.UserComments.Add(userComment);
            await _context.SaveChangesAsync();
        }

        // Update a user comment
        public async Task UpdateAsync(UserComment userComment)
        {
            _context.UserComments.Update(userComment);
            await _context.SaveChangesAsync();
        }

        // Remove a user comment
        public async Task RemoveAsync(UserComment userComment)
        {
            _context.UserComments.Remove(userComment);
            await _context.SaveChangesAsync();
        }
    }
}
