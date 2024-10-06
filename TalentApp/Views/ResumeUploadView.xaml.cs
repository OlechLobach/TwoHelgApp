using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;

namespace JobSeekerApp.Views
{
    public partial class ResumeUploadView : Page
    {
        public ResumeUploadView()
        {
            InitializeComponent();
        }

        private void SelectFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Select a file",
                Filter = "PDF files (*.pdf)|*.pdf|Word documents (*.docx)|*.docx|All files (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                ResumePathTextBox.Text = openFileDialog.FileName; 
            }
        }

        private void UploadResumeButton_Click(object sender, RoutedEventArgs e)
        {
            string resumePath = ResumePathTextBox.Text;

            if (string.IsNullOrEmpty(resumePath))
            {
                MessageBox.Show("Please, indicate the path to the resume.");
                return;
            }

            MessageBox.Show($"Resume upload: {resumePath}");

            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow?.NavigateTo<PersonalInfoView>();
        }
    }
}