using Blogoria.Contracts.Blogs;
using Blogoria.Models.Entities;

namespace Blogoria.Repositories.Interfaces
{
    public interface IBlogRepository : IGeneralRepository<Blog>
    {
        Task<IEnumerable<Blog>> GetFilteredAsync(FilterBlogRequest filterRequest);
    }
}
