using Blogoria.DTOs.Common;
using Blogoria.DTOs.UserDTOs;
using Blogoria.Models.Entities;

namespace Blogoria.Interfaces.Repositories
{
    public interface IUserRepository : IGeneralRepository<User>
    {
        Task<PagedResultDto<User>> GetFilteredUsersAsync(UserFilterDto filter);
    }
}
