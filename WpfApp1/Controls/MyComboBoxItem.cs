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

namespace WpfApp1.Controls
{
    public class MyComboBoxItem : ContentControl
    {
        static MyComboBoxItem()
        {
            HorizontalAlignmentProperty.OverrideMetadata(typeof(MyComboBoxItem), new FrameworkPropertyMetadata(HorizontalAlignment.Left));
            VerticalAlignmentProperty.OverrideMetadata(typeof(MyComboBoxItem), new FrameworkPropertyMetadata(VerticalAlignment.Center));

            EventManager.RegisterClassHandler(typeof(MyComboBoxItem), LoadedEvent, new RoutedEventHandler(OnLoaded));
        }

        public static void OnLoaded(object sender, RoutedEventArgs e)
        {
            var _this = (sender as MyComboBoxItem);
            //_this.VisualOffset = new Vector(0, 0);
        }
    }
}
