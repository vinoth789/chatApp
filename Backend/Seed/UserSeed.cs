using Backend.Entities;
using System.Collections.Generic;

namespace Backend.Seed
{
    public class UserSeed
    {
        public UserSeed()
        {
            UserEntries = new List<User>()
            {
                new User()
                {
                    Id = 1,
                    Username = "vinoth",
                    FirstName = "Vinoth",
                    LastName = "Moorthy",
                    Email = "vinoth@gmail.com",
                    Role = "Admin",
                },
                new User()
                {
                    Id = 2,
                    Username = "chittu",
                    FirstName = "Vivek",
                    LastName = "Moorthy",
                    Email = "chittu@gmail.com",
                    Role = "User",
                }
            };
        }

        public List<User> UserEntries { get; set; }
    }
}
