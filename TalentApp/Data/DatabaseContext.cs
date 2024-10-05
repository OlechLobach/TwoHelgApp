using JobSeekerApp.Models;
using Microsoft.EntityFrameworkCore;

namespace JobSeekerApp.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<JobModel> Jobs { get; set; }
        public DbSet<ResumeModel> Resumes { get; set; } // Додайте DbSet для ResumeModel

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                DatabaseConfig.Configure(optionsBuilder); // Використовуємо ваш метод конфігурації
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Налаштування моделі, якщо потрібно
            // Наприклад:
            modelBuilder.Entity<UserModel>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<JobModel>()
                .HasKey(j => j.Id);

            modelBuilder.Entity<ResumeModel>()
                .HasKey(r => r.Id);

            // Ви можете також налаштувати зв'язки між моделями, якщо це необхідно
        }
    }
}