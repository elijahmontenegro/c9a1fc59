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
using MaterialDesignThemes.Wpf;

namespace WpfApp1.Controls
{
    public class TopAppBar_UserAccountButton
        : Grid
    {
        bool m_CheckIfHandlerShouldExecute = true;

        static TopAppBar_UserAccountButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TopAppBar_UserAccountButton), new FrameworkPropertyMetadata(typeof(TopAppBar_UserAccountButton)));

            /////////////////////////////////////////////////////////////////////////////////
            /// Routed Events:
            /////////////////////////////////////////////////////////////////////////////////
            EventManager.RegisterClassHandler(typeof(TopAppBar_UserAccountButton), SizeChangedEvent, new RoutedEventHandler(OnLoad));
        }

        private static void OnLoad(object sender, RoutedEventArgs e)
        {
            var _this = (sender as TopAppBar_UserAccountButton);

            if (_this.m_CheckIfHandlerShouldExecute == false)
                return;

            var Button1 = new PopupBox()
            {
                Name = "UserAccountButton_Button1",
                Margin = new Thickness(0),
                Padding = new Thickness(0),
                HorizontalAlignment = HorizontalAlignment.Stretch,
                HorizontalContentAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                VerticalContentAlignment = VerticalAlignment.Stretch,
                Foreground = _this.FindResource("MaterialDesignPaper") as Brush,
                //Background = Brushes.Transparent,
            };

            EventManager.RegisterClassHandler(typeof(Button), MouseDownEvent, new RoutedEventHandler(Button_OnMouseDown));

            var PackIcon1 = new PackIcon()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Width = 20,
                Height = 20,
                Kind = PackIconKind.Account,
                Foreground = _this.FindResource("MaterialDesignPaper") as Brush,
            };

            Button1.ToggleContent = PackIcon1;

            var Card1 = new Card()
            {
                Width = 192,
                Height = 128,
                IsEnabled = true,
                Visibility = Visibility.Visible,
            };
            Button1.PopupContent = Card1;

            RippleAssist.SetClipToBounds(PackIcon1, true);
            RippleAssist.SetClipToBounds(_this, true);
            RippleAssist.SetClipToBounds(Button1, true);
            RippleAssist.SetRippleSizeMultiplier(_this, 0.875f);
            RippleAssist.SetRippleSizeMultiplier(PackIcon1, 0.875f);
            RippleAssist.SetRippleSizeMultiplier(Button1, 0.875f);
            RippleAssist.SetIsCentered(Button1, true);
            ShadowAssist.SetShadowDepth(Button1, ShadowDepth.Depth0);

            _this.Children.Add(Button1);

            _this.m_CheckIfHandlerShouldExecute = false;
        }

        private static void Button_OnMouseDown(object sender, RoutedEventArgs e)
        {
            var _this = (sender as Button);

            if (_this.Name != "UserAccountButton_Button1")
                return;

        }
    }
}
