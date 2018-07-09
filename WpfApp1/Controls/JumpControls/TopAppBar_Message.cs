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
    public class TopAppBar_Message 
        : Grid
    {
        bool m_CheckIfHandlerShouldExecute = true;

        static TopAppBar_Message()
       {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TopAppBar_Message), new FrameworkPropertyMetadata(typeof(TopAppBar_Message)));
            //Name = "UserAccountButton_Button1",

            /////////////////////////////////////////////////////////////////////////////////
            /// Routed Events:
            /////////////////////////////////////////////////////////////////////////////////
            EventManager.RegisterClassHandler(typeof(TopAppBar_Message), SizeChangedEvent, new RoutedEventHandler(OnLoad));
        }

        private static void OnLoad(object sender, RoutedEventArgs e)
        {
            var This = (sender as TopAppBar_Message);

            if (This.m_CheckIfHandlerShouldExecute == false)
                return;

            /////////////////////////////////////////////////////////////////////////////////

            // PopupBox Button
            var PopupBox1 = new PopupBox()
            {
                Name = "TopAppBar_Notifications_PopupBox1",
                //Style = _this.FindResource("MaterialDesignToolPopupBox") as Style,
                //Width = 32, Height = 32,
                ClipToBounds = true,
                StaysOpen = true,
                Margin = new Thickness(0),
                Padding = new Thickness(0),
                HorizontalAlignment = HorizontalAlignment.Stretch,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Stretch,
                VerticalContentAlignment = VerticalAlignment.Center,
                Foreground = This.FindResource("MaterialDesignPaper") as Brush,
                PopupMode = PopupBoxPopupMode.Click,
                UnfurlOrientation = Orientation.Horizontal,
                PlacementMode = PopupBoxPlacementMode.BottomAndAlignRightEdges,
                FlowDirection = FlowDirection.LeftToRight,
                UseLayoutRounding = true,
            };

            EventManager.RegisterClassHandler(typeof(PopupBox), PopupBox.OpenedEvent, new RoutedEventHandler(OnMouseDown));

            var PackIcon1 = new PackIcon()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Width = 18,
                Height = 18,
                Kind = PackIconKind.MessageProcessing,
                Foreground = This.FindResource("MaterialDesignPaper") as Brush,
            }; PopupBox1.ToggleContent = PackIcon1;
            
            ShadowAssist.SetShadowDepth(PopupBox1, ShadowDepth.Depth0);
            RippleAssist.SetRippleSizeMultiplier(PopupBox1, 0.5f);
            RippleAssist.SetClipToBounds(PopupBox1, false);
            RippleAssist.SetIsCentered(PopupBox1, true);
            RippleAssist.SetIsDisabled(PopupBox1, true);

            // PopupBox Button End

            // Card
            var PrimaryStackPanel1 = new StackPanel()
            {
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                Orientation = Orientation.Vertical,
            };

            var HeaderStackPanel1 = new StackPanel()
            {
                HorizontalAlignment = HorizontalAlignment.Stretch,
                Orientation = Orientation.Vertical,
                Background = Brushes.WhiteSmoke,
            };

            var TextBlock1 = new TextBlock()
            {
                FontFamily = new FontFamily("Roboto"),
                Padding = new Thickness(96,9,96,9),
                TextAlignment = TextAlignment.Center,
                FontSize = 13,
                Opacity = 0.75f,
                Text = Application.Current.MainWindow.Title == "" ? "Messages" : Application.Current.MainWindow.Title,
                //Background = Brushes.Purple,
            };

            HeaderStackPanel1.Children.Add(TextBlock1);

            var Button1 = new Button()
            {
                Style = This.FindResource("MaterialDesignToolButton") as Style,
                Height = 16,
                Content = new PackIcon()
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Width = 11, Height = 11,
                    Kind = PackIconKind.ArrowCollapseDown,
                    Margin = new Thickness(0, 0, 0, 0),
                    Padding = new Thickness(0, 0, 0, 0),
                },
                Padding = new Thickness(0, 0, 0, 0),
                Margin = new Thickness(0, 0, 0, 0),
                Background = Brushes.Gainsboro,
            };

            ShadowAssist.SetShadowEdges(Button1.Content as PackIcon, ShadowEdges.Top);
            ShadowAssist.SetShadowDepth(Button1, ShadowDepth.Depth1);
            ShadowAssist.SetShadowEdges(Button1, ShadowEdges.Top);
            ShadowAssist.SetShadowDepth(Button1, ShadowDepth.Depth1);
            RippleAssist.SetIsDisabled(Button1, false);
            RippleAssist.SetIsCentered(Button1, true);
            RippleAssist.SetClipToBounds(Button1, true);
            RippleAssist.SetRippleSizeMultiplier(Button1, 12.0f);

            var ListView1 = new StackPanel()
            {
                Orientation = Orientation.Vertical,
                Background = Brushes.WhiteSmoke,
            };

            ListView1.Children.Add(new TextBlock()
            {
                FontSize = 11,
                Opacity = 0.75f,
                Text = "All caught up!",
                //Width = 80, Height = 40,
                TextAlignment = TextAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                Margin = new Thickness(0, 96, 0, 96),
            });

            ShadowAssist.SetShadowEdges(ListView1, ShadowEdges.Bottom);
            ShadowAssist.SetShadowDepth(ListView1, ShadowDepth.Depth1);
            ShadowAssist.SetDarken(ListView1, true);

            PrimaryStackPanel1.Children.Add(HeaderStackPanel1);
            PrimaryStackPanel1.Children.Add(ListView1);
            PrimaryStackPanel1.Children.Add(Button1);
            // Card End

            PopupBox1.PopupContent = PrimaryStackPanel1;

            This.Children.Add(PopupBox1);

            /////////////////////////////////////////////////////////////////////////////////
            This.m_CheckIfHandlerShouldExecute = false;
        }

        private static void OnMouseDown(object sender, RoutedEventArgs e)
        {
            var This = (sender as PopupBox);

            if (This.Name != "TopAppBar_Notifications_PopupBox1")
                return;

            var PrimaryStackPanel1 = This.PopupContent as StackPanel;

            var ListView1 = PrimaryStackPanel1.Children[1] as StackPanel;


        }
    }
}
