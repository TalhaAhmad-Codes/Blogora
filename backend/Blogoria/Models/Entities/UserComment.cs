using Blogoria.Misc;

namespace Blogoria.Models.Entities
{
    public sealed class UserComment : BaseEntity
    {
        // Attributes
        public int UserId { get; private set; }
        public User User { get; private set; }
        public string Comment { get; private set; }

        // Constructors
        private UserComment() { }
        
        private UserComment(int userId, string comment)
        {
            // Guard against invalid value
            Guard.AgainstNullString(comment, nameof(Comment));

            // Assigning values
            UserId = userId;
            Comment = comment;
        }

        // Method - Create a new comment
        public static UserComment Create(int userId, string comment)
            => new(userId, comment);

        // Method - Update comment
        public void UpdateComment(string comment)
        {
            Guard.AgainstNullString(comment, nameof(Comment));

            Comment = comment;

            MarkUpdate();
        }
    }
}
