using JobSeekerApp.Data;
using JobSeekerApp.ViewModels;
using System.Windows;

namespace JobSeekerApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Ваш рядок підключення до бази даних
            string connectionString = "Host=aws-0-eu-central-1.pooler.supabase.com;Port=6543;Username=postgres.tnffjagxwqxtsvebuimo;Password=My_coursed_project;Database=postgres";
            var databaseConfig = new DatabaseConfig(connectionString);

            // Тепер ви можете передавати databaseConfig у ваші ViewModel
            var registrationViewModel = new RegistrationViewModel(databaseConfig);
            var userListViewModel = new UserListViewModel(databaseConfig);

            // Призначте ViewModel у DataContext
            this.DataContext = registrationViewModel; // або userListViewModel в залежності від контексту
        }
    }
}