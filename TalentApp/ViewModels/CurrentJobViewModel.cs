using System.Windows.Input;
using JobSeekerApp.Commands;
using JobSeekerApp.Repositories;
using JobSeekerApp.Models;
using System.Threading.Tasks;
using System;

namespace JobSeekerApp.ViewModels
{
    public class CurrentJobViewModel : BaseViewModel
    {
        private readonly UserRepository _userRepository;
        private string _currentJobTitle;
        private decimal _currentSalary;
        private bool _isSaving; // Додано для відстеження стану збереження
        private string _statusMessage; // Додано для повідомлень про статус

        public string CurrentJobTitle
        {
            get => _currentJobTitle;
            set
            {
                _currentJobTitle = value;
                OnPropertyChanged();
            }
        }

        public decimal CurrentSalary
        {
            get => _currentSalary;
            set
            {
                _currentSalary = value;
                OnPropertyChanged();
            }
        }

        public bool IsSaving
        {
            get => _isSaving;
            set
            {
                _isSaving = value;
                OnPropertyChanged();
            }
        }

        public string StatusMessage
        {
            get => _statusMessage;
            set
            {
                _statusMessage = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCurrentJobCommand { get; private set; }

        public CurrentJobViewModel(UserRepository userRepository)
        {
            _userRepository = userRepository;
            SaveCurrentJobCommand = new RelayCommand(async (param) => await OnSaveCurrentJob(param));
        }

        private async Task OnSaveCurrentJob(object parameter)
        {
            if (string.IsNullOrWhiteSpace(CurrentJobTitle) || CurrentSalary <= 0)
            {
                StatusMessage = "Please enter valid job title and salary.";
                return;
            }

            var jobModel = new JobModel
            {
                Title = CurrentJobTitle,
                Salary = CurrentSalary,
                Type = "Current" // Тип роботи: Поточна
            };

            IsSaving = true; // Встановлюємо стан збереження в true

            try
            {
                bool isSuccess = await _userRepository.SaveJobAsync(jobModel);
                if (isSuccess)
                {
                    StatusMessage = "Job saved successfully.";
                    // Додаткові дії, наприклад, очищення полів
                    CurrentJobTitle = string.Empty;
                    CurrentSalary = 0;
                }
                else
                {
                    StatusMessage = "Error saving job. Please try again.";
                }
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}"; // Відображаємо повідомлення про помилку
            }
            finally
            {
                IsSaving = false; // Завершуємо стан збереження
            }
        }
    }
}