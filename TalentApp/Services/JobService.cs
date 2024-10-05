using System.Collections.Generic;
using System.Threading.Tasks;
using JobSeekerApp.Models;
using JobSeekerApp.Repositories;

namespace JobSeekerApp.Services
{
    public class JobService
    {
        private readonly JobRepository _jobRepository;

        public JobService(JobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task<bool> AddJobAsync(JobModel job)
        {
            return await _jobRepository.AddJobAsync(job);
        }

        public async Task<IEnumerable<JobModel>> GetAllJobsAsync()
        {
            return await _jobRepository.GetAllJobsAsync();
        }
    }
}