using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BS.Items
{
    /// <summary>
    /// Interaction logic for WinLook.xaml
    /// </summary>
    public partial class WinLook : Window
    {
        public WinLook(ref bool OpenLook)
        {
            InitializeComponent();
            Logic = new VM.WinLookVM(ref OpenLook);
            this.DataContext = Logic;
            this.Top = System.Windows.SystemParameters.PrimaryScreenHeight * 0.07;
            this.Left = System.Windows.SystemParameters.PrimaryScreenWidth * 0.03;
        }
        VM.WinLookVM Logic;
        private void Close_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        public bool GetState()
        {
       return     this.Logic.GetState();
        }
    }
}
