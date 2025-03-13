using XUnitsTests.Data;

namespace XUnitsTests.Services
{
    public interface IUserServices
    {
        bool AddUser(User user);
        List<User> GetAllUsers();
        User? GetUserByName(string name);
        bool RemoveUser(string name);
    }

}