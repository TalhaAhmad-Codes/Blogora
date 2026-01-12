using Blogoria.DTOs.Common;
using Blogoria.DTOs.UserReactionDTOs;
using Blogoria.Models.Entities;

namespace Blogoria.Repositories.Interfaces
{
    public interface IUserReactionRepository : IGeneralRepository<UserReaction>
    {
        Task<bool> UserExists(int userId);
        Task<bool> BlogExists(int blogId);
        Task<PagedResultDto<UserReaction>> GetAllAsync(UserReactionFilterDto filterDto);
    }
}
