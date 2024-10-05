using System.Windows;
using JobSeekerApp.Repositories; // Додайте простір імен для UserRepository
using JobSeekerApp.Data; // Додайте простір імен для DatabaseContext

namespace JobSeekerApp.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Створіть контекст бази даних
            var databaseContext = new DatabaseContext();

            // Створіть екземпляр UserRepository
            var userRepository = new UserRepository(databaseContext);

            // Перейдіть на сторінку завантаження резюме з переданим userRepository
            MainFrame.Navigate(new ResumeUploadView(userRepository));
        }
    }
}