﻿using System.Globalization;
using System.Windows;

namespace FountainPlus
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Window landing;

            switch (CultureInfo.CurrentCulture.EnglishName)
            {
                case "Japanese (Japan)":
                    landing = new LandingEN();
                    break;
                case "Spanish (Mexico)":
                    landing = new LandingSP();
                    break;
                default:
                    landing = new LandingEN();
                    break;
            }

            landing.Show();
        }
    }


}