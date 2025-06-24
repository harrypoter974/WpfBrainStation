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
    /// Interaction logic for WinHeVowels.xaml
    /// </summary>
    public partial class WinHeVowels : Window
    {
        VM.HeVowelsVM _logic= new VM.HeVowelsVM();
        public WinHeVowels()
        {            
            InitializeComponent();
            this.DataContext = _logic;
        }
        private void labelHome_MouseDown(object sender, MouseButtonEventArgs e)
        {
           if(_logic.IsMoreThen2())
                Close();
        }
    }
}
