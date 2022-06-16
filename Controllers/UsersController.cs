using Countify.Models;
using Countify.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Countify.Controllers;

[ApiController]
[Route("accounts")]
public class UsersController : ControllerBase
{
    private readonly IUsersService UsersService;
    private readonly IAuthService AuthService;

    public UsersController(IUsersService usersService, IAuthService authservice)
    {
        UsersService = usersService;
        AuthService = authservice;
    }

    [HttpPost]
    [Route("register")]
    public async Task<ActionResult<User>> Register(User user)
    {
        await UsersService.Add(user);
        return Ok(user);
    }

    [HttpPost]
    [Route("login")]
    public async Task<ActionResult<string>> Login(string email, string password)
    {
        //validating the request body
        if (email == null || password == null) return BadRequest();

        //finding the user in the db
        var user = await UsersService.GetByEmail(email);
        if (user == null) return BadRequest("Email or password is wrong");

        //checking the password
        if (!AuthService.VerifyHash(user.Password, password)) return BadRequest("Email or password is wrong");

        return Ok(AuthService.login(user));
    }

    [HttpGet]
    [Authorize]
    [Route("displayAccount")]
    public async Task<ActionResult<User>> DisplayAccount(Guid id)
    {
        return await UsersService.GetById(id);
    }
    
    
    // for testing only
#if DEBUG
    [HttpGet]
    [Route("getall")]
    public async Task<ActionResult<List<User>>> getall()
    {
        return await UsersService.GetAll();
    }
#endif
}