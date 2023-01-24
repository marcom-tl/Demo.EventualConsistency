using ProfileService.Api.Domain;
using ProfileService.Api.Models;

namespace ProfileService.Api.Services
{
    public interface IProfileService
    {
        Task<ProfileModel> CreateProfileAsync(ProfileModel obj);

        Task DeleteProfile(int objId);

        Task<ProfileModel> GetProfileAsync(int objId);

        Task UpdateProfileAsync(ProfileModel obj);
    }
}
