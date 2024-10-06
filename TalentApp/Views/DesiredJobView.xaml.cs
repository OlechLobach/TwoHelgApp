using System.Windows;
using System.Windows.Controls;

namespace JobSeekerApp.Views
{
    public partial class DesiredJobView : Page
    {
        public DesiredJobView()
        {
            InitializeComponent();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            // Отримання введених даних
            string desiredJob = DesiredJobTextBox.Text;
            string desiredSalary = (DesiredSalaryComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (string.IsNullOrEmpty(desiredJob) || string.IsNullOrEmpty(desiredSalary))
            {
                MessageBox.Show("Please, fill in all fields.");
                return;
            }


            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow?.NavigateTo<VerificationView>(); 
        }
    }
}
