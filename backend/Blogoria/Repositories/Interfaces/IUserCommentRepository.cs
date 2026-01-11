using Blogoria.DTOs.Common;
using Blogoria.DTOs.UserCommentDTOs;
using Blogoria.Models.Entities;

namespace Blogoria.Repositories.Interfaces
{
    public interface IUserCommentRepository : IGeneralRepository<UserComment>
    {
        Task<PagedResultDto<UserComment>> GetAllAsync(UserCommentFilterDto filterDto);
    }
}
