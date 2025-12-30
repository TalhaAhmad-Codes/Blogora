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
        public string Password { get; private set; }

        // Constructors
        private User() { }

        private User(byte[]? profilePic, Email email, string username, string password)
        {
            // Guard against invalid values
            Guard.AgainstNullString(username, nameof(Username));
            Guard.AgainstNullString(password, nameof(Password));

            // Assigning values
            ProfilePic = profilePic;
            Email = email;
            Username = username;
            Password = password;
        }

        // Method - Create a new user
        public static User Create(byte[]? profilePic, Email email, string username, string password)
            => new(profilePic, email, username, password);

        /*******************************************/
        /* Methods - Change properties of the User */
        /*******************************************/

        // Update profile pic
        public void UpdateProfilePic(byte[]? profilePic = null)
        {
            ProfilePic = profilePic;
            
            MarkUpdate();
        }

        // Update email address
        public void UpdateEmail(string email)
        {
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
            // Rule: For security concern, the user must enter old password to change his current password.
            if (Password != oldPassword)
                throw new InvalidOperationException("Provided password didn't match with old one.");
            Guard.AgainstNullString(newPassword, nameof(Password));

            Password = newPassword;

            MarkUpdate();
        }
    }
}
