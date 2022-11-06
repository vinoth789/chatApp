using System.Collections.Generic;
using System.Linq;
using Backend.Entities;
using Microsoft.EntityFrameworkCore;
using Backend.Helpers;

namespace Backend.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        User CreateUser(User user);
    }


    public class UserService : IUserService
    {
        private DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }

        public User CreateUser(User user)
        {
            _context.Set<User>().Add(user);
            _context.SaveChanges();
            return user;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.UserEntries;
        }

        public User GetUserById(int Id)
        {
            return _context.UserEntries.Find(Id);
        }

    }
}