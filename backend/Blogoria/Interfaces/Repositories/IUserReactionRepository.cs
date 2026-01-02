using Blogoria.DTOs.Common;
using Blogoria.DTOs.UserReactionDTOs;
using Blogoria.Models.Entities;

namespace Blogoria.Interfaces.Repositories
{
    public interface IUserReactionRepository : IGeneralRepository<UserReaction>
    {
        Task<PagedResultDto<UserReaction>> GetFilteredUserReactionsAsync(UserReactionFilterDto filter);
    }
}
