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
            // Default Values
            /////////////////////////////////////////////////////////////////////////////////
            HeightProperty.OverrideMetadata(typeof(MyComboBox), new FrameworkPropertyMetadata(Convert.ToDouble(48)));
            WidthProperty.OverrideMetadata(typeof(MyComboBox), new FrameworkPropertyMetadata(Convert.ToDouble(128)));
            HorizontalContentAlignmentProperty.OverrideMetadata(typeof(MyComboBox), new FrameworkPropertyMetadata(HorizontalAlignment.Center));
            VerticalContentAlignmentProperty.OverrideMetadata(typeof(MyComboBox), new FrameworkPropertyMetadata(VerticalAlignment.Center));

            /////////////////////////////////////////////////////////////////////////////////
            // Content Support
            /////////////////////////////////////////////////////////////////////////////////
            m_ContentProperty = DependencyProperty.Register("ContentProperty", typeof(object), typeof(MyComboBox), null);
        }

        public object ContentProperty
        {
            get { return GetValue(m_ContentProperty); }
            set { SetValue(m_ContentProperty, value); }
        }

    }
}
