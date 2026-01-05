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
        Task<PagedResponse<UserResponse>> GetPagedAsync(PagedRequest request);
    }
}
