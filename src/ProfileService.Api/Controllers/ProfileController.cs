using Microsoft.AspNetCore.Mvc;
using ProfileService.Api.Models;


namespace ProfileService.Api.Controllers
{
    using Services;

    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }
        // GET: api/<ProfileController>/uuid
        [HttpGet]
        public async Task<IActionResult> GetById(string uuid)
        {
            if (string.IsNullOrEmpty(uuid))
                return BadRequest($"invalid uuid");
            var profile = await _profileService.GetProfileAsync(uuid);
            if (profile!=null)
                return Ok(profile);
            else
                return NotFound(uuid);
            
        }
        
        // POST api/<ProfileController>
        [HttpPost]
        public async Task<IActionResult> CreateProfile([FromBody] ProfileModel profile)
        {
            var createdProfile =await _profileService.CreateProfileAsync(profile);
            return Ok(createdProfile);
        }

        // PUT api/<ProfileController>/uuid
        [HttpPut("{uuid}")]
        public async Task<IActionResult> UpdateProfile(string uuid, [FromBody] ProfileModel profile)
        {
            var oldProfile = await _profileService.GetProfileAsync(uuid);
            if (oldProfile == null)
                return NotFound(uuid);
            await _profileService.UpdateProfileAsync(profile);
            return Ok();
        }

        // DELETE api/<ProfileController>/uuid
        [HttpDelete("{uuid}")]
        public async Task<IActionResult> Delete(string uuid)
        {
            var oldProfile = await _profileService.GetProfileAsync(uuid);
            if (oldProfile == null)
                return NotFound(uuid);
            await _profileService.DeleteProfile(uuid);
            return Ok();
        }
    }
}
