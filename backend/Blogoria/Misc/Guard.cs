using Blogoria.Misc.Exceptions;
using System.Text.RegularExpressions;

namespace Blogoria.Misc
{
    public static class Guard
    {
        public static void AgainstNullString(string value, string property)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new InvalidStringException($"{property} cannot be empty.");
        }

        public static void AgainstNegative(decimal value, string property)
        {
            if (value < 0)
                throw new InvalidValueException($"{property} cannot be negative.");
        }

        public static void AgainstZeroOrLess(int value, string property)
        {
            if (value <= 0)
                throw new InvalidValueException($"{property} must be greater than zero.");
        }

        public static void AgainstLowPasswordLength(string value, int limit, string property)
        {
            if (value.Length < limit)
                throw new InvalidCredentialsException($"{property} length must be at least {limit}.");
        }

        public static void AgainstOutOfRange(int rangeStart, int rangeEnd, int value, string property)
        {
            if (value < rangeStart || value > rangeEnd)
                throw new OutOfRangeException($"{property} must be between the range of {rangeStart} and {rangeEnd}.");
        }

        public static void AgainstInvalidEmail(string email)
        {
            var pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(email, pattern))
                throw new EmailPatternMismatchException("Email format is invalid.");
        }
    }
}
