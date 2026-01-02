using Blogoria.DTOs.BlogDTOs;
using Blogoria.DTOs.Common;
using Blogoria.Models.Entities;

namespace Blogoria.Interfaces.Repositories
{
    public interface IBlogRepository : IGeneralRepository<Blog>
    {
        Task<PagedResultDto<Blog>> GetFilteredBlogsAsync(BlogFilterDto filter);
    }
}
