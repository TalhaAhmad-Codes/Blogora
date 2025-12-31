namespace Blogoria.Misc.Exceptions
{
    public sealed class DuplicateReactionException : Exception
    {
        public DuplicateReactionException(string message) : base(message) { }
    }
}
