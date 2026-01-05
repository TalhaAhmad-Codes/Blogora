using Blogoria.Contracts.Common;
using Blogoria.Contracts.Users;

namespace Blogoria.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserResponse> CreateAsync(CreateUserRequest request);
        Task<UserResponse?> GetByIdAsync(int id);
        Task<UserResponse?> GetByEmailAsync(string email);
        Task<bool> ExistsByEmailAsync(string email);
        Task<bool> UpdateUsernameAsync(int userId, UpdateUsernameRequest request);
        Task<bool> UpdateEmailAsync(int userId, UpdateEmailRequest request);
        Task<bool> UpdatePasswordAsync(int userId, UpdatePasswordRequest request);
        Task<bool> RemoveAsync(int userId);
        Task<PagedResponse<UserResponse>> GetPagedAsync(PagedRequest request);
    }
}
