using System.Windows;
using System.Windows.Controls;
using JobSeekerApp.Models;
using JobSeekerApp.Repositories; // Додайте простір імен для UserRepository

namespace JobSeekerApp.Views
{
    public partial class PersonalInfoView : UserControl
    {
        private readonly UserRepository _userRepository; // Зберігання посилання на UserRepository

        public PersonalInfoView(UserRepository userRepository) // Додайте параметр UserRepository
        {
            InitializeComponent();
            _userRepository = userRepository; // Збережіть посилання на UserRepository
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            // Валідація введених даних
            if (string.IsNullOrWhiteSpace(FirstNameTextBox.Text) || string.IsNullOrWhiteSpace(LastNameTextBox.Text) || string.IsNullOrWhiteSpace(LocationTextBox.Text))
            {
                MessageBox.Show("Please fill in all the fields.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Збереження інформації про особисті дані
            var personalInfo = new UserModel
            {
                FirstName = FirstNameTextBox.Text,
                LastName = LastNameTextBox.Text,
                Location = LocationTextBox.Text
            };

            // Перехід до наступної сторінки, передаючи UserRepository
            ((MainWindow)Window.GetWindow(this)).MainFrame.Navigate(new CurrentJobView(_userRepository));
        }
    }
}