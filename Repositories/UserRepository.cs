using System.Collections.Generic;
using System.Linq;
using prjslnback_paulo_junior.Models;

namespace prjslnback_paulo_junior.Repositories
{
    public static class UserRepository
    {
        public static User Get(string username,string password)
        {
            var users = new List<User>();
            users.Add(new User { Id = 1, Username = "paulo", Password = "paulo" });
            return users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == x.Password).FirstOrDefault();
        }
    }
}