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
    public class TopAppBar_Button
        : Grid
    {
        bool m_CheckIfHandlerShouldExecute = true;

        public static readonly DependencyProperty m_IconProperty;

        static TopAppBar_Button()
        {
            DefaultStyleKeyProperty
                .OverrideMetadata(typeof(TopAppBar_Button), new FrameworkPropertyMetadata(typeof(TopAppBar_Button)));
            MarginProperty
                .OverrideMetadata(typeof(SideAppBar_Button), new FrameworkPropertyMetadata(new Thickness(0, 4, 0, 4)));

            /////////////////////////////////////////////////////////////////////////////////
            /// Custom Properties:
            /////////////////////////////////////////////////////////////////////////////////
            m_IconProperty
                = DependencyProperty.Register(nameof(Icon), typeof(PackIconKind), typeof(Icon), new PropertyMetadata(default(PackIconKind)));

            /////////////////////////////////////////////////////////////////////////////////
            /// Routed Events:
            /////////////////////////////////////////////////////////////////////////////////
            EventManager.RegisterClassHandler(typeof(TopAppBar_Button), SizeChangedEvent, new RoutedEventHandler(OnLoad));
        }

        public PackIconKind Icon
        {
            get { return (PackIconKind) GetValue(m_IconProperty); }
            set { SetValue(m_IconProperty, value); }
        }

        private static void OnLoad(object sender, RoutedEventArgs e)
        {
            var _this = (sender as TopAppBar_Button);

            if (_this.m_CheckIfHandlerShouldExecute == false)
                return;

            var Button1 = new Button()
            {
                Padding = new Thickness(0),
                Width = 32,
                Height = 32,
                HorizontalAlignment = HorizontalAlignment.Center,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center,
                Foreground = _this.FindResource("MaterialDesignPaper") as Brush,
                Style = _this.FindResource("MaterialDesignFloatingActionDarkButton") as Style,
                //Style = _this.FindResource("MaterialDesignRaisedDarkButton") as Style,
                //Background = Brushes.Transparent,
                Content = new PackIcon()
                {
                    Background = Brushes.Transparent,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Width = 18,
                    Height = 18,
                    Kind = _this.Icon,
                    Foreground = _this.FindResource("MaterialDesignPaper") as Brush,
                },
            };

            RippleAssist.SetIsCentered(Button1, true);
            RippleAssist.SetClipToBounds(Button1, true);
            ShadowAssist.SetShadowDepth(Button1, ShadowDepth.Depth0);

            _this.Children.Add(Button1);

            _this.m_CheckIfHandlerShouldExecute = false;
        }
    }
}
