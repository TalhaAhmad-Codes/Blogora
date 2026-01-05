using Blogoria.Data;
using Blogoria.Models.Entities;
using Blogoria.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blogoria.Repositories
{
    public sealed class UserRepository : GeneralRepository<User>, IUserRepository
    {
        // Constructor
        public UserRepository(BlogoriaDbContext context) : base(context) { }

        // Get user by email
        public async Task<User?> GetByEmailAsync(string email)
            => await _context.Users.FirstOrDefaultAsync(u => u.Email.Value == email);

        // Check if a user exists or not by en email
        public async Task<bool> ExistsByEmailAsync(string email)
            => await _context.Users.AnyAsync(u => u.Email.Value == email);
    }
}
