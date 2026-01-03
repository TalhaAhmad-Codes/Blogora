using Blogoria.Contracts.Blogs;
using Blogoria.Contracts.Common;
using Blogoria.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Blogoria.Controllers
{
    [ApiController]
    [Route("api/blogs")]
    public sealed class BlogsController : ControllerBase
    {
        private readonly IBlogService _blogService;

        public BlogsController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromQuery] int authorId,
            CreateBlogRequest request)
        {
            var blog = await _blogService.CreateAsync(authorId, request);
            return Ok(blog);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var blog = await _blogService.GetByIdAsync(id);
            return blog is null ? NotFound() : Ok(blog);
        }

        [HttpGet]
        public async Task<IActionResult> GetPaged([FromQuery] PagedRequest request)
        {
            var result = await _blogService.GetPagedAsync(request);
            return Ok(result);
        }
    }
}
