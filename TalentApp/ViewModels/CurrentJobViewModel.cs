using JobSeekerApp.Commands;
using System.Windows.Input;

namespace JobSeekerApp.ViewModels
{
    public class CurrentJobViewModel : BaseViewModel
    {
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

        public ICommand SaveCurrentJobCommand { get; set; } 

        public CurrentJobViewModel()
        {
            SaveCurrentJobCommand = new RelayCommand(SaveCurrentJob);
        }

        private void SaveCurrentJob(object parameter) 
        {
            System.Console.WriteLine($"Current Job: {CurrentJobTitle}, Salary: {CurrentSalary}");
        }
    }
}