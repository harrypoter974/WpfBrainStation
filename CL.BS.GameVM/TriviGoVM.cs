using BS.BingoBoard.VM;
using CL.BS.Contract;
using CL.BS.GameManager.Engen;
using CL.BS.GameManager.Interface;
using CL.BS.MEF;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;

namespace CL.BS.GameVM
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class TriviGoVM : BaseCubeGameVM, IPageVM
    {
        private ITriviaManager _logic = (ITriviaManager)
SupportHandlerManager.Base.GetManager("TriviaManager");
        public string TimerVisibility0 { get { return SoldierList[0].Uid; } set { SoldierList[0].Uid = value; } }
        public string TimerVisibility1 { get { return SoldierList[1].Uid; } set { SoldierList[1].Uid = value; } }
        public string TimerVisibility2 { get { return SoldierList[2].Uid; } set { SoldierList[2].Uid = value; } }
        public string TimerVisibility3 { get { return SoldierList[3].Uid; } set { SoldierList[3].Uid = value; } }

        private Dictionary<int, int>[] _hotSquare = new Dictionary<int, int>[3];

        private int[][,] _SoldierStep = new int[3][,];
        private int[] SoldierOrbit = new int[] { 0, 0, 0, 0 };
        private triviaQuestion _question;
        public override string Name => nameof(TriviGoVM);
        public TriviGoVM()
        {
            Timer = "12";
            for (int i = 0; i < Boards.Length; i++)
            {
                Boards[i] = new TriviaBoardVM(MiceName[i]);
                SoldierList[i].Uid = "Collapsed";
                NotifyPropertyChanged("TimerVisibility" + i);
            }
            _SoldierStep[0] = new int[,] { {7,41 }, {9,41 }, { 10, 41 }, { 10, 38 }, {10, 36 },
        { 11, 36 } , { 13, 36 }, { 15, 36 }, { 16, 36 }, { 17, 36 }, { 19, 36 }, { 20, 36 }, { 23, 36 }, { 26, 36 }
        ,  { 27, 36 }, { 30, 36 }, { 32, 36 }, { 34, 36 }, { 37, 36 }, { 38, 36 }, { 39, 36 }
        , { 42, 36 }, { 43, 36}, { 44, 36}, { 46, 36}, { 48, 36}, { 51, 36 }, { 54, 36 }, { 54, 35 }
       , { 54, 31 } , { 54, 29 }, { 54, 27 }, { 54, 24 }, { 54, 23 }, { 54, 20 }, { 54, 18 }, { 54,16}
       , { 54,12}, { 54,10}, {54,8}, { 51,8},{ 48,8},{ 46,8},{ 44,8},{ 43,8},{42,8}
        ,{ 39,8},{ 38,8},{37,8},{34,8},{32,8},{30,8},{27,8},{26,8},{23,8},{20,8},{19,8}
        ,{17,8},{16,8},{15,8},{13,8},{11,8},{10,8},{9,8},{8,8},{8,10},{8,12},{8,16},{8,18}
               ,{8,20},{8,23},{8,24},{8,27},{8,29}  ,{8,31},{8,35},{8,36},{9,36}};
            _SoldierStep[1] = new int[,] {{ 13, 31 }, { 15, 31 }, {16, 31},{17,31},{ 19,31},
 { 20, 31 }, { 23, 31 }, { 26, 31 } , {27,31}, { 30,31}, { 32, 31 }, {34,31},
 {37,31}, {38,31} , {39,31}, { 42,31}, { 43,31}, {44,31}, {46,31}, {48,31},
 { 48,29}, { 48, 27}, {48,24}, {48,23}, {48,20}, { 48,18}, { 48,16},{48,12 }
 ,{46,12 },{44,12},{43,12},{42,12},{39,12},{38,12 },{37,12},{34,12}
,{32,12},{30,12},{27,12},{26,12},{23,12},{20,12},{19,12},{17,12},{16,12}
 ,{15,12},{13,12},{11,12},{10,12},{10,16} ,{10,18 }, {10,20 }, { 10,23}, { 10, 24 }
   ,{10,27 } , { 10, 29 }, { 10, 31 }, { 11, 31 } };
            _SoldierStep[2] = new int[,] { {44,18 }, {43,18}, { 42,18}, { 39, 18},{ 38,18}
 , { 37, 18}, {34, 18}, {32,18}, { 30,18}, { 27,18}, { 26,18}, { 23,18}, { 20,18}, { 19,18}
 , { 17,18}, { 16,18}, { 15,18}, { 13,18}, { 13, 20 }, { 13, 23}, { 13, 24},{13, 27}
, { 15, 27 }, { 16, 27 }, { 17, 27 }, { 19, 27 }, { 20, 27 }, { 23, 27 }, { 26, 27 },
 { 27, 27 }, { 30, 27 }, { 32, 27}, { 34,27}, {37,27}, {38,27}, { 39,27}, { 42,27}
 ,{43, 27 },{44,27},{44,24},{44, 23 },{43, 23 },{42,23},{39,23},{38,23}
,{37,23},{34,23},{32,23},{30,23},{27,23},{26,23},{23,23},{20,23},{19,23},{16,23}};
            #region dic0
            _hotSquare[0] = new Dictionary<int, int>();
            _hotSquare[0].Add(6, 0);
            _hotSquare[0].Add(8, 2);
            _hotSquare[0].Add(10, 4);
            _hotSquare[0].Add(12, 6);
            _hotSquare[0].Add(13, 7);
            _hotSquare[0].Add(16, 10);
            _hotSquare[0].Add(18, 12);
            _hotSquare[0].Add(20, 14);
            _hotSquare[0].Add(22, 16);
            _hotSquare[0].Add(24, 18);
            _hotSquare[0].Add(30, 20);
            _hotSquare[0].Add(31, 21);
            _hotSquare[0].Add(34, 24);
            _hotSquare[0].Add(35, 25);
            _hotSquare[0].Add(37, 27);
            _hotSquare[0].Add(42, 28);
            _hotSquare[0].Add(44, 30);
            _hotSquare[0].Add(46, 32);
            _hotSquare[0].Add(49, 35);
            _hotSquare[0].Add(52, 38);
            _hotSquare[0].Add(55, 41);
            _hotSquare[0].Add(57, 43);
            _hotSquare[0].Add(59, 45);
            _hotSquare[0].Add(61, 47);
            _hotSquare[0].Add(68, 50);
            _hotSquare[0].Add(71, 53);
            _hotSquare[0].Add(73, 55);
            #endregion
            #region dic1
            _hotSquare[1] = new Dictionary<int, int>();
            _hotSquare[1].Add(1, 22);
            _hotSquare[1].Add(3, 24);
            _hotSquare[1].Add(5, 26);
            _hotSquare[1].Add(9, 30);
            _hotSquare[1].Add(11, 32);
            _hotSquare[1].Add(13, 34);
            _hotSquare[1].Add(15, 36);
            _hotSquare[1].Add(22, 39);
            _hotSquare[1].Add(29, 0);
            _hotSquare[1].Add(34, 5);
            _hotSquare[1].Add(37, 8);
            _hotSquare[1].Add(40, 11);
            _hotSquare[1].Add(42, 13);
            _hotSquare[1].Add(44, 15);
            _hotSquare[1].Add(52, 19);
            #endregion
            #region dic2
            _hotSquare[2] = new Dictionary<int, int>();
            _hotSquare[2].Add(3, 32);
            _hotSquare[2].Add(6, 35);
            _hotSquare[2].Add(10, 39);
            _hotSquare[2].Add(18, 51);
            _hotSquare[2].Add(28, 7);
            _hotSquare[2].Add(38, 17);
            _hotSquare[2].Add(41, 1);
            _hotSquare[2].Add(43, 35);
            _hotSquare[2].Add(47, 7);
            _hotSquare[2].Add(49, 29);
            _hotSquare[2].Add(52, 12);
            #endregion
            //  TapAnswer = new RelayCommand(DoTapAnswer);
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.509;
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.434;
            NotifyPropertyChanged(nameof(BoardWidth));
            NotifyPropertyChanged(nameof(BoardHeight));
            AnswerBut = new RelayCommand(StopGame);
            NextStep = new RelayCommand(DoNextStep);
            NewGame = new RelayCommand(Start_Game);//

        }

        private void StopGame(object obj)
        {
            base.DoExitBut(0);
            if (!gameRun)
            {
                gameRun = true;
                NotifyPropertyChanged(nameof(gameRun));
            }
        }
        private void Start_Game(object obj)
        {
            if (RunGame)
                ResatGame();
            else
            {
                new Thread(new ThreadStart(() =>
                {
                    base.SetNewGameBut(true);
                    RunGame = true;
                    gameRun = false;
                    NotifyPropertyChanged(nameof(gameRun));
                    IsQuestion = false;
                    BackgroundNewGame = System.AppDomain.CurrentDomain.BaseDirectory
                + @"Resources\BS.Items\buttonNewGame.png";
                    NotifyPropertyChanged(nameof(BackgroundNewGame));
                    int max = 0;
                    StartSum = new int[] { 0, 0, 0, 0 };
                    for (TurnInxex = 0; TurnInxex < StartSum.Length; TurnInxex++)
                    {
                        Soldier = SoldierTurn[TurnInxex];
                        if (!RunGame)
                            return;
                        int[] num = ((TriviaBoardVM)Boards[Soldier]).DoNextStep();
                        StartSum[TurnInxex] = num[0] + num[1];
                        if (StartSum[TurnInxex] > max)
                            max = StartSum[TurnInxex];
                        if (!RunGame)
                            return;
                    }
                    WhitTime(6000, ref RunGame);
                    TurnInxex = -1;
                    for (int i = 0; i < StartSum.Length; i++)
                    {
                        if (StartSum[i] == max & TurnInxex == -1)
                        {
                            TurnInxex = i;
                            Soldier = SoldierTurn[TurnInxex];
                        }
                        else
                        {

                            int t = SoldierTurn[i];
                            Boards[t].Clear();
                        }
                    }
                    Boards[Soldier].RestartClear();
                    IsStartGame = false;
                })).Start();
            }
        }


        private void DoTapAnswer(object obj)
        {
            if (SoldierList[Soldier].visibility == Visibility.Visible && (MiceLogic.GetMouseRotation() == MiceName[Soldier]
                || !MiceLogic.IsMouse()))
            {
                int a = int.Parse(obj.ToString()[1].ToString());
                //if ((_answerList[a] == _question.Answer[0] && SoldierOrbit[Soldier] != 2) ||
                //    (SoldierOrbit[Soldier] == 2 && _answerList[a] != _question.Answer[0])) 
                {

                    SoldierIndex[Soldier] = _hotSquare[SoldierOrbit[Soldier]][SoldierIndex[Soldier]];
                    SoldierOrbit[Soldier] = SoldierOrbit[Soldier] == 2 ? 2 : SoldierOrbit[Soldier] + 1;
                    SoldierList[Soldier].Width = _SoldierStep[SoldierOrbit[Soldier]][SoldierIndex[Soldier], 0];
                    SoldierList[Soldier].FontSize = _SoldierStep[SoldierOrbit[Soldier]][SoldierIndex[Soldier], 1];
                    NotifyPropertyChanged("SoldierX" + Soldier);
                    NotifyPropertyChanged("SoldierY" + Soldier);
                    SoldierList[Soldier].visibility = Visibility.Collapsed;
                    NotifyPropertyChanged("QuestionVisible" + Soldier);
                }
                base.NextTurn();
                for (int i = 0; i < VisibilityCubeList.Length; i++)
                {
                    VisibilityCubeList[i].Background = Soldier == i ? "Visible" : "Hidden";
                    NotifyPropertyChanged("VisibilityCube" + i);
                }
                if (!string.IsNullOrEmpty(_question.Pic))
                {
                    StepNum0 = System.AppDomain.CurrentDomain.BaseDirectory +
                              @"Resources\Cube\cube0.png";
                    StepNum1 = System.AppDomain.CurrentDomain.BaseDirectory +
                           @"Resources\Cube\cube0.png";
                    NotifyPropertyChanged(nameof(StepNum0));
                    NotifyPropertyChanged(nameof(StepNum1));
                }
                IsQuestion = false;
            }
        }

        private void DoNextStep(object obj)
        {
            if (IsQuestion || IsStartGame || TurnInxex == -1)
                return;
            if (obj.ToString() != Soldier.ToString())
                return;
            new Thread(new ThreadStart(() =>
            {
                if (SoldierOrbit[Soldier] == 2 && SoldierIndex[Soldier] >= _SoldierStep[SoldierOrbit[Soldier]].GetLength(0) - 1)
                {
                    base.NextTurn();
                    return;
                }
                IsQuestion = true;
                int[] num = ((TriviaBoardVM)Boards[Soldier]).DoNextStep();
                WhitTime(500, ref RunGame);
                int preStep = SoldierIndex[Soldier];
                SoldierIndex[Soldier] = SoldierIndex[Soldier] + num[0] + num[1];
                if (_SoldierStep[SoldierOrbit[Soldier]].GetLength(0) - 1 < SoldierIndex[Soldier])
                {
                    for (int i = preStep; i < _SoldierStep[SoldierOrbit[Soldier]].GetLength(0) - 1; i++)
                    {
                        SoldierList[Soldier].Width = _SoldierStep[SoldierOrbit[Soldier]][i, 0];
                        SoldierList[Soldier].FontSize = _SoldierStep[SoldierOrbit[Soldier]][i, 1];
                        NotifyPropertyChanged("SoldierX" + Soldier);
                        NotifyPropertyChanged("SoldierY" + Soldier);
                        Thread.Sleep(120);
                    }
                    if (SoldierOrbit[Soldier] == 0)
                        SoldierIndex[Soldier] = SoldierIndex[Soldier] - _SoldierStep[SoldierOrbit[Soldier]].GetLength(0) + 4;
                    else if (SoldierOrbit[Soldier] == 2)
                    {
                        SoldierIndex[Soldier] = _SoldierStep[SoldierOrbit[Soldier]].GetLength(0);
                        new Thread(new ThreadStart(() =>
                        { Boards[Soldier].GameWin(); })).Start();
                        PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Audio\EndWin.wav");
                        ResatGame();
                    }
                    else
                        SoldierIndex[Soldier] = SoldierIndex[Soldier] - _SoldierStep[SoldierOrbit[Soldier]].GetLength(0) + 1;

                    if (SoldierOrbit[Soldier] != 2)
                    {
                        for (int i = SoldierOrbit[Soldier] == 0 ? 4 : 0; i <= SoldierIndex[Soldier]; i++)
                        {
                            SoldierList[Soldier].Width = _SoldierStep[SoldierOrbit[Soldier]][i, 0];
                            SoldierList[Soldier].FontSize = _SoldierStep[SoldierOrbit[Soldier]][i, 1];
                            NotifyPropertyChanged("SoldierX" + Soldier);
                            NotifyPropertyChanged("SoldierY" + Soldier);
                            WhitTime(250, ref RunGame);
                        }
                    }
                }
                else if (SoldierOrbit[Soldier] == 2 && _SoldierStep[SoldierOrbit[Soldier]].GetLength(0) - 1 <= SoldierIndex[Soldier])
                {
                    new Thread(new ThreadStart(() =>
                    { Boards[Soldier].GameWin(); })).Start();
                    PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Audio\EndWin.wav");
                    SoldierIndex[Soldier] = _SoldierStep[SoldierOrbit[Soldier]].GetLength(0);
                    ResatGame();
                }
                else
                {
                    for (int i = preStep; i <= SoldierIndex[Soldier]; i++)
                    {
                        SoldierList[Soldier].Width = _SoldierStep[SoldierOrbit[Soldier]][i, 0];
                        SoldierList[Soldier].FontSize = _SoldierStep[SoldierOrbit[Soldier]][i, 1];
                        NotifyPropertyChanged("SoldierX" + Soldier);
                        NotifyPropertyChanged("SoldierY" + Soldier);
                        WhitTime(250, ref RunGame);
                    }
                }
                if (!_hotSquare[SoldierOrbit[Soldier]].ContainsKey(SoldierIndex[Soldier]))
                {
                    for (int i = 0; i < VisibilityCubeList.Length; i++)
                    {
                        VisibilityCubeList[i].Background = Soldier == i ? "Visible" : "Hidden";
                        NotifyPropertyChanged("VisibilityCube" + i);
                    }
                }
                else
                {
                    UrlPlay = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Audio\do.wav";
                    _question = _logic.GetTriviaQuestion();
                    ((TriviaBoardVM)Boards[Soldier]).setQuestion(_question);
                    if (!string.IsNullOrEmpty(_question.Adio))
                    {
                        PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory +
                                    (Common.StaticVar.IsGarden ? "" : @"Resources\Game\triva\" + _question.Adio + ".wav"));
                    }
                    SoldierList[Soldier].Uid = "Visible";
                    NotifyPropertyChanged("TimerVisibility" + Soldier);
                    if (TimerBut[0].Background.Contains("TimerControl0.png"))
                    {
                        Common.StaticVar.isTimerRedRun = true;
                        TBTimer = string.Empty;
                        NotifyPropertyChanged("TBTimer"); 
                        TBTimerColor = System.AppDomain.CurrentDomain.BaseDirectory
                        + @"Resources\BS.Items\UCTimerGreen.png";
                        NotifyPropertyChanged("TBTimerColor");
                        while (Common.StaticVar.isTimerRedRun && Boards[Soldier].GetIsFirst())
                            Thread.Sleep(90);
                        Thread.Sleep(1000);
                    }
                    else
                        TimerRun();
                    SoldierList[Soldier].Uid = "Collapsed";
                    NotifyPropertyChanged("TimerVisibility" + Soldier);
                    bool b = Boards[Soldier].CheckAnswer("");
                    PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Audio\" + (b ? "Victory.wav" : "Fault.wav"));
                    if ((b && SoldierOrbit[Soldier] != 2) || (SoldierOrbit[Soldier] == 2 && !b))
                    {
                        bool bb = SoldierOrbit[Soldier] == 2 && SoldierIndex[Soldier] < 40;
                        SoldierIndex[Soldier] = _hotSquare[SoldierOrbit[Soldier]][SoldierIndex[Soldier]];
                        SoldierOrbit[Soldier] = SoldierOrbit[Soldier] == 2 ? bb ? 1 : 2 : SoldierOrbit[Soldier] + 1;
                        SoldierList[Soldier].Width = _SoldierStep[SoldierOrbit[Soldier]][SoldierIndex[Soldier], 0];
                        SoldierList[Soldier].FontSize = _SoldierStep[SoldierOrbit[Soldier]][SoldierIndex[Soldier], 1];
                        NotifyPropertyChanged("SoldierX" + Soldier);
                        NotifyPropertyChanged("SoldierY" + Soldier);
                        SoldierList[Soldier].visibility = Visibility.Collapsed;
                        NotifyPropertyChanged("QuestionVisible" + Soldier);
                    }
                }
                Boards[Soldier].Clear();
                base.NextTurn();
                Boards[Soldier].RestartClear();
                IsQuestion = false;
            })).Start();
        }

        private void ResatGame()
        {
            base.SetNewGameBut(false);
            RunGame =  true; 
            Thread.Sleep(990);
            gameRun = true;
            NotifyPropertyChanged(nameof(gameRun));
            BackgroundNewGame = String.Empty;
            NotifyPropertyChanged(nameof(BackgroundNewGame));
            SoldierList[Soldier].Uid = "Collapsed";
            NotifyPropertyChanged("TimerVisibility" + Soldier);
            Soldier = 3;
            for (int i = 0; i < SoldierIndex.Length; i++)
            {
                SoldierOrbit[i] =
                SoldierIndex[i] = 0;
                SoldierList[i].Width = _SoldierStep[0][0, 0];
                SoldierList[i].FontSize = _SoldierStep[0][0, 1];
                NotifyPropertyChanged("SoldierX" + i);
                NotifyPropertyChanged("SoldierY" + i);
            }
            _logic.NewGame();
            for (int i = 0; i < SoldierList.Length; i++)
                SoldierList[i].visibility = Visibility.Collapsed;
            for (int i = 0; i < VisibilityCubeList.Length; i++)
            {
                VisibilityCubeList[i].Background = "Hidden";
                NotifyPropertyChanged("VisibilityCube" + i);
                Boards[i].Clear();
            }
            QuestionVisible = "Hidden";
            NotifyPropertyChanged("QuestionVisible");
           RunGame =  IsQuestion = false;
            //Boards[Soldier].SetBoard(null);
            IsStartGame = true;
        }
        void IPageVM.load()
        {
            ResatGame();
            base.SetBut();
            base.GameSettings();
            base.NotAlaweVolumZiro();
            MiceLogic.Run();
            MiceLogic.NewMouseSplitter();
            base.Settings();
        }
        int index = 6;
        private void ChackTrivi(object obj)
        {
            new Thread(new ThreadStart(() =>
            {
                int[] keys = new int[] {3,6,10,18,28,38,41,43,47,49,52};
                if (index>= _SoldierStep[2].Length-1)
                    index = 0;
                SoldierList[3].Width = _SoldierStep[2][keys[index], 0];
                SoldierList[3].FontSize = _SoldierStep[2][keys[index], 1];
                NotifyPropertyChanged("SoldierX3");
                NotifyPropertyChanged("SoldierY3");
                Thread.Sleep(1000);
                int p = _hotSquare[2][keys[index]];
                SoldierList[3].Width = _SoldierStep[2][p, 0];
                SoldierList[3].FontSize = _SoldierStep[2][p, 1];
                NotifyPropertyChanged("SoldierX3");
                NotifyPropertyChanged("SoldierY3");
                index++;
            })).Start();
        }
    }
}
