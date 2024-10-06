using JobSeekerApp.Commands;
using System.Collections.Generic;
using System.Windows.Input;

namespace JobSeekerApp.ViewModels
{
    public class RegistrationViewModel : BaseViewModel
    {
        public List<string> Steps { get; set; } 
        public int CurrentStepIndex { get; set; } 

        public ICommand NextCommand { get; set; } 
        public ICommand PreviousCommand { get; set; } 

        public RegistrationViewModel()
        {
            Steps = new List<string> { "Personal Info", "Current Job", "Desired Job", "Verification" };
            CurrentStepIndex = 0;

            NextCommand = new RelayCommand(NextStep);
            PreviousCommand = new RelayCommand(PreviousStep);
        }

        private void NextStep(object parameter)
        {
            if (CurrentStepIndex < Steps.Count - 1)
                CurrentStepIndex++;
            OnPropertyChanged(nameof(CurrentStepIndex));
        }

        private void PreviousStep(object parameter)
        {
            if (CurrentStepIndex > 0)
                CurrentStepIndex--;
            OnPropertyChanged(nameof(CurrentStepIndex));
        }
    }
}