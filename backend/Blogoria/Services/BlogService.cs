using Blogoria.DTOs.BlogDTOs;
using Blogoria.DTOs.BlogDTOs.BlogUpdateDtos;
using Blogoria.DTOs.Common;
using Blogoria.Mappers;
using Blogoria.Models.Entities;
using Blogoria.Repositories.Interfaces;
using Blogoria.Services.Interfaces;

namespace Blogoria.Services
{
    public sealed class BlogService : IBlogService
    {
        private readonly IBlogRepository _repository;

        public BlogService(IBlogRepository blogRepository)
        {
            _repository = blogRepository;
        }

        public async Task<BlogDto> CreateAsync(CreateBlogDto blogDto)
        {
            var blog = Blog.Create(
                featuredImage: blogDto.FeaturedImage,
                title: blogDto.Title,
                description: blogDto.Description,
                userId: blogDto.AuthorId
            );

            await _repository.AddAsync(blog);
            return BlogMapper.ToDto(blog);
        }

        public async Task<PagedResultDto<BlogDto>> GetAllAsync(BlogFilterDto filterDto)
        {
            var result = await _repository.GetAllAsync(filterDto);

            return new PagedResultDto<BlogDto>
            {
                Items = result.Items.Select(BlogMapper.ToDto).ToList(),
                TotalCount = result.TotalCount
            };
        }

        public async Task<BlogDto?> GetByIdAsync(int id)
        {
            var blog = await _repository.GetByIdAsync(id);

            return (blog is null) ? null : BlogMapper.ToDto(blog);
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var blog = await _repository.GetByIdAsync(id);

            if (blog is null) return false;

            await _repository.RemoveAsync(blog);
            return true;
        }

        public async Task<bool> UpdateDescriptionAsync(BlogUpdateDescriptionDto dto)
        {
            var blog = await _repository.GetByIdAsync(dto.Id);

            if (blog is null) return false;

            blog.UpdateDescription(dto.Description);
            await _repository.UpdateAsync(blog);
            return true;
        }

        public async Task<bool> UpdateFeaturedImageAsync(BlogUpdateFeaturedImageDto dto)
        {
            var blog = await _repository.GetByIdAsync(dto.Id);

            if (blog is null) return false;

            blog.UpdateFeaturedImage(blog.FeaturedImage);
            await _repository.UpdateAsync(blog);
            return true;
        }

        public async Task<bool> UpdateTitleAsync(BlogUpdateTitleDto dto)
        {
            var blog = await _repository.GetByIdAsync(dto.Id);

            if (blog is null) return false;

            blog.UpdateTitle(dto.Title);
            await _repository.UpdateAsync(blog);
            return true;
        }
    }
}
