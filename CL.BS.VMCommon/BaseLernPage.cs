using CL.BS.Common;
using CL.BS.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CL.BS.VMCommon
{
    public abstract class BaseLernPage : BasePageVM, IPageVM
    {
        /// <summary>
        /// It's the father of all the pages of the learning and game
        /// and learn all the logic that is shared to all the LearnPage.
        /// </summary>

        public Visibility KeyboardVisibility { get; set; }
        public int CardHeight { get; set; }
        public int CardWidth { get; set; }
        public double CardY { get; set; }
        public double CardX { get; set; }
        public string ExitButBackground { get; set; }
        public bool CanExit = true;
        public Visibility EGPic { get; set; }
        public ICommand OpenEG { get; set; }
        public ICommand MouseMove { get; set; }
        public ICommand ExitBut { get; set; }
        public ICommand ExitFromPage { get; set; }
        public ICommand PreviewMouseUp { get; set; }
        public ICommand PreviewMouseDown { get; set; }
        public string BackgroundVolume { get; set; }
        public string VisibilityCard { get; set; }
        public string TextCard { get; set; }
        public int TextSize { get; set; }
        public string TextResult { get; set; }
        public string PicCard { get; set; }
        public bool CardDrag = false;
        protected Point TrgetPoint;

        protected int _index;
        protected DateTime _startTime;

        public BaseLernPage()
        {
            ButSpeaker = new RelayCommand(DoButSpeaker);
            CloseSpeaker = new RelayCommand(DoCloseSpeaker);
            OpenEG = new RelayCommand(DoOpenEG);
            MouseMove = new RelayCommand(DoMouseMove);
            PreviewMouseUp = new RelayCommand(DoPreviewMouseUp);
            PreviewMouseDown = new RelayCommand(DoExitBut);
            ExitBut = new RelayCommand(DoExitBut);
            ExitFromPage = new RelayCommand(DoExitFromPage);
            EGPic = Visibility.Collapsed;
            NotifyPropertyChanged(nameof(EGPic));

            RefreshWinBut = System.AppDomain.CurrentDomain.BaseDirectory
         + @"Resources\BS.Items\GreenRefreshWin.png";
            NotifyPropertyChanged(nameof(RefreshWinBut));
            TextSize = 85;
            NotifyPropertyChanged(nameof(TextSize));
        }

        protected void DoExitBut(object obj)
        {
            CanExit = !CanExit;
            ExitButBackground = string.Format(@"{0}Resources\BS.Items\stop{1}Icon.png",
  System.AppDomain.CurrentDomain.BaseDirectory, CanExit ?"Green" : "Red" );
            NotifyPropertyChanged(nameof(ExitButBackground));
        }
        protected void DoExitFromPage(object obj)
        {
            if (CanExit)
                DoGoToPage(obj.ToString());
        }

        private void DoPreviewMouseUp(object obj)
        {
            CardDrag = false;
            //VisibilityCard = "Hidden";
            //NotifyPropertyChanged("VisibilityCard");
        }
        private void DoMouseMove(object obj)
        {
            if (CardDrag)
            {
                Point mousePos = Mouse.GetPosition((IInputElement)obj);
                CardX = mousePos.X - 25;
                CardY = mousePos.Y - 50;
                NotifyPropertyChanged("CardX");
                NotifyPropertyChanged("CardY");
                if (mousePos.Y < TrgetPoint.Y&& mousePos.X > TrgetPoint.X
                    && mousePos.X < TrgetPoint.X+200)
                {
                    VisibilityCard = "Hidden";
                    NotifyPropertyChanged("VisibilityCard");
                    CardAnswer();
                }
            }
        }

        protected void SetCard(string textCard ,float startPointX = 0.4f
            , float startPointY = 0.4f, float trgetPointX =0.4f, float trgetPointY =0.2f)
        {
            VisibilityCard = "Visible";
            if (textCard.Contains("Resources\\"))
            {
                TextCard = String.Empty;
                PicCard =System.AppDomain.CurrentDomain.BaseDirectory + textCard;
            }
            else
            {
                PicCard = String.Empty;
                TextCard =  textCard;
            }
            CardX = startPointX* System.Windows.SystemParameters.PrimaryScreenWidth ;
            CardY = startPointY* System.Windows.SystemParameters.PrimaryScreenHeight;
            CardWidth = 63; CardHeight = 85;
            TrgetPoint.X = trgetPointX * System.Windows.SystemParameters.PrimaryScreenWidth -100;
            TrgetPoint.Y = trgetPointY * System.Windows.SystemParameters.PrimaryScreenHeight;
            NotifyPropertyChanged("CardWidth");
            NotifyPropertyChanged("CardHeight");
            NotifyPropertyChanged("CardX");
            NotifyPropertyChanged("CardY");
            NotifyPropertyChanged("VisibilityCard");
            NotifyPropertyChanged("PicCard");
            NotifyPropertyChanged("TextCard");
        }

        private void DoOpenEG(object obj)
        {
            EGPic = EGPic == Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed;
            NotifyPropertyChanged("EGPic");
        }

        //private void DoSetVolume(object obj)
        //{//The  volume controller.
        //    lock (this)
        //    {
        //        int v = (int)(Volume * 200);
        //        if (obj.ToString() == "+")
        //            v = v == 100 ? 100 : v + 5;
        //        else
        //            v = v == 0 ? 0 : v - 5;
        //        Volume = ((double)v / 200);
        //        StaticVar.inline.Volume = Volume;
        //        ValueText = v.ToString();
        //        NotifyPropertyChanged("Volume");
        //        NotifyPropertyChanged("ValueText");
        //    }
        //}

        private void DoCloseSpeaker(object obj)
        {
            isSpeakerOpen = false;
            BackgroundVolume = string.Empty;
            NotifyPropertyChanged("BackgroundVolume");

            SpeakerButton = System.AppDomain.CurrentDomain.BaseDirectory
           + @"Resources\BS.Items\BigSpiker" + (StaticVar.inline.IsPlay ? "" : "X") + ".png";
            NotifyPropertyChanged("SpeakerButton");
            StaticVar.inline.Volume = Volume;
        }

        private void DoButSpeaker(object obj)
        {
            if (!isSpeakerOpen)
            {
                string v = Volume == 0 ? "0.0" : (Volume ==0.5 ? "0.5" : Volume.ToString());
                BackgroundVolume = System.AppDomain.CurrentDomain.BaseDirectory
                + @"Resources\BS.Items\sound_" + v + ".png";
                NotifyPropertyChanged("BackgroundVolume");
                new Thread(new ThreadStart(() =>
                {
                    Thread.Sleep(500);
                    isSpeakerOpen = true;
                })).Start();
        }
            else
            {
                StaticVar.inline.IsPlay = !StaticVar.inline.IsPlay;
                SpeakerButton = System.AppDomain.CurrentDomain.BaseDirectory
                    + @"Resources\BS.Items\BigSpiker" + (StaticVar.inline.IsPlay ? "" : "X") + ".png";
                IsPlay = StaticVar.inline.IsPlay ? "Play" : "Stop";
                NotifyPropertyChanged("IsPlay");
                NotifyPropertyChanged("SpeakerButton");
            }
        }
        public virtual void CardAnswer() { }
        protected void Settings()
        {
            CanExit = false;
            ExitButBackground = string.Format(@"{0}Resources\BS.Items\stopRedIcon.png",
  System.AppDomain.CurrentDomain.BaseDirectory);
            NotifyPropertyChanged(nameof(ExitButBackground));
            Volume = StaticVar.inline.Volume;           
            NotifyPropertyChanged("Volume");
            ValueText = ((int)(Volume * 200)).ToString();
            NotifyPropertyChanged("VolumeText");
            StaticVar.PlayMode =  isSpeakerOpen = false;
            bool b = StaticVar.inline.IsPlay;
            SpeakerButton = System.AppDomain.CurrentDomain.BaseDirectory
           + @"Resources\BS.Items\BigSpiker" + (StaticVar.inline.IsPlay ? "" : "X") + ".png";
            IsPlay = b ? "Play" : "Stop";
            NotifyPropertyChanged("IsPlay");
            NotifyPropertyChanged("SpeakerButton");
            UrlPlay = string.Empty;
            VisibilityCard = "Hidden";
            NotifyPropertyChanged("VisibilityCard");
            _startTime = DateTime.Now;
        }
        
        void IPageVM.load()
        {
            Settings();
        }
    }
}
