using System.Windows.Input;
using JobSeekerApp.Commands;
using JobSeekerApp.Repositories;
using JobSeekerApp.Models;
using System.Threading.Tasks;
using System;

namespace JobSeekerApp.ViewModels
{
    public class DesiredJobViewModel : BaseViewModel
    {
        private readonly UserRepository _userRepository;
        private string _desiredJobTitle;
        private decimal _desiredSalary;
        private bool _isSaving; // Для відстеження стану збереження
        private string _statusMessage; // Для повідомлень про статус

        public string DesiredJobTitle
        {
            get => _desiredJobTitle;
            set
            {
                _desiredJobTitle = value;
                OnPropertyChanged();
            }
        }

        public decimal DesiredSalary
        {
            get => _desiredSalary;
            set
            {
                _desiredSalary = value;
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

        public ICommand SaveDesiredJobCommand { get; private set; }

        public DesiredJobViewModel(UserRepository userRepository)
        {
            _userRepository = userRepository;
            SaveDesiredJobCommand = new RelayCommand(async (param) => await OnSaveDesiredJob(param));
        }

        private async Task OnSaveDesiredJob(object parameter)
        {
            if (string.IsNullOrWhiteSpace(DesiredJobTitle) || DesiredSalary <= 0)
            {
                StatusMessage = "Please enter valid job title and salary.";
                return;
            }

            var jobModel = new JobModel
            {
                Title = DesiredJobTitle,
                Salary = DesiredSalary,
                Type = "Desired" // Тип роботи: Бажана
            };

            IsSaving = true; // Встановлюємо стан збереження в true

            try
            {
                bool isSuccess = await _userRepository.SaveJobAsync(jobModel);
                if (isSuccess)
                {
                    StatusMessage = "Desired job saved successfully.";
                    // Додаткові дії, наприклад, очищення полів
                    DesiredJobTitle = string.Empty;
                    DesiredSalary = 0;
                }
                else
                {
                    StatusMessage = "Error saving desired job. Please try again.";
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