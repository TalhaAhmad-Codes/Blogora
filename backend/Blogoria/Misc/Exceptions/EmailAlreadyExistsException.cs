namespace Blogoria.Misc.Exceptions
{
    public sealed class EmailAlreadyExistsException : Exception
    {
        public EmailAlreadyExistsException(string message) : base(message) { }
    }
}
