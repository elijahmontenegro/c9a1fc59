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
    public class SideAppBar 
        : AppBar
    {
        bool CheckIfHandlerShouldExecute = true;

        static SideAppBar()
        {
            NameProperty
                .OverrideMetadata(typeof(SideAppBar), new FrameworkPropertyMetadata("SideAppBar1"));
            DefaultStyleKeyProperty
                .OverrideMetadata(typeof(SideAppBar), new FrameworkPropertyMetadata(typeof(SideAppBar)));
            WidthProperty
                .OverrideMetadata(typeof(SideAppBar), new FrameworkPropertyMetadata(Convert.ToDouble(48)));
            HorizontalAlignmentProperty
                .OverrideMetadata(typeof(SideAppBar), new FrameworkPropertyMetadata(HorizontalAlignment.Left));
            VerticalAlignmentProperty
                .OverrideMetadata(typeof(SideAppBar), new FrameworkPropertyMetadata(VerticalAlignment.Stretch));
            MarginProperty
                .OverrideMetadata(typeof(SideAppBar), new FrameworkPropertyMetadata(new Thickness(0, 40, 0, 0)));

            /////////////////////////////////////////////////////////////////////////////////
            /// Routed Events:
            /////////////////////////////////////////////////////////////////////////////////
            EventManager.RegisterClassHandler(typeof(SideAppBar), SizeChangedEvent, new RoutedEventHandler(OnLoaded));

        }

        private static void OnLoaded(object sender, RoutedEventArgs e)
        {
            var _this = (sender as SideAppBar);

            if (_this.CheckIfHandlerShouldExecute == false)
                return;

            _this.m_StackPanel1 = new StackPanel() {
                Margin = new Thickness(0, 0, 0, 0),
                Orientation = Orientation.Vertical,
                Width = _this.ActualWidth,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Stretch,
                Background = Brushes.Transparent,
            };

            _this.m_ColorZone1 = new ColorZone() {
                Mode = ColorZoneMode.PrimaryDark,
                Width = _this.ActualWidth,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Stretch,
                SnapsToDevicePixels = true,
            };

            ShadowAssist.SetShadowEdges(_this.m_ColorZone1, ShadowEdges.Right);
            ShadowAssist.SetShadowDepth(_this.m_ColorZone1, ShadowDepth.Depth0);

            SetZIndex(_this.m_ColorZone1, 0);
            SetZIndex(_this.m_StackPanel1, 0);

            foreach (var c in _this.Children.Cast<UIElement>().ToList().AsReadOnly())
            {
                _this.Children.Remove(c);
                _this.m_StackPanel1.Children.Add(c);
            }

            _this.Children.Add(_this.m_ColorZone1);
            _this.Children.Add(_this.m_StackPanel1);

            _this.StartAnimExpand();

            _this.CheckIfHandlerShouldExecute = false;
        }

        public void StartAnimExpand()
        {
            var fade = new DoubleAnimation()
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.33333333333333333333333333333333f),
            };

            Storyboard.SetTarget(fade, this);
            Storyboard.SetTargetProperty(fade, new PropertyPath(OpacityProperty));

            var storyboard = new Storyboard();
                storyboard.Children.Add(fade);

            storyboard.Begin();
            storyboard.Completed += (s, a) =>
            {
               Visibility = Visibility.Visible;
            };

            double newX = 0;
            Vector offset = VisualTreeHelper.GetOffset(this);
            var top = offset.Y;
            var left = offset.X;

            TranslateTransform trans = new TranslateTransform();
            this.RenderTransform = trans;
            DoubleAnimation anim2 = new DoubleAnimation(-40, newX - left, TimeSpan.FromSeconds(0.33333333333333333333333333333333f));
            trans.BeginAnimation(TranslateTransform.XProperty, anim2);
        }

        public void StartAnimCollapse()
        {
            var fade = new DoubleAnimation()
            {
                From = 1,
                To = 0,
                Duration = TimeSpan.FromSeconds(0.33333333333333333333333333333333f),
            };

            Storyboard.SetTarget(fade, this);
            Storyboard.SetTargetProperty(fade, new PropertyPath(Button.OpacityProperty));

            var storyboard = new Storyboard();
                storyboard.Children.Add(fade);

            storyboard.Begin();
            storyboard.Completed += (s, a) =>
            {
                Visibility = Visibility.Collapsed;
            };

            double newX = -40;
            Vector offset = VisualTreeHelper.GetOffset(this);
            var top = offset.Y;
            var left = offset.X;

            TranslateTransform trans = new TranslateTransform();
            this.RenderTransform = trans;
            DoubleAnimation anim2 = new DoubleAnimation(0, newX - left, TimeSpan.FromSeconds(0.33333333333333333333333333333333f));
            trans.BeginAnimation(TranslateTransform.XProperty, anim2);
        }

        public static void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            var SideAppBar = UIHelpers.FindChild<SideAppBar>("SideAppBar1");
            if (SideAppBar == null)
                return;

            if (SideAppBar.Opacity == 0.0f)
            {
                SideAppBar.StartAnimExpand();
            }
            else if (SideAppBar.Opacity == 1.0f)
            {
                SideAppBar.StartAnimCollapse();
            }
        }
    }
}