using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FountainPlus
{
    /// Interaction logic for MainWindow.xaml
    public partial class MainWindow : Window {

        public MainWindow() {
            InitializeComponent();
            Drop_Font.SelectedValue = "Consolas";
            Flags.Import("");
        }

        // Auto-Update
        private void BoxInput_TextChanged(object sender, TextChangedEventArgs e) {
            if (Check_AutoUpdate.IsChecked.GetValueOrDefault()) {
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

        private void Drop_Interface_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (Drop_Interface.SelectedIndex)
            {
                case 0:     // Light
                    try {
                        Bkg_PreviewHub.Background = SystemColors.ControlLightBrush;
                        Bkg_Tabbar.Background = SystemColors.ControlLightLightBrush;
                        Label_Input.Foreground = SystemColors.ActiveCaptionTextBrush;
                        Label_Outpt.Foreground = SystemColors.ActiveCaptionTextBrush;
                        Label_Edt.Foreground = SystemColors.ActiveCaptionTextBrush;
                        Label_Pre.Foreground = SystemColors.ActiveCaptionTextBrush;
                        Label_Int.Foreground = SystemColors.ActiveCaptionTextBrush;
                        boxInput.Background = SystemColors.ControlLightLightBrush;
                        boxInput.Foreground = SystemColors.ActiveCaptionTextBrush;
                    }
                    catch { }
                    break;
                case 1:     // Dark
                    try {
                        Bkg_PreviewHub.Background = SystemColors.ActiveCaptionTextBrush;
                        Bkg_Tabbar.Background = SystemColors.ControlDarkDarkBrush;
                        Label_Input.Foreground = SystemColors.ControlLightLightBrush;
                        Label_Outpt.Foreground = SystemColors.ControlLightLightBrush;
                        Label_Edt.Foreground = SystemColors.ControlLightLightBrush;
                        Label_Pre.Foreground = SystemColors.ControlLightLightBrush;
                        Label_Int.Foreground = SystemColors.ControlLightLightBrush;
                        boxInput.Background = SystemColors.ControlDarkDarkBrush;
                        boxInput.Foreground = SystemColors.ControlLightLightBrush;
                    }
                    catch { }
                    break;
            }
        }

        private void Drop_Font_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string font = Drop_Font.SelectedValue.ToString();
                boxInput.FontFamily = new FontFamily(font);
            }

            catch { }
        }
    }
}