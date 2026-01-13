namespace Blogoria.Misc
{
    public sealed class DomainException : Exception
    {
        public DomainException() : base() { }

        public DomainException(string message) : base(message) { }
    }
}
