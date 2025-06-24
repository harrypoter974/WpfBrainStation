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
    /// Interaction logic for UCSpeaker.xaml
    /// </summary>
    public partial class UCSpeaker : UserControl
    {
        public UCSpeaker()
        {
            InitializeComponent();
        }
        private bool SoundOn = true;
        private void bord_Loaded(object sender, RoutedEventArgs e)
        {
            string myUrl = System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\BS.Items\spiker" + (SoundOn ? string.Empty : "X") + ".png";
            Background = new ImageBrush(new BitmapImage(new Uri(myUrl)));
        }

        private void bord_MouseDown(object sender, MouseButtonEventArgs e)
        {
           // DataAudioManager.GetInstans().SetSoundOn(!AudioManager.SoundOn);
            string myUrl = System.AppDomain.CurrentDomain.BaseDirectory +
           @"Resources\BS.Items\spiker" + (SoundOn ? string.Empty : "X") + ".png";
            Background = new ImageBrush(new BitmapImage(new Uri(myUrl)));
        }
    }
}
