using Blogoria.DTOs.BlogDTOs;
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
        public async Task<IActionResult> Create(BlogDto blogDto)
        {
            var blog = await _blogService.CreateAsync(blogDto);
            return Ok(blog);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var blog = await _blogService.GetByIdAsync(id);
            return blog is null ? NotFound() : Ok(blog);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetPagedResult(BlogFilterDto filterDto)
        {
            var result = await _blogService.GetAllAsync(filterDto);
            return Ok(result);
        }
    }
}
