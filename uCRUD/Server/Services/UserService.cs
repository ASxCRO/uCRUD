using Microsoft.EntityFrameworkCore;
using uCRUD.Server.Data;
using uCRUD.Server.Data.Models;

namespace uCRUD.Server.Services
{
    public class UserService : IUserService
    {
        private readonly UserDbContext _ctx;

        public UserService(UserDbContext context)
        {
            this._ctx = context;
        }


        public async Task<User> CreateUserAsync(User newUser)
        {
            await _ctx.Users.AddAsync(newUser);
            await _ctx.SaveChangesAsync();

            return newUser;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var userToDelete = await _ctx.Users.FirstAsync(x => x.Id.Equals(id));
            _ctx.Users.Remove(userToDelete);
            await _ctx.SaveChangesAsync();

            return true;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _ctx.Users.ToListAsync();
        }

        public async Task<User> GetUserAsync(int id)
        {
            return await _ctx.Users.FirstAsync(x => x.Id.Equals(id));
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            var userToUpdate = await _ctx.Users.FirstAsync(x => x.Id.Equals(user.Id));
            userToUpdate = user;
            _ctx.Update(userToUpdate);
            await _ctx.SaveChangesAsync();

            return true;
        }
    }
}
