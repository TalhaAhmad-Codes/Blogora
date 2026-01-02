namespace Blogoria.DTOs.Common
{
    public abstract class PagedResultDto<T>
    {
        public IReadOnlyList<T> Items { get; init; } = [];
        public int TotalCount { get; init; }
    }
}
