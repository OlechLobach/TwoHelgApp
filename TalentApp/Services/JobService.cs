using System.Collections.Generic;
using System.Threading.Tasks;
using JobSeekerApp.Data;
using Microsoft.EntityFrameworkCore;

namespace JobSeekerApp.Services
{
    public class JobService
    {
        private readonly DatabaseContext _context;

        public JobService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<JobModel>> GetAllJobsAsync()
        {
            return await _context.Jobs.ToListAsync();
        }

        
        public async Task AddJobAsync(JobModel job)
        {
            await _context.Jobs.AddAsync(job);
            await _context.SaveChangesAsync(); 
        }
    }
}