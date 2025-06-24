using CL.BS.Database;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace WpfBrainStation
{
    /// <summary>
    ///This is the main page all the views appear on it.
    /// </summary>
    public partial class WindowBase : Window
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);
        System.Windows.Threading.DispatcherTimer _dispatcherTimer = new System.Windows.Threading.DispatcherTimer();

        public WindowBase()
        {
            try
            {
                MainVm mv = new MainVm();
                mv.CloseWin += Mv_CloseWin;
                mv.StraightWindow += Mv_StraightWindow;
                DataContext = mv;
                InitializeComponent();
                mv.InitCurStep();
            }
            catch (Exception e)
            {

                CL.BS.Common.StaticVar.inline.SaveGameData();
                Close();
                CL.BS.Common.GlobalLog.Write("Exception WindowBase" + DateTime.Now);
                throw;
            }
            _dispatcherTimer.Tick += dispatcherTimer_Tick;
            _dispatcherTimer.Interval = new TimeSpan(0, 0, 0,0,300);            
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            _dispatcherTimer.Stop();
            Mv_StraightWindow(null, null);
        }

        private void Mv_StraightWindow(object sender, EventArgs e)
        {
            WindowState = WindowState.Normal;
            WindowStyle = WindowStyle.None;
            ResizeMode = ResizeMode.NoResize;
            WindowState = WindowState.Maximized;
            this.Top = this.Left = 0;
        }

        private void Mv_CloseWin(object sender, EventArgs e)
        {
            CL.BS.Common.StaticVar.inline.SaveGameData();
            Close();
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
            this.MinHeight = this.ActualHeight;
            this.MinWidth = this.ActualWidth;
            CL.BS.Common.MiceKiller.KillAllMices(false);
            new Thread(new ThreadStart(() =>
            { System.Diagnostics.Process.Start(@"C:\Windows\System32\taskkill.exe", @"/F /IM explorer.exe"); })).Start();
        }
        
        private void Window_Closed(object sender, EventArgs e)
        {
            DatabaseManager.Inline.Save();
            CL.BS.Common.StaticVar.inline.SaveGameData();
            Process.Start( System.IO.Path.Combine(Environment.GetEnvironmentVariable("windir"),"explorer.exe"));
            CL.BS.Common.MiceKiller.KillAllMices(true); 
            CL.BS.Common.StaticVar.inline.SaveGameData();
        }

        private void Window_LocationChanged(object sender, EventArgs e)
        {
            _dispatcherTimer.Start();
        }
    }
}
