using Blogoria.Data;
using Blogoria.DTOs.Common;
using Blogoria.DTOs.UserDTOs;
using Blogoria.Models.Entities;
using Blogoria.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blogoria.Repositories
{
    public sealed class UserRepository : GeneralRepository<User>, IUserRepository
    {
        // Constructor
        public UserRepository(BlogoriaDbContext context) : base(context) { }

        // Checks whether a user exists by email or not
        public async Task<bool> ExistsByEmailAsync(string email)
            => await _set.AnyAsync(u => u.Email.Value == email);

        // Get users by applying filters and in paged result
        public async Task<PagedResultDto<User>> GetAllAsync(UserFilterDto filterDto)
        {
            var query = _set.AsQueryable();

            // Applying filters
            if (filterDto.Email != null)
                query = query.Where(u => u.Email.Value == filterDto.Email);

            if (filterDto.Username != null)
                query = query.Where(u => u.Username.ToLower() == filterDto.Username.ToLower());

            // Getting paged result
            var totalCount = await query.CountAsync();
            var items = await GetPagedResultItemsAsync(query, filterDto.PageNumber, filterDto.PageSize);

            return new PagedResultDto<User> 
            { 
                Items = items,
                TotalCount = totalCount
            };
        }
    }
}
