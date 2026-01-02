namespace Blogoria.DTOs.Common
{
    public abstract class BaseFilterDto
    {
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 10;
    }
}
