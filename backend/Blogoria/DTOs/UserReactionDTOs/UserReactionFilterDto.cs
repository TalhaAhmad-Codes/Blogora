using Blogoria.DTOs.Common;
using Blogoria.Models.Enums;

namespace Blogoria.DTOs.UserReactionDTOs
{
    public sealed class UserReactionFilterDto : BaseFilterDto
    {
        public int? UserId { get; init; }
        public ReactionType? ReactionType { get; init; }
    }
}
