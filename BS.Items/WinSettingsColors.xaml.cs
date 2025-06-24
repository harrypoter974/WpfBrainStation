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
    /// Interaction logic for WinSettingsColors.xaml
    /// </summary>
    public partial class WinSettingsColors : Window
    {
        public WinSettingsColors()
        {
            InitializeComponent();
            this.DataContext = new VM.SettingsColorsVM();
        }
        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Threading.Thread.Sleep(300);
            Close();
        }
    }
}
