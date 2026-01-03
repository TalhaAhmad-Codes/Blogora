using Blogoria.Contracts.Common;
using Blogoria.Contracts.Users;
using Blogoria.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Blogoria.Controllers
{
    [ApiController]
    [Route("api/users")]
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

        [HttpGet]
        public async Task<IActionResult> GetPaged([FromQuery] PagedRequest request)
        {
            var result = await _userService.GetPagedAsync(request);
            return Ok(result);
        }
    }
}
