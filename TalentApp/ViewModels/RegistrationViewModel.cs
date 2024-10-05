using System.Windows.Input;
using JobSeekerApp.Commands;
using JobSeekerApp.Models;
using JobSeekerApp.Repositories;

namespace JobSeekerApp.ViewModels
{
    public class RegistrationViewModel : BaseViewModel
    {
        private readonly UserRepository _userRepository;
        private string _currentStep;

        // Змінні для зберігання інформації про користувача
        private UserModel _userModel;

        public event Action RegistrationCompleted; // Додана подія для завершення реєстрації

        public string CurrentStep
        {
            get => _currentStep;
            set
            {
                _currentStep = value;
                OnPropertyChanged();
            }
        }

        public string FirstName
        {
            get => _userModel.FirstName;
            set
            {
                _userModel.FirstName = value;
                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get => _userModel.LastName;
            set
            {
                _userModel.LastName = value;
                OnPropertyChanged();
            }
        }

        public string Location
        {
            get => _userModel.Location;
            set
            {
                _userModel.Location = value;
                OnPropertyChanged();
            }
        }

        public string CurrentJob
        {
            get => _userModel.CurrentJob;
            set
            {
                _userModel.CurrentJob = value;
                OnPropertyChanged();
            }
        }

        public string DesiredJob
        {
            get => _userModel.DesiredJob;
            set
            {
                _userModel.DesiredJob = value;
                OnPropertyChanged();
            }
        }

        public ICommand NextCommand { get; private set; }
        public ICommand PreviousCommand { get; private set; }

        public RegistrationViewModel(UserRepository userRepository)
        {
            _userRepository = userRepository;
            CurrentStep = "ResumeUpload"; // Початок з кроку завантаження резюме
            _userModel = new UserModel(); // Ініціалізація моделі користувача

            NextCommand = new RelayCommand(OnNext);
            PreviousCommand = new RelayCommand(OnPrevious);
        }

        private void OnNext(object parameter)
        {
            if (CurrentStep == "ResumeUpload")
            {
                // Логіка для завантаження резюме
                CurrentStep = "PersonalInfo";
            }
            else if (CurrentStep == "PersonalInfo")
            {
                // Зберігаємо особисту інформацію користувача
                _userRepository.SaveUser(_userModel); // Заміна на SaveUser
                CurrentStep = "CurrentJob";
            }
            else if (CurrentStep == "CurrentJob")
            {
                // Зберігаємо дані про поточну роботу
                _userRepository.SaveUser(_userModel); // Заміна на SaveUser
                CurrentStep = "DesiredJob";
            }
            else if (CurrentStep == "DesiredJob")
            {
                // Завершуємо реєстрацію
                _userRepository.SaveUser(_userModel); // Заміна на SaveUser
                RegistrationCompleted?.Invoke(); // Виклик події завершення реєстрації
            }
        }

        private void OnPrevious(object parameter)
        {
            // Логіка для повернення на попередній крок
            if (CurrentStep == "PersonalInfo")
            {
                CurrentStep = "ResumeUpload";
            }
            else if (CurrentStep == "CurrentJob")
            {
                CurrentStep = "PersonalInfo";
            }
            else if (CurrentStep == "DesiredJob")
            {
                CurrentStep = "CurrentJob";
            }
        }
    }
}