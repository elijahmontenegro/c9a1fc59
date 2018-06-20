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
        : AppBar
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

            _this.m_StackPanel1 = new StackPanel() {
                Margin = new Thickness(0),
                Orientation = Orientation.Horizontal,
                Height = _this.ActualHeight,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Center,
                //Background = Brushes.Blue,
            };

            _this.m_StackPanel2 = new StackPanel()
            {
                Margin = new Thickness(0,0,4,0),
                Orientation = Orientation.Horizontal,
                FlowDirection = FlowDirection.RightToLeft,
                //Width = _this.ActualWidth * 0.25f,
                Height = _this.ActualHeight,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Center,
                //Background = Brushes.Red,
            };

            _this.m_ColorZone1 = new ColorZone() {
                Mode = ColorZoneMode.PrimaryMid,
                Height = _this.ActualHeight,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Center,
                SnapsToDevicePixels = true,
            };

            ShadowAssist.SetShadowEdges(_this.m_ColorZone1, ShadowEdges.Bottom);
            ShadowAssist.SetShadowDepth(_this.m_ColorZone1, ShadowDepth.Depth0);

            SetZIndex(_this.m_ColorZone1, 0);
            SetZIndex(_this.m_StackPanel1, 0);
            SetZIndex(_this.m_StackPanel2, 0);

            foreach (var c in _this.Children.Cast<UIElement>().ToList().AsReadOnly())
            {
                _this.Children.Remove(c);

                if (c.GetType() != typeof(TopAppBar_UserAccountButton))
                    _this.m_StackPanel1.Children.Add(c);
                else if(c.GetType() == typeof(TopAppBar_UserAccountButton))
                    _this.m_StackPanel2.Children.Add(c);
            }

            _this.Children.Add(_this.m_ColorZone1);
            _this.Children.Add(_this.m_StackPanel1);
            _this.Children.Add(_this.m_StackPanel2);

            _this.CheckIfHandlerShouldExecute = false;
        }
    }
}