using System.Collections.Generic;
using System.Linq;
using JobSeekerApp.Views;

namespace JobSeekerApp.Data
{
    public class UserRepository
    {
        private readonly DatabaseContext _context;

        public UserRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void AddUser(UserModel user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUser(UserModel user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void DeleteUser(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public UserModel GetUser(int userId)
        {
            return _context.Users.Find(userId);
        }

        public List<UserModel> GetAllUsers()
        {
            return _context.Users.ToList();
        }
    }
}