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
using System.Collections.ObjectModel;
using MaterialDesignThemes.Wpf;
using System.Windows.Threading;

namespace WpfApp1.Controls
{
    public class JumpComboBox 
        : Grid
    {
        bool CheckIfHandlerShouldExecute = true;

        static JumpComboBox()
        {
            // Specify veritical margins in the root Stackpanel.
            MarginProperty.OverrideMetadata(typeof(JumpComboBox), new FrameworkPropertyMetadata(new Thickness(0, 4, 4, 4)));
            HorizontalAlignmentProperty.OverrideMetadata(typeof(JumpComboBox), new FrameworkPropertyMetadata(HorizontalAlignment.Stretch));
            VerticalAlignmentProperty.OverrideMetadata(typeof(JumpComboBox), new FrameworkPropertyMetadata(VerticalAlignment.Stretch));
            //BackgroundProperty.OverrideMetadata(typeof(JumpComboBox), new FrameworkPropertyMetadata(Brushes.Transparent));
            EventManager.RegisterClassHandler(typeof(JumpComboBox), SizeChangedEvent, new RoutedEventHandler(OnSizeChanged));
        }

        private static void OnSizeChanged(object sender, RoutedEventArgs e) // this is called two times 
        {
            // Only specify horizontal margin here.
            var _this = (sender as JumpComboBox);

            if (_this.CheckIfHandlerShouldExecute == false)
                return;
            
            var ColorZone1 = new ColorZone()
            {
                Mode = ColorZoneMode.Light,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                SnapsToDevicePixels = true,
            };

            ShadowAssist.SetShadowEdges(ColorZone1, ShadowEdges.Right);
            ShadowAssist.SetShadowDepth(ColorZone1, ShadowDepth.Depth1);

            var StackPanel1 = new StackPanel()
            {
                Margin = new Thickness(0, 1, 0, 1),
                Orientation = Orientation.Horizontal,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                //Background = Brushes.Transparent,
            };

            var PackIcon1 = new PackIcon()
            {
                Margin = new Thickness(6, 0, 0, 0),
                Height = Convert.ToDouble(_this.ActualHeight),
                Width = Convert.ToDouble(14),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center,
                Kind = PackIconKind.ViewList,
                //Background = Brushes.Transparent,
            };

            StackPanel1.Children.Add(PackIcon1);

            var MyComboBox1 = new MyComboBox()
            {
                Margin = new Thickness(0, 0, 12, 0),
                Padding = new Thickness(4, 0, 0, 2),
                HorizontalContentAlignment = HorizontalAlignment.Left,
                VerticalContentAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                //Background = Brushes.Transparent,
                SnapsToDevicePixels = true,
            };

           var srcList = _this.Children.Cast<UIElement>().ToList().AsReadOnly();
           {
               for (int i = 0; i < srcList.Count; i++)
               {
                   var eItem = srcList.ElementAt(i);
                   if (!eItem.GetType().IsEquivalentTo(typeof(MyComboBoxItem)))
                       continue;

                   eItem.Visibility = Visibility.Collapsed;
                   eItem.IsEnabled = false;

                   var newItem = new MyComboBoxItem() {
                       Margin = new Thickness(0, -(_this.Margin.Top/2), 0, -(_this.Margin.Bottom/2)),
                       Content = $"{(eItem as MyComboBoxItem).Content}"
                   };

                   MyComboBox1.Items.Add(newItem);
               }
           }

            StackPanel1.Children.Add(MyComboBox1);
            ColorZone1.Content = StackPanel1;
            _this.Children.Add(ColorZone1);
            _this.CheckIfHandlerShouldExecute = false;
        }
    }
}
