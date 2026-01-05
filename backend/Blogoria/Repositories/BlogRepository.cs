using Blogoria.Data;
using Blogoria.Models.Entities;
using Blogoria.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blogoria.Repositories
{
    public sealed class BlogRepository : GeneralRepository<Blog>, IBlogRepository
    {
        // Constructor
        public BlogRepository(BlogoriaDbContext context) : base(context) { }

        // Get blog by author id
        public async Task<IReadOnlyList<Blog>> GetByAuthorIdAsync(int authorId)
            => await _context.Blogs
                .Where(b => b.UserId == authorId)
                .ToListAsync();
    }
}
