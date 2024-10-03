using Npgsql;
using System;
using System.Collections.Generic;

namespace JobSeekerApp.Data
{
    public class UserRepository
    {
        private readonly DatabaseConfig _databaseConfig;

        public UserRepository(DatabaseConfig databaseConfig)
        {
            _databaseConfig = databaseConfig;
        }

        // Метод для отримання списку всіх користувачів
        public List<UserModel> GetAllUsers()
        {
            var users = new List<UserModel>();

            using (var connection = _databaseConfig.GetConnection())
            {
                connection.Open(); // Відкриття з'єднання
                var query = "SELECT * FROM users";
                using (var command = new NpgsqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(new UserModel
                            {
                                Id = reader.GetInt32(0),
                                FirstName = reader.GetString(1),
                                LastName = reader.GetString(2),
                                Location = reader.GetString(3),
                                CurrentSalary = reader.GetDecimal(4),
                                DesiredSalary = reader.GetDecimal(5),
                                CurrentJob = reader.GetString(6),
                                DesiredJob = reader.GetString(7),
                                PhoneNumber = reader.GetString(8)
                            });
                        }
                    }
                }
            }

            return users;
        }

        // Метод для додавання нового користувача
        public void AddUser(UserModel user)
        {
            using (var connection = _databaseConfig.GetConnection())
            {
                connection.Open(); // Відкриття з'єднання
                var query = "INSERT INTO users (first_name, last_name, location, current_salary, desired_salary, current_job, desired_job, phone_number) " +
                            "VALUES (@FirstName, @LastName, @Location, @CurrentSalary, @DesiredSalary, @CurrentJob, @DesiredJob, @PhoneNumber)";
                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", user.FirstName);
                    command.Parameters.AddWithValue("@LastName", user.LastName);
                    command.Parameters.AddWithValue("@Location", user.Location);
                    command.Parameters.AddWithValue("@CurrentSalary", user.CurrentSalary);
                    command.Parameters.AddWithValue("@DesiredSalary", user.DesiredSalary);
                    command.Parameters.AddWithValue("@CurrentJob", user.CurrentJob);
                    command.Parameters.AddWithValue("@DesiredJob", user.DesiredJob);
                    command.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}