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
using System.Globalization;
using System.Windows.Markup;

namespace WpfApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}

namespace WpfApplication.Converters
{
        public class PercentageConverter : MarkupExtension, IValueConverter
        {
            private static PercentageConverter _instance;

            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return System.Convert.ToDouble(value) * System.Convert.ToDouble(parameter);
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }

            public override object ProvideValue(IServiceProvider serviceProvider)
            {
                return _instance ?? (_instance = new PercentageConverter());
            }
        }
}
