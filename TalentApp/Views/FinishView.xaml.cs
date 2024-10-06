using System.Windows;
using System.Windows.Controls;

namespace JobSeekerApp.Views
{
    public partial class FinishView : Page
    {
        public FinishView()
        {
            InitializeComponent();
        }

        private void CloseAppButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
