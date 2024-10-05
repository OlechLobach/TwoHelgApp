using Microsoft.EntityFrameworkCore; 
using Npgsql.EntityFrameworkCore.PostgreSQL; 

namespace JobSeekerApp.Data
{
    public class DatabaseConfig
    {
        public static void Configure(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=aws-0-eu-central-1.pooler.supabase.com;Port=6543;Username=postgres;Password=My_coursed_project;Database=postgres");
        }
    }
}