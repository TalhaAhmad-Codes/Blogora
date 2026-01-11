using Blogoria.Data;
using Blogoria.DTOs.Common;
using Blogoria.DTOs.UserReactionDTOs;
using Blogoria.Models.Entities;
using Blogoria.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blogoria.Repositories
{
    public sealed class UserReactionRepository : GeneralRepository<UserReaction>, IUserReactionRepository
    {
        // Constructor
        public UserReactionRepository(BlogoriaDbContext context) : base(context) { }

        public async Task<PagedResultDto<UserReaction>> GetAllAsync(UserReactionFilterDto filterDto)
        {
            var query = _set.AsQueryable();

            // Applying filters
            if (filterDto.UserId.HasValue)
                query = query.Where(r => r.UserId == filterDto.UserId);

            if (filterDto.BlogId.HasValue)
                query = query.Where(r => r.BlogId == filterDto.BlogId);

            if (filterDto.ReactionType.HasValue)
                query = query.Where(r => r.ReactionType == filterDto.ReactionType);

            // Getting paged result
            var totalCount = await query.CountAsync();
            var items = await GetPagedResultItemsAsync(query, filterDto.PageNumber, filterDto.PageSize);

            return new PagedResultDto<UserReaction>
            {
                Items = items,
                TotalCount = totalCount
            };
        }
    }
}
