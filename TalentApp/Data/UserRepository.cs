using JobSeekerApp.Data;
using JobSeekerApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobSeekerApp.Repositories
{
    public class UserRepository
    {
        private readonly DatabaseContext _context;

        public UserRepository(DatabaseContext context)
        {
            _context = context;
        }

        // Асинхронний метод для додавання користувача
        public async Task<bool> AddUserAsync(UserModel user)
        {
            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return true; // Повертаємо true, якщо додавання успішне
            }
            catch (Exception ex)
            {
                // Логіка обробки помилок
                Console.WriteLine($"Error adding user: {ex.Message}");
                return false; // Повертаємо false у випадку помилки
            }
        }

        // Асинхронний метод для отримання користувача за ID
        public async Task<UserModel> GetUserByIdAsync(int userId)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
        }

        // Асинхронний метод для оновлення користувача
        public async Task<bool> UpdateUserAsync(UserModel user)
        {
            try
            {
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return true; // Повертаємо true, якщо оновлення успішне
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating user: {ex.Message}");
                return false; // Повертаємо false у випадку помилки
            }
        }

        // Асинхронний метод для видалення користувача
        public async Task<bool> DeleteUserAsync(int userId)
        {
            var user = await GetUserByIdAsync(userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return true; // Повертаємо true, якщо видалення успішне
            }
            return false; // Повертаємо false, якщо користувача не знайдено
        }

        // Асинхронний метод для отримання всіх користувачів
        public async Task<List<UserModel>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync(); // Повертаємо список усіх користувачів
        }

        // Асинхронний метод для збереження резюме
        public async Task<bool> SaveResumeAsync(ResumeModel resume)
        {
            try
            {
                if (resume.ResumeFile == null || resume.ResumeFile.Length == 0)
                {
                    Console.WriteLine("Resume file is empty or null.");
                    return false; // Файл порожній
                }

                Console.WriteLine($"Attempting to save resume for UserId: {resume.UserId}, FileName: {resume.FileName}");

                await _context.Resumes.AddAsync(resume);
                Console.WriteLine("Resume added to context, attempting to save changes.");

                var result = await _context.SaveChangesAsync();

                // Логування результату збереження
                Console.WriteLine($"SaveChangesAsync result: {result}");

                if (result > 0)
                {
                    Console.WriteLine("Resume saved successfully.");
                    return true;
                }
                else
                {
                    Console.WriteLine("No changes were saved to the database.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while saving resume: {ex.Message}");
                return false;
            }
        }


        // Асинхронний метод для збереження роботи
        public async Task<bool> SaveJobAsync(JobModel job)
        {
            try
            {
                Console.WriteLine($"Saving job: {job.Title}, Salary: {job.Salary}, Type: {job.Type}");
                await _context.Jobs.AddAsync(job);
                await _context.SaveChangesAsync();
                Console.WriteLine("Job saved successfully.");
                return true; // Повертаємо true, якщо збереження успішне
            }
            catch (Exception ex)
            {
                // Логіка обробки помилок
                Console.WriteLine($"Error: {ex.InnerException?.Message ?? ex.Message}");
                return false; // Повертаємо false у випадку помилки
            }
        }
    }
}