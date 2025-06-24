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
using System.Windows.Shapes;

namespace BS.Items
{
    /// <summary>
    /// Interaction logic for WinHelp.xaml
    /// </summary>
    public partial class WinHelp : Window
    {
        public WinHelp(object page)
        {
            InitializeComponent();
            string myUrl = 
                System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\Instructions\" + page+".jpg";
            Background = new ImageBrush(new BitmapImage(new Uri(myUrl)));
        }

        private void labelClose_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
    }
}
