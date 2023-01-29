using Microsoft.AspNetCore.Mvc;
using UserService.Api.Models;
using UserService.Api.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: api/<ProfileController>/uuid
        [HttpGet]
        public async Task<IActionResult> GetById(string uuid)
        {
            if (string.IsNullOrEmpty(uuid))
                return BadRequest($"invalid uuid");
            var profile = await _userService.GetUserAsync(uuid);
            if (profile != null)
                return Ok(profile);
            return NotFound(uuid);
        }

        // POST api/<ProfileController>
        [HttpPost]
        public async Task<IActionResult> CreateProfile([FromBody] UserModel user)
        {
            var createdProfile = await _userService.CreateUserAsync(user);
            return Ok(createdProfile);
        }

        // PUT api/<ProfileController>/uuid
        [HttpPut("{uuid}")]
        public async Task<IActionResult> UpdateProfile(string uuid, [FromBody] UserModel user)
        {
            var oldProfile = await _userService.GetUserAsync(uuid);
            if (oldProfile == null)
                return NotFound(uuid);
            await _userService.UpdateUserAsync(user);
            return Ok();
        }

        // DELETE api/<ProfileController>/uuid
        [HttpDelete("{uuid}")]
        public async Task<IActionResult> Delete(string uuid)
        {
            var oldProfile = await _userService.GetUserAsync(uuid);
            if (oldProfile == null)
                return NotFound(uuid);
            await _userService.DeleteUser(uuid);
            return Ok();
        }
    }
}
