using Blogoria.Data;
using Blogoria.DTOs.BlogDTOs;
using Blogoria.DTOs.Common;
using Blogoria.Models.Entities;
using Blogoria.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blogoria.Repositories
{
    public sealed class BlogRepository : GeneralRepository<Blog>, IBlogRepository
    {
        // Constructor
        public BlogRepository(BlogoriaDbContext context) : base(context) { }

        public async Task<PagedResultDto<Blog>> GetAllAsync(BlogFilterDto filterDto)
        {
            var query = _set.AsQueryable();

            // Applying filters
            if (filterDto.AuthorId.HasValue)
                query = query.Where(b => b.UserId == filterDto.AuthorId);

            if (filterDto.CommentOfUserId.HasValue)
                query = query.Include(b => b.Comments.FirstOrDefault(c => c.UserId == filterDto.CommentOfUserId));

            if (filterDto.ReactionOfUserId.HasValue)
                query = query.Include(b => b.Reactions.FirstOrDefault(r => r.UserId == filterDto.ReactionOfUserId));

            if (filterDto.MinCommentsCount.HasValue)
                query = query.Where(b => b.TotalComments >= filterDto.MinCommentsCount);

            if (filterDto.MaxCommentsCount.HasValue)
                query = query.Where(b => b.TotalComments <= filterDto.MaxCommentsCount);

            if (filterDto.MinReactionsCount.HasValue)
                query = query.Where(b => b.TotalReactions >= filterDto.MinReactionsCount);

            if (filterDto.MaxReactionsCount.HasValue)
                query = query.Where(b => b.TotalReactions <= filterDto.MaxReactionsCount);

            // Getting paged result
            var totalCount = await query.CountAsync();
            var items = await GetPagedResultItemsAsync(query, filterDto.PageNumber, filterDto.PageSize);

            return new PagedResultDto<Blog>
            {
                Items = items,
                TotalCount = totalCount
            };
        }
    }
}
