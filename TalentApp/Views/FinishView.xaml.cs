using System.Windows;
using System.Windows.Controls;
using JobSeekerApp.Repositories; // Додаємо простір імен для UserRepository

namespace JobSeekerApp.Views
{
    public partial class FinishView : UserControl
    {
        private readonly UserRepository _userRepository;

        public FinishView(UserRepository userRepository) // Передаємо UserRepository у конструктор
        {
            InitializeComponent();
            _userRepository = userRepository;
        }

        private void ViewUsersButton_Click(object sender, RoutedEventArgs e)
        {
            // Переходимо до списку зареєстрованих користувачів
            var mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.MainFrame.Navigate(new UserListView(_userRepository)); // Передаємо UserRepository
            }
        }
    }
}