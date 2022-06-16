using Countify.Data;
using Countify.Models;
using Microsoft.EntityFrameworkCore;

namespace Countify.services;

public class PenaltiesService : IPenaltiesService
{
    private readonly DatabaseContext db;

    public PenaltiesService(DatabaseContext db)
    {
        this.db = db;
    }

    public async Task<Penalty> Add(Penalty p)
    {
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
}