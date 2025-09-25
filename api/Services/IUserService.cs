namespace api.Services{

    using api.Models;
    using System.Collections.Generic;
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();
        User? GetUserById(int id);
        User CreateUser(User user);
        
    }
}