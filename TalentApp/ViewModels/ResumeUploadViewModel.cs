using System.Windows.Input;
using JobSeekerApp.Commands;
using Microsoft.Win32;
using System.IO;
using JobSeekerApp.Repositories;
using JobSeekerApp.Models;
using System.Windows; // Необхідно для використання MessageBox

namespace JobSeekerApp.ViewModels
{
    public class ResumeUploadViewModel : BaseViewModel
    {
        private readonly UserRepository _userRepository;
        private string _resumeFilePath;

        public string ResumeFilePath
        {
            get => _resumeFilePath;
            set
            {
                _resumeFilePath = value;
                OnPropertyChanged();
            }
        }

        public ICommand UploadCommand { get; private set; }
        public ICommand BrowseCommand { get; private set; }

        public ResumeUploadViewModel(UserRepository userRepository)
        {
            _userRepository = userRepository;
            UploadCommand = new RelayCommand(OnUpload);
            BrowseCommand = new RelayCommand(OnBrowse);
        }

        private void OnBrowse(object parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Resume Files (*.pdf;*.doc;*.docx;*.txt;*.rtf)|*.pdf;*.doc;*.docx;*.txt;*.rtf", // Підтримуються формати
                Title = "Select a Resume File"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                ResumeFilePath = openFileDialog.FileName;
            }
        }

        private void OnUpload(object parameter)
        {
            if (!string.IsNullOrEmpty(ResumeFilePath))
            {
                try
                {
                    // Логіка для завантаження резюме
                    byte[] resumeData = File.ReadAllBytes(ResumeFilePath);
                    var resumeModel = new ResumeModel
                    {
                        FileName = Path.GetFileName(ResumeFilePath), // Зберігаємо ім'я файлу
                        ResumeFile = resumeData
                    };

                    // Виклик методу репозиторію для збереження резюме
                    _userRepository.SaveResume(resumeModel);
                    MessageBox.Show("Резюме успішно завантажено!", "Успіх", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Сталася помилка при завантаженні резюме: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                // Сповіщення про помилку, якщо файл не вибрано
                MessageBox.Show("Будь ласка, виберіть файл резюме перед завантаженням.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}