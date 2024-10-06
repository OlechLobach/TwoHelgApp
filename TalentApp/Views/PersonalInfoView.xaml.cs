using System.Windows;
using System.Windows.Controls;

namespace JobSeekerApp.Views
{
    public partial class PersonalInfoView : Page
    {
        public PersonalInfoView()
        {
            InitializeComponent();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            string firstName = FirstNameTextBox.Text;
            string lastName = LastNameTextBox.Text;
            string location = LocationTextBox.Text;

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(location))
            {
                MessageBox.Show("Please, fill in all fields.");
                return;
            }

            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow?.NavigateTo<CurrentJobView>();
        }
    }
}