namespace ProfileService.Api.Domain
{
    public interface IProfileRepository
    {
        Task<Profile> CreateProfileAsync(Profile obj);

        Task DeleteProfile(int objId);

        Task<Profile> GetProfileAsync(int objId);

        Task UpdateProfileAsync(Profile obj);
    }
}
