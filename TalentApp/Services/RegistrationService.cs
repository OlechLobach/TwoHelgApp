using System;
using System.Threading.Tasks;
using JobSeekerApp.Models;
using JobSeekerApp.Repositories;

namespace JobSeekerApp.Services
{
    public class RegistrationService
    {
        private readonly UserRepository _userRepository;

        public RegistrationService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> RegisterUserAsync(UserModel user)
        {
            try
            {
                // Логіка для реєстрації користувача
                await _userRepository.AddUserAsync(user);
                return true;
            }
            catch (Exception ex)
            {
                // Обробка помилки
                Console.WriteLine($"Error registering user: {ex.Message}");
                return false;
            }
        }
    }
}