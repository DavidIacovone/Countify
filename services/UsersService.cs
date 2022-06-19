using Countify.Data;
using Countify.Models;
using Microsoft.EntityFrameworkCore;

namespace Countify.services;

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

    public async Task<User> Remove(Guid id)
    {
        var user = await GetById(id);
        if (user == null) return null;

        db.Users.Remove(user);
        await db.SaveChangesAsync();

        return user;
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

    public async Task<User> Update(User updatedUser)
    {
        var userToUpdate = await GetById(updatedUser.Id);
        if (userToUpdate == null) return null;

        userToUpdate = updatedUser;
        await db.SaveChangesAsync();

        return userToUpdate;
    }
}