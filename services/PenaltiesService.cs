using Countify.Data;
using Countify.Models;
using Microsoft.EntityFrameworkCore;

namespace Countify.services;

public class PenaltiesService : IPenaltiesService
{
    private readonly DatabaseContext db;
    private readonly IUsersService UsersService;

    public PenaltiesService(DatabaseContext db, IUsersService usersService)
    {
        this.db = db;
        UsersService = usersService;
    }

    public async Task<Penalty> Add(Penalty p)
    {
        var userWithAppliedPenalty = await UsersService.GetById(p.OwnerId);
        userWithAppliedPenalty.Balance = userWithAppliedPenalty.Balance + p.Amount;

        await db.Penalties.AddAsync(p);
        await db.SaveChangesAsync();
        return await db.Penalties.FirstOrDefaultAsync(i => i.Id == p.Id);
    }

    public async Task<Penalty> Update(Penalty updatedPenalty)
    {
        var penaltyToUpdate = await db.Penalties.FirstOrDefaultAsync(i => i.Id == updatedPenalty.Id);
        if (penaltyToUpdate == null) return null;

        penaltyToUpdate = updatedPenalty;
        await db.SaveChangesAsync();
        return await db.Penalties.FirstOrDefaultAsync(i => i.Id == updatedPenalty.Id);
    }

    public async Task<List<Penalty>> GetPenalties(Guid id)
    {
        var penalties = await db.Penalties.Where(p => p.OwnerId == id).ToListAsync();
        return penalties;
    }
}