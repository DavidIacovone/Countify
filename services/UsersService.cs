using Countify.Data;
using Countify.Models;
using Microsoft.EntityFrameworkCore;

namespace Countify.services
{
    public class UsersService : IUsersService
    {
        private readonly DatabaseContext db;
        private readonly IAuthService authService;

        public UsersService(DatabaseContext db, IAuthService authService)
        {
            this.db = db;
            this.authService = authService;
        }

        public async Task Add(User user)
        {
            user.Password = authService.Hash(user.Password);
            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();  
        }

        public async Task<User> GetById(Guid id)
        {
            return await db.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> GetByEmail(string email)
        {
            return await db.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<List<User>> GetAll()
        {
            return await db.Users.ToListAsync<User>();
        }
    }
}
