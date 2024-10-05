using Microsoft.Win32;
using System.IO;
using System.Windows;
using JobSeekerApp.Models;
using JobSeekerApp.Services;
using System.Windows.Controls;
using JobSeekerApp.Repositories;
using JobSeekerApp.Data;

namespace JobSeekerApp.Views
{
    public partial class ResumeUploadView : UserControl
    {
        private readonly UserService _userService;
        private byte[] resumeFile; // Змінна для збереження файлу резюме
        private string fileName;   // Назва файлу

        public ResumeUploadView(UserRepository userRepository)
        {
            InitializeComponent();
            _userService = new UserService(userRepository);
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
                fileName = Path.GetFileName(openFileDialog.FileName); // Зберігаємо ім'я файлу
                resumeFile = File.ReadAllBytes(openFileDialog.FileName); // Читаємо файл як масив байтів
                FileNameTextBlock.Text = fileName; // Виводимо ім'я файлу на екран
            }
        }

        private async void UploadButton_Click(object sender, RoutedEventArgs e)
        {
            // Перевіряємо, чи файл був вибраний
            if (resumeFile == null || string.IsNullOrEmpty(fileName))
            {
                StatusTextBlock.Text = "Please select a file.";
                return;
            }

            try
            {
                // Створюємо модель резюме
                ResumeModel resume = new ResumeModel
                {
                    UserId = 1, // Ідентифікатор користувача за логікою програми
                    FileName = fileName, // Ім'я файлу
                    ResumeFile = resumeFile // Масив байтів файлу
                };

                // Збереження резюме
                bool isSuccess = await _userService.SaveResumeAsync(resume);
                if (isSuccess)
                {
                    StatusTextBlock.Text = "Resume uploaded successfully!";
                    // Переход на сторінку введення особистих даних
                    DatabaseContext context = new DatabaseContext();
                    UserRepository userRepository = new UserRepository(context);
                    ((MainWindow)Window.GetWindow(this)).MainFrame.Navigate(new PersonalInfoView(userRepository));
                }
                else
                {
                    StatusTextBlock.Text = "Failed to upload resume.";
                }
            }
            catch (Exception ex)
            {
                // Обробка помилок
                StatusTextBlock.Text = $"An error occurred: {ex.Message}";
            }
        }
    }
}