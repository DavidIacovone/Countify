using System.Diagnostics.CodeAnalysis;
using Countify.Models;
using Countify.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Countify.Controllers
{
    [ApiController]
    [Route("Taxes")]
    [SuppressMessage("ReSharper", "ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract")]
    public class TaxController : ControllerBase
    {
        private readonly IUsersService UsersService;

        public TaxController(IUsersService usersService)
        {
            this.UsersService = usersService;
        }
        
        [HttpPost]
        [Authorize(Roles = "MoneyKeeper")]
        [Route("UpdateBalance")]
        public async Task<ActionResult<decimal>> UpdateBalance(decimal change, string email)
        {
            //finding the user 
            var user = await UsersService.GetByEmail(email);
            if (user == null) return BadRequest("This email is not registered");

            user.Balance = user.Balance + change;
            var updatedUser = await UsersService.Update(user);

            return Ok(updatedUser.Balance);
        }
    }
}
