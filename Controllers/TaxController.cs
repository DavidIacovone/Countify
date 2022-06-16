using System.Diagnostics.CodeAnalysis;
using Countify.Models;
using Countify.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Countify.Controllers;

[ApiController]
[Route("Taxes")]
[SuppressMessage("ReSharper", "ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract")]
public class TaxController : ControllerBase
{
    private readonly IUsersService UsersService;
    private readonly IPenaltiesService PenaltyService;

    public TaxController(IUsersService usersService, IPenaltiesService penaltyService)
    {
        UsersService = usersService;
        PenaltyService = penaltyService;
    }

    [HttpPost]
    [Authorize(Roles = "MoneyKeeper")]
    [Route("UpdateBalance")]
    public async Task<ActionResult<decimal>> UpdateBalance(decimal change, string email)
    {
        //finding the user 
        var user = await UsersService.GetByEmail(email);
        if (user == null) return BadRequest("This email is not registered");

        //updating the balance
        user.Balance = user.Balance + change;
        var updatedUser = await UsersService.Update(user);

        return Ok(updatedUser.Balance);
    }

    [HttpPost]
    [Authorize(Roles = "MoneyKeeper")]
    [Route("AddPenalty")]
    public async Task<ActionResult<Penalty>> AddPenalty(Penalty penalty)
    {
        var createdPenalty = await PenaltyService.Add(penalty);
        return Ok(createdPenalty);
    }
}