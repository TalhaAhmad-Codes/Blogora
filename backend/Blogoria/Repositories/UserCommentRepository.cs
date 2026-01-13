using Blogoria.Data;
using Blogoria.DTOs.Common;
using Blogoria.DTOs.UserCommentDTOs;
using Blogoria.Models.Entities;
using Blogoria.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blogoria.Repositories
{
    public sealed class UserCommentRepository : GeneralRepository<UserComment>, IUserCommentRepository
    {
        // Constructor
        public UserCommentRepository(BlogoriaDbContext context) : base(context) { }
        public async Task<bool> UserExists(int userId)
            => await _context.Users.AnyAsync(u => u.Id == userId);

        public async Task<bool> BlogExists(int blogId)
            => await _context.Blogs.AnyAsync(b => b.Id == blogId);

        public async Task<PagedResultDto<UserComment>> GetAllAsync(UserCommentFilterDto filterDto)
        {
            var query = _set.AsQueryable();

            // Applying filters
            if (filterDto.UserId.HasValue)
                query = query.Where(c => c.UserId == filterDto.UserId);

            if (filterDto.BlogId.HasValue)
                query = query.Where(c => c.BlogId == filterDto.BlogId);

            // Getting paged result
            var totalCount = await query.CountAsync();
            var items = await GetPagedResultItemsAsync(query, filterDto.PageNumber, filterDto.PageSize);

            return new PagedResultDto<UserComment>
            {
                Items = items,
                TotalCount = totalCount
            };
        }
    }
}
