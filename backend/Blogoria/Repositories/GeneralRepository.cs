using Blogoria.Data;
using Blogoria.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Blogoria.Repositories
{
    public abstract class GeneralRepository<T> : IGeneralRepository<T> where T : class
    {
        // Attributes
        protected readonly BlogoriaDbContext _context;
        protected readonly DbSet<T> _dbSet;

        // Constructor
        protected GeneralRepository(BlogoriaDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        // Method - Get all entities
        public async Task<IQueryable<T>?> GetAllAsync()
            => _dbSet.AsQueryable();

        // Method - Get entity by Id
        public async Task<T?> GetByIdAsync(int id)
            => await _dbSet.FindAsync(id);

        // Method - Add an entity into Database
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        // Method - Update an entity inside Database
        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        // Method - Remove an entity from Database
        public async Task RemoveAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
