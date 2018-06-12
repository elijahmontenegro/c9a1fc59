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
    public class JumpSideAppBar : Grid
    {
        bool CheckIfHandlerShouldExecute = true;

        public static readonly DependencyProperty m_ContentProperty;

        static JumpSideAppBar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(JumpSideAppBar), new FrameworkPropertyMetadata(typeof(JumpSideAppBar)));
            WidthProperty.OverrideMetadata(typeof(JumpSideAppBar), new FrameworkPropertyMetadata(Convert.ToDouble(48)));
            HorizontalAlignmentProperty.OverrideMetadata(typeof(JumpSideAppBar), new FrameworkPropertyMetadata(HorizontalAlignment.Left));
            VerticalAlignmentProperty.OverrideMetadata(typeof(JumpSideAppBar), new FrameworkPropertyMetadata(VerticalAlignment.Stretch));
            MarginProperty.OverrideMetadata(typeof(JumpSideAppBar), new FrameworkPropertyMetadata(new Thickness(0,40,0,0)));
            EventManager.RegisterClassHandler(typeof(JumpSideAppBar), SizeChangedEvent, new RoutedEventHandler(OnLoaded));
        }


        private static void OnLoaded(object sender, RoutedEventArgs e)
        {
            var _this = (sender as JumpSideAppBar);
            if (_this.CheckIfHandlerShouldExecute == false)
                return;

            StackPanel StackPanel1 = new StackPanel()
            {
                Orientation = Orientation.Vertical,
                Width = _this.ActualWidth,
                Background = Brushes.Transparent,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
            };

            ColorZone ColorZone1 = new ColorZone()
            {
                Mode = ColorZoneMode.PrimaryDark,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                SnapsToDevicePixels = true,
            };

            ShadowAssist.SetShadowEdges(ColorZone1, ShadowEdges.Right);
            ShadowAssist.SetShadowDepth(ColorZone1, ShadowDepth.Depth1);

            foreach (var c in _this.Children.Cast<UIElement>().ToList().AsReadOnly())
            {
                _this.Children.Remove(c);
                StackPanel1.Children.Add(c);
            }

            SetZIndex(ColorZone1, 0);
            SetZIndex(StackPanel1, -1);
            _this.Children.Add(ColorZone1);
            _this.Children.Add(StackPanel1);
            _this.CheckIfHandlerShouldExecute = false;
        }
    }
}