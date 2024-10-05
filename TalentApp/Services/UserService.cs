using JobSeekerApp.Models;
using JobSeekerApp.Repositories;
using System.Threading.Tasks;

namespace JobSeekerApp.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // Метод для збереження резюме
        public async Task<bool> SaveResumeAsync(ResumeModel resume)
        {
            return await _userRepository.SaveResumeAsync(resume);
        }
    }
}