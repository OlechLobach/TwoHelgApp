using System.Windows;
using System.Windows.Controls;
using JobSeekerApp.Models;
using JobSeekerApp.Repositories; // Додайте простір імен для UserRepository

namespace JobSeekerApp.Views
{
    public partial class CurrentJobView : UserControl
    {
        private readonly UserRepository _userRepository;

        public CurrentJobView(UserRepository userRepository) // Додайте параметр UserRepository
        {
            InitializeComponent();
            _userRepository = userRepository; // Збережіть посилання на UserRepository
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            // Валідація введених даних
            if (string.IsNullOrWhiteSpace(JobTitleTextBox.Text) || string.IsNullOrWhiteSpace(SalaryTextBox.Text))
            {
                MessageBox.Show("Please fill in all the fields.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Збереження інформації про поточну роботу
            var currentJobInfo = new JobModel
            {
                Title = JobTitleTextBox.Text, // Використовуємо властивість Title для назви роботи
                Salary = decimal.Parse(SalaryTextBox.Text), // Перевірка та конвертація введених даних
                Type = "Current" // Вказуємо тип роботи як "поточна"
            };

            // Перехід на сторінку введення бажаної роботи, передаючи UserRepository
            ((MainWindow)Window.GetWindow(this)).MainFrame.Navigate(new DesiredJobView(_userRepository));
        }
    }
}
