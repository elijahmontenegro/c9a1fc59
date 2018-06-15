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
        bool CheckIfHandlerShouldExecute = true;

        static SideAppBar_Button()
        {
            DefaultStyleKeyProperty
                .OverrideMetadata(typeof(SideAppBar_Button), new FrameworkPropertyMetadata(typeof(SideAppBar_Button)));

            /////////////////////////////////////////////////////////////////////////////////
            /// Routed Events:
            /////////////////////////////////////////////////////////////////////////////////
            EventManager.RegisterClassHandler(typeof(SideAppBar_Button), SizeChangedEvent, new RoutedEventHandler(OnLoad));
        }

        private static void OnLoad(object sender, RoutedEventArgs e)
        {
            var _this = (sender as SideAppBar_Button);

            if (_this.CheckIfHandlerShouldExecute == false)
                return;

            var Button1 = new Button()
            {
                Margin = new Thickness(0, 4, 0, 4),
                Padding = new Thickness(0),
                Width = 32,
                Height = 32,
                HorizontalAlignment = HorizontalAlignment.Center,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center,
                Foreground = _this.FindResource("MaterialDesignPaper") as Brush,
                //Style = _this.FindResource("MaterialDesignFloatingActionDarkButton") as Style,
                Style = _this.FindResource("MaterialDesignRaisedDarkButton") as Style,
                //Background = Brushes.Transparent,
                Content = new PackIcon()
                {
                    Background = Brushes.Transparent,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Width = 24,
                    Height = 24,
                    Kind = PackIconKind.Bug,
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
