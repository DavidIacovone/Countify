﻿using Countify.Models;

namespace Countify.services
{
    public interface IUsersService
    {
        Task Add(User user);
        Task<List<User>> GetAll();
        Task<User> GetById(Guid id);
    }
}