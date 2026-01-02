using Blogoria.DTOs.Common;
using Blogoria.DTOs.UserReactionDTOs;

namespace Blogoria.Interfaces.Services
{
    public interface IUserReactionService
    {
        Task<PagedResultDto<UserReactionDto>> GetFilteredUserReactionsAsync(UserReactionFilterDto filter);
    }
}
