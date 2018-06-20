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
            //BackgroundProperty.OverrideMetadata(typeof(TopAppBar_UserAccountButton), new FrameworkPropertyMetadata(Brushes.Red));
            WidthProperty.OverrideMetadata(typeof(TopAppBar_UserAccountButton), new FrameworkPropertyMetadata(Convert.ToDouble(32)));
            HeightProperty.OverrideMetadata(typeof(TopAppBar_UserAccountButton), new FrameworkPropertyMetadata(Convert.ToDouble(32)));
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

            var PopupBox1 = new PopupBox()
            {
               //Style = _this.FindResource("MaterialDesignToolPopupBox") as Style,
               ClipToBounds = false,
               StaysOpen = true,
               Name = "UserAccountButton_Button1",
               Margin = new Thickness(0),
               Padding = new Thickness(0),
               HorizontalAlignment = HorizontalAlignment.Stretch,
               HorizontalContentAlignment = HorizontalAlignment.Center,
               VerticalAlignment = VerticalAlignment.Stretch,
               VerticalContentAlignment = VerticalAlignment.Center,
               Foreground = _this.FindResource("MaterialDesignPaper") as Brush,
               PopupMode = PopupBoxPopupMode.Click,
               UnfurlOrientation = Orientation.Horizontal,
               PlacementMode = PopupBoxPlacementMode.BottomAndAlignRightEdges,
               FlowDirection = FlowDirection.LeftToRight,
            };

            //EventManager.RegisterClassHandler(typeof(Button), MouseDownEvent, new RoutedEventHandler(Button_OnMouseDown));

            var PackIcon1 = new PackIcon()
            {
               HorizontalAlignment = HorizontalAlignment.Center,
               VerticalAlignment = VerticalAlignment.Center,
               Width = 20,
               Height = 20,
               Kind = PackIconKind.AccountBox,
               Foreground = _this.FindResource("MaterialDesignPaper") as Brush,
            }; PopupBox1.ToggleContent = PackIcon1;

            var Card1 = new Card()
            {
               Width = 256,
               Height = 256,
               Background = _this.FindResource("MaterialDesignPaper") as Brush,
            }; PopupBox1.PopupContent = Card1;
            
            ShadowAssist.SetShadowDepth(PopupBox1.PopupContent as UIElement, ShadowDepth.Depth0);
            ShadowAssist.SetShadowDepth(Card1, ShadowDepth.Depth0);
            ShadowAssist.SetShadowDepth(PopupBox1, ShadowDepth.Depth0);
            RippleAssist.SetRippleSizeMultiplier(PopupBox1, 0.5f);
            RippleAssist.SetClipToBounds(PopupBox1, false);
            RippleAssist.SetIsCentered(PopupBox1, true);
            RippleAssist.SetIsDisabled(PopupBox1, true);

            var Grid1 = new Grid();
            RowDefinition r2 = new RowDefinition();
            RowDefinition r1 = new RowDefinition();
            r1.Height = new GridLength(64, GridUnitType.Pixel);
            Grid1.RowDefinitions.Add(r1);
            var TextBlock1 = new TextBlock()
            {
                Padding = new Thickness(16),
                TextAlignment = TextAlignment.Left,
                FontSize = 12,
                Text = "Place Holder",
                Background = Brushes.WhiteSmoke,
            };
            var TextBlock2 = new TextBlock()
            {
                Text = "Text2",
                Background = Brushes.Green,
            };
            TextBlock1.SetValue(Grid.RowProperty, 0);
            TextBlock2.SetValue(Grid.RowProperty, 1);
            Grid1.Children.Add(TextBlock1);
           // Grid1.Children.Add(TextBlock2);

            //Grid.SetRow(uc, TheGrid.RowDefinitions.Count - 1);
            Card1.Content = Grid1;

            _this.Children.Add(PopupBox1);

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
