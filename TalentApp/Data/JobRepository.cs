using JobSeekerApp.Data;
using JobSeekerApp.Models;
using Microsoft.EntityFrameworkCore; // Необхідно для використання асинхронних методів
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace JobSeekerApp.Repositories
{
    public class JobRepository
    {
        private readonly DatabaseContext _context;

        public JobRepository(DatabaseContext context)
        {
            _context = context;
        }

        // Асинхронний метод для додавання роботи
        public async Task<bool> AddJobAsync(JobModel job)
        {
            try
            {
                await _context.Jobs.AddAsync(job);
                await _context.SaveChangesAsync();
                return true; // Повертаємо true, якщо додавання успішне
            }
            catch
            {
                return false; // Повертаємо false у випадку помилки
            }
        }

        // Метод для отримання роботи за ідентифікатором
        public async Task<JobModel> GetJobByIdAsync(int jobId)
        {
            return await _context.Jobs.FirstOrDefaultAsync(j => j.Id == jobId);
        }

        // Асинхронний метод для оновлення роботи
        public async Task<bool> UpdateJobAsync(JobModel job)
        {
            try
            {
                _context.Jobs.Update(job);
                await _context.SaveChangesAsync();
                return true; // Повертаємо true, якщо оновлення успішне
            }
            catch
            {
                return false; // Повертаємо false у випадку помилки
            }
        }

        // Метод для видалення роботи
        public async Task<bool> DeleteJobAsync(int jobId)
        {
            var job = await GetJobByIdAsync(jobId);
            if (job != null)
            {
                _context.Jobs.Remove(job);
                await _context.SaveChangesAsync();
                return true; // Повертаємо true, якщо видалення успішне
            }
            return false; // Повертаємо false, якщо робота не знайдена
        }

        // Асинхронний метод для отримання всіх робіт
        public async Task<IEnumerable<JobModel>> GetAllJobsAsync()
        {
            return await _context.Jobs.ToListAsync();
        }
    }
}