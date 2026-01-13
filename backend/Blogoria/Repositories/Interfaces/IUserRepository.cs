using Blogoria.DTOs.Common;
using Blogoria.DTOs.UserDTOs;
using Blogoria.Models.Entities;

namespace Blogoria.Repositories.Interfaces
{
    public interface IUserRepository : IGeneralRepository<User>
    {
        Task<bool> ExistsByEmailAsync(string email);
        Task<PagedResultDto<User>> GetAllAsync(UserFilterDto filterDto);
    }
}
