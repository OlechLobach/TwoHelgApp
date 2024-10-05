using System.Windows.Controls;
using JobSeekerApp.ViewModels;
using JobSeekerApp.Repositories; // Додаємо простір імен для UserRepository

namespace JobSeekerApp.Views
{
    public partial class UserListView : UserControl
    {
        private readonly UserRepository _userRepository;

        public UserListView(UserRepository userRepository)
        {
            InitializeComponent();
            _userRepository = userRepository;
            DataContext = new UserListViewModel(_userRepository); // Передаємо UserRepository у ViewModel
        }
    }
}