using Blogoria.Data;
using Blogoria.DTOs.Common;
using Blogoria.DTOs.UserCommentDTOs;
using Blogoria.Interfaces.Repositories;
using Blogoria.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blogoria.Repositories
{
    public class UserCommentRepository : GeneralRepository<UserComment>, IUserCommentRepository
    {
        // Constructor
        public UserCommentRepository(BlogoriaDbContext context) : base(context) { }

        // Method - Get all user comments by applying filters
        public async Task<PagedResultDto<UserComment>> GetFilteredUserCommentsAsync(UserCommentFilterDto filter)
        {
            var query = _dbSet.AsQueryable();

            // Applying filters
            if (filter.UserId.HasValue)
                query = query.Where(c => c.UserId == filter.UserId);

            // Calculation & applying paged result
            var totalCount = await query.CountAsync();

            var items = await query
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();

            return new PagedResultDto<UserComment>
            {
                Items = items,
                TotalCount = totalCount
            };
        }
    }
}
