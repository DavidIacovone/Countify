using Countify.Models;
using Countify.services;
using Microsoft.AspNetCore.Mvc;

namespace Countify.Controllers
{
    [ApiController]
    [Route("accounts")]
    public class UsersController :ControllerBase
    {
        private readonly IUsersService usersService;
        private readonly IAuthService authservice;

        public UsersController(IUsersService usersService, IAuthService authservice)
        {
            this.usersService = usersService;
            this.authservice = authservice;
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<User>> Register(User user)
        {
            await usersService.Add(user);
            return Ok(user);
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<string>> login(string email, string password)
        {

        }
    }
}
