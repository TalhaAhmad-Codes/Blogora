using Blogoria.DTOs.Common;
using Blogoria.DTOs.UserCommentDTOs;

namespace Blogoria.Interfaces.Services
{
    public interface IUserCommentService
    {
        Task<PagedResultDto<UserCommentDto>> GetFilteredUserCommentsAsync(UserCommentFilterDto filter);
    }
}
