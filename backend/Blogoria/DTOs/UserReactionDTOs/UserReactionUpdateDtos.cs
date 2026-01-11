using Blogoria.DTOs.Common;
using Blogoria.Models.Enums;

namespace Blogoria.DTOs.UserReactionDTOs.UserReactionUpdateDtos
{
    public sealed class UserReactionUpdateReactionDto : BaseDto
    {
        public ReactionType ReactionType { get; init; }
    }
}
