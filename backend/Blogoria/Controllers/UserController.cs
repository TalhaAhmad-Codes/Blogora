using Blogoria.Contracts.Common;
using Blogoria.Contracts.Users;
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
        public async Task<IActionResult> Create(CreateUserRequest request)
        {
            var result = await _userService.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            return user is null ? NotFound() : Ok(user);
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            var user = await _userService.GetByEmailAsync(email);
            return user is null ? NotFound() : Ok(user);
        }

        [HttpPut]
        [Route("/api/users/update/username")]
        public async Task<IActionResult> UpdateUsername(int id, UpdateUsernameRequest request)
        {
            bool result = await _userService.UpdateUsernameAsync(id, request);
            return result ? Ok(result) : NotFound();
        }

        [HttpPut]
        [Route("/api/users/update/email")]
        public async Task<IActionResult> UpdateEmail(int id, UpdateEmailRequest request)
        {
            bool result = await _userService.UpdateEmailAsync(id, request);
            return result ? Ok(result) : NotFound();
        }

        [HttpPut]
        [Route("/api/users/update/password")]
        public async Task<IActionResult> UpdatePassword(int id, UpdatePasswordRequest request)
        {
            bool result = await _userService.UpdatePasswordAsync(id, request);
            return result ? Ok(result) : NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetPaged([FromQuery] PagedRequest request)
        {
            var result = await _userService.GetPagedAsync(request);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(int id)
        {
            var result = await _userService.RemoveAsync(id);
            return result ? Ok(result) : NotFound();
        }
    }
}
