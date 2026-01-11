using Blogoria.Models.Enums;

namespace Blogoria.DTOs.UserReactionDTOs
{
    public sealed class AddUserReactionDto
    {
        public int UserId { get; init; }
        public int BlogId { get; init; }
        public ReactionType ReactionType { get; init; }
    }
}
