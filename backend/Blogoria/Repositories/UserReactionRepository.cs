using Blogoria.Data;
using Blogoria.Models.Entities;
using Blogoria.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blogoria.Repositories
{
    public class UserReactionRepository : IUserReactionRepository
    {
        private readonly BlogoriaDbContext _context;

        // Constructor
        public UserReactionRepository(BlogoriaDbContext context) => _context = context;

        // Get a user reaction by id
        public async Task<UserReaction?> GetByIdAsync(int id)
            => await _context.UserReactions
                .Include(r => r.BlogId)     // To let frontend know on which blog the user had reacted
                .Include(r => r.UserId)     // To let frontend know which user had reacted
                .FirstOrDefaultAsync(r => r.Id == id);

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

        // Add a user reaction
        public async Task AddAsync(UserReaction userReaction)
        {
            _context.UserReactions.Add(userReaction);
            await _context.SaveChangesAsync();
        }

        // Update a user reaction
        public async Task UpdateAsync(UserReaction userReaction)
        {
            _context.Update(userReaction);
            await _context.SaveChangesAsync();
        }
        
        // Remove a user reaction
        public async Task RemoveAsync(UserReaction userReaction)
        {
            _context.Remove(userReaction);
            await _context.SaveChangesAsync();
        }
    }
}
