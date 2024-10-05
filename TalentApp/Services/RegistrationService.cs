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

        public void RegisterUser(UserModel user)
        {
            // Логіка перевірки та збереження користувача
            _userRepository.SaveUser(user);
            // Можливо, додайте інші кроки, такі як верифікація
        }
    }
}
