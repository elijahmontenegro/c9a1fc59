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
    public class SideAppBar_Button
        : Grid
    {
        bool m_CheckIfHandlerShouldExecute = true;

        public static readonly DependencyProperty m_IconProperty;

        static SideAppBar_Button()
        {
            DefaultStyleKeyProperty
                .OverrideMetadata(typeof(SideAppBar_Button), new FrameworkPropertyMetadata(typeof(SideAppBar_Button)));
            MarginProperty
                .OverrideMetadata(typeof(SideAppBar_Button), new FrameworkPropertyMetadata(new Thickness(0, 0, 0, 0)));
            BackgroundProperty
                .OverrideMetadata(typeof(SideAppBar_Button), new FrameworkPropertyMetadata(Brushes.Transparent));

            /////////////////////////////////////////////////////////////////////////////////
            /// Custom Properties:
            /////////////////////////////////////////////////////////////////////////////////
            m_IconProperty
                = DependencyProperty.Register(nameof(Icon), typeof(PackIconKind), typeof(Icon), new PropertyMetadata(default(PackIconKind)));

            /////////////////////////////////////////////////////////////////////////////////
            /// Routed Events:
            /////////////////////////////////////////////////////////////////////////////////
            EventManager.RegisterClassHandler(typeof(SideAppBar_Button), SizeChangedEvent, new RoutedEventHandler(OnLoad));
        }

        public PackIconKind Icon
        {
            get { return (PackIconKind) GetValue(m_IconProperty); }
            set { SetValue(m_IconProperty, value); }
        }

        private static void OnLoad(object sender, RoutedEventArgs e)
        {
            var _this = (sender as SideAppBar_Button);
            if (_this.m_CheckIfHandlerShouldExecute == false)
                return;

            var Button1 = new Button()
            {
                Margin = new Thickness(0),
                Padding = new Thickness(0),
                HorizontalAlignment = HorizontalAlignment.Stretch,
                HorizontalContentAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                VerticalContentAlignment = VerticalAlignment.Stretch,
                Foreground = _this.FindResource("MaterialDesignPaper") as Brush,
                //Background = Brushes.Transparent,
            };

            RippleAssist.SetClipToBounds(Button1, true);
            RippleAssist.SetIsCentered(Button1, true);
            ShadowAssist.SetShadowDepth(Button1, ShadowDepth.Depth0);

            if (((_this.GetUIParentCore() as StackPanel).Parent as AppBar).m_ColorZone1.Mode == ColorZoneMode.PrimaryMid)
            {
                Button1.Width = 32;
                Button1.Height = 32;
                _this.Margin = new Thickness(0, 4, 4, 4);
                //Button1.Style = _this.FindResource("MaterialDesignFloatingActionButton") as Style;
                Button1.Style = _this.FindResource("MaterialDesignRaisedButton") as Style;
                var PackIcon1 = new PackIcon()
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Width = 20,
                    Height = 20,
                    Kind = _this.Icon,
                    Foreground = _this.FindResource("MaterialDesignPaper") as Brush,
                };
                RippleAssist.SetRippleSizeMultiplier(Button1, 0.5f);
                Button1.Content = PackIcon1;
            }
            else
            {
                _this.Margin = new Thickness(4, 4, 4, 4);
                //Button1.Width = 32;
                Button1.Height = 32;
                Button1.Style = _this.FindResource("MaterialDesignRaisedDarkButton") as Style;
                var PackIcon1 = new PackIcon()
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Width = 20,
                    Height = 20,
                    Kind = _this.Icon,
                    Foreground = _this.FindResource("MaterialDesignPaper") as Brush,
                };
                RippleAssist.SetRippleSizeMultiplier(Button1, 0.875f);
                Button1.Content = PackIcon1;
            }
            //Button1.Style = _this.FindResource("MaterialDesignRaisedLightButton") as Style;

            //MessageBox.Show($"Button1.ActualWidth {Button1.ActualWidth}");

            _this.Children.Add(Button1);

            _this.m_CheckIfHandlerShouldExecute = false;
        }
    }
}
