namespace Blogoria.DTOs.Common
{
    public sealed class PagedResultDto<T> where T : class
    {
        public IReadOnlyList<T> Items { get; init; }
        public int TotalCount { get; init; }
    }
}
