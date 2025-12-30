using Blogoria.Misc;
using Blogoria.Models.Enums;

namespace Blogoria.Models.Entities
{
    public sealed class Blog : BaseEntity
    {
        // Attributes
        public byte[]? FeaturedImage { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public Dictionary<int, UserReaction> Reactions { get; private set; }
        public Dictionary<int, UserComment> Comments { get; private set; }
        public int UserId { get; private set; }
        public User User { get; private set; }

        // Constructors
        private Blog() { }

        private Blog(byte[]? featuredImage, string title, string description, Dictionary<int, UserReaction> reactions, Dictionary<int, UserComment> comments, int userId)
        {
            // Guard against invalid values
            Guard.AgainstNullString(title, nameof(Title));
            Guard.AgainstNullString(description, nameof(Description));

            // Assigning values
            FeaturedImage = featuredImage;
            Title = title;
            Description = description;
            Reactions = reactions;
            Comments = comments;
            UserId = userId;
        }

        // Method - Create a new blog
        public static Blog Create(byte[]? featuredImage, string title, string description, Dictionary<int, UserReaction> reactions, Dictionary<int, UserComment> comments, int userId)
            => new(featuredImage, title, description, reactions, comments, userId);

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
        public void AddUserReaction(int userReactionId, UserReaction userReaction)
        {
            // Rule: User can't react on his own blog
            if (userReaction.UserId == UserId)
                throw new InvalidOperationException("User can't react on his own post.");

            Reactions.Add(userReactionId, userReaction);
            MarkUpdate();
        }

        // Update a user's reaction
        public void UpdateUserReaction(int userReactionId, ReactOnPost reactOnPost)
        {
            Reactions[userReactionId].UpdateReactOnPost(reactOnPost);
            MarkUpdate();
        }

        // Remove a user's reaction
        public void RemoveUserReaction(int userReactionId)
        {
            Reactions.Remove(userReactionId);
            MarkUpdate();
        }

        // Add a user's comment
        public void AddUserComment(int userCommentId, UserComment userComment)
        {
            Comments.Add(userCommentId, userComment);
            MarkUpdate();
        }

        // Update a user's comment
        public void UpdateUserComment(int userCommentId, string comment)
        {
            Comments[userCommentId].UpdateComment(comment);
            MarkUpdate();
        }

        // Remove a user's comment
        public void RemoveUserComment(int userCommentId)
        {
            Comments.Remove(userCommentId);
            MarkUpdate();
        }
    }
}
