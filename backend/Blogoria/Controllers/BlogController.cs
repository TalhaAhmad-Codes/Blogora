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
        private readonly IBlogService _service;

        public BlogsController(IBlogService service)
            => _service = service;

        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogDto blogDto)
        {
            try
            {
                var blog = await _service.CreateAsync(blogDto);
                return Ok(blog);
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var blog = await _service.GetByIdAsync(id);
                return blog is null ? NotFound() : Ok(blog);
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("update/image")]
        public async Task<IActionResult> UpdateFeaturedImageAsync(BlogUpdateFeaturedImageDto dto)
        {
            try
            {
                var result = await _service.UpdateFeaturedImageAsync(dto);
                return result ? Ok("Featured image has been successfully updated.") : NotFound();
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("update/title")]
        public async Task<IActionResult> UpdateTitleAsync(BlogUpdateTitleDto dto)
        {
            try
            {
                var result = await _service.UpdateTitleAsync(dto);
                return result ? Ok("Title has been successfully updated.") : NotFound();
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("update/description")]
        public async Task<IActionResult> UpdateDescriptionAsync(BlogUpdateDescriptionDto dto)
        {
            try
            {
                var result = await _service.UpdateDescriptionAsync(dto);
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
            try
            {
                var result = await _service.RemoveAsync(id);
                return result ? Ok("Blog has been successfully removed.") : NotFound();
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetPagedResultAsync([FromQuery] BlogFilterDto filterDto)
        {
            try
            {
                var result = await _service.GetAllAsync(filterDto);
                return Ok(result);
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
