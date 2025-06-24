using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfBrainStation
{
    #region MEF
    [Export(typeof(IPageVM))]
    #endregion MEF
    internal class OpenVM : BasePageVM, IPageVM
    {
        WindowBase Win;
        //public string passwordText { get; set; }
        //private string Password = String.Empty;
        public string BackgroundError { get; set; }
        public string Visibility { get; set; }
        public ICommand Enter { get; set; }
        public ICommand TypeNum { get; set; }
        //private DateTime dateTime=DateTime.Now.AddHours(-5);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int ExitWindowsEx(int uFlags, int dwReason);
        System.Windows.Threading.DispatcherTimer _dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        public override string Name => nameof(OpenVM);
        private MainWindow _win;
        //private int _fillExperience = 0;
            //string FILE_NAME = @"C:\bs\passwordText.txt";
        public OpenVM(MainWindow win)
        {
            //BackgroundError = "White";
            //NotifyPropertyChanged(nameof(BackgroundError));
            _dispatcherTimer.Tick += dispatcherTimer_Tick;
            _dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 300);
            _dispatcherTimer.Start();
            _win = win;
            //passwordText = string.Empty;
         TypeNum = new RelayCommand(DoTypeNum);
            Enter = new RelayCommand(DoEnter);
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            _dispatcherTimer.Stop();
            Win = new WindowBase();
            //if (File.Exists(FILE_NAME))
            //{
            //    string[] t = File.ReadAllText(FILE_NAME).Split('#');
            //    Password = t[0];
            //    if (t.Length > 1)
            //    {
            //        dateTime = DateTime.Parse(t[1]);
            //        if (dateTime > DateTime.Now.AddHours(-4))
            //        {
            //            BackgroundError = "Transparent";
            //            NotifyPropertyChanged(nameof(BackgroundError));
            //        }
            //    }
            //    if (string.IsNullOrEmpty(Password))
            //        DoEnter(null);
            //}
            //else
            //{
            //    File.WriteAllText(FILE_NAME, Password);
               DoEnter(null);
            //}
            //Visibility = "Collapsed";
            //NotifyPropertyChanged(nameof(Visibility));
        }

        private void DoEnter(object obj)
        {
            //if (Win == null || dateTime > DateTime.Now.AddHours(-4))
            //    return;
            //if (Password == passwordText|| "11235813" == passwordText)
            //{
                Win.Show();
                _win.Close();
            //}
            //else
            //{
            //    _fillExperience++;
            //    if (_fillExperience == 3)
            //    {
            //        dateTime = DateTime.Now;
            //        BackgroundError = "Transparent";
            //        NotifyPropertyChanged(nameof(BackgroundError));

            //        _dispatcherTimer.Tick += OpenTimer_Tick;
            //        _dispatcherTimer.Interval = new TimeSpan(0, 4, 0, 0);
            //        _dispatcherTimer.Start();
            //        if (File.Exists(FILE_NAME))
            //        {
            //            Password = File.ReadAllText(FILE_NAME);
            //            File.WriteAllText(FILE_NAME, String.Format("{0}#{1}",Password,dateTime.ToString()));
            //        }
            //    }
            //}
        }


        private void DoTypeNum(object obj)
        {
            //string l = obj.ToString();
            //if (l != "d")
            //    passwordText += l;
            //else
            //{
            //    string t = string.Empty;
            //    for (int i = 0; i < passwordText.Length-1; i++)
            //        t += passwordText[i];
            //    passwordText = t;
            //}
            //NotifyPropertyChanged(nameof(passwordText));
        }
        private void OpenTimer_Tick(object sender, EventArgs e)
        {
            BackgroundError = "White";
            NotifyPropertyChanged(nameof(BackgroundError));
        }

    }
}
