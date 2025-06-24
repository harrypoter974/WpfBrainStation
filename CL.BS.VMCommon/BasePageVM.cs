using CL.BS.Common;
using CL.BS.Contract;
using CL.BS.VMCommon.Win;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Input;

namespace CL.BS.VMCommon
{
    public abstract class BasePageVM : INotifyPropertyChanged, IPageVM
    {
        /// <summary>
        /// This class is the father for all VM classes of the solution
        /// it control on. 
        /// </summary>

        private int _playListIndex = 0;
        private string[] _playList = null;
        public Action<BasePageVM, string> GoHome { get; set; }
        public string SpeakerMargin { get; set; }
        public abstract string Name { get; }
        public ICommand NoticePlay { get; set; }
        public ICommand StopPlay { get; set; }
        public ICommand ChangeCardOrWrote { get; set; }
        public ICommand GoToPage { get; set; }
        public ICommand ButSpeaker { get; set; }
        public ICommand AnswerBut { get; set; }
        public ICommand OpenHelp { get; set; }
        public ICommand CloseSpeaker { get; set; }
        public ICommand StopSetVolume { get; set; }
        public string CardOrWrotePic { get; set; }
        public string BackgroundAnswerButton { get; set; }
        public string SpeakerButton { get; set; }
        public string ValueText { get; set; }
        public string IsPlay { get; set; }
        public string RefreshWinBut { get; set; }
        public double Volume { get; set; }
        public string VolumeText { get; set; }
        public string messagePic { get; set; }
        public bool IsQuestionMode = true;
        public bool isSpeakerOpen { get; set; }
        public ICommand SetVolume { get; set; }
        private Random _ran = new Random(DateTime.Now.Millisecond);
        private string _playUrl;
        public string UrlPlay
        {
            get { return _playUrl; }
            set
            {
                if (_playUrl == value) return;
                _playUrl = value;
                NotifyPropertyChanged("UrlPlay");
            }
        }
        string IPageVM.Name
        {
            get
            {
                return "";
            }
        }

        Action<IPageVM, string> IPageVM.GoToAction
        {
            set { }
        }

        public BasePageVM()
        {
            Volume = StaticVar.inline.Volume;
            BackgroundAnswerButton = System.AppDomain.CurrentDomain.BaseDirectory
                + @"Resources\BS.Items\ButtonG.png";
            GoToPage = new RelayCommand(DoGoToPage);
            OpenHelp = new RelayCommand(DoOpenHelp);
            NoticePlay = new RelayCommand(DoNoticePlay);
            StopPlay = new RelayCommand(DoStopPlay); 
            CardOrWrotePic = System.AppDomain.CurrentDomain.BaseDirectory
             + @"Resources\BS.Items\Button" + StaticVar.inline.CardOrWritingPic(false);
            SpeakerMargin = string.Format("{0},{1},0,0", (System.Windows.SystemParameters.PrimaryScreenWidth * 0.04)
                 , (System.Windows.SystemParameters.PrimaryScreenHeight * 0.014));
            NotifyPropertyChanged("SpeakerMargin");
            NotifyPropertyChanged("CardOrWrotePic");
            NotifyPropertyChanged("BackgroundAnswerButton");
            StopSetVolume = new RelayCommand(DoStopSetVolume);
            SetVolume = new RelayCommand(DoSetVolume);
        }

        Thread PlayThread;
        private void DoSetVolume(object obj)
        {//volume controller
            //PlayThread = new Thread(new ThreadStart(() =>
            //{
            //    while (true)
            //    {
                    int v = (int)(Volume * 200);

                    if (obj.ToString() == "+")
                        v = v > 95 ? 100 : v + 5;
                    else
                        v =  v < 5? 0 : v - 5;
                    
                    Volume = ((double)v / 200);
                    StaticVar.inline.Volume = Volume;
                    ValueText = v.ToString();
                    NotifyPropertyChanged("Volume");
                    NotifyPropertyChanged("ValueText");
                    Thread.Sleep(300);
                    //if (v == 0 || v >= 100)
                    //{
                    //    break;
                    //}
                
            //}}));
            //PlayThread.Start();
        }

        private void DoStopSetVolume(object obj)
        {
            //if(PlayThread.IsAlive)
            //    PlayThread.Suspend();
        }
        private void DoStopPlay(object obj)
        {
            ///This method if the play stops it enabels another file to play
            ///and if its a playlist it goes to the next file until the end.
            if (_playList != null)//is Play_list
            {
                _playListIndex++;
                if (_playListIndex == _playList.Length)
                {
                    _playList = null;
                    _playListIndex = 0;
                    StaticVar.PlayMode = false;
                }
                else
                {
                    string url = System.AppDomain.CurrentDomain.BaseDirectory + _playList[_playListIndex];
                    while (!File.Exists(url))
                    {
                        _playListIndex++;
                        if (_playListIndex == _playList.Length)//end pley list
                        {
                            _playList = null;
                            _playListIndex = 0;
                            StaticVar.PlayMode = false;
                            return;
                        }
                        //pley the next file
                        url = System.AppDomain.CurrentDomain.BaseDirectory + _playList[_playListIndex];
                    }
                    if (_playListIndex < _playList.Length)
                    {
                        UrlPlay = string.Empty;
                        UrlPlay = url;
                    }
                }
            }
            else
                StaticVar.PlayMode = false;
        }

