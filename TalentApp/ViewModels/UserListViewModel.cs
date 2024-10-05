using System.Collections.ObjectModel;
using JobSeekerApp.Repositories;
using JobSeekerApp.Models;

namespace JobSeekerApp.ViewModels
{
    public class UserListViewModel : BaseViewModel
    {
        private readonly UserRepository _userRepository;
        public ObservableCollection<UserModel> Users { get; private set; }

        public UserListViewModel(UserRepository userRepository)
        {
            _userRepository = userRepository;
            Users = new ObservableCollection<UserModel>();
            LoadUsers();
        }

        private void LoadUsers()
        {
            var users = _userRepository.GetAllUsers();
            foreach (var user in users)
            {
                Users.Add(user);
            }
        }
    }
}