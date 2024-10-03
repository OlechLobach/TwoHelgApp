using System.Collections.ObjectModel;
using JobSeekerApp.Data;

namespace JobSeekerApp.ViewModels
{
    public class UserListViewModel
    {
        private UserRepository _userRepository;
        public ObservableCollection<UserModel> Users { get; private set; }

        public UserListViewModel(DatabaseConfig databaseConfig)
        {
            _userRepository = new UserRepository(databaseConfig);
            LoadUsers();
        }

        private void LoadUsers()
        {
            var usersFromDb = _userRepository.GetAllUsers();
            Users = new ObservableCollection<UserModel>(usersFromDb);
        }
    }
}