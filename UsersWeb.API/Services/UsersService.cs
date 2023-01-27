using System;
using UsersWeb.API.Models;

public interface IUserService
{
    public Task<List<User>> GetUsers();


    public class UserService : IUserService
    {
        public Task<List<User>> GetUsers()
        {
            throw new NotImplementedException();
        }

    }
}