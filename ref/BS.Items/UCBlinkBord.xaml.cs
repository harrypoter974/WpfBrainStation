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
    /// Interaction logic for UCBlinkBord.xaml
    /// </summary>
    public partial class UCBlinkBord : UserControl
    {        
        private System.Windows.Threading.DispatcherTimer dispatcherTimer;
        public UCBlinkBord()
        {
            InitializeComponent();
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();//אתכול של שעון
            dispatcherTimer.Tick += Timer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 2);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Image1.Visibility = Visibility.Hidden;
            dispatcherTimer.Stop();
        }

        public void StartBLink()
        {
            Image1.Visibility = Visibility.Visible;
            dispatcherTimer.Start();
        }
    }
}
