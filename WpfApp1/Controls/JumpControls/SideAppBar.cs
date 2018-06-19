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
        : AppBar
    {
        bool CheckIfHandlerShouldExecute = true;

        static SideAppBar()
        {
            NameProperty
                .OverrideMetadata(typeof(SideAppBar), new FrameworkPropertyMetadata("SideAppBar1"));
            DefaultStyleKeyProperty
                .OverrideMetadata(typeof(SideAppBar), new FrameworkPropertyMetadata(typeof(SideAppBar)));
            WidthProperty
                .OverrideMetadata(typeof(SideAppBar), new FrameworkPropertyMetadata(Convert.ToDouble(48)));
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

            _this.m_StackPanel1 = new StackPanel() {
                Margin = new Thickness(0, 0, 0, 0),
                Orientation = Orientation.Vertical,
                Width = _this.ActualWidth,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Stretch,
                Background = Brushes.Transparent,
            };

            _this.m_ColorZone1 = new ColorZone() {
                Mode = ColorZoneMode.PrimaryDark,
                Width = _this.ActualWidth,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Stretch,
                SnapsToDevicePixels = true,
            };

            //ShadowAssist.SetShadowEdges(_this.m_ColorZone1, ShadowEdges.Right);
            ShadowAssist.SetShadowDepth(_this.m_ColorZone1, ShadowDepth.Depth0);

            SetZIndex(_this.m_ColorZone1, 0);
            SetZIndex(_this.m_StackPanel1, 0);

            foreach (var c in _this.Children.Cast<UIElement>().ToList().AsReadOnly())
            {
                _this.Children.Remove(c);
                _this.m_StackPanel1.Children.Add(c);
            }

            _this.Children.Add(_this.m_ColorZone1);
            _this.Children.Add(_this.m_StackPanel1);

            _this.CheckIfHandlerShouldExecute = false;
        }
    }
}