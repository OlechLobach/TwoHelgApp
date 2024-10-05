using JobSeekerApp.Data;
using JobSeekerApp.Models;
using System.Linq;

namespace JobSeekerApp.Repositories
{
    public class JobRepository
    {
        private readonly DatabaseContext _context;

        public JobRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void AddJob(JobModel job)
        {
            _context.Jobs.Add(job);
            _context.SaveChanges();
        }

        public JobModel GetJobById(int jobId)
        {
            return _context.Jobs.FirstOrDefault(j => j.Id == jobId);
        }

        public void UpdateJob(JobModel job)
        {
            _context.Jobs.Update(job);
            _context.SaveChanges();
        }

        public void DeleteJob(int jobId)
        {
            var job = GetJobById(jobId);
            if (job != null)
            {
                _context.Jobs.Remove(job);
                _context.SaveChanges();
            }
        }
    }
}