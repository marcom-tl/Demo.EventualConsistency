namespace UserService.Api.Domain
{
    public interface IUserRepository
    {
        Task<User> CreateUserAsync(User obj);

        Task DeleteUser(string uuid);

        Task<User> GetUserAsync(string uuid);

        Task UpdateUserAsync(User obj);
    }
}
