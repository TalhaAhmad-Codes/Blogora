using Blogoria.DTOs.UserDTOs;
using Blogoria.DTOs.UserDTOs.UserUpdateDtos;
using Blogoria.Misc;
using Blogoria.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Blogoria.Controllers
{
    [ApiController]
    [Route("/api/users")]
    public sealed class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserDto user)
        {
            try
            {
                var result = await _userService.CreateAsync(user);
                return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            return user is null ? NotFound() : Ok(user);
        }

        [HttpPut]
        [Route("/api/users/update/username")]
        public async Task<IActionResult> UpdateUsername(UserUpdateUsernameDto dto)
        {
            try
            {
                bool result = await _userService.UpdateUsernameAsync(dto);
                return result ? Ok("Username has been successfully updated.") : NotFound();
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("/api/users/update/email")]
        public async Task<IActionResult> UpdateEmail(UserUpdateEmailDto dto)
        {
            try
            {
                bool result = await _userService.UpdateEmailAsync(dto);
                return result ? Ok("Email has been successfully updated.") : NotFound();
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("/api/users/update/password")]
        public async Task<IActionResult> UpdatePassword(UserUpdatePasswordDto dto)
        {
            try
            {
                bool result = await _userService.UpdatePasswordAsync(dto);
                return result ? Ok("Password has been successfully updated.") : NotFound();
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("/api/users/update/profile-pic")]
        public async Task<IActionResult> UpdateProfilePic(UserUpdateProfilePicDto dto)
        {
            bool result = await _userService.UpdateProfilePicAsync(dto);
            return result ? Ok("Profile picture has been successfully updated.") : NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetPagedResult([FromQuery] UserFilterDto filterDto)
        {
            var result = await _userService.GetAllAsync(filterDto);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(int id)
        {
            var result = await _userService.RemoveAsync(id);
            return result ? Ok("User has been successfully removed.") : NotFound();
        }
    }
}
