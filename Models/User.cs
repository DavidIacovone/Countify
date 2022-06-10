namespace Countify.Models
{
    public class User
    {
        public string Id { get; init; }
        public string Name { get; init; }
        public Role Role { get; set; }
        public decimal Balance { get; set; }
    }
}
