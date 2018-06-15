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
    public class SideAppBar 
        : Grid
    {
        bool CheckIfHandlerShouldExecute = true;

        public static readonly DependencyProperty m_ContentProperty;

        static SideAppBar()
        {
            DefaultStyleKeyProperty
                .OverrideMetadata(typeof(SideAppBar), new FrameworkPropertyMetadata(typeof(SideAppBar)));
            WidthProperty
                .OverrideMetadata(typeof(SideAppBar), new FrameworkPropertyMetadata(Convert.ToDouble(40)));
            HorizontalAlignmentProperty
                .OverrideMetadata(typeof(SideAppBar), new FrameworkPropertyMetadata(HorizontalAlignment.Left));
            VerticalAlignmentProperty
                .OverrideMetadata(typeof(SideAppBar), new FrameworkPropertyMetadata(VerticalAlignment.Stretch));
            MarginProperty
                .OverrideMetadata(typeof(SideAppBar), new FrameworkPropertyMetadata(new Thickness(0, 40, 0, 0)));

            /////////////////////////////////////////////////////////////////////////////////
            /// Routed Events:
            /////////////////////////////////////////////////////////////////////////////////
            EventManager.RegisterClassHandler(typeof(SideAppBar), SizeChangedEvent, new RoutedEventHandler(OnLoaded));
        }

        private static void OnLoaded(object sender, RoutedEventArgs e)
        {
            var _this = (sender as SideAppBar);

            if (_this.CheckIfHandlerShouldExecute == false)
                return;

            StackPanel StackPanel1 = new StackPanel() {
                Margin = new Thickness(2, 0, 2, 4),
                Orientation = Orientation.Vertical,
                Width = _this.ActualWidth,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Stretch,
                Background = Brushes.Transparent,
            };

            ColorZone ColorZone1 = new ColorZone() {
                Mode = ColorZoneMode.PrimaryDark,
                Width = _this.ActualWidth,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Stretch,
                SnapsToDevicePixels = true,
            };

            //ShadowAssist.SetShadowEdges(ColorZone1, ShadowEdges.Right);
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