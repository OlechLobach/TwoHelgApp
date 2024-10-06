using JobSeekerApp.Commands;
using System.Windows.Input;

namespace JobSeekerApp.ViewModels
{
    public class VerificationViewModel : BaseViewModel
    {
        private string _verificationCode;

        public string VerificationCode
        {
            get => _verificationCode;
            set
            {
                _verificationCode = value;
                OnPropertyChanged();
            }
        }

        public ICommand VerifyCommand { get; set; }

        public VerificationViewModel()
        {
            VerifyCommand = new RelayCommand(VerifyCode);
        }

        private void VerifyCode(object parameter) 
        {
            System.Console.WriteLine($"Verification code entered: {VerificationCode}");
        }
    }
}