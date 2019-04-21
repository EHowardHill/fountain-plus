using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;

namespace FountainPlus
{
    /// Interaction logic for MainWindow.xaml
    public partial class LandingEN : Window
    {
        String SaveFile = null;

        public LandingEN() {
            InitializeComponent();
            Drop_Font.SelectedValue = "Consolas";

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

        //Reruns text processing when update button is checked
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

        //Changes the fonts
        private void Drop_Font_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string font = Drop_Font.SelectedValue.ToString();
                boxInput.FontFamily = new FontFamily(font);
            }

            catch { }
        }

        //Save file button
        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            // left text field = boxInput
            string textToSave = boxInput.Text;
            if (SaveFile == null){
                // Open Save dialogue and save text to selected file
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                if (saveFileDialog.ShowDialog() == true)
                {
                    using (StreamWriter outputFile = new StreamWriter(saveFileDialog.FileName))
                    {
                        outputFile.WriteLine(textToSave);
                        outputFile.Close();
                    }
                    SaveFile = saveFileDialog.FileName;
                    MessageBox.Show("Save successful! ;)");
                }
            }
            else
            {
                System.IO.File.WriteAllText(SaveFile, textToSave);
                MessageBox.Show("Save successful! ;)");
            }
        }

        //Save as file button
        private void Button_SaveAs_Click(object sender, RoutedEventArgs e)
        {
            // left text field = boxInput
            string textToSave = boxInput.Text;

            // Open Save dialogue and save text to selected file
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                using (StreamWriter outputFile = new StreamWriter(saveFileDialog.FileName))
                {
                    outputFile.WriteLine(textToSave);
                    outputFile.Close();
                }
                SaveFile = saveFileDialog.FileName;
                MessageBox.Show("Save successful! ;)");
            }
        }

        //Open button
        private void Button_Open_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == true)
                    //boxInput is the left hand size text input box
                    boxInput.Text = File.ReadAllText(openFileDialog.FileName);
                    SaveFile = openFileDialog.FileName;
            }
            catch (IOException error1)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(error1.Message);
            }
        }

        //Import button
        private void Button_Import_Click(object sender, RoutedEventArgs e)
        {
            //Clicking this button should maybe open a file browser right here, or maybe should query
            //the Flags class, and perhaps it should handle that?
            //TODO

            //Currently, only attempt to load if not HTML
            if (!InterpreterSelection.Text.Equals("HTML"))
            {
                //Loads the flag of the currently selected formatting
                Flags CurrentFlag = Flags.Import(InterpreterSelection.Text);
                Trace.WriteLine(CurrentFlag.jsSnippet);

            }
        }

        private void Button_New_Click(object sender, RoutedEventArgs e)
        {
            boxInput.Text = null;
            SaveFile = null;
        }

        private void Button_Export_Click(object sender, RoutedEventArgs e)
        {
            dynamic doc = OutputBrowser.Document;
            String htmlText = doc.documentElement.InnerHtml;
            // Open Save dialogue and save text to selected file
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = ".html";
            saveFileDialog.Filter = "HTML files (.html)|*.html";
            if (saveFileDialog.ShowDialog() == true)
            {
                using (StreamWriter outputFile = new StreamWriter(saveFileDialog.FileName))
                {
                    outputFile.WriteLine(htmlText);
                    outputFile.Close();
                }
                MessageBox.Show("Export successful! ;)");
            }
        }
    }


}