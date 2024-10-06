using System.Collections.Generic;
using System.Linq;

namespace JobSeekerApp.Data
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

        public void UpdateJob(JobModel job)
        {
            _context.Jobs.Update(job);
            _context.SaveChanges();
        }

        public void DeleteJob(int jobId)
        {
            var job = _context.Jobs.Find(jobId);
            if (job != null)
            {
                _context.Jobs.Remove(job);
                _context.SaveChanges();
            }
        }

        public JobModel GetJob(int jobId)
        {
            return _context.Jobs.Find(jobId);
        }

        public List<JobModel> GetAllJobs()
        {
            return _context.Jobs.ToList();
        }
    }
}