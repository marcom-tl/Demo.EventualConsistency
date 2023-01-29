namespace ProfileService.Api.Domain
{
    public interface IProfileRepository
    {
        Task<Profile> CreateProfileAsync(Profile obj);

        Task DeleteProfile(string uuid);

        Task<Profile> GetProfileAsync(string uuid);

        Task<Profile> GetProfileByUserIdAsync(string userId);

        Task UpdateProfileAsync(Profile obj);
    }
}
