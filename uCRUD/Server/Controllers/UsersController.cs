using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using uCRUD.Server.Data.Models;
using uCRUD.Server.Services;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net;

namespace uCRUD.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IWebHostEnvironment _env;

        public UsersController(IUserService userService, IWebHostEnvironment env)
        {
            this._userService = userService ;
            this._env = env;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<int> Create(User user)
        {
            var createdUser = await _userService.CreateUserAsync(user);
            return createdUser.Id;
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

        [HttpPost]
        [Route("UploadUsers")]
        public async Task<IActionResult> UploadUsers([FromForm] IEnumerable<IFormFile> files)
        {
            var file = files.First();

            var trustedFileNameForFileStorage = Path.GetRandomFileName();

            var path = Path.Combine(_env.ContentRootPath, "file_uploads", $"{trustedFileNameForFileStorage}.json");
            try
            {
                    await using FileStream fs = new(path, FileMode.Create);
                    await file.CopyToAsync(fs);

                fs.Close();

                using (var stream = new StreamReader(path))
                {
                    var json = await stream.ReadToEndAsync();
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    var users = JsonSerializer.Deserialize<List<User>>(json,options);
                    bool isValid = true;
                    if (users.Count() > 0)
                    {
                        isValid = await _userService.CreateRangeOfUsersAsync(users);
                        return isValid ? Ok() : BadRequest();
                    }
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }
    }
}
