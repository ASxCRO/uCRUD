using uCRUD.Server.Data.Models;

namespace uCRUD.Server.Services
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserAsync(int id);
        Task<User> CreateUserAsync(User newUser);
        Task<bool> CreateRangeOfUsersAsync(List<User> newUser);

        Task<bool> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(int id);
    }
}
