using System.ComponentModel;
using System.Runtime.CompilerServices;
using JobSeekerApp.Data;

namespace JobSeekerApp.ViewModels
{
    public class RegistrationViewModel : INotifyPropertyChanged
    {
        private string _firstName;
        private string _lastName;
        private string _location;
        private UserRepository _userRepository;

        public event PropertyChangedEventHandler PropertyChanged;

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

        public RegistrationViewModel(DatabaseConfig databaseConfig)
        {
            _userRepository = new UserRepository(databaseConfig);
        }

        public void RegisterUser()
        {
            var user = new UserModel
            {
                FirstName = _firstName,
                LastName = _lastName,
                Location = _location
            };

            _userRepository.AddUser(user);
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}