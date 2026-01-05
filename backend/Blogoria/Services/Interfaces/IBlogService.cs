using Blogoria.Contracts.Blogs;
using Blogoria.Contracts.Common;

namespace Blogoria.Services.Interfaces
{
    public interface IBlogService
    {
        Task<BlogResponse> CreateAsync(int authorId, CreateBlogRequest request);
        Task<BlogResponse?> GetByIdAsync(int id);
        Task<PagedResponse<BlogResponse>> GetFilteredAsync(FilterBlogRequest filterRequest, PagedRequest pagedRequest);
    }
}
