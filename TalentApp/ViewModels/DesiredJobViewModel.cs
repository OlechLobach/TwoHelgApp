using JobSeekerApp.Commands;
using System.Windows.Input;

namespace JobSeekerApp.ViewModels
{
    public class DesiredJobViewModel : BaseViewModel
    {
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

        public ICommand SaveDesiredJobCommand { get; set; }

        public DesiredJobViewModel()
        {
            SaveDesiredJobCommand = new RelayCommand(SaveDesiredJob);
        }

        private void SaveDesiredJob(object parameter)
        {
            System.Console.WriteLine($"Desired Job: {DesiredJobTitle}, Desired Salary: {DesiredSalary}");
        }
    }
}