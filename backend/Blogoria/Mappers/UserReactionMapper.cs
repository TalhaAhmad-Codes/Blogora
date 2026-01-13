using Blogoria.DTOs.UserReactionDTOs;
using Blogoria.Models.Entities;

namespace Blogoria.Mappers
{
    public static class UserReactionMapper
    {
        public static UserReactionDto ToDto(UserReaction userReaction)
            => new() {
                Id = userReaction.Id,
                UserId = userReaction.UserId,
                BlogId = userReaction.BlogId,
                ReactionType = userReaction.ReactionType,
                CreatedAt = userReaction.CreatedAt,
                UpdatedAt = userReaction.UpdatedAt
            };
    }
}
