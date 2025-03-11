using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitsTests.Data
{
    public static class Messages
    {
        public static string Empty = "Item Not Found!";
    }

    internal class User
    {
        public string? Name { get; set; }
        public int Age { get; set; }
        public bool IsAdmin { get; set; }


        public string GetUserName ()
        {
            if (!string.IsNullOrWhiteSpace(Name))
            {
                return Name;
            }

            return Messages.Empty;
        }

        public User? GetUser()
        { 
            if(string.IsNullOrWhiteSpace(Name))
            {
                return null;
            }
            return new User { Name = Name, Age = Age, IsAdmin = IsAdmin};
        }
 

    }
}
