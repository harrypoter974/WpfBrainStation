using CL.BS.Common;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace BS.Items
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class WinSpeaker1 : Window
    {
        public WinSpeaker1(bool isBlue)
        {
            InitializeComponent();
            //if (isBlue)
            //{
            //    this.Top = 1000;
            //    this.Left = 1000;
            //} else
            {
            this.Top = 10;
            this.Left = 50;
            }
            label1.Background = new ImageBrush(new BitmapImage(new Uri(
                System.AppDomain.CurrentDomain.BaseDirectory
                + @"Resources\BS.Items\spiker" + ( StaticVar.inline.IsPlay ? "" : "X") + ".png")));
            sliderVolume.Value =StaticVar.inline.Volume;
        }

        private void labelColse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void label1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            StaticVar.inline.IsPlay =!StaticVar.inline.IsPlay;
           label1.Background= new ImageBrush(new BitmapImage(new Uri(
               System.AppDomain.CurrentDomain.BaseDirectory
               + @"Resources\BS.Items\spiker" + ( StaticVar.inline.IsPlay ? "" : "X") + ".png")));
            StaticVar.inline.Volume = 0.0;
            sliderVolume.Value = 0.0;
        }

        private void sliderVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (StaticVar.inline.Volume <= 0.0)
            {
                label1.Background = new ImageBrush(new BitmapImage(new Uri(
          System.AppDomain.CurrentDomain.BaseDirectory  + @"Resources\BS.Items\spikerX.png")));
            }
            else
            {
                StaticVar.inline.IsPlay = true;
                label1.Background = new ImageBrush(new BitmapImage(new Uri(
          System.AppDomain.CurrentDomain.BaseDirectory
          + @"Resources\BS.Items\spiker.png")));
            }
            StaticVar.inline.Volume = sliderVolume.Value;
        }
    }
}
