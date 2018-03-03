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
            Title = $"{assembly.GetName().Name} - CIG QA - Version {assembly.GetName().Version}";
            AutoUpdater.LetUserSelectRemindLater = true;
            AutoUpdater.RemindLaterTimeSpan = RemindLaterFormat.Minutes;
            AutoUpdater.RemindLaterAt = 1;
            AutoUpdater.ReportErrors = true;
            DispatcherTimer timer = new DispatcherTimer { Interval = TimeSpan.FromMinutes(2) };
            timer.Tick += delegate
            {
                AutoUpdater.Start("https://github.com/b8394edf/c9a1fc59/raw/master/MyWPFApplication/JumpStart.xml");
            };
            timer.Start();
        }

        private void ButtonCheckForUpdate_Click(object sender, RoutedEventArgs e)
        {
            AutoUpdater.Start("https://github.com/b8394edf/c9a1fc59/raw/master/MyWPFApplication/JumpStart.xml");

            Console.Write("Works!");
            Console.Write("Works!");
        }

        private void ToolBar_Loaded(object sender, RoutedEventArgs e)
        {
            //ToolBar toolBar = sender as ToolBar;
            //var overflowGrid = toolBar.Template.FindName("OverflowGrid", toolBar) as FrameworkElement;
            //if (overflowGrid != null)
            //{
            //    overflowGrid.Visibility = Visibility.Collapsed;
            //}
            //var mainPanelBorder = toolBar.Template.FindName("MainPanelBorder", toolBar) as FrameworkElement;
            //if (mainPanelBorder != null)
            //{
            //    mainPanelBorder.Margin = new Thickness();
            //}
        }
    }
}
