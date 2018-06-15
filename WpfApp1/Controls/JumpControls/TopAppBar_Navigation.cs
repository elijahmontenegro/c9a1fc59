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
    public class TopAppBar_Navigation 
        : Grid
    {
        bool CheckIfHandlerShouldExecute = true;

        static TopAppBar_Navigation()
        {
            DefaultStyleKeyProperty
                .OverrideMetadata(typeof(TopAppBar_Navigation), new FrameworkPropertyMetadata(typeof(TopAppBar_Navigation)));

            /////////////////////////////////////////////////////////////////////////////////
            /// Routed Events:
            /////////////////////////////////////////////////////////////////////////////////
            EventManager.RegisterClassHandler(typeof(TopAppBar_Navigation), SizeChangedEvent, new RoutedEventHandler(OnLoad));
        }

        private static void OnLoad(object sender, RoutedEventArgs e)
        {
            var _this = (sender as TopAppBar_Navigation);

            if (_this.CheckIfHandlerShouldExecute == false)
                return;

            var Button1 = new Button()
            {
                Margin = new Thickness(2, 0, 2, 0),
                Padding = new Thickness(0),
                Width = 32,
                Height = 32,
                HorizontalAlignment = HorizontalAlignment.Center,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center,
                Foreground = _this.FindResource("MaterialDesignPaper") as Brush,
                Style = _this.FindResource("MaterialDesignFloatingActionButton") as Style,
                //Style = _this.FindResource("MaterialDesignRaisedButton") as Style,
                //Background = Brushes.Transparent,
                Content = new PackIcon()
                {
                    Background = Brushes.Transparent,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Width = 18,
                    Height = 18,
                    Kind = PackIconKind.Menu,
                    Foreground = _this.FindResource("MaterialDesignPaper") as Brush,
                },
            };

            RippleAssist.SetIsCentered(Button1, true);
            RippleAssist.SetClipToBounds(Button1, true);
            //RippleAssist.SetRippleSizeMultiplier(Button1, 0.70f);
            ShadowAssist.SetShadowDepth(Button1, ShadowDepth.Depth0);

            _this.Children.Add(Button1);

            _this.CheckIfHandlerShouldExecute = false;
        }
    }
}
