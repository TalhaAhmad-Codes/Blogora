using Blogoria.DTOs.BlogDTOs;
using Blogoria.Models.Entities;

namespace Blogoria.Mappers
{
    public static class BlogMapper
    {
        public static BlogDto ToDto(Blog blog)
            => new() {
                Id = blog.Id,
                AuthorId = blog.UserId,
                FeaturedImage = blog.FeaturedImage,
                Title = blog.Title,
                Description = blog.Description,
                CreatedAt = blog.CreatedAt,
                UpdatedAt = blog.UpdatedAt
            };
    }
}
