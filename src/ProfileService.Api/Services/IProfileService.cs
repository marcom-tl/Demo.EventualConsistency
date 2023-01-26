using ProfileService.Api.Domain;
using ProfileService.Api.Models;

namespace ProfileService.Api.Services
{
    public interface IProfileService
    {
        Task<ProfileModel> CreateProfileAsync(ProfileModel obj);

        Task DeleteProfile(string uuid);

        Task<ProfileModel?> GetProfileAsync(string uuid);

        Task UpdateProfileAsync(ProfileModel obj);
    }
}
