using Countify.Data;
using Countify.Models;
using Microsoft.EntityFrameworkCore;

namespace Countify.services
{
    public class UsersService : IUsersService
    {
        private readonly DatabaseContext db;

        public UsersService(DatabaseContext db)
        {
            this.db = db;
        }

        public async Task Add(User user)
        {
            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();  
        }

        public async Task<User> GetById(Guid id)
        {
            return await db.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<User>> GetAll()
        {
            return await db.Users.ToListAsync<User>();
        }
    }
}
