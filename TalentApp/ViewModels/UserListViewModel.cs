using System.Collections.ObjectModel;
using System.Threading.Tasks; // Додайте директиву using для асинхронного програмування
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
            LoadUsersAsync(); // Виклик асинхронного методу
        }

        private async Task LoadUsersAsync() // Зробіть метод асинхронним
        {
            var users = await _userRepository.GetAllUsersAsync(); // Використання асинхронного методу
            foreach (var user in users)
            {
                Users.Add(user);
            }
        }
    }
}