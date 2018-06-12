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

namespace WpfApp1.Controls
{
    public class MyComboBox : ComboBox
    {
        public static readonly DependencyProperty m_ContentProperty;

        static MyComboBox()
        {
            /////////////////////////////////////////////////////////////////////////////////
            // Content Support
            m_ContentProperty = DependencyProperty.Register(nameof(Content), typeof(object), typeof(MyComboBox), null);

            /////////////////////////////////////////////////////////////////////////////////
            // EventManager
            EventManager.RegisterClassHandler(typeof(JumpComboBox), LoadedEvent, new RoutedEventHandler(OnLoaded));
        }

        public object Content
        {
            get { return GetValue(m_ContentProperty); }
            set { SetValue(m_ContentProperty, value); }
        }

        private static void OnLoaded(object sender, RoutedEventArgs e)
        {
            var _this = (sender as JumpComboBox);
        }
    }
}
