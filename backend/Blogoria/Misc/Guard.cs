using System.Text.RegularExpressions;

namespace Blogoria.Misc
{
    public static class Guard
    {
        public static void AgainstNullString(string value, string property)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new DomainException($"{property} cannot be empty.");
        }

        public static void AgainstNegative(decimal value, string property)
        {
            if (value < 0)
                throw new DomainException($"{property} cannot be negative.");
        }

        public static void AgainstZeroOrLess(int value, string property)
        {
            if (value <= 0)
                throw new DomainException($"{property} must be greater than zero.");
        }

        public static void AgainstLowPasswordLength(string value, int limit)
        {
            if (value.Length < limit)
                throw new DomainException($"The given password length is invalid, it must be at least {limit} characters long.");
        }

        public static void AgainstOutOfRange(int rangeStart, int rangeEnd, int value, string property)
        {
            if (value < rangeStart || value > rangeEnd)
                throw new DomainException($"{property} must be between the range of {rangeStart} and {rangeEnd}.");
        }

        public static void AgainstInvalidRange(int start, int end, string property)
        {
            if (start > end)
                throw new DomainException($"{property} has invalid range of ({start}, {end}).");
        }

        public static void AgainstInvalidEmail(string email)
        {
            var pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(email, pattern))
                throw new DomainException("The given email format is invalid.");
        }
    }
}
