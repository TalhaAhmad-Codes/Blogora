using Blogoria.Data;
using Blogoria.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blogoria.Repositories
{
    public abstract class GeneralRepository<T> : IGeneralRepository<T> where T : class
    {
        protected readonly BlogoriaDbContext _context;
        protected readonly DbSet<T> _set;

        public GeneralRepository(BlogoriaDbContext context)
        {
            _context = context;
            _set = _context.Set<T>();
        }

        // Get an entity by Id
        public async Task<T?> GetByIdAsync(int id)
            => await _set.FindAsync(id);

        // Add an entity
        public async Task AddAsync(T entity)
        {
            await _set.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        // Update an entity
        public async Task UpdateAsync(T entity)
        {
            _set.Update(entity);
            await _context.SaveChangesAsync();
        }

        // Remove an entity
        public async Task RemoveAsync(T entity)
        {
            _set.Remove(entity);
            await _context.SaveChangesAsync();
        }

        // Get paged result items
        protected async Task<List<T>> GetPagedResultItemsAsync(IQueryable<T> query, int pageNumber, int pageSize)
            => await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
    }
}
