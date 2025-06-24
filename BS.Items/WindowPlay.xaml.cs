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
    /// Interaction logic for WindowPlay.xaml
    /// </summary>
    public partial class WindowPlay : Window
    {
        private string _film;
        public WindowPlay(string film)
        {
            _film = film;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            mediaElement.Source =new Uri(String.Format(@"{0}\Resources\Audio\{1}.mp4"
, System.AppDomain.CurrentDomain.BaseDirectory,_film=="0"? "He" : "HeOld"));
            mediaElement.Play();
        }

        private void mediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            Close();
        }

        //private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        //{ MouseDown="Window_MouseDown"
        //    if (ResizeMode == ResizeMode.NoResize)
        //    {
        //        ResizeMode = ResizeMode.CanResize;
        //        WindowStyle = WindowStyle.ThreeDBorderWindow;
        //    }
        //    else
        //    {
        //        ResizeMode = ResizeMode.NoResize;
        //        WindowStyle = WindowStyle.None;
        //    }

        //}
    }
}
