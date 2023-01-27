namespace ProfileService.Api.Domain
{
    public interface IProfileRepository
    {
        Task<Profile> CreateProfileAsync(Profile obj);

        Task DeleteProfile(string uuid);

        Task<Profile> GetProfileAsync(string uuid);

        Task UpdateProfileAsync(Profile obj,Profile oldObj);
    }
}
