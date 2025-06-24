using BS.Items;
using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;

namespace CL.BS.HebrewVM.Game.BS.MenuVM
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class MenuOpenVM : BaseMenuVM,  IPageVM
    {
        public ICommand ChangeLanguage { get; set; }
        public ICommand Close { get; set; }
        public ICommand Restart { get; set; }
        public ICommand Reboot { get; set; }
        public ICommand ToSpeaker { get; set; }
        public ICommand StartPlay { get; set; }
        public string SpeakerPic { get; set; }
        public override string Name
        {
            get
            {
                return "MenuOpenVM";
            }
        }  

        [DllImport("user32.dll")]
        public static extern int ExitWindowsEx(int uFlags, int dwReason);
        [DllImport("Powrprof.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool SetSuspendState(bool hiberate, bool forceCritical, bool disableWakeEvent);

       

        public MenuOpenVM()
        {
            UrlPlay =String.Format( @"{0}\Resources\Audio\{1}\Open.wav" 
,System.AppDomain.CurrentDomain.BaseDirectory, Common.StaticVar.inline.SelectedLanguage);
            Close = new RelayCommand(DoClose);
            Restart = new RelayCommand(DoRestart);
            Reboot = new RelayCommand(DoReboot);
            ToSpeaker = new RelayCommand(DoToSpeaker);
            StartPlay = new RelayCommand(DoStartPlay);
            ChangeLanguage = new RelayCommand(DoChangeLanguage);
            base.Settings();

        }

        private void DoRestart(object obj)
        {
            Application.Current.Shutdown();
            Process.Start("shutdown", "-r -t  1 ");
        }

        void IPageVM.disload()
        {
            UrlPlay = string.Empty;
        }

        private void DoStartPlay(object obj)
        {
            new WindowPlay(obj.ToString()).ShowDialog();
        }
       
        private void DoChangeLanguage(object obj)
        {
            Common.StaticVar.inline.SelectedLanguage=obj.ToString();
            PlayUrl(String.Format(@"{0}\Resources\Audio\{1}\Open.wav"
, System.AppDomain.CurrentDomain.BaseDirectory, Common.StaticVar.inline.SelectedLanguage));
        }

        private void DoToSpeaker(object obj)
        {
            new WinSpeaker1(true).ShowDialog();
            bool b = Common.StaticVar.inline.IsPlay ||Common.StaticVar.inline.Volume == 0;
            SpeakerPic = b ? System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\BS.Items\BlueSpeakerX.png" : string.Empty;
            NotifyPropertyChanged("SpeakerPic");
        }

        private void DoClose(object obj)
        {
            //http://www.c-sharpcorner.com/article/lock-logoff-reboot-shutdown-hibernate-standby-in-net/
            //ExitWindowsEx(0, 0);

            Application.Current.Shutdown();
            Process.Start("shutdown", " -s -t 1");//shutdown.exe -s -t 1
            //Hibernate https://stackoverflow.com/questions/2079813/c-sharp-put-pc-to-sleep-or-hibernate
        }

        private void DoReboot(object obj)
        {
            //http://www.c-sharpcorner.com/article/lock-logoff-reboot-shutdown-hibernate-standby-in-net/
             ExitWindowsEx(4, 0);
            //Hibernate https://stackoverflow.com/questions/2079813/c-sharp-put-pc-to-sleep-or-hibernate
            //  SetSuspendState(false, true, true);
        }  
    }
}
