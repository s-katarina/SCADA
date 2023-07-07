using CORE.Database;
using CORE.Interfaces;
using CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CORE.Impl
{
    public class UserService : IUserService
    {
        public bool Login(string username, string password)
        {
            using (UserDatabase db = new UserDatabase())
            {
                //User u1 = new User() { Name = "Pera", Surname = "Peric", Username = "pera", Password = "222" };
                //User u2 = new User() { Name = "Mika", Surname = "Mikic", Username = "mika", Password = "222" };

                //db.Users.Add(u1);
                //db.Users.Add(u2);
                //db.SaveChanges();

                foreach (User user in db.Users)
                    if (user.Username.Equals(username) && user.Password.Equals(password))
                        return true;
            }

            return false;
        }
    }
}
