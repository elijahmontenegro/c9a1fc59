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
                Name = "Button1",
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
                    Width = 17,
                    Height = 17,
                    Kind = PackIconKind.Menu,
                    Foreground = _this.FindResource("MaterialDesignPaper") as Brush,
                },
            };

            EventManager.RegisterClassHandler(typeof(Button), MouseDownEvent, new RoutedEventHandler(Button_OnMouseDown));

            RippleAssist.SetIsCentered(Button1, true);
            RippleAssist.SetClipToBounds(Button1, true);
            RippleAssist.SetIsDisabled(Button1, true);
            ShadowAssist.SetShadowDepth(Button1, ShadowDepth.Depth0);

            _this.Children.Add(Button1);

            _this.m_CheckIfHandlerShouldExecute = false;
        }

        private void Story_CompletedCollapsed(object sender, EventArgs e)
        {
            var _this = (sender as SideAppBar);
            _this.Visibility = Visibility.Collapsed;
        }

        private static void Button_OnMouseDown(object sender, RoutedEventArgs e)
        {
            var _this = (sender as Button);
            if (_this.Name != "Button1")
                return;
            var _parent = (_this.Parent as TopAppBar_Navigation);
            var SideAppBar1 = UIHelpers.FindChild<SideAppBar>("SideAppBar1");
            if (SideAppBar1 == null)
                return;
            if (SideAppBar1.Visibility == Visibility.Visible)
            {
                var fDuration = 0.2f;
                var fade = new DoubleAnimation() {
                    From = 1,
                    To = 0,
                    Duration = TimeSpan.FromSeconds(fDuration),
                };
                
                Storyboard.SetTarget(fade, SideAppBar1);
                Storyboard.SetTargetProperty(fade, new PropertyPath(Button.OpacityProperty));

                var sb = new Storyboard();
                sb.Children.Add(fade);

                sb.Completed += (s, a) =>
                {
                    SideAppBar1.Visibility = Visibility.Collapsed;
                };

                sb.Begin();
                
                double newX = -40;
                Vector offset = VisualTreeHelper.GetOffset(SideAppBar1);
                var top = offset.Y;
                var left = offset.X;
                TranslateTransform trans = new TranslateTransform();
                SideAppBar1.RenderTransform = trans;
                DoubleAnimation anim2 = new DoubleAnimation(0, newX - left, TimeSpan.FromSeconds(fDuration));
                trans.BeginAnimation(TranslateTransform.XProperty, anim2);
            }

            else 
            if(SideAppBar1.Visibility != Visibility.Visible)
            {
                var fDuration = 0.2f;
                var fade = new DoubleAnimation()
                {
                    From = 0,
                    To = 1,
                    Duration = TimeSpan.FromSeconds(fDuration),
                };

                Storyboard.SetTarget(fade, SideAppBar1);
                Storyboard.SetTargetProperty(fade, new PropertyPath(Button.OpacityProperty));

                var sb = new Storyboard();
                sb.Children.Add(fade);

                sb.Begin();

                SideAppBar1.Visibility = Visibility.Visible;

                double newX = 0;
                Vector offset = VisualTreeHelper.GetOffset(SideAppBar1);
                var top = offset.Y;
                var left = offset.X;
                TranslateTransform trans = new TranslateTransform();
                SideAppBar1.RenderTransform = trans;
                DoubleAnimation anim2 = new DoubleAnimation(-40, newX - left, TimeSpan.FromSeconds(fDuration));
                trans.BeginAnimation(TranslateTransform.XProperty, anim2);
            }
        }
    }
}
