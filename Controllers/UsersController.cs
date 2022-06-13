using Countify.Models;
using Countify.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Countify.Controllers
{
    [ApiController]
    [Route("accounts")]
    public class UsersController :ControllerBase
    {
        private readonly IUsersService usersService;
        private readonly IAuthService authService;

        public UsersController(IUsersService usersService, IAuthService authservice)
        {
            this.usersService = usersService;
            this.authService = authservice;
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
            //validating the request body
            if (email == null || password == null) return BadRequest();

            //finding the user in the db
            var user = await usersService.GetByEmail(email);
            if (user == null) return BadRequest("Email or password is wrong");

            //checking the password
            if (!authService.VerifyHash(user.Password, password)) return BadRequest("Email or password is wrong");

            return Ok(authService.login(user));
        }

        [HttpGet]
        [Authorize]
        [Route("displayAccount")]
        public async Task<ActionResult<User>> DisplayAccount(Guid id)
        {
            return await usersService.GetById(id);
        }
    }
}
