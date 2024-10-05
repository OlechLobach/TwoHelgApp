using System.Windows.Input;
using JobSeekerApp.Commands;
using JobSeekerApp.Models;
using JobSeekerApp.Repositories;

namespace JobSeekerApp.ViewModels
{
    public class PersonalInfoViewModel : BaseViewModel
    {
        private readonly UserRepository _userRepository;

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

        public ICommand NextCommand { get; private set; }

        public PersonalInfoViewModel(UserRepository userRepository)
        {
            _userRepository = userRepository;
            NextCommand = new RelayCommand(OnNext);
        }

        private void OnNext(object parameter)
        {
            // Зберігаємо особисті дані
            var userModel = new UserModel
            {
                FirstName = FirstName,
                LastName = LastName,
                Location = Location
            };

            _userRepository.SaveUser(userModel);
            // Перехід до наступного кроку
        }
    }
}