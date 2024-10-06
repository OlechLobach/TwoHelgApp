using Microsoft.EntityFrameworkCore;

namespace JobSeekerApp.Data
{
    public class DatabaseConfig
    {
        public static DbContextOptions<DatabaseContext> GetOptions(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseNpgsql(connectionString); 
            return optionsBuilder.Options;
        }
    }
}