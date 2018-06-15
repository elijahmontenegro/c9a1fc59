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
using System.Windows.Controls.Primitives;
using MaterialDesignThemes.Wpf;

namespace WpfApp1.Controls
{
    public class TopAppBar
        : Grid
    {
        bool CheckIfHandlerShouldExecute = true;

        static TopAppBar()
        {
            DefaultStyleKeyProperty
                .OverrideMetadata(typeof(TopAppBar), new FrameworkPropertyMetadata(typeof(TopAppBar)));
            BackgroundProperty
                .OverrideMetadata(typeof(TopAppBar), new FrameworkPropertyMetadata(Brushes.Transparent));
            HeightProperty
                .OverrideMetadata(typeof(TopAppBar), new FrameworkPropertyMetadata(Convert.ToDouble(40)));
            HorizontalAlignmentProperty
                .OverrideMetadata(typeof(TopAppBar), new FrameworkPropertyMetadata(HorizontalAlignment.Stretch));
            VerticalAlignmentProperty
                .OverrideMetadata(typeof(TopAppBar), new FrameworkPropertyMetadata(VerticalAlignment.Top));

            /////////////////////////////////////////////////////////////////////////////////
            /// Routed Events:
            /////////////////////////////////////////////////////////////////////////////////
            EventManager.RegisterClassHandler(typeof(TopAppBar), SizeChangedEvent, new RoutedEventHandler(OnLoaded));
        }

        private static void OnLoaded(object sender, RoutedEventArgs e)
        {
            var _this = (sender as TopAppBar);

            if (_this.CheckIfHandlerShouldExecute == false)
                return;

            StackPanel StackPanel1 = new StackPanel() {
                Margin = new Thickness(2, 4, 2, 4),
                Orientation = Orientation.Horizontal,
                Height = _this.ActualHeight,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Center,
                Background = Brushes.Transparent,
            };

            ColorZone ColorZone1 = new ColorZone() {
                Mode = ColorZoneMode.PrimaryMid,
                Height = _this.ActualHeight,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Center,
                SnapsToDevicePixels = true,
            };

            //ShadowAssist.SetShadowDepth(ColorZone1, ShadowDepth.Depth1);

            SetZIndex(ColorZone1, 0);
            SetZIndex(StackPanel1, 0);

            foreach (var c in _this.Children.Cast<UIElement>().ToList().AsReadOnly())
            {
                _this.Children.Remove(c);
                StackPanel1.Children.Add(c);
            }

            _this.Children.Add(ColorZone1);
            _this.Children.Add(StackPanel1);

            _this.CheckIfHandlerShouldExecute = false;
        }
    }
}