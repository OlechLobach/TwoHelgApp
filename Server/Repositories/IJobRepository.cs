using System.Collections.Generic;
using System.Threading.Tasks;
using MyApp.Models;

namespace MyApp.Repositories
{
    public interface IJobRepository
    {
        Task<Job> GetByIdAsync(int id);
        Task<IEnumerable<Job>> GetAllAsync();
        Task AddAsync(Job job);
        Task UpdateAsync(Job job);
        Task DeleteAsync(int id);
    }
}