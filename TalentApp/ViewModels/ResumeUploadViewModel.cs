using JobSeekerApp.Commands;
using System.Windows.Input;

namespace JobSeekerApp.ViewModels
{
    public class ResumeUploadViewModel : BaseViewModel
    {
        private string _resumePath;

        public string ResumePath
        {
            get => _resumePath;
            set
            {
                _resumePath = value;
                OnPropertyChanged();
            }
        }

        public ICommand UploadResumeCommand { get; set; } 

        public ResumeUploadViewModel()
        {
            UploadResumeCommand = new RelayCommand(UploadResume);
        }

        private void UploadResume(object parameter)
        {
            System.Console.WriteLine($"Resume uploaded: {ResumePath}");
        }
    }
}