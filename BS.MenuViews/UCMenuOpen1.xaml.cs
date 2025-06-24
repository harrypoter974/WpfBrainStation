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

namespace BS.MenuViews
{
    /// <summary>
    /// Key.Escape
    /// Interaction logic for UCMenuOpen1.xaml
    /// </summary>
    public partial class UCMenuOpen1 : UserControl
    {
        public UCMenuOpen1()
        {
            InitializeComponent();
        }
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);
        private void Ellipse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            keybd_event((byte)System.Windows.Forms.Keys.Escape, 0, 0, 0);
        }
    }
}
