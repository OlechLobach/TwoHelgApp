using System.Windows.Input;
using JobSeekerApp.Commands;
using JobSeekerApp.Repositories;
using JobSeekerApp.Models;

namespace JobSeekerApp.ViewModels
{
    public class CurrentJobViewModel : BaseViewModel
    {
        private readonly UserRepository _userRepository;
        private string _currentJobTitle;
        private decimal _currentSalary;

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

        public ICommand SaveCurrentJobCommand { get; private set; }

        public CurrentJobViewModel(UserRepository userRepository)
        {
            _userRepository = userRepository;
            SaveCurrentJobCommand = new RelayCommand(OnSaveCurrentJob);
        }

        private void OnSaveCurrentJob(object parameter)
        {
            var jobModel = new JobModel
            {
                Title = CurrentJobTitle,
                Salary = CurrentSalary,
                Type = "Current" // Тип роботи: Поточна
            };

            _userRepository.SaveJob(jobModel);
        }
    }
}