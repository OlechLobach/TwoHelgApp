using System.Windows.Input;
using JobSeekerApp.Commands;
using JobSeekerApp.Repositories;
using JobSeekerApp.Models;

namespace JobSeekerApp.ViewModels
{
    public class DesiredJobViewModel : BaseViewModel
    {
        private readonly UserRepository _userRepository;
        private string _desiredJobTitle;
        private decimal _desiredSalary;

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

        public ICommand SaveDesiredJobCommand { get; private set; }

        public DesiredJobViewModel(UserRepository userRepository)
        {
            _userRepository = userRepository;
            SaveDesiredJobCommand = new RelayCommand(OnSaveDesiredJob);
        }

        private void OnSaveDesiredJob(object parameter)
        {
            var jobModel = new JobModel
            {
                Title = DesiredJobTitle,
                Salary = DesiredSalary,
                Type = "Desired" // Тип роботи: Бажана
            };

            _userRepository.SaveJob(jobModel);
        }
    }
}