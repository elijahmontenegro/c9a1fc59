using AutoUpdaterDotNET;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
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
            Title = $"{assembly.GetName().Name} - Version {assembly.GetName().Version.Major}.{assembly.GetName().Version.Minor}.{assembly.GetName().Version.Build}";
        }

        private void ButtonCheckForUpdate_Click(object sender, RoutedEventArgs e)
        {
            AutoUpdater.Start("https://github.com/b8394edf/c9a1fc59/raw/master/MyWPFApplication/JumpStart.xml");
        }

        private void ListViewApps_OnLoaded(object sender, RoutedEventArgs e)
        {
            List<ListViewItem> list = new List<ListViewItem>();

            list.Add(new ListViewItem() { Content = $"Star Citizen", Tag = "CLIENT" });
            list.Add(new ListViewItem() { Content = $"Sandbox Editor", Tag = "ENGINE" });
            list.Add(new ListViewItem() { Content = $"Dedicated Launcher", Tag = "ENGINE" });
            list.Add(new ListViewItem() { Content = $"DataForge", Tag = "MISC" });
            list.Add(new ListViewItem() { Content = $"Subsumption Editor", Tag = "MISC" });
            list.Add(new ListViewItem() { Content = $"3ds Max 2018", Tag = "EXTERNAL"});


            var listView = sender as ListView;
            listView.ItemsSource = list;
        }

        private void ListViewItem_OnSelected(object sender, RoutedEventArgs e)
        {
            var item = (sender as ListView).SelectedItem as ListViewItem;

            if (item == null)
                return;

            var id = item.Content as string;
            var type = item.Tag as string;
            List<ListViewItem> data = new List<ListViewItem>();

            if (type == "CLIENT")
            {
                data.Add(new ListViewItem() { Content = $"Auto Connect" });
            }

            if (type == "CLIENT"
              || type == "ENGINE")
            {
                data.Add(new ListViewItem() { Content = $"Page Heap" });
            }

            if (type == "CLIENT"
              || type == "ENGINE"
              || type == "MISC")
            {
                data.Add(new ListViewItem() { Content = $"Visual Studio" }); // hold ctrl to select two or more options -- i.e: page heap and also visual studio
            }

            listViewOptions.ItemsSource = null;
            listViewOptions.ItemsSource = data;
        }
    }

    class JumpStartListViewItem
    {
        public string name { get; set; }
        public string type { get; set; }
        public string last_accessed { get; set; }
    }
}
