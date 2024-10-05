using System.Windows;
using System.Windows.Controls;
using JobSeekerApp.Repositories; // Додаємо простір імен для UserRepository

namespace JobSeekerApp.Views
{
    public partial class VerificationView : UserControl
    {
        private readonly UserRepository _userRepository;

        public VerificationView(UserRepository userRepository) // Передаємо UserRepository у конструктор
        {
            InitializeComponent();
            _userRepository = userRepository;
        }

        private void VerifyButton_Click(object sender, RoutedEventArgs e)
        {
            // Валідація введених даних
            if (string.IsNullOrWhiteSpace(PhoneNumberTextBox.Text) || string.IsNullOrWhiteSpace(VerificationCodeTextBox.Text))
            {
                MessageBox.Show("Please fill in all the fields.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Логіка верифікації (наприклад, код 6-значний)
            if (VerificationCodeTextBox.Text.Length == 6)
            {
                MessageBox.Show("Verification successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                // Перекидання до фінальної сторінки після верифікації
                ((MainWindow)Window.GetWindow(this)).MainFrame.Navigate(new FinishView(_userRepository)); // Передаємо UserRepository
            }
            else
            {
                MessageBox.Show("Invalid verification code. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}