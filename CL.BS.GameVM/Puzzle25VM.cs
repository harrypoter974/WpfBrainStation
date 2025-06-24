using CL.BS.Contract;
using CL.BS.GameManager.Interface;
using CL.BS.MEF;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CL.BS.GameVM
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class Puzzle25VM : BaseLernPage, IPageVM
    {
        public override string Name => nameof(Puzzle25VM) ;
        private int _groupIndex;
        private Dictionary<string, int> _groupDic = new Dictionary<string, int>();
        public ICommand SetGroup { get; set; }
        public ICommand SetPlayer { get; set; }
        public ICommand NewGame { get; set; }
        public ICommand _GoHome { get; set; }
        public string EGPic { get; set; }
        public string BackgroundNewGame { get; set; }
        public string BackgroundPic { get; set; }
        public string VisibilityCard { get; set; }
        public string RowCard { get; set; }
        public string RowSpanCard { get; set; }
        public string PlayerBut1 { get; set; }
        public string PlayerBut2 { get; set; }
        public string GroupBut0 { get { return _groups[0].Background; } set { _groups[0].Background = value; } }
        public string GroupBut1 { get { return _groups[1].Background; } set { _groups[1].Background = value; } }
        public string GroupBut2 { get { return _groups[2].Background; } set { _groups[2].Background = value; } }
        public string GroupBut3 { get { return _groups[3].Background; } set { _groups[3].Background = value; } }
        private ItemObject[] _groups = new ItemObject[4];
        public Puzzle25BoardVM Card00 { get { return _cards[0]; } set { _cards[0] = value; } }
        public Puzzle25BoardVM Card10 { get { return _cards[1]; } set { _cards[1] = value; } }
        public Puzzle25BoardVM Card20 { get { return _cards[2]; } set { _cards[2] = value; } }
        public Puzzle25BoardVM Card30 { get { return _cards[3]; } set { _cards[3] = value; } }
        public Puzzle25BoardVM Card40 { get { return _cards[4]; } set { _cards[4] = value; } }
        public Puzzle25BoardVM Card50 { get { return _cards[5]; } set { _cards[5] = value; } }  
       
        public Puzzle25BoardVM Card01 { get { return _cards[6]; } set { _cards[0] = value; } }
        public Puzzle25BoardVM Card11 { get { return _cards[7]; } set { _cards[1] = value; } }
        public Puzzle25BoardVM Card21 { get { return _cards[8]; } set { _cards[2] = value; } }
        public Puzzle25BoardVM Card31 { get { return _cards[9]; } set { _cards[3] = value; } }
        public Puzzle25BoardVM Card41 { get { return _cards[10]; } set { _cards[4] = value; } }
        public Puzzle25BoardVM Card51 { get { return _cards[11]; } set { _cards[5] = value; } }
    
        public Puzzle25BoardVM Card02 { get { return _cards[12]; } set { _cards[12] = value; } }
        public Puzzle25BoardVM Card12 { get { return _cards[13]; } set { _cards[13] = value; } }
        public Puzzle25BoardVM Card22 { get { return _cards[14]; } set { _cards[14] = value; } }
        public Puzzle25BoardVM Card32 { get { return _cards[15]; } set { _cards[15] = value; } }
        public Puzzle25BoardVM Card42 { get { return _cards[16]; } set { _cards[16] = value; } }
        public Puzzle25BoardVM Card52 { get { return _cards[17]; } set { _cards[17] = value; } }

        public Puzzle25BoardVM Card03 { get { return _cards[18]; } set { _cards[18] = value; } }
        public Puzzle25BoardVM Card13 { get { return _cards[19]; } set { _cards[19] = value; } }
        public Puzzle25BoardVM Card23 { get { return _cards[20]; } set { _cards[20] = value; } }
        public Puzzle25BoardVM Card33 { get { return _cards[21]; } set { _cards[21] = value; } }
        public Puzzle25BoardVM Card43 { get { return _cards[22]; } set { _cards[22] = value; } }
        public Puzzle25BoardVM Card53 { get { return _cards[23]; } set { _cards[23] = value; } }
        private Puzzle25BoardVM[] _cards = new Puzzle25BoardVM[24];
        private IPuzzle25Manager _logic = (IPuzzle25Manager)
SupportHandlerManager.Base.GetManager("Puzzle25Manager");

        public Puzzle25VM()
        {
            SetGroup = new RelayCommand(DoSetGroup);
            SetPlayer = new RelayCommand(DoSetPlayer);
            NewGame = new RelayCommand(DoNewGame);
            _GoHome = new RelayCommand(DoGoHome);
            OpenEG = new RelayCommand(DoOpenEG);
            AnswerBut = new RelayCommand(DoAnswerBut);
            _groupDic.Add("1", 0);
            _groupDic.Add("2", 1);
            _groupDic.Add("3", 2);
            _groupDic.Add("6", 3);
            for (int i = 0; i < _groups.Length; i++)
                _groups[i] = new ItemObject();
            for (int i = 0; i < _cards.Length; i++)
                _cards[i] = new Puzzle25BoardVM("RGBY"[i/6]);
        }

        private void DoAnswerBut(object obj)
        { 
            if (base.IsQuestionMode)
            {
                BackgroundNewGame = System.AppDomain.CurrentDomain.BaseDirectory
                + @"Resources\BS.Items\buttonNewGame.png";
            }
            else
            {
                BackgroundNewGame = string.Empty;
            }
            base.IsQuestionMode = !base.IsQuestionMode;
            base.CanExit = !base.CanExit;
            NotifyPropertyChanged(nameof(BackgroundNewGame));
            ExitButBackground = string.Format(@"{0}Resources\BS.Items\stop{1}Icon.png",
System.AppDomain.CurrentDomain.BaseDirectory, CanExit ? "Green" : "Red");
            NotifyPropertyChanged(nameof(ExitButBackground));
        }

        private void DoGoHome(object obj)
        {
            if (Common.StaticVar.IsGarden)
                DoGoToPage("MenuHeGeneralGameVM");
            else
                DoGoToPage("MenuGameVM");         
        }

        private void DoOpenEG(object obj)
        {
            if (EGPic == "Collapsed")
                EGPic = "Visible";
            else
                EGPic = "Collapsed";
            NotifyPropertyChanged("EGPic");
        }

        private void DoNewGame(object obj)
        {
            if (!IsQuestionMode)
                return;
            DoAnswerBut(0);
            //new Thread(new ThreadStart(() =>   {Thread.Sleep(2000);  })).Start();

            List<int[,]> cards = _logic.GetCard(_groupIndex);

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (i < cards.Count())
                        _cards[j * 6 + i].SetCard(cards[i]);
                    _cards[j * 6 + i].SetVisibility(i < cards.Count());
                    NotifyPropertyChanged("Card" + i + j);
                }
            }

        }

        private void DoSetGroup(object obj)
        {
            //if (!base.IsQuestionMode)
            //    return;
            _groups[_groupIndex].Background = string.Empty;
            NotifyPropertyChanged("GroupBut" + _groupIndex);
            _groupIndex = _groupDic[obj.ToString()];
            _groups[_groupIndex].Background = System.AppDomain.CurrentDomain.BaseDirectory +
                @"\Resources\Number\" + obj + "b.png";
            NotifyPropertyChanged("GroupBut" + _groupIndex);
        }
        private void DoSetPlayer(object obj)
        {
            if (!base.IsQuestionMode)
                return;
            if (obj.ToString()=="1")
            {
                BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
   @"Resources\Game\UCPuzzle25\card.png";
                PlayerBut2 = string.Empty;
                PlayerBut1 = System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\Number\1b.png";
                BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
              @"Resources\Game\UCPuzzle25\UCPuzzle1.jpg";
                VisibilityCard = "Collapsed";
                RowSpanCard = "3";
                RowCard = "6";
            }
            else
            {
                BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
   @"Resources\Game\UCPuzzle25\card.png";
                PlayerBut1 =  string.Empty;
                PlayerBut2 = System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\Number\2b.png";
                BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\Game\UCPuzzle25\UCPuzzle2.jpg";
                VisibilityCard  = "Visible";
                RowSpanCard = "2";
                RowCard     = "8";
            }
            NotifyPropertyChanged("VisibilityCard");
            NotifyPropertyChanged("RowSpanCard");
            NotifyPropertyChanged("RowCard");
            NotifyPropertyChanged("BackgroundPic");
            NotifyPropertyChanged("PlayerBut1");
            NotifyPropertyChanged("PlayerBut2");
        }
        void IPageVM.load()
        {
            PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory +
                 @"Resources\Audio\He\Title\Puzzle25.wav");
            EGPic = "Collapsed";
            NotifyPropertyChanged("EGPic");
            base.Settings();
            DoSetPlayer(2);
            _groupIndex = 0;
            DoSetGroup(1);
           DoNewGame(0);
            base.IsQuestionMode = false;
            DoAnswerBut(0);
        }

        void IPageVM.disload()
        {
            _groups[_groupIndex].Background = string.Empty;
            NotifyPropertyChanged("GroupBut" + _groupIndex);
        }
    }
}
