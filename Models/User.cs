using System.ComponentModel.DataAnnotations;

namespace Countify.Models
{
    public class User
    {
        public User()
        {
            //Adding basic values on creation
            Id = Guid.NewGuid();
            Balance = 0;
        }

        public Guid Id { get; init; }
        [Required] public string Name { get; init; }
        [Required] public Role? Role { get; set; }
        [Required][EmailAddress] public string Email { get; set; }
        [Required][MinLength(6)] public string Password { get; set; }
        public decimal Balance { get; set; }
    }
}
