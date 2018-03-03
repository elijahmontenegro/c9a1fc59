using System;
using System.Globalization;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using AutoUpdaterDotNET;
using System.Windows.Controls;
namespace MyWPFApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Assembly assembly = Assembly.GetEntryAssembly();
            Title = $"{assembly.GetName().Name} - Version {assembly.GetName().Version}";

            DispatcherTimer timer = new DispatcherTimer { Interval = TimeSpan.FromMinutes( AutoUpdater.RemindLaterAt = 1) };
            timer.Tick += delegate
            {
                AutoUpdater.Start("https://github.com/b8394edf/c9a1fc59/raw/master/MyWPFApplication/JumpStart.xml");
            };
            timer.Start();
        }

        private void ButtonCheckForUpdate_Click(object sender, RoutedEventArgs e)
        {
            AutoUpdater.Start("https://github.com/b8394edf/c9a1fc59/raw/master/MyWPFApplication/JumpStart.xml");
        }
    }
}
