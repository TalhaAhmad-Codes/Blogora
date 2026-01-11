using Blogoria.Data;
using Blogoria.DTOs.BlogDTOs;
using Blogoria.DTOs.Common;
using Blogoria.Misc;
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
            else
                query = query.Include(b => b.Comments);

            if (filterDto.ReactionOfUserId.HasValue)
                query = query.Include(b => b.Reactions.FirstOrDefault(r => r.UserId == filterDto.ReactionOfUserId));
            else
                query = query.Include(b => b.Reactions);

            if (filterDto.MinCommentsCount.HasValue)
                query = query.Where(b => b.Comments.Count >= filterDto.MinCommentsCount);

            if (filterDto.MaxCommentsCount.HasValue)
            {
                // Guard against invalid comments count range
                if (filterDto.MinCommentsCount.HasValue)
                    Guard.AgainstInvalidRange(
                        start: filterDto.MinCommentsCount.Value,
                        end: filterDto.MaxCommentsCount.Value,
                        property: "Comments count"
                    );

                query = query.Where(b => b.Comments.Count <= filterDto.MaxCommentsCount);
            }

            if (filterDto.MinReactionsCount.HasValue)
                query = query.Where(b => b.Reactions.Count >= filterDto.MinReactionsCount);

            if (filterDto.MaxReactionsCount.HasValue)
            {
                // Guard against invalid reactions count range
                if (filterDto.MinReactionsCount.HasValue)
                    Guard.AgainstInvalidRange(
                        start: filterDto.MinReactionsCount.Value,
                        end: filterDto.MaxReactionsCount.Value,
                        property: "Reactions count"
                    );

                query = query.Where(b => b.Reactions.Count <= filterDto.MaxReactionsCount);
            }

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
