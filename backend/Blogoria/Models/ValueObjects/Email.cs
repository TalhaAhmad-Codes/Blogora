using Blogoria.Misc;

namespace Blogoria.Models.ValueObjects
{
    public sealed class Email
    {
        public string Value { get; }

        // Constructor
        private Email(string value) => Value = value;

        // Method - Create an email object
        public static Email Create(string value)
        {
            // Checking if email is null
            Guard.AgainstNullString(value, nameof(Email));

            // Matching pattern of the email
            Guard.AgainstInvalidEmail(value);

            return new Email(value);
        }

        // Method - To string convertor
        public override string ToString()
            => Value;
    }
}