        private void DoNoticePlay(object obj)
        {//Play win or loose file.
            int i = _ran.Next(7);
            if ("Good" == obj.ToString())
            {
                PlayList(new string[] { StaticVar.inline.PlayName(),
                    @"Resources\Audio\He\Good\Win" + i + ".wav" });
            }
            else
            {
                if (StaticVar.inline.IsBoy)
                {
                    PlayList(new string[] { StaticVar.inline.PlayName(),
                    @"Resources\Audio\He\Bad\Error" + (i % 4) + ".wav" });
                }
                else
                {

                    PlayList(new string[] { StaticVar.inline.PlayName(),
                    @"Resources\Audio\He\Bad\Error" + (i % 3) + ".wav" });
                }
            }
        }

        private void DoChangeCardOrWrote(object obj)
        {
            CardOrWrotePic = System.AppDomain.CurrentDomain.BaseDirectory
                + @"Resources\BS.Items\Button" + StaticVar.inline.CardOrWritingPic(true);
            NotifyPropertyChanged("CardOrWrotePic");
        }

        public void SwitchAnswerButton()
        {
            IsQuestionMode = !IsQuestionMode;
            if (IsQuestionMode)
                BackgroundAnswerButton = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\BS.Items\ButtonG.png";
            else
                BackgroundAnswerButton = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\BS.Items\ButtonV.png";
            NotifyPropertyChanged("BackgroundAnswerButton");
        }

        void IPageVM.disload() {
           StaticVar.inline.Volume =  Volume;
            UrlPlay = string.Empty;
            StaticVar.PlayMode = true;
            if (!IsQuestionMode)
                SwitchAnswerButton();
        }

        public void DoGoToPage(object obj)
        {// go to enve page           
            GoHome(this, obj.ToString());
        }

        private void DoOpenHelp(object page)
        {
            new WinHelp(page).Show();
        }
   
        public void PlayList(string[] list)
        {//start play list of file
            if (IsPlay == "Stop" || StaticVar.PlayMode|| list.Length==0)
                return;
            StaticVar.PlayMode = true;
            _playList = list;
            _playListIndex = 0;

            string url = System.AppDomain.CurrentDomain.BaseDirectory + list[_playListIndex];
            while (!File.Exists(url)&& _playListIndex < list.Length)//[_playListIndex]
            {
                _playListIndex++;
                url = System.AppDomain.CurrentDomain.BaseDirectory + list[_playListIndex];
            }
            if (_playListIndex < list.Length)//[_playListIndex]
            {
                UrlPlay = string.Empty;
                UrlPlay = url;
            }
            else
            {
                StaticVar.PlayMode = false;
                _playList = null;
                _playListIndex = 0;
            }
        }

        public void PlayUrl(string url)
        {//Start play single file.
            if (IsPlay == "Stop"|| !File.Exists(url) ||StaticVar.PlayMode)
                return;
            if (File.Exists(url))
            {
                StaticVar.PlayMode = true;
                UrlPlay = string.Empty;
                UrlPlay = url;
            }
        }

        protected void WhitAntilPlayStop(ref bool playRun)
        {
            while (playRun && StaticVar.PlayMode)
                Thread.Sleep(100);
        }

        protected void WhitTime(int time, ref bool PlayRun)
        {
            for (int i = 0; i < time && PlayRun; i += 100)
                Thread.Sleep(100);
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        protected void NotifyPropertyChanged(string propertyName)
        {
            VerifyPropertyName(propertyName);
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void NotifyPropertyChanged(int propertyValue)
        {
            VerifyPropertyName(propertyValue);
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyValue.ToString()));
        }

        [Conditional("DEBUG")]
        private void VerifyPropertyName(string propertyName)
        {
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
                throw new ArgumentNullException(GetType().Name + " does not contain property: " + propertyName);
        }

        [Conditional("DEBUG")]
        private void VerifyPropertyName(int propertyValue)
        {
            if (TypeDescriptor.GetProperties(this)[propertyValue] == null)
                throw new ArgumentNullException(GetType().Name + " does not contain property: " + propertyValue);
        }

        void IPageVM.load()
        {
        }
    }
}
