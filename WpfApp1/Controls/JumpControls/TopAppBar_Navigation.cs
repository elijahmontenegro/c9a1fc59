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
using System.Windows.Media.Animation;

namespace WpfApp1.Controls
{

    public class TopAppBar_Navigation 
        : Grid
    {
        bool m_CheckIfHandlerShouldExecute = true;

        static TopAppBar_Navigation()
        {
            DefaultStyleKeyProperty
                .OverrideMetadata(typeof(TopAppBar_Navigation), new FrameworkPropertyMetadata(typeof(TopAppBar_Navigation)));
            MarginProperty
                .OverrideMetadata(typeof(TopAppBar_Navigation), new FrameworkPropertyMetadata(new Thickness(4,4,4,4)));
            BackgroundProperty
                .OverrideMetadata(typeof(TopAppBar_Navigation), new FrameworkPropertyMetadata(Brushes.Transparent));

            /////////////////////////////////////////////////////////////////////////////////
            /// Routed Events:
            ///////////////////////////////////////////////////////////////////////////////// 
            EventManager.RegisterClassHandler(typeof(TopAppBar_Navigation), SizeChangedEvent, new RoutedEventHandler(OnLoad));
        }

        private static void OnLoad(object sender, RoutedEventArgs e)
        {
            var _this = (sender as TopAppBar_Navigation);
            
            if (_this.m_CheckIfHandlerShouldExecute == false)
                return;

            var Button1 = new Button()
            {
                Name = "TopAppBar_Navigation_Button1",
                Margin = new Thickness(0),
                Padding = new Thickness(0),
                Width = 40,
                Height = 32,
                HorizontalAlignment = HorizontalAlignment.Center,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center,
                Foreground = _this.FindResource("MaterialDesignPaper") as Brush,
                //Style = _this.FindResource("MaterialDesignFloatingActionButton") as Style,
                Style = _this.FindResource("MaterialDesignRaisedButton") as Style,
                Content = new PackIcon()
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Width = 18,
                    Height = 18,
                    Kind = PackIconKind.Menu,
                    Foreground = _this.FindResource("MaterialDesignPaper") as Brush,
                },
            };

            Button1.AddHandler(MouseDownEvent, new MouseButtonEventHandler(SideAppBar.OnMouseDown), true);

            RippleAssist.SetIsCentered(Button1, true);
            RippleAssist.SetClipToBounds(Button1, true);
            RippleAssist.SetIsDisabled(Button1, true);
            ShadowAssist.SetShadowDepth(Button1, ShadowDepth.Depth0);

            _this.Children.Add(Button1);

            _this.m_CheckIfHandlerShouldExecute = false;
        }
    }
}
