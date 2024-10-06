using Microsoft.EntityFrameworkCore;

namespace JobSeekerApp.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<RegistrationModel> Registrations { get; set; }
        public DbSet<SalaryModel> Salaries { get; set; }
        public DbSet<JobModel> Jobs { get; set; }
        public DbSet<ResumeModel> Resumes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.Property(u => u.FirstName)
                      .IsRequired()
                      .HasMaxLength(50); 
                entity.Property(u => u.LastName)
                      .IsRequired()
                      .HasMaxLength(50);
                entity.Property(u => u.Location)
                      .HasMaxLength(100); 
                entity.Property(u => u.PhoneNumber)
                      .IsRequired()
                      .HasMaxLength(15); 
                entity.HasIndex(u => u.PhoneNumber).IsUnique(); 
            });

            modelBuilder.Entity < RegistrationModel>(entity =>
            {
                entity.HasKey(r => r.Id); 
                entity.HasOne(r => r.User) 
                      .WithMany(u => u.Registrations)
                      .HasForeignKey(r => r.UserId);
                entity.Property(r => r.RegistrationDate)
                      .IsRequired(); 
            });

            modelBuilder.Entity<SalaryModel>(entity =>
            {
                entity.HasKey(s => s.Id); 
                entity.HasOne(s => s.User) 
                      .WithMany(u => u.Salaries)
                      .HasForeignKey(s => s.UserId);
                entity.Property(s => s.Amount)
                      .IsRequired();
                entity.Property(s => s.Type)
                      .IsRequired(); 
            });

            modelBuilder.Entity<JobModel>(entity =>
            {
                entity.HasKey(j => j.Id); 
                entity.HasOne(j => j.User) 
                      .WithMany(u => u.Jobs)
                      .HasForeignKey(j => j.UserId);
                entity.Property(j => j.Title)
                      .IsRequired()
                      .HasMaxLength(100);
                entity.Property(j => j.Type)
                      .IsRequired(); 
            });
        }
    }
}