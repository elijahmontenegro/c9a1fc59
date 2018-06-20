using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            ToolTipService.IsEnabledProperty.OverrideMetadata(typeof(DependencyObject), new FrameworkPropertyMetadata(false));
            //(WindowButtonCommands.IsEnabledProperty as DependencyObject).SetValue(ToolTipService.IsEnabledProperty, false);
        }
    }
}
