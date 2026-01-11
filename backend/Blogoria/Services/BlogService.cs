using Blogoria.DTOs.BlogDTOs;
using Blogoria.DTOs.BlogDTOs.BlogUpdateDtos;
using Blogoria.DTOs.Common;
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

        public async Task<BlogDto> CreateAsync(BlogDto blogDto)
        {
            var blog = Blog.Create(
                featuredImage: blogDto.FeaturedImage,
                title: blogDto.Title,
                description: blogDto.Description,
                userId: blogDto.AuthorId
            );

            await _repository.AddAsync(blog);
            return blogDto;
        }

        public Task<PagedResultDto<BlogDto>> GetAllAsync(BlogFilterDto filterDto)
        {
            throw new NotImplementedException();
        }

        public Task<BlogDto?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateDescriptionAsync(BlogUpdateDescriptionDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateFeaturedImageAsync(BlogUpdateFeaturedImageDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateTitleAsync(BlogUpdateTitleDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
