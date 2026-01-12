using Blogoria.DTOs.Common;
using Blogoria.DTOs.UserCommentDTOs;
using Blogoria.Models.Entities;

namespace Blogoria.Repositories.Interfaces
{
    public interface IUserCommentRepository : IGeneralRepository<UserComment>
    {
        Task<bool> UserExists(int userId);
        Task<bool> BlogExists(int blogId);
        Task<PagedResultDto<UserComment>> GetAllAsync(UserCommentFilterDto filterDto);
    }
}
