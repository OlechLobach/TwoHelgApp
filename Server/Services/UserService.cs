using System.Collections.Generic;
using System.Threading.Tasks;
using MyApp.Models;
using MyApp.Repositories;

namespace MyApp.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<User> GetByIdAsync(int id) => _userRepository.GetByIdAsync(id);
        public Task<IEnumerable<User>> GetAllAsync() => _userRepository.GetAllAsync();
        public Task AddAsync(User user) => _userRepository.AddAsync(user);
        public Task UpdateAsync(User user) => _userRepository.UpdateAsync(user);
        public Task DeleteAsync(int id) => _userRepository.DeleteAsync(id);
    }
}