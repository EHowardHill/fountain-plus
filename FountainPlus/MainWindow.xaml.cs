using System.Windows;
using System.Windows.Controls;

namespace FountainPlus
{
    /// Interaction logic for MainWindow.xaml
    public partial class MainWindow : Window {

        public MainWindow() {
            InitializeComponent();
        }

        // Auto-Update
        private void BoxInput_TextChanged(object sender, TextChangedEventArgs e) {
            if (Check_Update.IsChecked.GetValueOrDefault()) {
                try { OutputBrowser.NavigateToString(Fountain.Process(boxInput.Text)); }
                catch { OutputBrowser.NavigateToString("<html></html>"); }
            }
        }

        // Enable or disable the auto-update button
        private void Check_Update_Checked(object sender, RoutedEventArgs e)
        {
            Btn_Update.IsEnabled = false;
        }

        private void Check_Update_Unchecked(object sender, RoutedEventArgs e)
        {
            Btn_Update.IsEnabled = true;
        }

        private void Btn_Update_Click(object sender, RoutedEventArgs e)
        {
            try { OutputBrowser.NavigateToString(Fountain.Process(boxInput.Text)); }
            catch { OutputBrowser.NavigateToString("<html></html>"); }
        }
    }
}