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
    public class JumpTopAppBar
        : Grid
    {
        bool CheckIfHandlerShouldExecute = true;

        static JumpTopAppBar()
        {
            DefaultStyleKeyProperty
                .OverrideMetadata(typeof(JumpTopAppBar), new FrameworkPropertyMetadata(typeof(JumpTopAppBar)));
            BackgroundProperty
                .OverrideMetadata(typeof(JumpTopAppBar), new FrameworkPropertyMetadata(Brushes.Transparent));
            HeightProperty
                .OverrideMetadata(typeof(JumpTopAppBar), new FrameworkPropertyMetadata(Convert.ToDouble(40)));
            HorizontalAlignmentProperty
                .OverrideMetadata(typeof(JumpTopAppBar), new FrameworkPropertyMetadata(HorizontalAlignment.Stretch));
            VerticalAlignmentProperty
                .OverrideMetadata(typeof(JumpTopAppBar), new FrameworkPropertyMetadata(VerticalAlignment.Top));

            /////////////////////////////////////////////////////////////////////////////////
            /// Routed Events:
            /////////////////////////////////////////////////////////////////////////////////
            EventManager.RegisterClassHandler(typeof(JumpTopAppBar), SizeChangedEvent, new RoutedEventHandler(OnLoaded));
        }

        private static void OnLoaded(object sender, RoutedEventArgs e)
        {
            var _this = (sender as JumpTopAppBar);
            if (_this.CheckIfHandlerShouldExecute == false)
                return;

            StackPanel StackPanel1 = new StackPanel()
            {
                Margin = new Thickness(0, 4, 0, 4),
                Orientation = Orientation.Horizontal,
                Height = _this.ActualHeight,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Center,
                Background = Brushes.Transparent,
            };

            ColorZone ColorZone1 = new ColorZone()
            {
                Mode = ColorZoneMode.PrimaryMid,
                Height = _this.ActualHeight,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Center,
                SnapsToDevicePixels = true,
                Background = Brushes.Transparent,
            };

            foreach (var c in _this.Children.Cast<UIElement>().ToList().AsReadOnly())
            {
                _this.Children.Remove(c);
                StackPanel1.Children.Add(c);
            }

            SetZIndex(ColorZone1, 0);
            SetZIndex(StackPanel1, 0);
            _this.Children.Add(ColorZone1);
            _this.Children.Add(StackPanel1);

            ShadowAssist.SetShadowDepth(ColorZone1, ShadowDepth.Depth1);

            //foreach (var c in _this.Children.Cast<UIElement>().ToList().AsReadOnly())
            //{
            //    _this.Children.Remove(c);
            //    StackPanel1.Children.Add(c);
            //}

            ////Button Button1 = new Button()
            ////{
            ////    Margin = new Thickness(6, 0, 2, 0),
            ////    Padding = new Thickness(0),
            ////    Width = 24,
            ////    Height = 24,
            ////    HorizontalAlignment = HorizontalAlignment.Center,
            ////    HorizontalContentAlignment = HorizontalAlignment.Center,
            ////    VerticalAlignment = VerticalAlignment.Center,
            ////    VerticalContentAlignment = VerticalAlignment.Center,
            ////    Style = _this.FindResource("MaterialDesignFloatingActionButton") as Style,
            ////    Foreground = _this.FindResource("MaterialDesignPaper") as Brush,
            ////    //Style = _this.FindResource("MaterialDesignRaisedDarkButton") as Style,
            ////    //Background = Brushes.Transparent,
            ////};

            ////RippleAssist.SetIsCentered(Button1, true);
            ////ShadowAssist.SetShadowDepth(Button1, ShadowDepth.Depth0);

            ////var PackIcon1 = new PackIcon()
            ////{
            ////    HorizontalAlignment = HorizontalAlignment.Center,
            ////    VerticalAlignment = VerticalAlignment.Center,
            ////    Width = 16,
            ////    Height = 16,
            ////    Kind = PackIconKind.Menu,
            ////    Foreground = _this.FindResource("MaterialDesignPaper") as Brush,
            ////};

            ////Button1.Content = PackIcon1;

            ////var TextBlock1 = new TextBlock()
            ////{
            ////    Margin = new Thickness(2, 0, 7, 0),
            ////    //Height = Convert.ToDouble(_this.ActualHeight),
            ////    HorizontalAlignment = HorizontalAlignment.Center,
            ////    VerticalAlignment = VerticalAlignment.Center,
            ////    Text = "Placeholder",
            ////    FontFamily = new FontFamily("Roboto"),
            ////    FontSize = 13,
            ////    //Background = Brushes.Yellow,
            ////    Foreground = _this.FindResource("MaterialDesignPaper") as Brush,
            ////};

            ////StackPanel1.Children.Insert(0, TextBlock1);
            ////StackPanel1.Children.Insert(0, Button1);

            //SetZIndex(ColorZone1, -1);
            //SetZIndex(StackPanel1, 0);

            ////_this.Children.Add(ColorZone1);
            //_this.Children.Add(StackPanel1);

            _this.CheckIfHandlerShouldExecute = false;
        }
    }
}