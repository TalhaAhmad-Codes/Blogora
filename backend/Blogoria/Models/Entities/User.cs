using Blogoria.Misc;
using Blogoria.Models.ValueObjects;

namespace Blogoria.Models.Entities
{
    public sealed class User : BaseEntity
    {
        // Attributes
        public byte[]? ProfilePic { get; private set; }
        public Email Email { get; private set; }
        public string Username { get; private set; }
        public string PasswordHash { get; private set; }
        
        // Foriegn Attributes
        private readonly List<UserReaction> _reactions = new();
        private readonly List<UserComment> _comments = new();
        
        // Navigation properties
        public IReadOnlyCollection<UserReaction> Reactions => _reactions;
        public IReadOnlyCollection<UserComment> Comments => _comments;

        // Constructors
        private User() { }

        private User(byte[]? profilePic, string email, string username, string password)
        {
            // Guard against invalid values
            Guard.AgainstNullString(username, nameof(Username));
            Guard.AgainstNullString(password, nameof(PasswordHash));
            Guard.AgainstLowPasswordLength(password, 8);

            // Assigning values
            ProfilePic = profilePic;
            Email = Email.Create(email);
            Username = username;
            PasswordHash = PasswordHasher.Hash(password);
        }

        // Method - Create a new user
        public static User Create(byte[]? profilePic, string email, string username, string password)
            => new(profilePic, email, username, password);

        /*******************************************/
        /* Methods - Change properties of the User */
        /*******************************************/

        // Update profile pic
        public void UpdateProfilePic(byte[]? profilePic)
        {
            ProfilePic = profilePic;
            
            MarkUpdate();
        }

        // Update email address
        public void UpdateEmail(string password, string email)
        {
            if (!PasswordHasher.Verify(password, PasswordHash))
                throw new DomainException("Password didn't match.");

            Email = Email.Create(email);

            MarkUpdate();
        }

        // Update username
        public void UpdateUsername(string username)
        {
            Guard.AgainstNullString(username, nameof(Username));

            Username = username;

            MarkUpdate();
        }

        // Update password
        public void UpdatePassword(string oldPassword, string newPassword)
        {
            Guard.AgainstNullString(oldPassword, nameof(PasswordHash));
            Guard.AgainstNullString(newPassword, nameof(PasswordHash));
            Guard.AgainstLowPasswordLength(newPassword, 8);

            // Rule: For security concern, the user must enter old password to change his current password.
            if (!PasswordHasher.Verify(oldPassword, PasswordHash))
                throw new DomainException("Provided password didn't match with old one.");

            PasswordHash = PasswordHasher.Hash(newPassword);

            MarkUpdate();
        }
    }
}
