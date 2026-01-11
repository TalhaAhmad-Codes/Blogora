using Blogoria.DTOs.BlogDTOs;
using Blogoria.DTOs.BlogDTOs.BlogUpdateDtos;
using Blogoria.Misc;
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
        public async Task<IActionResult> Create(CreateBlogDto blogDto)
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

        [HttpPut]
        [Route("/api/blogs/update/image")]
        public async Task<IActionResult> UpdateFeaturedImageAsync(BlogUpdateFeaturedImageDto dto)
        {
            var result = await _blogService.UpdateFeaturedImageAsync(dto);
            return result ? Ok("Featured image has been successfully updated.") : NotFound();
        }

        [HttpPut]
        [Route("/api/blogs/update/title")]
        public async Task<IActionResult> UpdateTitleAsync(BlogUpdateTitleDto dto)
        {
            try
            {
                var result = await _blogService.UpdateTitleAsync(dto);
                return result ? Ok("Title has been successfully updated.") : NotFound();
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("/api/blogs/update/description")]
        public async Task<IActionResult> UpdateDescriptionAsync(BlogUpdateDescriptionDto dto)
        {
            try
            {
                var result = await _blogService.UpdateDescriptionAsync(dto);
                return result ? Ok("Description has been successfully updated.") : NotFound();
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveAsync(int id)
        {
            var result = await _blogService.RemoveAsync(id);
            return result ? Ok("Blog has been successfully removed.") : NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetPagedResultAsync([FromQuery] BlogFilterDto filterDto)
        {
            var result = await _blogService.GetAllAsync(filterDto);
            return Ok(result);
        }
    }
}
