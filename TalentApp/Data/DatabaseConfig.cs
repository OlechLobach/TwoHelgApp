using Npgsql;

namespace JobSeekerApp.Data
{
    public class DatabaseConfig
    {
        private readonly string _connectionString;

        public DatabaseConfig(string connectionString)
        {
            _connectionString = connectionString;
        }

        public NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(_connectionString);
        }
    }
}