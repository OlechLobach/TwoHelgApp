using Microsoft.Win32;
using System.IO;
using System.Windows;
using JobSeekerApp.Models;
using JobSeekerApp.Services;
using System.Windows.Controls;
using JobSeekerApp.Repositories; // Додайте простір імен для UserRepository

namespace JobSeekerApp.Views
{
    public partial class ResumeUploadView : UserControl
    {
        private readonly UserService _userService;

        // Додайте параметр для UserRepository
        public ResumeUploadView(UserRepository userRepository)
        {
            InitializeComponent();
            _userService = new UserService(userRepository); // Передайте userRepository
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "PDF Files (*.pdf)|*.pdf|Word Documents (*.doc;*.docx)|*.doc;*.docx",
                Title = "Select a Resume File"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                FilePathTextBox.Text = openFileDialog.FileName;
            }
        }

        private void UploadButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(FilePathTextBox.Text))
            {
                StatusTextBlock.Text = "Please select a file.";
                return;
            }

            // Логіка завантаження резюме
            byte[] resumeFile = File.ReadAllBytes(FilePathTextBox.Text);
            ResumeModel resume = new ResumeModel
            {
                UserId = 1, // Встановіть ідентифікатор користувача відповідно до вашої логіки
                ResumeFile = resumeFile
            };

            _userService.SaveResume(resume);
            StatusTextBlock.Text = "Resume uploaded successfully!";
        }
    }
}