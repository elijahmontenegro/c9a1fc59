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
    public class Ordained_SearchBox : Control
    {
        static Ordained_SearchBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Ordained_SearchBox), new FrameworkPropertyMetadata(typeof(Ordained_SearchBox)));
        }
    }
}
