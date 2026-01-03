using Blogoria.Misc;
using Blogoria.Models.Enums;

namespace Blogoria.Models.Entities
{
    public sealed class UserReaction : BaseEntity
    {
        // Attributes
        public int UserId { get; private set; }
        public int BlogId { get; private set; }
        public ReactionType ReactionType { get; private set; }
        
        // Navigation property (EF Core)
        public User User { get; private set; }
        public Blog Blog { get; private set; }

        // Constructors
        private UserReaction() { }
        
        private UserReaction(int userId, int blogId, ReactionType reactionType)
        {
            Guard.AgainstZeroOrLess(userId, nameof(UserId));
            Guard.AgainstZeroOrLess(blogId, nameof(BlogId));

            UserId = userId;
            BlogId = blogId;
            ReactionType = reactionType;
        }

        // Method - Create a new user reaction
        public static UserReaction Create(int userId, int blogId, ReactionType reactionType)
            => new(userId, blogId, reactionType);

        // Method - Update reaction
        public void UpdateReactionType(ReactionType reactOnPost)
        {
            ReactionType = reactOnPost;
            MarkUpdate();
        }
    }
}
