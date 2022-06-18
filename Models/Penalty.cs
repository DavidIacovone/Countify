namespace Countify.Models;

public class Penalty
{

    public Penalty()
    {
        Id = new Guid();
        IsPaid = false;
    }
    
    public Guid Id { get; init; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public bool IsPaid { get; set; }
    public Guid OwnerId { get; set; }
    public Guid CreatorId { get; set; }
}