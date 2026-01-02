using Blogoria.DTOs.Common;
using Blogoria.DTOs.UserDTOs;

namespace Blogoria.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserDto?> GetByEmailAsync(string email);
        Task<PagedResultDto<UserDto>> GetFilteredUsersAsync(UserFilterDto filter);
    }
}
