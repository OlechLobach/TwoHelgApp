using System.Windows.Input;
using JobSeekerApp.Commands;
using Microsoft.Win32;
using System.IO;
using JobSeekerApp.Repositories;
using JobSeekerApp.Models;
using System.Windows; // Необхідно для використання MessageBox
using System.Threading.Tasks; // Необхідно для використання Task

namespace JobSeekerApp.ViewModels
{
    public class ResumeUploadViewModel : BaseViewModel
    {
        private readonly UserRepository _userRepository;
        private int _currentUserId; // Зберігаємо ідентифікатор користувача
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

        public ResumeUploadViewModel(UserRepository userRepository, int currentUserId)
        {
            _userRepository = userRepository;
            _currentUserId = currentUserId; // Присвоюємо ідентифікатор користувача
            UploadCommand = new RelayCommand(async (param) => await OnUpload(param)); // Виклик асинхронного методу
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

        private async Task OnUpload(object parameter)
        {
            if (!string.IsNullOrEmpty(ResumeFilePath))
            {
                try
                {
                    // Логіка для завантаження резюме
                    byte[] resumeData = File.ReadAllBytes(ResumeFilePath);

                    var resumeModel = new ResumeModel
                    {
                        UserId = _currentUserId,
                        FileName = Path.GetFileName(ResumeFilePath),
                        ResumeFile = resumeData
                    };

                    // Логування перед викликом методу
                    Console.WriteLine($"Attempting to save resume for UserId: {resumeModel.UserId}, FileName: {resumeModel.FileName}");

                    // Виклик методу репозиторію для збереження резюме
                    bool success = await _userRepository.SaveResumeAsync(resumeModel);
                    if (success)
                    {
                        MessageBox.Show("Резюме успішно завантажено!", "Успіх", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Не вдалося завантажити резюме.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Сталася помилка при завантаженні резюме: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть файл резюме перед завантаженням.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}