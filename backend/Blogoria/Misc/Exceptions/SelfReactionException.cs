namespace Blogoria.Misc.Exceptions
{
    public sealed class SelfReactionException : Exception
    {
        public SelfReactionException(string message) : base(message) { }
    }
}
