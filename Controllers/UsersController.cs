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

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        [HttpPost]
        [Route("register")]
        [ProducesResponseType(201)]
        public async Task<ActionResult<User>> Register(User user)
        {
            await usersService.Add(user);
            return Ok(user);
        }

        [HttpGet]
        [Route("get")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<List<User>>> GetAll()
        {
            return Ok(await usersService.GetAll());   
        }
    }
}
