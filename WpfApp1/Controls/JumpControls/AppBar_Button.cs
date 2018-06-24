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
using System.Windows.Threading;
using MaterialDesignThemes.Wpf;

namespace WpfApp1.Controls
{
    public class AppBar_Button 
        : Button
    {
        bool m_CheckIfHandlerShouldExecute = true;
        public PackIcon m_PackIcon;
        public static readonly DependencyProperty m_IconProperty;
        bool m_bMouseDown = false;
        bool m_bMouseLeave = false;

        static AppBar_Button()
        {
            // Routed Events
            EventManager.RegisterClassHandler(typeof(AppBar_Button), SizeChangedEvent, new RoutedEventHandler(OnLoad));

            // Custom Properties
            m_IconProperty = DependencyProperty.Register(nameof(Icon), typeof(PackIconKind), typeof(Icon), new PropertyMetadata(default(PackIconKind)));
        }

        public PackIconKind Icon
        {
            get { return (PackIconKind)GetValue(m_IconProperty); }
            set { SetValue(m_IconProperty, value); }
        }

        private static void OnLoad(object sender, RoutedEventArgs e)
        {
            var This = (sender as AppBar_Button);

            if (This.m_CheckIfHandlerShouldExecute == false)
                return;

            /////////////////////////////////////////////////////////////////////////////////

            // Routed Events 
            EventManager.RegisterClassHandler(typeof(AppBar_Button), MouseEnterEvent, new RoutedEventHandler(OnMouseEnter));
            EventManager.RegisterClassHandler(typeof(AppBar_Button), MouseLeaveEvent, new RoutedEventHandler(OnMouseLeave));
            EventManager.RegisterClassHandler(typeof(AppBar_Button), MouseDownEvent, new RoutedEventHandler(OnMouseDown));
            EventManager.RegisterClassHandler(typeof(AppBar_Button), MouseUpEvent, new RoutedEventHandler(OnMouseUp));
            // Routed Events End

            // Default Properties
            This.Margin = new Thickness(0);
            This.Padding = new Thickness(0);
            This.HorizontalContentAlignment = HorizontalAlignment.Center;
            This.VerticalContentAlignment = VerticalAlignment.Center;
            This.Foreground = This.FindResource("MaterialDesignPaper") as Brush;
            // Default Properties End

            // Icon
            This.m_PackIcon = new PackIcon() {
                Kind = This.Icon,
                Foreground = This.FindResource("MaterialDesignPaper") as Brush,
            };
            
            RippleAssist.SetClipToBounds(This, true);
            RippleAssist.SetIsCentered(This, true);
            ShadowAssist.SetShadowDepth(This, ShadowDepth.Depth0);

            This.Content = This.m_PackIcon;
            // Icon End

            // Mode
            var Root = (This.Parent as StackPanel).Parent as AppBar;

            if ( Root.m_ColorZone1.Mode == ColorZoneMode.PrimaryMid ) {
                This.Margin = new Thickness(0, 4, 4, 4);
                This.m_PackIcon.Width = 20;
                This.m_PackIcon.Height = 20;
                This.Width  = 32;
                This.Height = 32;
                This.Style = This.FindResource("MaterialDesignFloatingActionButton") as Style;

                RippleAssist.SetRippleSizeMultiplier(This, 1.75f);
            }
            else if( Root.m_ColorZone1.Mode == ColorZoneMode.PrimaryDark ) {
                This.Margin = new Thickness(0);
                This.m_PackIcon.Width = 24;
                This.m_PackIcon.Height = 24;
                This.Height = 32;
                This.Style = This.FindResource("MaterialDesignRaisedDarkButton") as Style;

                RippleAssist.SetIsCentered(This, false);
                RippleAssist.SetRippleSizeMultiplier(This, 1.50f);
            }
            // Mode End

            /////////////////////////////////////////////////////////////////////////////////
            This.m_CheckIfHandlerShouldExecute = false;
        }

        private static void OnMouseEnter(object sender, RoutedEventArgs e)
        {
            var This = (sender as AppBar_Button);

            if(This.m_bMouseDown == false)
                This.m_PackIcon.Foreground = This.FindResource("AccentColorBrush4") as Brush;
            This.m_bMouseLeave = false;
        }

        private static void OnMouseLeave(object sender, RoutedEventArgs e)
        {
            var This = (sender as AppBar_Button);

            This.m_PackIcon.Foreground = This.FindResource("MaterialDesignPaper") as Brush;

            This.m_bMouseLeave = true;
        }

        private static void OnMouseDown(object sender, RoutedEventArgs e)
        {
            var This = (sender as AppBar_Button);

            This.m_PackIcon.Foreground = This.FindResource("MaterialDesignPaper") as Brush;

            This.m_bMouseDown = true;
        }

        private static void OnMouseUp(object sender, RoutedEventArgs e)
        {
            var This = (sender as AppBar_Button);

            var t = new DispatcherTimer {
                Interval = TimeSpan.FromMilliseconds(333.33)
            };
            t.Start();
            t.Tick += (s, a) =>
            {   t.Stop();

                if(This.m_bMouseLeave == false)
                    This.m_PackIcon.Foreground = This.FindResource("AccentColorBrush4") as Brush;

                This.m_bMouseDown = false;
            };
        }
    }
}
