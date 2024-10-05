using System.Windows;
using System.Windows.Controls;
using JobSeekerApp.Models;
using JobSeekerApp.Repositories; // Додаємо простір імен для UserRepository

namespace JobSeekerApp.Views
{
    public partial class DesiredJobView : UserControl
    {
        private readonly UserRepository _userRepository;

        public DesiredJobView(UserRepository userRepository) // Передаємо UserRepository у конструктор
        {
            InitializeComponent();
            _userRepository = userRepository;
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            // Валідація введених даних
            if (string.IsNullOrWhiteSpace(DesiredJobTitleTextBox.Text) || string.IsNullOrWhiteSpace(DesiredSalaryTextBox.Text))
            {
                MessageBox.Show("Please fill in all the fields.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Збереження бажаної роботи та зарплати
            var desiredJobInfo = new JobModel
            {
                Title = DesiredJobTitleTextBox.Text, // Використовуємо властивість Title замість JobTitle
                Salary = decimal.Parse(DesiredSalaryTextBox.Text), // Перевірка та конвертація введених даних
                Type = "Desired" // Вказуємо тип роботи як "бажана"
            };

            // Перехід до наступної сторінки - VerificationView
            ((MainWindow)Window.GetWindow(this)).MainFrame.Navigate(new VerificationView(_userRepository)); // Передаємо UserRepository
        }
    }
}