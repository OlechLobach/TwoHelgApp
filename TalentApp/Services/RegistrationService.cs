using System.Threading.Tasks;
using JobSeekerApp.Data;

namespace JobSeekerApp.Services
{
    public class RegistrationService
    {
        private readonly DatabaseContext _context;

        public RegistrationService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task RegisterUserAsync(UserModel user, RegistrationModel registration)
        {
            await _context.Users.AddAsync(user);
            await _context.Registrations.AddAsync(registration);
            await _context.SaveChangesAsync(); 
        }
    }
}