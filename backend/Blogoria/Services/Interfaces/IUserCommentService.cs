using Blogoria.DTOs.Common;
using Blogoria.DTOs.UserCommentDTOs;
using Blogoria.DTOs.UserCommentDTOs.UserCommentUpdateDtos;

namespace Blogoria.Services.Interfaces
{
    public interface IUserCommentService
    {
        Task<UserCommentDto> AddUserCommentAsync(UserCommentDto userCommentDto);
        Task<PagedResultDto<UserCommentDto>> GetAllAsync(UserCommentFilterDto filterDto);
        Task<UserCommentDto?> GetByIdAsync(int id);
        Task<bool> RemoveAsync(int id);
        Task<bool> UpdateUserCommentAsync(UserCommentUpdateCommentDto dto);
    }
}
