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

namespace BS.Items.Properties
{
    /// <summary>
    /// Interaction logic for WinHeSettingsLetters.xaml
    /// </summary>
    public partial class WinHeSettingsLetters : Window
    {
        VM.HeSettingsLettersVM _locig;
        public WinHeSettingsLetters(object name)
        {
            InitializeComponent();
            _locig= new VM.HeSettingsLettersVM(name);
            this.DataContext =_locig; 
        }

        private void labelHome_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (_locig.Have5())
            {
                System.Threading.Thread.Sleep(300);
                Close();
            }
            else
                MessageBox.Show("צריך לבחור לפחות 5 אותיות", "שגיאה", MessageBoxButton.OK, MessageBoxImage.Warning);

        }
    }
}
