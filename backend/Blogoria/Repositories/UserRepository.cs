using Blogoria.Data;
using Blogoria.DTOs.Common;
using Blogoria.DTOs.UserDTOs;
using Blogoria.Interfaces.Repositories;
using Blogoria.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blogoria.Repositories
{
    public sealed class UserRepository : GeneralRepository<User>, IUserRepository
    {
        // Constructor
        public UserRepository(BlogoriaDbContext context) : base(context) { }

        // Method - Get all users by applying filters
        public async Task<PagedResultDto<User>> GetFilteredUsersAsync(UserFilterDto filter)
        {
            var query = _dbSet.AsQueryable();

            // Applying filters
            if (filter.Username is not null)
                query = query.Where(u => u.Username == filter.Username);

            if (filter.Email is not null)
                query = query.Where(u => u.Email.Value == filter.Email);

            // Calculation & applying paged result
            var totalCount = await query.CountAsync();

            var items = await query
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();

            return new PagedResultDto<User> 
            {
                Items = items,
                TotalCount = totalCount
            };
        }
    }
}
