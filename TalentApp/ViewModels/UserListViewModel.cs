using JobSeekerApp.Commands;
using JobSeekerApp.Data;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JobSeekerApp.ViewModels
{
    public class UserListViewModel : BaseViewModel
    {
        public ObservableCollection<UserModel> Users { get; set; } 

        public ICommand LoadUsersCommand { get; set; } 

        public UserListViewModel()
        {
            Users = new ObservableCollection<UserModel>();
            LoadUsersCommand = new RelayCommand(LoadUsers); 
        }

        private async void LoadUsers(object parameter) 
        {
            await LoadUsersAsync(); 
        }

        private async Task LoadUsersAsync()
        {
            
            var users = await GetUsersFromService(); 
            Users.Clear(); 
            foreach (var user in users)
            {
                Users.Add(user);
            }
        }

        private Task<List<UserModel>> GetUsersFromService()
        {
           
            return Task.FromResult(new List<UserModel>());
        }
    }
}