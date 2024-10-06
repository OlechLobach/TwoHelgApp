using System.Windows;
using System.Windows.Controls;

namespace JobSeekerApp.Views
{
    public partial class CurrentJobView : Page
    {
        public CurrentJobView()
        {
            InitializeComponent();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            string currentJob = CurrentJobTextBox.Text;
            string currentSalary = (CurrentSalaryComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (string.IsNullOrEmpty(currentJob) || string.IsNullOrEmpty(currentSalary))
            {
                MessageBox.Show("Please, fill in all fields.");
                return;
            }

            MessageBox.Show($"Current Job: {currentJob}\nCurrent Salary: {currentSalary}");

            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow?.NavigateTo<DesiredJobView>(); 
        }
    }
}