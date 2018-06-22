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
    public class AppBarButton : Button
    {
        bool m_CheckIfHandlerShouldExecute = true;
        public PackIcon m_PackIcon = new PackIcon();

        static AppBarButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AppBarButton), new FrameworkPropertyMetadata(typeof(Button)));
            MarginProperty.OverrideMetadata(typeof(AppBarButton), new FrameworkPropertyMetadata(new Thickness(0)));
            PaddingProperty.OverrideMetadata(typeof(AppBarButton), new FrameworkPropertyMetadata(new Thickness(0)));
            HorizontalAlignmentProperty.OverrideMetadata(typeof(AppBarButton), new FrameworkPropertyMetadata(HorizontalAlignment.Stretch));
            HorizontalContentAlignmentProperty.OverrideMetadata(typeof(AppBarButton), new FrameworkPropertyMetadata(HorizontalAlignment.Stretch));
            VerticalAlignmentProperty.OverrideMetadata(typeof(AppBarButton), new FrameworkPropertyMetadata(VerticalAlignment.Stretch));
            VerticalContentAlignmentProperty.OverrideMetadata(typeof(AppBarButton), new FrameworkPropertyMetadata(VerticalAlignment.Stretch));
            ForegroundProperty.OverrideMetadata(typeof(AppBarButton), new FrameworkPropertyMetadata(Application.Current.MainWindow.FindResource("MaterialDesignPaper") as Brush));
            ClipToBoundsProperty.OverrideMetadata(typeof(AppBarButton), new FrameworkPropertyMetadata(true));

            /// Routed Events:
            EventManager.RegisterClassHandler(typeof(AppBarButton), LoadedEvent, new RoutedEventHandler(OnLoad));

            // Dependency Properties:
            //m_IconProperty = DependencyProperty.Register(nameof(Icon), typeof(PackIconKind), typeof(Icon), new PropertyMetadata(default(PackIconKind)));
        }

        private static void OnLoad(object sender, RoutedEventArgs e)
        {
            var This = (sender as AppBarButton);

            if (This.m_CheckIfHandlerShouldExecute == false)
                return;

            RippleAssist.SetClipToBounds(This, true);
            RippleAssist.SetIsCentered(This, true);
            ShadowAssist.SetShadowDepth(This, ShadowDepth.Depth0);

            This.Content = This.m_PackIcon;
            This.m_CheckIfHandlerShouldExecute = false;
        }
    }
}
