
using Blogoria.DTOs.Common;
using Blogoria.DTOs.UserDTOs;
using Blogoria.DTOs.UserDTOs.UserUpdateDtos;

namespace Blogoria.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> CreateAsync(CreateUserDto userDto);
        Task<PagedResultDto<UserDto>> GetAllAsync(UserFilterDto filterDto);
        Task<UserDto?> GetByIdAsync(int id);
        Task<bool> RemoveAsync(int id);
        Task<bool> UpdateProfilePicAsync(UserUpdateProfilePicDto dto);
        Task<bool> UpdateUsernameAsync(UserUpdateUsernameDto dto);
        Task<bool> UpdateEmailAsync(UserUpdateEmailDto dto);
        Task<bool> UpdatePasswordAsync(UserUpdatePasswordDto dto);
    }
}
