using Blogoria.Data;
using Blogoria.Models.Entities;
using Blogoria.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blogoria.Repositories
{
    public sealed class UserRepository : IUserRepository
    {
        private readonly BlogoriaDbContext _context;

        // Constructor
        public UserRepository(BlogoriaDbContext context) => _context = context;

        // Get user by Id
        public async Task<User?> GetByIdAsync(int id)
            => await _context.Users.FindAsync(id);

        // Get user by email
        public async Task<User?> GetByEmailAsync(string email)
            => await _context.Users.FirstOrDefaultAsync(u => u.Email.Value == email);

        // Check if a user exists or not by en email
        public async Task<bool> ExistsByEmailAsync(string email)
            => await _context.Users.AnyAsync(u => u.Email.Value == email);

        // Get all users
        public async Task<IEnumerable<User>> GetAllAsync()
            => await _context.Users.ToListAsync();

        // Add a user
        public async Task AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        // Update a user
        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        // Remove a user
        public async Task RemoveAsync(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
