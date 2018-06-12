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
    public class Dependant_ComboBox : Control
    {
        static Dependant_ComboBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Dependant_ComboBox), new FrameworkPropertyMetadata(typeof(Dependant_ComboBox)));
        }
    }
}
