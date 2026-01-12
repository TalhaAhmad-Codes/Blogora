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
            {
                var authorId = filterDto.AuthorId.Value;

                Guard.AgainstZeroOrLess(authorId, nameof(filterDto.AuthorId));

                query = query.Where(b => b.UserId == authorId);
            }

            if (filterDto.CommentOfUserId.HasValue)
            {
                var commentOfUserId = filterDto.CommentOfUserId.Value;

                Guard.AgainstZeroOrLess(commentOfUserId, nameof(filterDto.CommentOfUserId));
                
                query = query.Include(b => b.Comments.FirstOrDefault(c => c.UserId == commentOfUserId));
            }
            else
                query = query.Include(b => b.Comments);

            if (filterDto.ReactionOfUserId.HasValue)
            {
                var reactionOfUserId = filterDto.ReactionOfUserId.Value;

                Guard.AgainstZeroOrLess(reactionOfUserId, nameof(filterDto.ReactionOfUserId));

                query = query.Include(b => b.Reactions.FirstOrDefault(r => r.UserId == reactionOfUserId));
            }
            else
                query = query.Include(b => b.Reactions);

            if (filterDto.MinCommentsCount.HasValue)
            {
                var count = filterDto.MinCommentsCount.Value;

                Guard.AgainstNegative(count, nameof(filterDto.MinCommentsCount));

                query = query.Where(b => b.Comments.Count >= count);
            }

            if (filterDto.MaxCommentsCount.HasValue)
            {
                var count = filterDto.MaxCommentsCount.Value;

                Guard.AgainstNegative(count, nameof(filterDto.MaxCommentsCount));

                // Guard against invalid comments count range
                if (filterDto.MinCommentsCount.HasValue)
                    Guard.AgainstInvalidRange(
                        start: filterDto.MinCommentsCount.Value,
                        end: count,
                        property: "Comments count"
                    );

                query = query.Where(b => b.Comments.Count <= count);
            }

            if (filterDto.MinReactionsCount.HasValue)
            {
                var count = filterDto.MinReactionsCount.Value;

                Guard.AgainstNegative(count, nameof(filterDto.MinReactionsCount));

                query = query.Where(b => b.Reactions.Count >= count);
            }

            if (filterDto.MaxReactionsCount.HasValue)
            {
                var count = filterDto.MaxReactionsCount.Value;

                Guard.AgainstNegative(count, nameof(filterDto.MaxReactionsCount));

                // Guard against invalid reactions count range
                if (filterDto.MinReactionsCount.HasValue)
                    Guard.AgainstInvalidRange(
                        start: filterDto.MinReactionsCount.Value,
                        end: count,
                        property: "Reactions count"
                    );

                query = query.Where(b => b.Reactions.Count <= count);
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
