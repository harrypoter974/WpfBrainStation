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
    /// Interaction logic for WinEnSettingsLetters.xaml
    /// </summary>
    public partial class WinEnSettingsLetters : Window
    {
        VM.EnSettingsLettersVM _logic= new VM.EnSettingsLettersVM();
        public WinEnSettingsLetters()
        {
            InitializeComponent();
            //this.Top = System.Windows.SystemParameters.PrimaryScreenHeight * 0.02;
            //this.Left = System.Windows.SystemParameters.PrimaryScreenWidth * 0.35;
            this.DataContext = _logic;
        }

        private void labelHome_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (_logic.Have5())
            {
                System.Threading.Thread.Sleep(300);
                Close();
            }
            else
                MessageBox.Show("צריך לבחור לפחות 5 אותיות", "שגיאה", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public object IsBig()
        {
           return true ;
        }
    }
}
