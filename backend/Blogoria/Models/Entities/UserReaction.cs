using Blogoria.Misc;
using Blogoria.Models.Enums;

namespace Blogoria.Models.Entities
{
    public sealed class UserReaction : BaseEntity
    {
        // Attributes
        public int UserId { get; private set; }
        public ReactOnPost ReactOnPost { get; private set; }
        
        // Navigation property (EF Core)
        public User User { get; private set; }

        // Constructors
        private UserReaction() { }
        
        private UserReaction(int userId, ReactOnPost reactOnPost)
        {
            Guard.AgainstZeroOrLess(userId, nameof(UserId));

            UserId = userId;
            ReactOnPost = reactOnPost;
        }

        // Method - Create a new user reaction
        public static UserReaction Create(int userId, ReactOnPost reactOnPost)
            => new(userId, reactOnPost);

        // Method - Update reaction
        public void UpdateReactOnPost(ReactOnPost reactOnPost)
        {
            ReactOnPost = reactOnPost;
            MarkUpdate();
        }
    }
}
