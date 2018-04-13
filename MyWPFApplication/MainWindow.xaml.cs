using System;
using System.Globalization;
using System.Reflection;
using System.Windows;
using AutoUpdaterDotNET;
using System.Windows.Controls;

using System.Collections.Generic;
using System.Windows.Media;

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
        }

        private void ButtonCheckForUpdate_Click(object sender, RoutedEventArgs e)
        {
            AutoUpdater.Start("https://github.com/b8394edf/c9a1fc59/raw/master/MyWPFApplication/JumpStart.xml");
        }

        private void ListViewApps_OnLoaded(object sender, RoutedEventArgs e)
        {
            List<ListViewItem> list = new List<ListViewItem>();

            for (int i = 1; i <= 3; i++){
                var data = new ListViewItem() { Content = $"name ({i})" };
                list.Add(data);
            }

            var listView = sender as ListView;
            listView.ItemsSource = list;
        }

        private void ListViewOptions_OnLoaded(object sender, RoutedEventArgs e)
        {
            List<ListViewItem> list = new List<ListViewItem>();

            list.Add(new ListViewItem() { Content = $"Auto Connect" });
            list.Add(new ListViewItem() { Content = $"Launch with Page Heap" });
            list.Add(new ListViewItem() { Content = $"Launch with Visual Studio" });

            var listView = sender as ListView;
            listView.ItemsSource = list;
        }
    }

    class JumpStartListViewItem
    {
        public string name { get; set; }
        public string type { get; set; }
        public string last_accessed { get; set; }
    }
}
