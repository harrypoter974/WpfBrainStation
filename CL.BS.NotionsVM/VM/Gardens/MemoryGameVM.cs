using BS.Items;
using BS.Items.Properties;
using CL.BS.Contract;
using CL.BS.MEF;
using CL.BS.Model;
using CL.BS.NotionsManager.Interface;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CL.BS.NotionsVM.VM.Gardens
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class MemoryGameVM : BaseLernPage, IPageVM
    {
        public string BackgroundGrope { get; set; }
        public string NumCardBut0 { get { return Buts[0].Background; } set { Buts[0].Background = value; } }
        public string NumCardBut1 { get { return Buts[1].Background; } set { Buts[1].Background = value; } }
        public string NumCardBut2 { get { return Buts[2].Background; } set { Buts[2].Background = value; } }
        public string NumCardBut3 { get { return Buts[3].Background; } set { Buts[3].Background = value; } }
        public string NumCardBut4 { get { return Buts[4].Background; } set { Buts[4].Background = value; } }
        protected SoldierObject[] Buts = new SoldierObject[5];
        public string BackgroundNewGame { get; set; }
        //public string BackgroundPic { get; set; }
        public string TBTimerColor { get; set; }
        public string OpenMenuBut { get; set; }
        public string TBTimer { get; set; }
        public bool gameRun { get; set; }
        public ICommand SetCardNum { get; set; }
        public ICommand SetGrope { get; set; }
        public ICommand NewGame { get; set; }
        public ICommand OpenMenu { get; set; }
        public ICommand TapAnswer { get; set; }
        public string TimerVisibility { get; set; }
        private List<LetterObject> _list;

        private int _gropeIndex = 0, _CurrentQuestion=0;
        private int _numIndex = 0;
        //private int[] _nums = new int[] { 4, 6, 8 };
        private IMemoryGameManager _logic = (IMemoryGameManager)
SupportHandlerManager.Base.GetManager("MemoryGameManager");
        public override string Name => nameof(MemoryGameVM) ;

        public MemoryGameVM()
        {
            for (int i = 0; i < SoldierList.Length; i++)
                SoldierList[i] = new LetterObject();
            for (int i = 0; i < Images.Length; i++)
                Images[i] = new LetterObject();
            for (int i = 0; i < Buts.Length; i++)
                Buts[i] = new SoldierObject();
            AnswerBut = new RelayCommand(StopeGame);
            SetCardNum = new RelayCommand(DoSetCardNum);
            SetGrope = new RelayCommand(DoSetGrope);
            NewGame = new RelayCommand(DoNewGame);
            OpenMenu = new RelayCommand(DoOpenMenu);
            OpenHelp= new RelayCommand(DoOpenHelp);
            TapAnswer = new RelayCommand(DoTapAnswer);
        }

        void IPageVM.load()
        {
            //PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory +
            // @"Resources\Audio\He\Title\Memory.wav");
            base.Settings();
            gameRun = true;
            OpenMenuBut = string.Empty;
            BackgroundAnswerButton = System.AppDomain.CurrentDomain.BaseDirectory
         + @"Resources\BS.Items\stopGreenIcon.png";
            NotifyPropertyChanged("gameRun");
            NotifyPropertyChanged("OpenMenuBut");
            NotifyPropertyChanged("BackgroundAnswerButton");

            for (int i = 0; i < SoldierPosition.Length; i++)
            {
                SoldierList[i].visibility = Visibility.Collapsed;
                NotifyPropertyChanged("BaseWinBlink" + i);
                SetSoldierPosition(false, i);
            }

        }

        void IPageVM.disload()
        {
            ResetGame();
        }

        private void DoTapAnswer(object obj)
        {
            if (!Common.StaticVar.isTimerRedRun)
                return;
            string a=obj.ToString();
            int p = int.Parse(a[0].ToString());
            int an = int.Parse(a[1].ToString());
            bool b = (_gropeIndex == 0 ? Images[an + 8].Background : Images[an + 8].Text) ==
                Images[_CurrentQuestion].Uid;
            if (b)
            {
                Common.StaticVar.isTimerRedRun = false;
              bool isEnd= SetSoldierPosition(b, p);
                if (isEnd)
                {
                    new Thread(new ThreadStart(() =>
                    {
                        SoldierList[p].visibility = Visibility.Visible;
                    NotifyPropertyChanged("BaseWinBlink" + p);
                    PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Audio\EndWin.wav");
                    WaitTimerRun(2 );
                    StopeGame(0);
                    })).Start();
                }
            }
        }

        private void DoOpenHelp(object obj)
       {
     //       if (BackgroundPic.Contains("Instructions.jpg"))
     //       {
     //           BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory
     //             + @"Resources\Notions\Memory\Board" + (_gropeIndex == 0 ? "Animal" : "Letter") + ".jpg";
     //       }
     //       else
     //       {
     //           BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory
     //+ @"Resources\Notions\Memory\Instructions.jpg";
     //       }
     //       NotifyPropertyChanged("BackgroundPic");
     //       TimerVisibility = "Collapsed";
     //       NotifyPropertyChanged("TimerVisibility");
        }

        private void DoOpenMenu(object obj)
        {
            if (_gropeIndex < 2)
                return;
            OpenMenuBut = System.AppDomain.CurrentDomain.BaseDirectory +
     @"Resources\BS.Items\ChooseLetters.jpg";
            NotifyPropertyChanged("OpenMenuBut");
            Window win;
            if(_gropeIndex==2)
             win = new WinHeSettingsLetters("");
            else
                win = new WinEnSettingsLetters();
            win.Closed += Win_Closed;
            win.ShowDialog();
        }

        private void Win_Closed(object sender, EventArgs e)
        {
            OpenMenuBut =  System.AppDomain.CurrentDomain.BaseDirectory +
     @"Resources\BS.Items\GreenButtonNewGame.jpg";
            NotifyPropertyChanged("OpenMenuBut");
        }

        private void DoNewGame(object obj)
        {
            gameRun = false;
            NotifyPropertyChanged("gameRun");
            SetNewGameBut(true);
            TimerVisibility = "Visible";
            NotifyPropertyChanged("TimerVisibility");
            new Thread(new ThreadStart(() =>
            {
                while (!gameRun)
                {
                    _list = _logic.NewGame(_numIndex+4);
                    List<LetterObject> nl = Common.GeneralFunctions.ShuffleList<LetterObject>(_list);
                    for (int i = 0; i < _list.Count()&& !gameRun; i++)
                    {
                        if (_gropeIndex == 0)
                        {
                            Images[i+8].Background = nl[i].Uid;
                        NotifyPropertyChanged("ImageQuestion" + i);
                        }
                        else
                        {
                            Images[i+8].Text = nl[i].Uid;
                            NotifyPropertyChanged("TextQuestion" + i);
                        }
                        Images[i].Uid = _list[i].Uid;
                        Images[i].Background = _list[i].Background;
                        NotifyPropertyChanged("Image" +i);
                        Images[i].Text = _list[i].Text;
                        NotifyPropertyChanged("Text" + i);
                        Images[i].Width = _list[i].Width;
                        NotifyPropertyChanged("Angle" + i);
                    }
                 //   list = Common.GeneralFunctions.ShuffleList<ViewObject>(list);
                    WaitTimerRun(12);
                    if (gameRun)
                        break;
                    for (int i = 0; i < _list.Count()&& !gameRun; i++)
                    {
                        Images[i].Background = System.AppDomain.CurrentDomain.BaseDirectory
              + @"Resources\Notions\Memory\Card" + (_gropeIndex == 0 ? "Animal" : "Letter") + ".png";
                        NotifyPropertyChanged("Image" + i);
                        Images[i].Text = string.Empty;
                        NotifyPropertyChanged("Text" +i);
                    }
                    WaitTimerRun(3);
                    if (gameRun)
                        break;
                    Common.GeneralFunctions logic = new Common.GeneralFunctions();
                    for (int j = 0; j < _list.Count() && !gameRun; j++)
                    {
                        _CurrentQuestion = logic.GetIndex(_list.Count());
                        Images[_CurrentQuestion].Background = System.AppDomain.CurrentDomain.BaseDirectory
              + @"Resources\Notions\Memory\Card" + (_gropeIndex == 0 ? "Animal" : "Letter") + ".png";
                        NotifyPropertyChanged("Image" + _CurrentQuestion);
                        Images[_CurrentQuestion].Text = "?";
                        NotifyPropertyChanged("Text" + _CurrentQuestion);
                        TimerRun(12);
                        if (gameRun)
                            break;
                        Images[_CurrentQuestion].Background = _list[_CurrentQuestion].Background;
                        NotifyPropertyChanged("Image" + _CurrentQuestion);
                        Images[_CurrentQuestion].Text = _list[_CurrentQuestion].Text;
                        NotifyPropertyChanged("Text" + _CurrentQuestion);
                        WaitTimerRun(12);
                        if (gameRun)
                            break;
                    }
                    for (int i = 0; i < _list.Count(); i++)
                    {
                        Images[i].Background = string.Empty;
                        NotifyPropertyChanged("Image" + i);
                        Images[i].Text = string.Empty;
                        NotifyPropertyChanged("Text" + i);
                    }
                }
                SetNewGameBut(false);
                gameRun = true;
                NotifyPropertyChanged("gameRun");
            })).Start();

        }

        private void DoSetGrope(object obj)
        {
            _gropeIndex = int.Parse(obj.ToString());
            BackgroundGrope = _logic.SetGrope(_gropeIndex);
            NotifyPropertyChanged("BackgroundGrope");
            if (_gropeIndex > 1)
            {
                OpenMenuBut = System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\BS.Items\GreenButtonNewGame.jpg";
            }
            else
                OpenMenuBut = string.Empty;
            NotifyPropertyChanged("OpenMenuBut");
        }

        private void DoSetCardNum(object obj)
        {
            Buts[_numIndex].Background = string.Empty;
            NotifyPropertyChanged("NumCardBut" + _numIndex);
            _numIndex = int.Parse(obj.ToString());
            Buts[_numIndex].Background = System.AppDomain.CurrentDomain.BaseDirectory
                + @"Resources\Number\" +( _numIndex+4) + "b.png"; 
            NotifyPropertyChanged("NumCardBut" + _numIndex);
        }

        private void StopeGame(object obj)
        {
            if (BackgroundNewGame != string.Empty)
            {
                ResetGame();
                for (int i = 0; i < Images.Count()/2; i++)
                {   
                    Images[i+8].Text =Images[i+8].Background = Images[i].Text =Images[i].Background = string.Empty;
                    NotifyPropertyChanged("Image" + i);
                    NotifyPropertyChanged("ImageQuestion" + i);
                    NotifyPropertyChanged("TextQuestion" + i);
                    NotifyPropertyChanged("Text" + i);
                }
            }
        }

        private void ResetGame()
        {
            gameRun = true;
            NotifyPropertyChanged("gameRun");
            SetNewGameBut(false);
            for (int i = 0; i < SoldierPosition.Length; i++) {
                SetSoldierPosition(false, i);
                SoldierList[i].visibility = Visibility.Collapsed;
                NotifyPropertyChanged("BaseWinBlink" + i);
            }
        }

        private void SetNewGameBut(bool IsNewGame)
        {
            if (IsNewGame)
            {
                BackgroundNewGame = System.AppDomain.CurrentDomain.BaseDirectory
                + @"Resources\BS.Items\buttonNewGame.png";
                BackgroundAnswerButton = System.AppDomain.CurrentDomain.BaseDirectory
               + @"Resources\BS.Items\stopRedIcon.png";
            }
            else
            {
                BackgroundAnswerButton = System.AppDomain.CurrentDomain.BaseDirectory
               + @"Resources\BS.Items\stopGreenIcon.png";
                BackgroundNewGame = string.Empty;
                TBTimer = "0";
                NotifyPropertyChanged("TBTimer");
            }
            NotifyPropertyChanged("BackgroundNewGame");
            NotifyPropertyChanged("BackgroundAnswerButton");
        }
        #region Timer
        public void WaitTimerRun(int waitTime = 12)
        {
            TBTimerColor = System.AppDomain.CurrentDomain.BaseDirectory
                        + @"Resources\BS.Items\UCTimerOrange.png";
            NotifyPropertyChanged("TBTimerColor");
            TBTimer = "45,0";
            NotifyPropertyChanged("TBTimer");

            string point = "45,0";
            for (double time = 0; !gameRun && time < 361; time++)
            {
                Thread.Sleep(3 * waitTime);
                point += " " + (45 + 45 * Math.Sin(time / 45.0)) + ',' + (45 - 45 * Math.Cos(time / 45.0));
                TBTimer = point;
                NotifyPropertyChanged("TBTimer");
            }
        }
        public void TimerRun(int timeWate)
        {
            Common.StaticVar.isTimerRedRun = true;
            TBTimerColor = System.AppDomain.CurrentDomain.BaseDirectory
                        + @"Resources\BS.Items\UCTimerGreen.png";
            NotifyPropertyChanged("TBTimerColor");
            string point = "45,0";
            for (double time = 0; !gameRun && Common.StaticVar.isTimerRedRun && time < 361; time += 3)
            {
                Thread.Sleep(9 * timeWate);
                point += " " + (45 + 45 * Math.Sin(time / 45.0)) + ',' + (45 - 45 * Math.Cos(time / 45.0));
                TBTimer = point;
                NotifyPropertyChanged("TBTimer");
            }
            Common.StaticVar.isTimerRedRun = false;
        }

        #endregion Timer
        #region Image List
        public string Image0  { get { return Images[0].Background; }   set{ Images[0].Background = value; } }
        public string Image1  { get { return Images[1].Background ;}   set{ Images[1].Background = value; } }
        public string Image2  { get { return Images[2].Background ;}   set{ Images[2].Background = value; } }
        public string Image3  { get { return Images[3].Background ;}   set{ Images[3].Background = value; } }
        public string Image4  { get { return Images[4].Background ;}   set{ Images[4].Background = value; } }
        public string Image5  { get { return Images[5].Background ;}   set{ Images[5].Background = value; } }
        public string Image6  { get { return Images[6].Background ;}   set{ Images[6].Background = value; } }
        public string Image7  { get { return Images[7].Background ;}   set{ Images[7].Background = value; } }



        public string Text0  { get { return Images[0].Text;   } set { Images[0].Text = value; } }
        public string Text1  { get { return Images[1].Text;   } set { Images[1].Text = value; } }
        public string Text2  { get { return Images[2].Text;   } set { Images[2].Text = value; } }
        public string Text3  { get { return Images[3].Text;   } set { Images[3].Text = value; } }
        public string Text4  { get { return Images[4].Text;   } set { Images[4].Text = value; } }
        public string Text5  { get { return Images[5].Text;   } set { Images[5].Text = value; } }
        public string Text6  { get { return Images[6].Text;   } set { Images[6].Text = value; } }
        public string Text7  { get { return Images[7].Text;   } set { Images[7].Text = value; } }

        public string ImageQuestion0 { get { return Images[8].Background; } set { Images[8].Background = value; } }
        public string ImageQuestion1 { get { return Images[9].Background; } set { Images[9].Background = value; } }
        public string ImageQuestion2 { get { return Images[10].Background; } set { Images[10].Background = value; } }
        public string ImageQuestion3 { get { return Images[11].Background; } set { Images[11].Background = value; } }
        public string ImageQuestion4 { get { return Images[12].Background; } set { Images[12].Background = value; } }
        public string ImageQuestion5 { get { return Images[13].Background; } set { Images[13].Background = value; } }
        public string ImageQuestion6 { get { return Images[14].Background; } set { Images[14].Background = value; } }
        public string ImageQuestion7 { get { return Images[15].Background; } set { Images[15].Background = value; } }
        public string TextQuestion0 { get { return Images[8].Text; } set { Images[8].Text = value; } }
        public string TextQuestion1 { get { return Images[9].Text; } set { Images[9].Text = value; } }
        public string TextQuestion2 { get { return Images[10].Text; } set { Images[10].Text = value; } }
        public string TextQuestion3 { get { return Images[11].Text; } set { Images[11].Text = value; } }
        public string TextQuestion4 { get { return Images[12].Text; } set { Images[12].Text = value; } }
        public string TextQuestion5 { get { return Images[13].Text; } set { Images[13].Text = value; } }
        public string TextQuestion6 { get { return Images[14].Text; } set { Images[14].Text = value; } }
        public string TextQuestion7 { get { return Images[15].Text; } set { Images[15].Text = value; } }
        public int Angle0  { get { return  Images[0].Width; } set {  Images[0].Width = value; } }
        public int Angle1  { get { return  Images[1].Width; } set {  Images[1].Width = value; } }
        public int Angle2  { get { return  Images[2].Width; } set {  Images[2].Width = value; } }
        public int Angle3  { get { return  Images[3].Width; } set {  Images[3].Width = value; } }
        public int Angle4  { get { return  Images[4].Width; } set {  Images[4].Width = value; } }
        public int Angle5  { get { return  Images[5].Width; } set {  Images[5].Width = value; } }
        public int Angle6  { get { return  Images[6].Width; } set {  Images[6].Width = value; } }
        public int Angle7  { get { return  Images[7].Width; } set {  Images[7].Width = value; } }
      
        protected LetterObject[] Images = new LetterObject[16];
        #endregion
        #region Soldier

        private bool SetSoldierPosition(bool ToUper,int player)
        {//He bring's the soldier up if he win's the game and in the new square he starts a new game.
            SoldierPosition[player] = !ToUper ? 0 :
           SoldierList.Length - 1 == SoldierPosition[player] ? SoldierList.Length - 1 : SoldierPosition[player] + 1;
            bool b = SoldierPosition[player] == 4;
            for (int i = 0; i <5; i++)
            {
                if (i == SoldierPosition[player])
                {
                    SoldierList[i+5*player].Background =
                    System.AppDomain.CurrentDomain.BaseDirectory +
                   @"Resources\Pion\" + "CBDA"[player] + ".png";
                }
                else
                {
                    SoldierList[i + 5 * player].Background = string.Empty;
                }
                NotifyPropertyChanged("TBSoldier" + player+ i);
            }
            return b;
        }
        private int [] SoldierPosition=new int[4];

        public Visibility BaseWinBlink0 { get { return SoldierList[0].visibility; } set { SoldierList[0].visibility = value; } }
        public Visibility BaseWinBlink1 { get { return SoldierList[1].visibility; } set { SoldierList[1].visibility = value; } }
        public Visibility BaseWinBlink2 { get { return SoldierList[2].visibility; } set { SoldierList[2].visibility = value; } }
        public Visibility BaseWinBlink3 { get { return SoldierList[3].visibility; } set { SoldierList[3].visibility = value; } }
    
        public string TBSoldier00 { get { return SoldierList[0].Background; } set { SoldierList[0].Background = value; } }
        public string TBSoldier01 { get { return SoldierList[1].Background; } set { SoldierList[1].Background = value; } }
        public string TBSoldier02 { get { return SoldierList[2].Background; } set { SoldierList[2].Background = value; } }
        public string TBSoldier03 { get { return SoldierList[3].Background; } set { SoldierList[3].Background = value; } }
        public string TBSoldier04 { get { return SoldierList[4].Background; } set { SoldierList[4].Background = value; } }

        public string TBSoldier10 { get { return SoldierList[5].Background; } set { SoldierList[5].Background = value; } }
        public string TBSoldier11 { get { return SoldierList[6].Background; } set { SoldierList[6].Background = value; } }
        public string TBSoldier12 { get { return SoldierList[7].Background; } set { SoldierList[7].Background = value; } }
        public string TBSoldier13 { get { return SoldierList[8].Background; } set { SoldierList[8].Background = value; } }
        public string TBSoldier14 { get { return SoldierList[9].Background; } set { SoldierList[9].Background = value; } }

        public string TBSoldier20 { get { return SoldierList[10].Background; } set { SoldierList[10].Background = value; } }
        public string TBSoldier21 { get { return SoldierList[11].Background; } set { SoldierList[11].Background = value; } }
        public string TBSoldier22 { get { return SoldierList[12].Background; } set { SoldierList[12].Background = value; } }
        public string TBSoldier23 { get { return SoldierList[13].Background; } set { SoldierList[13].Background = value; } }
        public string TBSoldier24 { get { return SoldierList[14].Background; } set { SoldierList[14].Background = value; } }
     
        public string TBSoldier30 { get { return SoldierList[15].Background; } set { SoldierList[15].Background = value; } }
        public string TBSoldier31 { get { return SoldierList[16].Background; } set { SoldierList[16].Background = value; } }
        public string TBSoldier32 { get { return SoldierList[17].Background; } set { SoldierList[17].Background = value; } }
        public string TBSoldier33 { get { return SoldierList[18].Background; } set { SoldierList[18].Background = value; } }
        public string TBSoldier34 { get { return SoldierList[19].Background; } set { SoldierList[19].Background = value; } }


        protected LetterObject[] SoldierList = new LetterObject[20];
        #endregion Soldier
    }
}
