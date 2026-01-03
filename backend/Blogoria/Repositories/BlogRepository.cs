using Blogoria.Data;
using Blogoria.Models.Entities;
using Blogoria.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blogoria.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogoriaDbContext _context;

        // Constructor
        public BlogRepository(BlogoriaDbContext context) => _context = context;

        // Get blog by id
        public async Task<Blog?> GetByIdAsync(int id)
            => await _context.Blogs
                .Include(b => b.User)
                .FirstOrDefaultAsync(b => b.Id == id);

        // Get blog by author id
        public async Task<IReadOnlyList<Blog>> GetByAuthorIdAsync(int authorId)
            => await _context.Blogs
                .Where(b => b.UserId == authorId)
                .ToListAsync();

        // Add a blog
        public async Task AddAsync(Blog blog)
        {
            _context.Blogs.Add(blog);
            await _context.SaveChangesAsync();
        }

        // Update a blog
        public async Task UpdateAsync(Blog blog)
        {
            _context.Blogs.Update(blog);
            await _context.SaveChangesAsync();
        }

        // Remove a blog
        public async Task RemoveAsync(Blog blog)
        {
            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();
        }
    }
}
