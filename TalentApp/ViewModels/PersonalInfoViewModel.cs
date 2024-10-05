using System.Windows.Input;
using JobSeekerApp.Commands;
using JobSeekerApp.Models;
using JobSeekerApp.Repositories;
using System.Threading.Tasks;
using System;

namespace JobSeekerApp.ViewModels
{
    public class PersonalInfoViewModel : BaseViewModel
    {
        private readonly UserRepository _userRepository;

        private string _firstName;
        private string _lastName;
        private string _location;
        private bool _isSaving; // Для відстеження стану збереження
        private string _statusMessage; // Для повідомлень про статус

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

        public ICommand NextCommand { get; private set; }

        public PersonalInfoViewModel(UserRepository userRepository)
        {
            _userRepository = userRepository;
            NextCommand = new RelayCommand(async (param) => await OnNext(param));
        }

        private async Task OnNext(object parameter)
        {
            if (string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName) || string.IsNullOrWhiteSpace(Location))
            {
                StatusMessage = "Please fill in all fields.";
                return;
            }

            var userModel = new UserModel
            {
                FirstName = FirstName,
                LastName = LastName,
                Location = Location
            };

            IsSaving = true; // Встановлюємо стан збереження в true

            try
            {
                bool isSuccess = await _userRepository.AddUserAsync(userModel); // Викликаємо AddUserAsync
                if (isSuccess)
                {
                    StatusMessage = "Personal information saved successfully.";
                    // Додаткові дії, наприклад, перехід до наступного кроку
                }
                else
                {
                    StatusMessage = "Error saving personal information. Please try again.";
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