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
        public static readonly DependencyProperty m_HeaderProperty;


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

            m_HeaderProperty = DependencyProperty.Register(nameof(Header), typeof(string), typeof(TopAppBar), null);

            /////////////////////////////////////////////////////////////////////////////////
            /// Routed Events:
            /////////////////////////////////////////////////////////////////////////////////
            EventManager.RegisterClassHandler(typeof(TopAppBar), SizeChangedEvent, new RoutedEventHandler(OnLoaded));
        }

        public string Header
        {
            get { return (string)GetValue(m_HeaderProperty); }
            set { SetValue(m_HeaderProperty, value); }
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

            var TopAppBar_Navigation1 = new TopAppBar_Navigation();
            var TopAppBar_UserAccount1 = new TopAppBar_UserAccount()
            {
                Width = 26,
                Height = 26,
                Margin = new Thickness(4, 4, 0, 4),
                ClipToBounds = true,
            };
            var TopAppBar_Notifications1 = new TopAppBar_Notifications()
            {
                Width = 26,
                Height = 26,
                Margin = new Thickness(4, 4, 0, 4),
                ClipToBounds = true,
            };
            var TopAppBar_Message1 = new TopAppBar_Message()
            {
                Width = 26,
                Height = 26,
                Margin = new Thickness(4, 4, 0, 4),
                ClipToBounds = true,
            };
            var TopAppBar_Apps1 = new TopAppBar_Apps()
            {
                Width = 26,
                Height = 26,
                Margin = new Thickness(4, 4, 0, 4),
                ClipToBounds = true,
            };

            _this.m_StackPanel2.Children.Add(TopAppBar_UserAccount1);
            _this.m_StackPanel2.Children.Add(TopAppBar_Notifications1);
            _this.m_StackPanel2.Children.Add(TopAppBar_Message1);
            _this.m_StackPanel2.Children.Add(TopAppBar_Apps1);

            _this.m_StackPanel1.Children.Add(TopAppBar_Navigation1);

            var TextBlock1 = new TextBlock()
            {
                Padding = new Thickness(0,0,0,0),
                Text = _this.Header,
                FontSize = 14.5,
                FontWeight = FontWeights.Regular,
                Margin = new Thickness(0, 4, 8, 4),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Foreground = _this.FindResource("MaterialDesignPaper") as Brush,
            };
            _this.m_StackPanel1.Children.Add(TextBlock1);

            foreach (var c in _this.Children.Cast<UIElement>().ToList().AsReadOnly())
            {
                _this.Children.Remove(c);
                _this.m_StackPanel1.Children.Add(c);
            }

            _this.Children.Add(_this.m_ColorZone1);
            _this.Children.Add(_this.m_StackPanel1);
            _this.Children.Add(_this.m_StackPanel2);

            _this.CheckIfHandlerShouldExecute = false;
        }
    }
}