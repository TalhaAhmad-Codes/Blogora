namespace Blogoria.Contracts.Common
{
    // Values for paging
    public sealed record PagedRequest(
        int Page = 1,
        int PageSize = 10
    );

    // Get paged result/response
    public sealed record PagedResponse<T>(
        IReadOnlyList<T> Items,
        int TotalCount,
        int Page,
        int PageSize
    );
}
