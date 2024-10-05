using JobSeekerApp.Models;
using JobSeekerApp.Repositories;

namespace JobSeekerApp.Services
{
    public class JobService
    {
        private readonly UserRepository _userRepository;

        public JobService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void SaveJob(JobModel job)
        {
            _userRepository.SaveJob(job);
        }

        // Інші методи для управління роботами можна додати сюди
    }
}