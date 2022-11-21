using Microsoft.AspNetCore.Mvc;
using UserSearchApp.Services.Services;

namespace UserSearchApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> SearchUser(string name)
        {
           await _userService.SearchAsync(name);
            return Ok();
        }
    }
}  