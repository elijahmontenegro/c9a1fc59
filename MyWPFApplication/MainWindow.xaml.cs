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

            list.Add(new ListViewItem() { Content = $"Star Citizen" });
            list.Add(new ListViewItem() { Content = $"Sandbox Editor" });
            list.Add(new ListViewItem() { Content = $"Dedicated Launcher" });
            list.Add(new ListViewItem() { Content = $"DataForge" });
            list.Add(new ListViewItem() { Content = $"Subsumption Editor" });
            list.Add(new ListViewItem() { Content = $"3ds Max 2018" });


            var listView = sender as ListView;
            listView.ItemsSource = list;
        }

        private void ListViewItem_OnSelected(object sender, RoutedEventArgs e)
        {
            var item = (sender as ListView).SelectedItem as ListViewItem;

            if (item == null)
                return;

            var id = item.Content as string;
            var type = "" as string;
            var src = listViewOptions.ItemsSource;
            List<ListViewItem> data = new List<ListViewItem>();

            if (type == "default")
            {
                data.Add(new ListViewItem() { Content = $"Auto Connect" });
                data.Add(new ListViewItem() { Content = $"Launch with Page Heap" });
                data.Add(new ListViewItem() { Content = $"Launch with Visual Studio" });
            }
            else if (type == "tools")
            {
                data.Add(new ListViewItem() { Content = $"Launch with Page Heap" });
                data.Add(new ListViewItem() { Content = $"Launch with Visual Studio" }); // hold ctrl to select two or more options -- i.e: page heap and also visual studio
            }
            else
            {
                src = null;
            }

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
