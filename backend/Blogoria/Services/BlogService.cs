using Blogoria.Contracts.Blogs;
using Blogoria.Contracts.Common;
using Blogoria.Models.Entities;
using Blogoria.Repositories.Interfaces;
using Blogoria.Services.Interfaces;

namespace Blogoria.Services
{
    public sealed class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;

        public BlogService(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<BlogResponse> CreateAsync(int authorId, CreateBlogRequest request)
        {
            var blog = Blog.Create(
                featuredImage: null,
                title: request.Title,
                description: request.Description,
                userId: authorId
            );

            await _blogRepository.AddAsync(blog);

            return MapToResponse(blog);
        }

        public async Task<BlogResponse?> GetByIdAsync(int id)
        {
            var blog = await _blogRepository.GetByIdAsync(id);
            return blog is null ? null : MapToResponse(blog);
        }

        public async Task<PagedResponse<BlogResponse>> GetPagedAsync(PagedRequest request)
        {
            var page = request.Page <= 0 ? 1 : request.Page;
            var pageSize = request.PageSize <= 0 ? 10 : request.PageSize;

            var blogs = await _blogRepository.GetAllAsync();
            var total = blogs.Count();

            var items = blogs
                .OrderByDescending(b => b.CreatedAt)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(MapToResponse)
                .ToList();

            return new PagedResponse<BlogResponse>(
                items,
                total,
                page,
                pageSize
            );
        }

        private static BlogResponse MapToResponse(Blog blog)
            => new(
                Id: blog.Id,
                FeaturedImage: blog.FeaturedImage,
                Title: blog.Title,
                Description: blog.Description,
                AuthorId: blog.UserId,
                CreatedAt: blog.CreatedAt,
                UpdatedAt: blog.UpdatedAt
            );
    }
}
