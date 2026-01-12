using Blogoria.DTOs.UserCommentDTOs;
using Blogoria.DTOs.UserCommentDTOs.UserCommentUpdateDtos;
using Blogoria.Misc;
using Blogoria.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Blogoria.Controllers
{
    [ApiController]
    [Route("api/comments")]
    public sealed class UserCommentController : ControllerBase
    {
        private readonly IUserCommentService _service;

        public UserCommentController(IUserCommentService service)
            => _service = service;

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var comment = await _service.GetByIdAsync(id);
                return comment is null ? NotFound() : Ok(comment);
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetPagedesultAsync([FromQuery] UserCommentFilterDto dto)
        {
            try
            {
                var result = await _service.GetAllAsync(dto);
                return result is null ? NotFound() : Ok(result);
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
                return result ? Ok("User comment has been successfully removed.") : NotFound();
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddUserCommentAsync(AddUserCommentDto dto)
        {
            try
            {
                var comment = await _service.AddUserCommentAsync(dto);
                return Ok(comment);
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("update/comment")]
        public async Task<IActionResult> UpdateCommentAsync(UserCommentUpdateCommentDto dto)
        {
            try
            {
                var result = await _service.UpdateUserCommentAsync(dto);
                return result ? Ok("User comment has been successfully updated.") : NotFound();
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
