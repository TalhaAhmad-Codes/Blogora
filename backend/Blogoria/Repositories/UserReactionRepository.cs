using Blogoria.Data;
using Blogoria.DTOs.Common;
using Blogoria.DTOs.UserReactionDTOs;
using Blogoria.Interfaces.Repositories;
using Blogoria.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blogoria.Repositories
{
    public sealed class UserReactionRepository : GeneralRepository<UserReaction>, IUserReactionRepository
    {
        // Constructor
        public UserReactionRepository(BlogoriaDbContext context) : base(context) { }

        // Method - Get user reactions by applying filters
        public async Task<PagedResultDto<UserReaction>> GetFilteredUserReactionsAsync(UserReactionFilterDto filter)
        {
            var query = _dbSet.AsQueryable();

            // Applying filters
            if (filter.UserId.HasValue)
                query = query.Where(r => r.UserId == filter.UserId.Value);

            if (filter.ReactionType.HasValue)
                query = query.Where(r => r.ReactionType == filter.ReactionType.Value);

            // Calculation & applying paged result
            var totalCount = await query.CountAsync();

            var items = await query
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();

            return new PagedResultDto<UserReaction>
            {
                Items = items,
                TotalCount = totalCount
            };
        }
    }
}
