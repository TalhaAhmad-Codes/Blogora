using Blogoria.DTOs.UserReactionDTOs;
using Blogoria.DTOs.UserReactionDTOs.UserReactionUpdateDtos;
using Blogoria.Misc;
using Blogoria.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Blogoria.Controllers
{
    [ApiController]
    [Route("api/reactions")]
    public sealed class UserReactionController : ControllerBase
    {
        private readonly IUserReactionService _service;

        public UserReactionController(IUserReactionService service)
            => _service = service;

        [HttpPost]
        public async Task<IActionResult> AddAsync(AddUserReactionDto dto)
        {
            try
            {
                var reaction = await _service.AddUserReaction(dto);
                return Ok(reaction);
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var reaction = await _service.GetByIdAsync(id);
                return reaction is null ? NotFound() : Ok(reaction);
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("update/reaction-type")]
        public async Task<IActionResult> UpdateReactionTypeAsync(UserReactionUpdateReactionDto dto)
        {
            try
            {
                var result = await _service.UpdateUserReactionAsync(dto);
                return result ? Ok("User reaction has been successfully updated.") : NotFound();
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
                return result ? Ok("User reaction reaction has been successfully removed") : NotFound();
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetPagedResultAsync([FromQuery] UserReactionFilterDto dto)
        {
            try
            {
                var result = await _service.GetAllAsync(dto);
                return Ok(result);
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
