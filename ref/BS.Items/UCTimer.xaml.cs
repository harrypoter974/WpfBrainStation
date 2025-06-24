using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BS.Items
{
    /// <summary>
    /// Interaction logic for UCTimer.xaml
    /// </summary>
    public partial class UCTimer : UserControl
    {
        private int Tick;
       // private InterfaceGame interfaceGame;
        private System.Windows.Threading.DispatcherTimer dispatcherTimer;
        private DateTime dt;
        public UCTimer()
        {
            InitializeComponent();
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();//אתכול של שעון
            dispatcherTimer.Tick += Timer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 25);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (dt.AddMilliseconds(250) < DateTime.Now)
            {
                dt = DateTime.Now;
                if (Tick > -4)
                {
                    Tick--;
                    if (Tick == 0) // http://freesound.org/browse/
                    {
                      //  interfaceGame.Timer_Tick();
                        new Thread(new ThreadStart(() =>
                        {
                           // logic.AudioManager.Play(@"Resources\Audio\gong.wav");
                        })).Start();
                    }

                    if (Tick >= 0)
                        TBTime.Text = (Tick / 4).ToString();
                    else
                        Visibility = Tick % 2 == 0 ? Visibility.Hidden : Visibility.Visible;

                }
                else
                {
                    Visibility = Visibility.Visible;
                    dispatcherTimer.Stop();
                }
            }
        }


        internal void Stop()
        {
            TBTime.Text = string.Empty;
            dispatcherTimer.Stop();
        }
        public bool isNotRun()
        {
            return Tick <= 0;
        }
    }
}