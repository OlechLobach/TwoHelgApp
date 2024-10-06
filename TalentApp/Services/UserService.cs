using System.Collections.Generic;
using System.Threading.Tasks;
using JobSeekerApp.Data;
using Microsoft.EntityFrameworkCore;

namespace JobSeekerApp.Services
{
    public class UserService
    {
        private readonly DatabaseContext _context;

        public UserService(DatabaseContext context)
        {
            _context = context;
        }

        
        public async Task<List<UserModel>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<List<ResumeModel>> GetUserResumesAsync(int userId)
        {
            return await _context.Resumes
                .Where(r => r.UserId == userId)
                .ToListAsync();
        }
    }
}