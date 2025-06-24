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

namespace BS.Items
{
    /// <summary>
    /// Interaction logic for UCCheckBox.xaml
    /// </summary>
    public partial class UCCheckBox : UserControl
    {
        public bool IsVisibility = true;
        public UCCheckBox()
        {
            InitializeComponent();
            Label1.Background = new ImageBrush(new BitmapImage(new Uri(
                                System.AppDomain.CurrentDomain.BaseDirectory
                                + @"Resources\BS.Items\UCCheckBoxOn.jpg")));
            ;
        }

        public void Swich()
        {
            Label1.Background = new ImageBrush(new BitmapImage(new Uri(
                                System.AppDomain.CurrentDomain.BaseDirectory
                                + @"Resources\BS.Items\UCCheckBox" + (IsVisibility ? "On" : "Off") +
                                ".jpg")));

        }
    }
}
