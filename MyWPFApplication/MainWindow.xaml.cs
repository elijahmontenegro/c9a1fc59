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
            List<ListViewItem> listView_itemList = new List<ListViewItem>();

            for (int i=0; i < 3; i++)
            {
                var listViewItem = new ListViewItem();
                listViewItem.Content = $"test ({i})";
                //
                listView_itemList.Add(listViewItem);
            }

            var listView = sender as ListView;
            listView.ItemsSource = listView_itemList;
        }
    }
}
