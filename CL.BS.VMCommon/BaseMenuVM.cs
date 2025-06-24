
using CL.BS.Common;
using CL.BS.Contract;
using CL.BS.Model;
using CL.BS.VMCommon.Win;
using System;
using System.Threading;
using System.Windows.Input;

namespace CL.BS.VMCommon
{
    public abstract class BaseMenuVM : BasePageVM, IPageVM
    {
        /// <summary>
        /// This class control's on all the menu VM classes
        /// like BaseLearnPage 
        /// </summary>

        private WindowLook _wl;
        protected string[] PageList;
        public string BackgroundVolume { get; set; }
        public string HomeBut { get; set; }
        public ICommand LookHome { get; set; }
        public ICommand GOHome { get; set; }
        public ICommand ExitingGame { get; set; }
        public bool HomeOpen;
        public int WidthSpeaker { get; set; }
        #region Open Page
        public string BackgroundBut0 { get { return BackgroundBut[0].Background; } set { BackgroundBut[0].Background = value; } }
        public string BackgroundBut1 { get { return BackgroundBut[1].Background; } set { BackgroundBut[1].Background = value; } }
        public string BackgroundBut2 { get { return BackgroundBut[2].Background; } set { BackgroundBut[2].Background = value; } }
        public string BackgroundBut3 { get { return BackgroundBut[3].Background; } set { BackgroundBut[3].Background = value; } }
        public string BackgroundBut4 { get { return BackgroundBut[4].Background; } set { BackgroundBut[4].Background = value; } }
        public string BackgroundBut5 { get { return BackgroundBut[5].Background; } set { BackgroundBut[5].Background = value; } }
        public string BackgroundBut6 { get { return BackgroundBut[6].Background; } set { BackgroundBut[6].Background = value; } }
        public string BackgroundBut7 { get { return BackgroundBut[7].Background; } set { BackgroundBut[7].Background = value; } }
        public string BackgroundBut8 { get { return BackgroundBut[8].Background; } set { BackgroundBut[8].Background = value; } }
        public string BackgroundBut9 { get { return BackgroundBut[9].Background; } set { BackgroundBut[9].Background = value; } }
        public string BackgroundBut10 { get { return BackgroundBut[10].Background; } set { BackgroundBut[10].Background = value; } }
        public string BackgroundBut11 { get { return BackgroundBut[11].Background; } set { BackgroundBut[11].Background = value; } }
        public string BackgroundBut12 { get { return BackgroundBut[12].Background; } set { BackgroundBut[12].Background = value; } }
        public string BackgroundBut13 { get { return BackgroundBut[13].Background; } set { BackgroundBut[13].Background = value; } }
        public string BackgroundBut14 { get { return BackgroundBut[14].Background; } set { BackgroundBut[14].Background = value; } }
        public string BackgroundBut15 { get { return BackgroundBut[15].Background; } set { BackgroundBut[15].Background = value; } }
        public string BackgroundBut16 { get { return BackgroundBut[16].Background; } set { BackgroundBut[16].Background = value; } }
        public string BackgroundBut17 { get { return BackgroundBut[17].Background; } set { BackgroundBut[17].Background = value; } }
        public string BackgroundBut18 { get { return BackgroundBut[18].Background; } set { BackgroundBut[18].Background = value; } }
        public string BackgroundBut19 { get { return BackgroundBut[19].Background; } set { BackgroundBut[19].Background = value; } }
        public string BackgroundBut20 { get { return BackgroundBut[20].Background; } set { BackgroundBut[20].Background = value; } }
        public string BackgroundBut21 { get { return BackgroundBut[21].Background; } set { BackgroundBut[21].Background = value; } }
        public string BackgroundBut22 { get { return BackgroundBut[22].Background; } set { BackgroundBut[22].Background = value; } }
        public string BackgroundBut23 { get { return BackgroundBut[23].Background; } set { BackgroundBut[23].Background = value; } }
        public string BackgroundBut24 { get { return BackgroundBut[24].Background; } set { BackgroundBut[24].Background = value; } }
        protected SoldierObject[] BackgroundBut = new SoldierObject[25];
        protected string[] Pages =new string[0];
        #endregion Open Page
        public BaseMenuVM()
        {
            for (int i = 0; i < BackgroundBut.Length; i++)
                BackgroundBut[i] = new SoldierObject();
            ButSpeaker = new RelayCommand(DoButSpeaker);
            CloseSpeaker = new RelayCommand(DoCloseSpeaker);
            //LookHome = new RelayCommand(DoLookHome);
            GOHome = new RelayCommand(DoGoHome);
            ExitingGame = new RelayCommand(DoExitingGame);
            RefreshWinBut = System.AppDomain.CurrentDomain.BaseDirectory
          + @"Resources\BS.Items\RefreshWin.png";
            NotifyPropertyChanged("RefreshWinBut");
            HomeOpen = true;
          
        }
        private void DoExitingGame(object obj)
        {
            if (HomeOpen)
            {
                Common.MiceKiller.KillAllMices(false);
                DoGoToPage(obj);
            }
        }

