using CL.BS.VMCommon;
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

namespace WpfBrainStation
{
    /// <summary>
    /// Interaction logic for WindowBase.xaml
    /// </summary>
    public partial class WindowBase : Window
    {
        public WindowBase()
        {
            InitializeComponent();
            DataContext = new MainVm();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                if (ResizeMode != ResizeMode.NoResize)
                {
                    WindowStyle = WindowStyle.None;
                    WindowState = WindowState.Maximized;
                    ResizeMode = ResizeMode.NoResize;
                }
                else
                {
                    WindowStyle = WindowStyle.SingleBorderWindow;
                    ResizeMode = ResizeMode.CanResize;
                }
            }
        }
        /*     mediaElement.Volume = slider.Value;// 0 < 1;
                         string[] mylist = new string[3];
                    mylist[0] = @"C:\brinStation\no_cam\bordGameA16\WpfComposite\bin\Debug\Resources\Audio\gong.wav";
                    mylist[1] = @"C:\brinStation\no_cam\bordGameA16\WpfComposite\bin\Debug\Resources\Audio\He\Num\n1.wav";
                    mylist[2] = @"C:\brinStation\no_cam\bordGameA16\WpfComposite\bin\Debug\Resources\Audio\He\Num\n2.wav";
                    for (int i = 0; i < mylist.Length; i++)
                    {
                        mediaElement.Source = new Uri(mylist[i]);
                        WaveFileReader reader=new WaveFileReader(mylist[i]);
                        TimeSpan span = reader.TotalTime;
                        int t = 150;// + (int)span.TotalMilliseconds; 
                        Thread.Sleep(1000);
                    }*/
    }
}
