using Countify.Models;

namespace Countify.services;

public interface IPenaltiesService
{
    Task<Penalty> Add(Penalty p);
    Task<Penalty> Update(Penalty updatedPenalty);
    Task<List<Penalty>> GetPenalties(Guid id);
}