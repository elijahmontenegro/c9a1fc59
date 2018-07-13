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
    public class TopAppBar_Apps
        : Grid
    {
        bool m_CheckIfHandlerShouldExecute = true;

        static TopAppBar_Apps()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TopAppBar_Apps), new FrameworkPropertyMetadata(typeof(TopAppBar_Apps)));
            //Name = "UserAccountButton_Button1",

            /////////////////////////////////////////////////////////////////////////////////
            /// Routed Events:
            /////////////////////////////////////////////////////////////////////////////////
            EventManager.RegisterClassHandler(typeof(TopAppBar_Apps), SizeChangedEvent, new RoutedEventHandler(OnLoad));
        }

        private static void OnLoad(object sender, RoutedEventArgs e)
        {
            var This = (sender as TopAppBar_Apps);

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
                UnfurlOrientation = Orientation.Vertical,
                PlacementMode = PopupBoxPlacementMode.BottomAndAlignRightEdges,
                FlowDirection = FlowDirection.LeftToRight,
                SnapsToDevicePixels = true,
            };

            //EventManager.RegisterClassHandler(typeof(PopupBox), PopupBox.OpenedEvent, new RoutedEventHandler(OnPopupOpened));

            var PackIcon1 = new PackIcon()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Width = 18,
                Height = 18,
                Kind = PackIconKind.Apps,
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
                Padding = new Thickness(96, 9, 96, 9),
                TextAlignment = TextAlignment.Center,
                FontSize = 13,
                Opacity = 0.75f,
                Text = Application.Current.MainWindow.Title == "" ? "Apps" : Application.Current.MainWindow.Title,
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
                    Width = 11,
                    Height = 11,
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
                MinWidth = 96, MinHeight = 192,
                Orientation = Orientation.Horizontal,
                FlowDirection = FlowDirection.LeftToRight,
                //HorizontalContentAlignment = HorizontalAlignment.Left,
                //VerticalContentAlignment = VerticalAlignment.Top,
                Background = Brushes.WhiteSmoke,
            };

            //ListView1.Children.Add(new TextBlock()
            //{
            //    FontSize = 11,
            //    Opacity = 0.75f,
            //    Text = "Nothing to see here!",
            //    //Width = 80, Height = 40,
            //    TextAlignment = TextAlignment.Center,
            //    HorizontalAlignment = HorizontalAlignment.Stretch,
            //    VerticalAlignment = VerticalAlignment.Stretch,
            //    Margin = new Thickness(0, 96, 0, 96),
            //});

            var Button_App1 = new Button()
            {
                Name = "TopAppBar_Apps_App1_Button",
                Style = This.FindResource("MaterialDesignFlatButton") as Style,
                Margin = new Thickness(4),
                Padding = new Thickness(0),
                Width = 48, Height = 48,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Content = new PackIcon()
                {
                    Width = 32, Height = 32,
                    Padding = new Thickness(0),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(0),
                    //Foreground = This.FindResource("MaterialDesignPaper") as Brush,
                    Kind = PackIconKind.Launch,
                },
                ToolTip = "Launch Portal"
            };

            RippleAssist.SetClipToBounds(Button_App1, true);
            RippleAssist.SetIsCentered(Button_App1, true);
            ShadowAssist.SetShadowDepth(Button_App1, ShadowDepth.Depth1);
            ListView1.Children.Add(Button_App1);

            var Button_App0 = new Button()
            {
                Name = "TopAppBar_Apps_App0_Button",
                Style = This.FindResource("MaterialDesignFlatButton") as Style,
                Margin = new Thickness(4),
                Padding = new Thickness(0),
                Width = 48,
                Height = 48,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Content = new PackIcon()
                {
                    Width = 32,
                    Height = 32,
                    Padding = new Thickness(0),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(0),
                    //Foreground = This.FindResource("MaterialDesignPaper") as Brush,
                    Kind = PackIconKind.Home,
                },
                ToolTip = "Home"
            };
            RippleAssist.SetClipToBounds(Button_App0, true);
            RippleAssist.SetIsCentered(Button_App0, true);
            ShadowAssist.SetShadowDepth(Button_App0, ShadowDepth.Depth1);
            ListView1.Children.Add(Button_App0);

            EventManager.RegisterClassHandler(typeof(Button), MouseUpEvent, new RoutedEventHandler(OnAppChangedMouseUp));

            PrimaryStackPanel1.Children.Add(HeaderStackPanel1);
            PrimaryStackPanel1.Children.Add(ListView1);
            PrimaryStackPanel1.Children.Add(Button1);
            // Card End

            PopupBox1.PopupContent = PrimaryStackPanel1;

            // Move PopupBox Attempt
            var part = PopupBox1.PopupContent as FrameworkElement;
            if (part == null)
                Console.WriteLine("part = Null");
            else
            {
                var parent = part.Parent as FrameworkElement;

                if (parent == null)
                    Console.WriteLine("parent = Null");
                else if (parent != null)
                {
                    parent.RenderTransform = new TranslateTransform(100, 0);
                }

                part.ClipToBounds = true;
            }

            // End

            This.Children.Add(PopupBox1);

            /////////////////////////////////////////////////////////////////////////////////
            This.m_CheckIfHandlerShouldExecute = false;
        }

        private static void OnAppChangedMouseUp(object sender, RoutedEventArgs e)
        {
            var This = (sender as Button);


            if (This.Name == "TopAppBar_Apps_App1_Button")
            {
                Application.Current.MainWindow.Content = null;
                if (!Application.Current.MainWindow.HasContent)
                    Application.Current.MainWindow.Content = new AppWindows.LaunchPortal();
            }

            if (This.Name == "TopAppBar_Apps_App0_Button")
            {
                Application.Current.MainWindow.Content = null;
                
                if (!Application.Current.MainWindow.HasContent)
                    Application.Current.MainWindow.Content = new AppWindows.WelcomePortal();
            }
        }

        private static void OnPopupOpened(object sender, RoutedEventArgs e)
        {
            var This = (sender as PopupBox);

            if (This.Name != "TopAppBar_Notifications_PopupBox1")
                return;

            //var container = VisualTreeHelper.GetParent(This.PopupContent as UIElement ) as UIElement;

            //container.SetValue(BackgroundProperty, Brushes.Red);
        }
    }
}
