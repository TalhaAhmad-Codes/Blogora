using Blogoria.Misc;
using Blogoria.Misc.Exceptions;

namespace Blogoria.Models.Entities
{
    public sealed class Blog : BaseEntity
    {
        // Attributes
        public byte[]? FeaturedImage { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        private readonly List<UserReaction> _reactions = new();
        private readonly List<UserComment> _comments = new();
        public int UserId { get; private set; }

        public int TotalReactions => _reactions.Count;
        public int TotalComments => _comments.Count;
        
        // Navigation properties (EF Core)
        public User User { get; private set; }
        public IQueryable<UserComment> Comments
            => _comments.AsQueryable();
        public IQueryable<UserReaction> Reactions 
            => _reactions.AsQueryable();

        // Constructors
        private Blog() { }

        private Blog(byte[]? featuredImage, string title, string description, int userId)
        {
            // Guard against invalid values
            Guard.AgainstNullString(title, nameof(Title));
            Guard.AgainstNullString(description, nameof(Description));
            Guard.AgainstZeroOrLess(userId, nameof(UserId));

            // Assigning values
            FeaturedImage = featuredImage;
            Title = title;
            Description = description;
            UserId = userId;
        }

        // Method - Create a new blog
        public static Blog Create(byte[]? featuredImage, string title, string description, int userId)
            => new(featuredImage, title, description, userId);

        /*******************************************/
        /* Methods - Change properties of the Blog */
        /*******************************************/

        // Update featured image
        public void UpdateFeaturedImage(byte[]? featuredImage)
        {
            FeaturedImage = featuredImage;
            
            MarkUpdate();
        }

        // Update title of the blog
        public void UpdateTitle(string title)
        {
            Guard.AgainstNullString(title, nameof(Title));

            Title = title;

            MarkUpdate();
        }

        // Update description of the blog
        public void UpdateDescription(string description)
        {
            Guard.AgainstNullString(description, nameof(Description));

            Description = description;

            MarkUpdate();
        }

        // Add a user's reaction
        public void AddUserReaction(UserReaction userReaction)
        {
            // Rule: User can't react on his own blog
            if (userReaction.UserId == UserId)
                throw new SelfReactionException("User can't react on his own post.");

            // Rule: User can't react on an already reacted blog
            if (_reactions.Any(r => r.UserId == userReaction.UserId))
                throw new DuplicateReactionException("User has already reacted to this blog.");

            _reactions.Add(userReaction);

            MarkUpdate();
        }

        // Remove a user's reaction
        public void RemoveUserReaction(UserReaction userReaction)
        {
            if (!_reactions.Remove(userReaction))
                throw new EntityNotFoundException("Reaction not found.");

            MarkUpdate();
        }

        // Add a user's comment
        public void AddUserComment(UserComment userComment)
        {
            _comments.Add(userComment);

            MarkUpdate();
        }

        // Remove a user's comment
        public void RemoveUserComment(UserComment userComment)
        {
            if (!_comments.Remove(userComment))
                throw new EntityNotFoundException("Comment not found.");

            MarkUpdate();
        }
    }
}
