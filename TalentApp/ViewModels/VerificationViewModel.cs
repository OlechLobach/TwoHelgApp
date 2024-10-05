using System.Windows.Input;
using JobSeekerApp.Commands;
using JobSeekerApp.Repositories;

namespace JobSeekerApp.ViewModels
{
    public class VerificationViewModel : BaseViewModel
    {
        private readonly UserRepository _userRepository;
        private string _verificationCode;
        private bool _isVerified;

        public string VerificationCode
        {
            get => _verificationCode;
            set
            {
                _verificationCode = value;
                OnPropertyChanged();
            }
        }

        public bool IsVerified
        {
            get => _isVerified;
            set
            {
                _isVerified = value;
                OnPropertyChanged();
            }
        }

        public ICommand VerifyCommand { get; private set; }

        public VerificationViewModel(UserRepository userRepository)
        {
            _userRepository = userRepository;
            VerifyCommand = new RelayCommand(OnVerify);
        }

        private void OnVerify(object parameter)
        {
            // Логіка верифікації, наприклад, перевірка коду
            if (VerificationCode == "123456") // Тут ви повинні реалізувати свою логіку
            {
                IsVerified = true;
            }
            else
            {
                // Повідомлення про невірний код
                IsVerified = false;
            }
        }
    }
}