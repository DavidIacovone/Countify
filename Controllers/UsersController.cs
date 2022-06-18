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
    private readonly IPenaltiesService PenaltiesService;

    public UsersController(IUsersService usersService, IAuthService authService, IPenaltiesService penaltiesService)
    {
        UsersService = usersService;
        AuthService = authService;
        PenaltiesService = penaltiesService;
    }

    [HttpPost]
    [Route("register")]
    public async Task<ActionResult<User>> Register(User user)
    {
        try
        {
            await UsersService.Add(user);
            return Ok(user);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpPost]
    [Route("login")]
    public async Task<ActionResult<string>> Login(string email, string password)
    {
        try
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
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpGet]
    [Authorize]
    [Route("getAccount")]
    public async Task<ActionResult<User>> GetAccount(Guid id)
    {
        try
        {
            return await UsersService.GetById(id);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpGet]
    [Authorize]
    [Route("getPenalties")]
    public async Task<ActionResult<List<Penalty>>> GetPenalties(Guid id)
    {
        try
        {
            return Ok(await PenaltiesService.GetPenalties(id));
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }


    // for testing only
#if DEBUG
    [HttpGet]
    [Route("getAll")]
    public async Task<ActionResult<List<User>>> getall()
    {
        try
        {
            return await UsersService.GetAll();
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }
#endif
}