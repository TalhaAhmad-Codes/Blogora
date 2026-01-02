using Blogoria.Data;
using Blogoria.DTOs.BlogDTOs;
using Blogoria.DTOs.Common;
using Blogoria.Interfaces.Repositories;
using Blogoria.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blogoria.Repositories
{
    public sealed class BlogRepository : GeneralRepository<Blog>, IBlogRepository
    {
        // Constructor
        public BlogRepository(BlogoriaDbContext context) : base(context) { }

        // Method - Get blog by id including comments and reactions
        public async Task<Blog?> GetBlogAsync(int id)
            => await _dbSet
                .Include(b => b.Comments)
                .Include(b => b.Reactions)
                .FirstOrDefaultAsync(b => b.Id == id);

        // Method - Get all blogs by applying filters
        public async Task<PagedResultDto<Blog>> GetFilteredBlogsAsync(BlogFilterDto filter)
        {
            var query = _dbSet.AsQueryable();

            // Applying filters
            if (filter.BlogUserId.HasValue)
                query = query.Where(b => b.UserId == filter.BlogUserId.Value);

            if (filter.MinReactionsCount.HasValue)
                query = query.Where(b => b.TotalReactions >= filter.MinReactionsCount.Value);

            if (filter.MaxReactionsCount.HasValue)
                query = query.Where(b => b.TotalReactions <= filter.MaxReactionsCount.Value);

            if (filter.MinCommentsCount.HasValue)
                query = query.Where(b => b.TotalComments >= filter.MinCommentsCount.Value);

            if (filter.MaxCommentsCount.HasValue)
                query = query.Where(b => b.TotalComments <= filter.MaxCommentsCount.Value);

            if (filter.ReactionType.HasValue)
                query = query.Where(b => b.Reactions.Any(r => r.ReactionType == filter.ReactionType.Value));

            // Calculation & applying paged result
            var totalCount = await query.CountAsync();

            var items = await query
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();

            return new PagedResultDto<Blog>
            {
                Items = items,
                TotalCount = totalCount
            };
        }
    }
}
