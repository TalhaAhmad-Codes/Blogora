namespace Blogoria.Misc.Exceptions
{
    public sealed class EmailPatternMismatchException : Exception
    {
        public EmailPatternMismatchException(string message) : base(message) { }
    }
}
