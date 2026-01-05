using Blogoria.Contracts.Blogs;
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
        public async Task<IEnumerable<Blog>> GetFilteredAsync(FilterBlogRequest filterRequest)
        {
            var query = _set.AsQueryable();

            if (filterRequest.AuthorId.HasValue)
                query = query.Where(b => b.UserId == filterRequest.AuthorId.Value);

            if (filterRequest.MinReactions.HasValue)
                query = query.Where(b => b.Reactions.Count >= filterRequest.MinReactions.Value);

            if (filterRequest.MaxReactions.HasValue)
                query = query.Where(b => b.Reactions.Count <= filterRequest.MaxReactions.Value);

            if (filterRequest.MinComments.HasValue)
                query = query.Where(b => b.Comments.Count >= filterRequest.MinComments.Value);

            if (filterRequest.MaxComments.HasValue)
                query = query.Where(b => b.Comments.Count <= filterRequest.MaxComments.Value);

            return await query.ToListAsync();
        }
    }
}
