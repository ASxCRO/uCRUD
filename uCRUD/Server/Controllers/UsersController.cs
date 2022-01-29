using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using uCRUD.Server.Data.Models;
using uCRUD.Server.Services;

namespace uCRUD.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService voznjaService)
        {
            this._userService = voznjaService;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(User user)
        {
            await _userService.CreateUserAsync(user);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.DeleteUserAsync(id);
            return Ok();
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<List<User>> Get()
        {
            return await _userService.GetAllUsersAsync();
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<User> GetById(int id)
        {
            return await _userService.GetUserAsync(id);
        }

        [HttpPut]
        [Route("Update")]
        public async  Task<IActionResult> Update(User user)
        {
            await _userService.UpdateUserAsync(user);
            return Ok();
        }
    }
}
