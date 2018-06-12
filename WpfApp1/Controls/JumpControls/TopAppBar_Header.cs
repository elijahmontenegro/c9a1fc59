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
    public class TopAppBar_Header : Control
    {
        static TopAppBar_Header()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TopAppBar_Header), new FrameworkPropertyMetadata(typeof(TopAppBar_Header)));
        }
    }
}
