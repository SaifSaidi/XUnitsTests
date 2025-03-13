using Castle.Core.Logging;
using XUnitsTests.Data;

namespace XUnitsTests.Services
{
    public class UserServices : IUserServices
    {
        private readonly List<User> _users = []; 

        private readonly IConsoleLog _logger;

        public UserServices(List<User> users, IConsoleLog logger)
        {
            _users = users;
            _logger = logger;
        }

        public bool AddUser(User user)
        {
            if (user != null)
            { 
                _users.Add(user);
                _logger.Log("Add new user!");
                return true;
            }
            return false;
        }

        public List<User> GetAllUsers()
        {
            return _users;
        }

        public User? GetUserByName(string name)
        {
            return _users.FirstOrDefault(u => u.Name == name);
        }

        public bool RemoveUser(string name)
        {
            var user = GetUserByName(name);
            if (user != null)
            {
                _users.Remove(user);

                _logger.Log("Remove user!");
                return true;
            }
            return false;
        }
    }
}
