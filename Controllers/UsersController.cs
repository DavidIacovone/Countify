using Countify.Models;
using Microsoft.AspNetCore.Mvc;

namespace Countify.Controllers
{
    [ApiController]
    [Route("accounts")]
    public class UsersController :ControllerBase
    {
        [HttpPost]
        [Route("register")]
        [ProducesResponseType(201)]
        public ActionResult<User> Register(User user)
        {
            return Ok(user);
        }
    }
}
