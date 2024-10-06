using JobSeekerApp.Commands;
using System.Windows.Input;

namespace JobSeekerApp.ViewModels
{
    public class PersonalInfoViewModel : BaseViewModel
    {
        private string _firstName;
        private string _lastName;
        private string _location;

        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }

        public string Location
        {
            get => _location;
            set
            {
                _location = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; set; } 

        public PersonalInfoViewModel()
        {
            SaveCommand = new RelayCommand(SavePersonalInfo);
        }

        private void SavePersonalInfo(object parameter)
        {
            System.Console.WriteLine($"Saved: {FirstName} {LastName}, Location: {Location}");
        }
    }
}
