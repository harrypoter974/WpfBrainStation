using BS.BingoBoard.VM;
using CL.BS.Contract;
using CL.BS.MEF;
using CL.BS.Model;
using CL.BS.NotionsManager.Interface;
using CL.BS.NotionsVM.VM.General.Prepositions;
using CL.BS.VMCommon;
using CL.BS.VMCommon.Mice;
using System;
using System.Threading;
using System.Windows.Input;

namespace CL.BS.NotionsVM.VM.General
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class HePrepositionsVM : BaseLernPage, IPageVM
    {
        private IHePrepositionsManager _logic = (IHePrepositionsManager)
SupportHandlerManager.Base.GetManager("HePrepositionsManager");
        protected IMiceManager MiceLogic = new TouchManager();//MiceManager  ;
        private string[] _playList = new string[0];
        public override string Name =>nameof(HePrepositionsVM) ;
        public ICommand StartGame { get; set; }
        public ICommand SwitchLanguage { get; set; }
        public ICommand OpenInstructions { get; set; }
        public BoardPrepositionsVM BoardPrepositions { get; set; }
        public ICommand SetTime { get; set; }
        public ICommand RePlay { get; set; }
        private int _playerIndex =0; 
        public bool NotGameRun { get; set; }
        public double BoardHeight { get; set; }
        public double BoardWidth { get; set; }
        public string BackgroundNewGame { get; set; }
        private string[] MiceName = new string[] { "A", "D", "C", "B" };
        protected string Timer = "12";
        protected int TimerIndex = 3;
        protected string[] TimerList;
        public string TBTimer { get; set; }
        public string TBTimerColor { get; set; }
        public double AnglePic { get; set; }
        public string LanguageBut0 { get { return LanguageBut[0].Background; } set { LanguageBut[0].Background = value; } }
        public string LanguageBut1 { get { return LanguageBut[1].Background; } set { LanguageBut[1].Background = value; } }
        public string LanguageBut2 { get { return LanguageBut[2].Background; } set { LanguageBut[2].Background = value; } }
        protected SoldierObject[] LanguageBut = new SoldierObject[3];
        public string TimerBut0 { get { return TimerBut[0].Background; } set { TimerBut[0].Background = value; } }
        public string TimerBut1 { get { return TimerBut[1].Background; } set { TimerBut[1].Background = value; } }
        public string TimerBut2 { get { return TimerBut[2].Background; } set { TimerBut[2].Background = value; } }
        public string TimerBut3 { get { return TimerBut[3].Background; } set { TimerBut[3].Background = value; } }

        protected SoldierObject[] TimerBut = new SoldierObject[4];
        public TrafficLightsBoardVM Board0 { get { return Boards[0]; } set { Boards[0] = value; } }
        public TrafficLightsBoardVM Board1 { get { return Boards[1]; } set { Boards[1] = value; } }
        public TrafficLightsBoardVM Board2 { get { return Boards[2]; } set { Boards[2] = value; } }
        public TrafficLightsBoardVM Board3 { get { return Boards[3]; } set { Boards[3] = value; } }
        public TrafficLightsBoardVM[] Boards = new TrafficLightsBoardVM[4];
        private BoardPrepositionsVM[] BordPic =new BoardPrepositionsVM[] {
            new BoardPrepositionsVM1(), new BoardPrepositionsVM2(),new BoardPrepositionsVM3(),new BoardPrepositionsVM4() };
      
        public HePrepositionsVM()
        {
            for (int i = 0; i < LanguageBut.Length; i++)
                LanguageBut[i] = new SoldierObject();
            AnswerBut = new RelayCommand(StopGame);
            StartGame = new RelayCommand(DoStartGame);
            SwitchLanguage = new RelayCommand(DoSwitchLanguage);
            for (int i = 0; i < Boards.Length; i++) {
                Boards[i] = new TrafficLightsBoardVM(i,3, MiceName[i]);
                BordPic[i].SetMice(MiceLogic);
                TimerBut[i] = new SoldierObject();
            }
            SetTime = new RelayCommand(DoSetTime);
            TimerList = new string[] { "3", "6", "9", "12" };
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.139;
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.191;
            NotifyPropertyChanged("BoardWidth");
            NotifyPropertyChanged("BoardHeight");
            LanguageBut[0].Background = System.AppDomain.CurrentDomain.BaseDirectory +
        @"Resources\Notions\Animals\AnimalStitle0.png";
            NotifyPropertyChanged("LanguageBut0");
        }

        private void DoStartGame(object obj)
        {
            new Thread(new ThreadStart(() =>
            {
                BackgroundNewGame = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\BS.Items\buttonNewGame.png";
                BackgroundAnswerButton = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\BS.Items\stopRedIcon.png";
                NotifyPropertyChanged("BackgroundAnswerButton");
                NotifyPropertyChanged("BackgroundNewGame");
                NotGameRun = false;
                NotifyPropertyChanged("NotGameRun");
                while (!NotGameRun)
                {
                    while (Common.StaticVar.PlayMode)
                        Thread.Sleep(100);
                    _playList = _logic.GetQuestion();
                    PlayList(_playList);
                    BoardPrepositions = BordPic[int.Parse(_playList[0])];
                    BoardPrepositions.SetMiceName(MiceName[_playerIndex]);
                    AnglePic = new int[] { 0, 1, 2, 3 }[_playerIndex] * 90;
                    for (int i = 0; i < Boards.Length; i++)
                        Boards[i].SetBoardPic(_playerIndex);
                    NotifyPropertyChanged("BoardPrepositions");
                    NotifyPropertyChanged("AnglePic");
                    while (Common.StaticVar.PlayMode)
                        Thread.Sleep(100);
                    BoardPrepositions.AnswerIndex = string.Empty;
                    if (BoardPrepositions == null)
                        return;
                    TimerRun();
                    if (BoardPrepositions != null)
                    {
                        if (BoardPrepositions.AnswerIndex == _logic.GetAnswer())
                        {
                            if (Boards[_playerIndex].SetSoldierPosition(true))
                            {
                                PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Audio\EndWin.wav");
                                Boards[_playerIndex].GameWin();
                                break;
                            }
                        }
                    }
                    TBTimer = string.Empty;
                    NotifyPropertyChanged("TBTimer");
                    _playerIndex = _playerIndex == 3 ? 0 : _playerIndex + 1;
                }
                ResetGame();
            })).Start();
        }

        protected void DoSetTime(object obj)
        {
            //set time of question
            string num = obj.ToString();
            if ((MiceLogic.IsMouseRotation() || num == "-1") && num != "0")
            {
                num = num == "-1" ? "1" : num;
                TimerBut[TimerIndex].Background = string.Empty;
                NotifyPropertyChanged("TimerBut" + TimerIndex);
                int ti = int.Parse(num);
                TimerBut[0].Background = System.AppDomain.CurrentDomain.BaseDirectory
                    + @"Resources\BS.Items\TimerControl" + num + ".png";
                NotifyPropertyChanged("TimerBut0");
                Timer = TimerList[ti];
                TimerIndex = ti;
            }
        }


        public void TimerRun()
        {
            Common.StaticVar.isTimerRedRun = true;
            TBTimerColor = System.AppDomain.CurrentDomain.BaseDirectory
                        + @"Resources\BS.Items\UCTimerGreen.png";
            NotifyPropertyChanged("TBTimerColor");
            int timeWate = int.Parse(Timer);
            string point = "45,0";


            for (double time = 0; Common.StaticVar.isTimerRedRun && time < 361; time += 3)
            {
                if (BoardPrepositions != null)
                {
                    if (BoardPrepositions.AnswerIndex != string.Empty || NotGameRun)
                        return;
                }
                else
                    return;
                Thread.Sleep(9 * timeWate);
                point += " " + (45 + 45 * Math.Sin(time / 45.0)) + ',' + (45 - 45 * Math.Cos(time / 45.0));
                TBTimer = point;
                NotifyPropertyChanged("TBTimer");

            }
                Common.StaticVar.isTimerRedRun = false;
           
        }
        private void DoSwitchLanguage(object obj)
        {
            _logic.SwitchLanguage(obj);
            string lan = obj.ToString();
            for (int l = 0; l < LanguageBut.Length; l++)
            {
                LanguageBut[l].Background = lan == l.ToString() ? System.AppDomain.CurrentDomain.BaseDirectory +
                  @"Resources\Notions\Animals\AnimalStitle" + l + ".png" : string.Empty;
                NotifyPropertyChanged("LanguageBut" + l);
            }
        }
        private void DoRePlay(object obj)
        {
            if (!base.IsQuestionMode)
                PlayList(_playList);
        }
        private void StopGame(object obj)
        {
            NotGameRun = true;
            NotifyPropertyChanged("NotGameRun");
        }

        private void ResetGame()
        {
            NotGameRun = true;
            NotifyPropertyChanged("NotGameRun");
            BackgroundNewGame = BackgroundAnswerButton = string.Empty;
            NotifyPropertyChanged("BackgroundAnswerButton");
            NotifyPropertyChanged("BackgroundNewGame");
            BoardPrepositions =null;
            NotifyPropertyChanged("BoardPrepositions");
            for (int i = 0; i < Boards.Length; i++)
                Boards[i].SetSoldierPosition(false);
        }

        void IPageVM.load()
        {  
            DoSetTime(-1);
            base.Settings();
            ResetGame();
            MiceLogic.Run();
            MiceLogic.NewMouseSplitter();
            Common.MiceKiller.KillAllMices(true);          
        }

        void IPageVM.disload()
        {
            MiceLogic.OnClosing();
            MiceLogic.Close();
            MiceLogic.Dispose();
            Common.MiceKiller.KillAllMices(false);
        }
    }
}   