        private void DoGoHome(object obj)
        {
            if (HomeOpen)
                DoGoToPage(obj);
        }

        private void DoLookHome(object obj)
        {
            _wl = new WindowLook(ref HomeOpen);
            _wl.Closed += Wl_Closed;
            _wl.ShowDialog();
        }

        private void Wl_Closed(object sender, EventArgs e)
        {//not allow to go back is to have the child learn only one subject
            HomeOpen = _wl.GetState();
            if (HomeOpen)
                HomeBut = string.Empty;
            else
            {
                HomeBut = System.AppDomain.CurrentDomain.BaseDirectory
                + @"Resources\BS.Items\LOCKER_HOME.png";
            }
             NotifyPropertyChanged("HomeBut");
        }
        private void DoCloseSpeaker(object obj)
        {
            if (isSpeakerOpen)
            {
                isSpeakerOpen = false;
                WidthSpeaker = 35;
                NotifyPropertyChanged("WidthSpeaker");
                VolumeText = (Volume * 100).ToString().Split('.')[0];
                NotifyPropertyChanged("VolumeText");
            }
            StaticVar.inline.Volume = Volume;
        }

        private void DoButSpeaker(object obj)
        {
            StaticVar.inline.IsPlay = !StaticVar.inline.IsPlay;
            SpeakerButton = System.AppDomain.CurrentDomain.BaseDirectory
                + @"Resources\BS.Items\BigBlueSpeaker" + (StaticVar.inline.IsPlay ? "" : "X") + ".png";
            IsPlay = StaticVar.inline.IsPlay ? "Play" : "Stop";
            NotifyPropertyChanged("IsPlay");
            NotifyPropertyChanged("SpeakerButton");
        }

        protected  void Settings()
        {
            Volume = StaticVar.inline.Volume;
            NotifyPropertyChanged("Volume");
            ValueText = ((int)(Volume * 200)).ToString();
            NotifyPropertyChanged("VolumeText");
            WidthSpeaker = 35;
            NotifyPropertyChanged("WidthSpeaker");
            StaticVar.PlayMode= isSpeakerOpen = false;
            bool b = StaticVar.inline.IsPlay;
            SpeakerButton = System.AppDomain.CurrentDomain.BaseDirectory
               + @"Resources\BS.Items\BigBlueSpeaker" + (b ? "" : "X") + ".png";
            IsPlay = b ? "Play" : "Stop";
            NotifyPropertyChanged("IsPlay");
            NotifyPropertyChanged("SpeakerButton");
        }

        void IPageVM.load()
        {
            Settings();
            showPagePermissions();
        }
        public void showPagePermissions()
        {
            for (int i = 0; i < Pages.Length; i++)
            {
                BackgroundBut[i].Background = (Common.StaticVar.inline.LimitingPages.Contains(Pages[i]) ? "#7FFFFFFF" : "Transparent");
                NotifyPropertyChanged("BackgroundBut" + i);
            }
        }

    }
}
