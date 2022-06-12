using Countify.Data;
using Countify.Models;

namespace Countify.services
{
    public class UsersService
    {
        private readonly DatabaseContext db;

        public UsersService(DatabaseContext db)
        {
            this.db = db;
        }

        public void Add(User user)
        {
            db.Users.Add(user);
        }

        public User GetById(Guid id)
        {
            return db.Users.FirstOrDefault(x => x.Id == id);
        }

        public List<User> GetAll()
        {
            return db.Users.ToList();
        }
    }
}
