using Blogoria.DTOs.Common;
using Blogoria.DTOs.UserCommentDTOs;
using Blogoria.Models.Entities;

namespace Blogoria.Interfaces.Repositories
{
    public interface IUserCommentRepository : IGeneralRepository<UserComment>
    {
        Task<PagedResultDto<UserComment>> GetFilteredUserCommentsAsync(UserCommentFilterDto filter);
    }
}
