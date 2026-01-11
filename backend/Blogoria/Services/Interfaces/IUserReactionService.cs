using Blogoria.DTOs.Common;
using Blogoria.DTOs.UserReactionDTOs;
using Blogoria.DTOs.UserReactionDTOs.UserReactionUpdateDtos;

namespace Blogoria.Services.Interfaces
{
    public interface IUserReactionService
    {
        Task<UserReactionDto> AddUserReaction(UserReactionDto userReactionDto);
        Task<PagedResultDto<UserReactionDto>> GetAllAsync(UserReactionFilterDto filterDto);
        Task<UserReactionDto?> GetByIdAsync(int id);
        Task<bool> RemoveAsync(int id);
        Task<bool> UpdateUserReactionAsync(UserReactionUpdateReactionDto dto);
    }
}
