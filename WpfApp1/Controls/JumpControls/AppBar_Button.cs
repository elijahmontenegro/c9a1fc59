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
    public class AppBar_Button : Grid
    {
        AppBarButton m_Button;
        bool m_CheckIfHandlerShouldExecute = true;
        public static readonly DependencyProperty m_IconProperty;

        static AppBar_Button()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AppBar_Button), new FrameworkPropertyMetadata(typeof(AppBar_Button)));
            MarginProperty.OverrideMetadata(typeof(AppBar_Button), new FrameworkPropertyMetadata(new Thickness(0, 0, 0, 0)));
            BackgroundProperty.OverrideMetadata(typeof(AppBar_Button), new FrameworkPropertyMetadata(Brushes.Transparent));

            /////////////////////////////////////////////////////////////////////////////////
            /// Custom Properties:
            /////////////////////////////////////////////////////////////////////////////////
            m_IconProperty = DependencyProperty.Register(nameof(Icon), typeof(PackIconKind), typeof(Icon), new PropertyMetadata(default(PackIconKind)));

            /////////////////////////////////////////////////////////////////////////////////
            /// Routed Events:
            /////////////////////////////////////////////////////////////////////////////////
            EventManager.RegisterClassHandler(typeof(AppBar_Button), SizeChangedEvent, new RoutedEventHandler(OnLoad));
        }

        //private static void OnMouseEnter(object sender, RoutedEventArgs e)
        //{
        //    var _this = (sender as AppBarButton);

        //    //if(!_this.m_MouseDown)
        //    //    _this.m_PackIcon.Foreground = _this.FindResource("AccentColorBrush4") as Brush;
        //    RippleAssist.SetFeedback(_this, Brushes.White);
        //}

        //private static void OnMouseLeave(object sender, RoutedEventArgs e)
        //{
        //    var _this = (sender as AppBarButton);

        //    //_this.m_PackIcon.Foreground = _this.FindResource("MaterialDesignPaper") as Brush;
        //}

        //private static void OnMouseDown(object sender, RoutedEventArgs e)
        //{
        //    var _this = (sender as AppBarButton);

        //    //_this.m_MouseDown = true;
        //    //_this.m_PackIcon.Foreground = _this.FindResource("MaterialDesignPaper") as Brush;
        //}

        public PackIconKind Icon
        {
            get { return (PackIconKind) GetValue(m_IconProperty); }
            set { SetValue(m_IconProperty, value); }
        }

        private static void OnLoad(object sender, RoutedEventArgs e)
        {
            var This = (sender as AppBar_Button);

            if (This.m_CheckIfHandlerShouldExecute == false)
                return;

            var Button1 = new AppBarButton();
            var TopAppBar1 = (This.GetUIParentCore() as StackPanel).Parent as AppBar;

            Button1.m_PackIcon.HorizontalAlignment = HorizontalAlignment.Center;
            Button1.m_PackIcon.VerticalAlignment = VerticalAlignment.Center;
            Button1.m_PackIcon.Width = 24;
            Button1.m_PackIcon.Height = 24;
            Button1.m_PackIcon.Foreground = This.FindResource("MaterialDesignPaper") as Brush;
            Button1.m_PackIcon.Kind = This.Icon;

            if (TopAppBar1.m_ColorZone1.Mode == ColorZoneMode.PrimaryMid)
            {
                Button1.Width = 32;
                Button1.Height = 32;
                This.Margin = new Thickness(0, 4, 4, 4);
                Button1.Style = This.FindResource("MaterialDesignFloatingActionButton") as Style;

                RippleAssist.SetRippleSizeMultiplier(Button1, 1.75f);
            }
            else
            {
                This.Margin = new Thickness(4, 4, 4, 4);
                Button1.Height = 32;
                Button1.Style = This.FindResource("MaterialDesignRaisedDarkButton") as Style;

                RippleAssist.SetIsCentered(Button1, false);
                RippleAssist.SetRippleSizeMultiplier(Button1, 1.50f);
            }

            This.m_Button = Button1;

            This.Children.Add(This.m_Button);

            This.m_CheckIfHandlerShouldExecute = false;
        }
    }
}
