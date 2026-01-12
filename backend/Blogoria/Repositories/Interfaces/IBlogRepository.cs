using Blogoria.DTOs.BlogDTOs;
using Blogoria.DTOs.Common;
using Blogoria.Models.Entities;

namespace Blogoria.Repositories.Interfaces
{
    public interface IBlogRepository : IGeneralRepository<Blog>
    {
        Task<PagedResultDto<Blog>> GetAllAsync(BlogFilterDto filterDto);
    }
}
