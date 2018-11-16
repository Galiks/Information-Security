using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Users
    {
        public static Dictionary<string, string> UsersList;

        public Users()
        {
            //login - password
            UsersList = new Dictionary<string, string>()
            {
                {"admin", "admin" },
            };
        }
    }
}
