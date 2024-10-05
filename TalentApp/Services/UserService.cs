using JobSeekerApp.Models;
using JobSeekerApp.Repositories;
using System.Collections.Generic;

namespace JobSeekerApp.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserModel GetUserById(int userId)
        {
            return _userRepository.GetUserById(userId);
        }

        public List<UserModel> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public void UpdateUser(UserModel user)
        {
            _userRepository.UpdateUser(user);
        }

        public void DeleteUser(int userId)
        {
            _userRepository.DeleteUser(userId);
        }

        public void SaveResume(ResumeModel resume)
        {
            _userRepository.SaveResume(resume);
        }
    }
}