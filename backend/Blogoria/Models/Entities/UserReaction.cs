using Blogoria.Misc;
using Blogoria.Models.Enums;

namespace Blogoria.Models.Entities
{
    public sealed class UserReaction : BaseEntity
    {
        // Attributes
        public int UserId { get; private set; }
        public ReactionType ReactionType { get; private set; }
        
        // Navigation property (EF Core)
        public User User { get; private set; }

        // Constructors
        private UserReaction() { }
        
        private UserReaction(int userId, ReactionType reactionType)
        {
            Guard.AgainstZeroOrLess(userId, nameof(UserId));

            UserId = userId;
            ReactionType = reactionType;
        }

        // Method - Create a new user reaction
        public static UserReaction Create(int userId, ReactionType reactionType)
            => new(userId, reactionType);

        // Method - Update reaction
        public void UpdateReactionType(ReactionType reactOnPost)
        {
            ReactionType = reactOnPost;
            MarkUpdate();
        }
    }
}
