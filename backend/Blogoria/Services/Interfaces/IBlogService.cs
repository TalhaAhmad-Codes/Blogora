using Blogoria.DTOs.BlogDTOs;
using Blogoria.DTOs.BlogDTOs.BlogUpdateDtos;
using Blogoria.DTOs.Common;

namespace Blogoria.Services.Interfaces
{
    public interface IBlogService
    {
        Task<BlogDto> CreateAsync(BlogDto blogDto);
        Task<BlogDto?> GetByIdAsync(int id);
        Task<PagedResultDto<BlogDto>> GetAllAsync(BlogFilterDto filterDto);
        Task<bool> RemoveAsync(int id);

        Task<bool> UpdateFeaturedImageAsync(BlogUpdateFeaturedImageDto dto);
        Task<bool> UpdateTitleAsync(BlogUpdateTitleDto dto);
        Task<bool> UpdateDescriptionAsync(BlogUpdateDescriptionDto dto);
    }
}
