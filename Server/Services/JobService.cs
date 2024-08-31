using System.Collections.Generic;
using System.Threading.Tasks;
using MyApp.Models;
using MyApp.Repositories;

namespace MyApp.Services
{
    public class JobService
    {
        private readonly IJobRepository _jobRepository;

        public JobService(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public Task<Job> GetByIdAsync(int id) => _jobRepository.GetByIdAsync(id);
        public Task<IEnumerable<Job>> GetAllAsync() => _jobRepository.GetAllAsync();
        public Task AddAsync(Job job) => _jobRepository.AddAsync(job);
        public Task UpdateAsync(Job job) => _jobRepository.UpdateAsync(job);
        public Task DeleteAsync(int id) => _jobRepository.DeleteAsync(id);
    }
}