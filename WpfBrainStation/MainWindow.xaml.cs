using BS.Items;
using CL.BS.Common;
using CL.BS.EnglishVM.Notions;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfBrainStation
{
    /// <summary>
    ///  This is a little page that open's in the beginning
    ///  https://www.youtube.com/watch?v=Y4nF1sL16Es
    ///  https://appuals.com/how-to-disable-task-view-on-windows-10/
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _openGame = true;
        OpenVM _vm; 
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Mv_StraightWindow(object sender, EventArgs e)
        {
            WindowState = WindowState.Normal;
            WindowStyle = WindowStyle.None;
            ResizeMode = ResizeMode.NoResize;
            WindowState = WindowState.Maximized;
            this.Top = this.Left = 0;
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.E)
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            _vm = new OpenVM(this);
            DataContext = _vm;
            CL.BS.VMCommon.GameHandler.GetIntense();
            this.MinHeight = this.ActualHeight;
            this.MinWidth = this.ActualWidth;
            VolumeUp();
            this.Cursor = Cursors.Arrow;
        }

        private void VolumeUp()
        {
            //  pbStatus.Visibility = Visibility.Visible;
            new Thread(new ThreadStart(() =>
            {
                for (int i = 0; i < 50; i++)
            {
                keybd_event((byte)System.Windows.Forms.Keys.VolumeUp, 0, 0, 0);
                Thread.Sleep(10);
                }
            })).Start();
        }
    }
}
