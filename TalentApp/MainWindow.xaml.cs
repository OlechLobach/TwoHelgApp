using System.Windows;
using System.Windows.Controls;
using JobSeekerApp.Data;

namespace JobSeekerApp.Views
{
    public partial class MainWindow : Window
    {
        private readonly DatabaseContext _dbContext;

        public MainWindow()
        {
            InitializeComponent();

            _dbContext = new DatabaseContext(DatabaseConfig.GetOptions("your_connection_string"));

            NavigateTo<ResumeUploadView>();
        }

        public void NavigateTo<T>() where T : Page, new()
        {
            var page = new T();
            MainFrame.Content = page;
        }

        private void ResumeUpload_Click(object sender, RoutedEventArgs e)
        {
            NavigateTo<ResumeUploadView>();
        }
    }
}