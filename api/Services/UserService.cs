namespace api.Services;
using api.Models;

public class UserService : IUserService
{
    private static List<User> _users = new List<User>
    {
        new User(1, "Alice", "alice@example.com", "password123"),
        new User(2, "Bob", "bob@example.com", "password456")
    };

    private static int _nextId = 3;

    public IEnumerable<User> GetAllUsers()
    {
        return _users;
    }

    public User? GetUserById(int id)
    {
        return _users.FirstOrDefault(u => u.Id == id);
    }
    public User CreateUser(User user)
    {
        user.Id = _nextId++;
        _users.Add(user);
        return user;
    }
}