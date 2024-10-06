using System.Windows;
using System.Windows.Controls;

namespace JobSeekerApp.Views
{
    public partial class VerificationView : Page
    {
        public VerificationView()
        {
            InitializeComponent();
        }

        private void SendCodeButton_Click(object sender, RoutedEventArgs e)
        {
            string phoneNumber = PhoneNumberTextBox.Text;

            if (string.IsNullOrEmpty(phoneNumber))
            {
                MessageBox.Show("Please enter a phone number.");
                return;
            }

            MessageBox.Show($"Verification code sent to: {phoneNumber}");

            VerificationPanel.Visibility = Visibility.Visible;
        }

        private void VerifyButton_Click(object sender, RoutedEventArgs e)
        {
            string verificationCode = VerificationCodeTextBox.Text;

            if (string.IsNullOrEmpty(verificationCode))
            {
                MessageBox.Show("Please enter the verification code.");
                return;
            }

          
            MessageBox.Show("Verification successful!");

            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow?.NavigateTo<FinishView>(); 
        }
    }
}