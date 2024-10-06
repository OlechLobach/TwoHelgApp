using Npgsql;
using System;

namespace JobSeekerApp.Data
{
    public class ResumeRepository
    {
        private readonly string _connectionString = "Host=aws-0-eu-central-1.pooler.supabase.com;Port=6543;Username=postgres;Password=My_coursed_project;Database=postgres";

        public void UploadResume(int userId, byte[] resumeFile)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                string query = "INSERT INTO resumes (user_id, resume) VALUES (@userId, @resumeFile)";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);
                    command.Parameters.AddWithValue("@resumeFile", resumeFile);

                    command.ExecuteNonQuery();
                    Console.WriteLine($"Resume for user {userId} uploaded.");
                }
            }
        }

        public byte[] GetResume(int userId)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT resume FROM resumes WHERE user_id = @userId";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);

                    var resume = command.ExecuteScalar() as byte[];

                    if (resume != null)
                    {
                        Console.WriteLine($"Resume retrieved for user {userId}.");
                        return resume;
                    }
                    else
                    {
                        Console.WriteLine($"No resume found for user {userId}.");
                        return null;
                    }
                }
            }
        }
    }
}