using System.ComponentModel;
using System.Runtime.CompilerServices;
using JobSeekerApp.Data;

namespace JobSeekerApp.ViewModels
{
    public class VerificationViewModel : INotifyPropertyChanged
    {
        private string _phoneNumber;
        private string _verificationCode;
        private bool _isVerified;

        public event PropertyChangedEventHandler PropertyChanged;

        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                _phoneNumber = value;
                OnPropertyChanged();
            }
        }

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
            private set
            {
                _isVerified = value;
                OnPropertyChanged();
            }
        }

        public void VerifyCode(string inputCode)
        {
            if (inputCode == _verificationCode)
            {
                IsVerified = true;
            }
            else
            {
                IsVerified = false;
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}