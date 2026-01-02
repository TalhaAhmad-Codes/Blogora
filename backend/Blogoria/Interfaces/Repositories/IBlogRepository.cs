using Blogoria.DTOs.BlogDTOs;
using Blogoria.DTOs.Common;
using Blogoria.Models.Entities;

namespace Blogoria.Interfaces.Repositories
{
    public interface IBlogRepository : IGeneralRepository<Blog>
    {
        Task<Blog?> GetBlogAsync(int id);
        Task<PagedResultDto<Blog>> GetFilteredBlogsAsync(BlogFilterDto filter);
    }
}
