using UserService.Api.Models;

namespace UserService.Api.Services
{
    public interface IUserService
    {
        Task<UserModel> CreateUserAsync(UserModel obj);

        Task DeleteUser(string uuid);

        Task<UserModel?> GetUserAsync(string uuid);

        Task UpdateUserAsync(UserModel obj);
    }
}
