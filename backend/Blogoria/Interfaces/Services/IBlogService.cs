using Blogoria.DTOs.BlogDTOs;
using Blogoria.DTOs.Common;

namespace Blogoria.Interfaces.Services
{
    public interface IBlogService
    {
        Task<PagedResultDto<BlogDto>> GetFilteredBlogsAsync(BaseFilterDto filter);
    }
}
