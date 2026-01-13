using Blogoria.Misc;

namespace Blogoria.Models.Entities
{
    public sealed class UserComment : BaseEntity
    {
        // Attributes
        public int UserId { get; private set; }
        public int BlogId { get; private set; }
        public string Comment { get; private set; }
        
        // Navigation property (EF Core)
        public User User { get; private set; }
        public Blog Blog { get; private set; }

        // Constructors
        private UserComment() { }
        
        private UserComment(int userId, int blogId, string comment)
        {
            // Guard against invalid value
            Guard.AgainstZeroOrLess(userId, nameof(UserId));
            Guard.AgainstZeroOrLess(blogId, nameof(BlogId));
            Guard.AgainstNullString(comment, nameof(Comment));

            // Assigning values
            UserId = userId;
            BlogId = blogId;
            Comment = comment;
        }

        // Method - Create a new comment
        public static UserComment Create(int userId, int blogId, string comment)
            => new(userId, blogId, comment);

        // Method - Update comment
        public void UpdateComment(string comment)
        {
            Guard.AgainstNullString(comment, nameof(Comment));

            Comment = comment;

            MarkUpdate();
        }
    }
}
