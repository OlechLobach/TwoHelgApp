using JobSeekerApp.Data;
using JobSeekerApp.Models;
using System.Collections.Generic; // Додайте цей using
using System.Linq;

namespace JobSeekerApp.Repositories
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

        public UserModel GetUserById(int userId)
        {
            return _context.Users.FirstOrDefault(u => u.Id == userId);
        }

        public void UpdateUser(UserModel user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void DeleteUser(int userId)
        {
            var user = GetUserById(userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public void SaveUser(UserModel user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // Логіка обробки помилок (логування, виведення повідомлення тощо)
                throw new Exception("Unable to save user.", ex);
            }
        }

        public void SaveJob(JobModel job)
        {
            try
            {
                _context.Jobs.Add(job);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // Логіка обробки помилок (логування, виведення повідомлення тощо)
                throw new Exception("Unable to save job.", ex);
            }
        }

        public void SaveResume(ResumeModel resume)
        {
            try
            {
                _context.Resumes.Add(resume); // Припускаємо, що у вас є таблиця Resumes у контексті бази даних
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // Логіка обробки помилок (логування, виведення повідомлення тощо)
                throw new Exception("Unable to save resume.", ex);
            }
        }

        // Додайте метод для отримання всіх користувачів
        public List<UserModel> GetAllUsers()
        {
            return _context.Users.ToList(); // Повертаємо список усіх користувачів
        }
    }
}