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
            //if (ReadLocalValue(ToolTipService.IsEnabledProperty) == DependencyProperty.UnsetValue)
            //    ToolTipService.IsEnabledProperty.OverrideMetadata(typeof(DependencyObject), new FrameworkPropertyMetadata(true));
            //if(ReadLocalValue(ToolTipService.InitialShowDelayProperty) == DependencyProperty.UnsetValue)
            //    ToolTipService.InitialShowDelayProperty.OverrideMetadata(typeof(DependencyObject), new FrameworkPropertyMetadata(0));
            //if(ReadLocalValue(ToolTipService.VerticalOffsetProperty) == DependencyProperty.UnsetValue)
            //    ToolTipService.VerticalOffsetProperty.OverrideMetadata(typeof(DependencyObject), new FrameworkPropertyMetadata(Convert.ToDouble(-8)));
            //(WindowButtonCommands.IsEnabledProperty as DependencyObject).SetValue(ToolTipService.IsEnabledProperty, false);
        }
    }
}
