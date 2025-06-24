using BS.BingoBoard.VM;
using CL.BS.Contract;
using CL.BS.MathLearningManager.Interface.Game;
using CL.BS.MEF;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.MathLearningVM.VM.Game
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class LaddersAndRopesMathVM : BaseCubeGameVM, IPageVM
    {
        public override string Name => nameof(LaddersAndRopesMathVM);
        public LaddersAndRopesBoardVM Board_0 { get { return _Boards[0]; } set { _Boards[0] = value; } }
        public LaddersAndRopesBoardVM Board_1 { get { return _Boards[1]; } set { _Boards[1] = value; } }
        public LaddersAndRopesBoardVM Board_2 { get { return _Boards[2]; } set { _Boards[2] = value; } }
        public LaddersAndRopesBoardVM Board_3 { get { return _Boards[3]; } set { _Boards[3] = value; } }
        private LaddersAndRopesBoardVM[] _Boards = new LaddersAndRopesBoardVM[4];
        public string LOperator0 { get { return _operatorBut[0].Background; } set { _operatorBut[0].Background = value; } }
        public string LOperator1 { get { return _operatorBut[1].Background; } set { _operatorBut[1].Background = value; } }
        public string LOperator2 { get { return _operatorBut[2].Background; } set { _operatorBut[2].Background = value; } }
        public string LOperator3 { get { return _operatorBut[3].Background; } set { _operatorBut[3].Background = value; } }
        private ItemObject[] _operatorBut = new ItemObject[4];
        public string LLimit0 { get { return _limitBut[0].Background; } set { _limitBut[0].Background = value; } }
        public string LLimit1 { get { return _limitBut[1].Background; } set { _limitBut[1].Background = value; } }
        public string LLimit2 { get { return _limitBut[2].Background; } set { _limitBut[2].Background = value; } }
        private ItemObject[] _limitBut = new ItemObject[3];
        private string[] LimitText = {  "10", "40", "100" };
        public ICommand SetLimit { get; set; }
        public ICommand SetOperator { get; set; }
        private ILaddersAndRopesMathManager _logic = (ILaddersAndRopesMathManager)
SupportHandlerManager.Base.GetManager("LaddersAndRopesMathManager");
        private int[,] SoldierStep = new int[,] { {6,18 }, {8,18 }, { 9, 18 }, { 10, 18 }
           , { 11, 18 }, { 12, 18 } , { 13, 18 }, { 15, 18 }, { 16, 18}
      , { 18, 18 }, { 19, 18 }, { 21, 18 }, { 22, 18 }, { 23, 18 }, { 24, 18 }, { 25, 18 }
        , { 25, 16}, {24, 16 }, { 23, 16 }, { 22, 16 }, { 21, 16 }, { 19, 16 }, { 18, 16 }
 , {16, 16 },   { 15, 16 }, { 13, 16 }, { 12, 16 }, { 11, 16 }, { 10, 16 } , { 9, 16} , { 8, 16 }
   , { 8, 14 } , { 9, 14 }, { 10, 14}, { 11, 14}, { 12, 14}, { 13, 14},{ 15, 14}, { 16, 14}
       , { 18, 14 }, { 19, 14 },{ 21, 14 },{ 22, 14 },{ 23, 14 },{24, 14},{ 25, 14}
        ,{ 25, 13 },{ 24, 13 },{ 23, 13 },{ 22, 13 },{21,13},{19,13},{18,13},{16,13}
 ,{15,13},{13,13},{12,13},{11,13},{10,13},{9,13},{8,13}
            ,{8,12},{9,12},{10,12},{11,12},{12,12},{13,12},{15,12}
            ,{16,12},{18,12},{19,12},{21,12},{22,12},{23,12},{24,12},{25,12}
            ,{25,11},{24,11},{23,11},{22,11},{21,11},{19,11},{18,11},{16,11},{15,11},{13,11}
        ,{12,11},{11,11},{10,11},{9,11},{8,11}
            ,{8,9},{9,9},{10,9},{11,9},{12,9},{13,9},{15,9},{16,9}
            ,{18,9},{19,9},{21,9},{22,9},{23,9},{24,9},{25,9}
            ,{25,7},{24,7},{23,7},{22,7},{21,7},{19,7},{18,7},{16,7},{15,7},{13,7}
        ,{12,7},{11,7},{10,7},{9,7},{8,7}   };

        private Dictionary<int, int> Ladders = new Dictionary<int, int>();
        private Dictionary<int, int> Ropes = new Dictionary<int, int>();
        public LaddersAndRopesMathVM() 
        {
            NextStep = new RelayCommand(DoNextStep);
            NewGame = new RelayCommand(Start_Game);
            TapAnswer = new RelayCommand(DoTapAnswer);
            AnswerBut = new RelayCommand(StopeGame);
            Ladders.Add(2, 28);
            Ladders.Add(5, 25); 
            Ladders.Add(7, 23);
            Ladders.Add(9, 40);
            Ladders.Add(11, 21);
            Ladders.Add(13, 19);
            Ladders.Add(15, 44);
            Ladders.Add(18, 47);
            Ladders.Add(22, 94);
            Ladders.Add(26, 36);
            Ladders.Add(30, 59);
            Ladders.Add(33, 64);
            Ladders.Add(34, 56);
            Ladders.Add(37, 55);
            Ladders.Add(41, 51);
            Ladders.Add(49, 73);
            Ladders.Add(52, 70);
            Ladders.Add(60, 62);
            Ladders.Add(69, 97);
            Ladders.Add(75, 77);
            Ladders.Add(79, 107);
            Ladders.Add(81, 113);
            Ladders.Add(90, 92);
            Ladders.Add(96, 116);

            Ropes.Add(27, 7);
            Ropes.Add(42, 12);
            Ropes.Add(58, 29);
            Ropes.Add(72, 25);
            Ropes.Add(78, 16);
            Ropes.Add(84, 54);
            Ropes.Add(87, 61);
            Ropes.Add(101, 70);
            Ropes.Add(102, 82);
            Ropes.Add(107, 77);
            Ropes.Add(110, 98);
            Ropes.Add(114, 85);
            Ropes.Add(117, 65);
            Ropes.Add(119, 89);
            for (int i = 0; i < _Boards.Length; i++)
            {
                _Boards[i] = new LaddersAndRopesBoardVM();//"ABCD"[i]
                _Boards[i].SetBackground("DCBA"[i]);
            }
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.156;
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.192;
            NotifyPropertyChanged(nameof(BoardWidth));
            NotifyPropertyChanged(nameof(BoardHeight));
            SetLimit = new RelayCommand(DoSetLimit);
            SetOperator = new RelayCommand(DoSetOperator);
            for (int i = 0; i < _limitBut.Length; i++)
                _limitBut[i] = new ItemObject() { Uid = i.ToString() };
            string[] Operator = { "+", "-", "x", ":" };
            for (int i = 0; i < _operatorBut.Length; i++)
                _operatorBut[i] = new ItemObject() { Uid = Operator[i] };

        }


        private void StopeGame(object obj)
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
            if (!gameRun)
                return;
            if (RunGame)
            {
                ResatGame();
            }
            else
            {
       new Thread(new ThreadStart(() =>
            {
                base.SetNewGameBut(true);
                IsQuestion = gameRun = false;
                NotifyPropertyChanged(nameof(gameRun));
                IsStartGame = RunGame = true;
                BackgroundNewGame = System.AppDomain.CurrentDomain.BaseDirectory
           + @"Resources\BS.Items\buttonNewGame.png";
                NotifyPropertyChanged(nameof(BackgroundNewGame));
                int max = 0;
                StartSum = new int[] { 0, 0, 0, 0 };
                for (TurnInxex = 0; TurnInxex < StartSum.Length; TurnInxex++)
                {
                    Soldier = SoldierTurn[TurnInxex];
                    int num = _Boards[Soldier].TapCube();
                    if (TurnInxex == -1)
                        continue;
                    try
                    {
                        StartSum[TurnInxex] = num;
                        if (StartSum[TurnInxex] > max)
                            max = StartSum[TurnInxex];
                        WhitTime(800, ref RunGame);
                    }
                    catch (Exception ex) { }
                }
                TurnInxex = -1;
                WhitTime(6000, ref RunGame);
                for (int i = 0; i < StartSum.Length; i++)
                {
                    if (StartSum[i] == max & TurnInxex == -1)
                    {
                        TurnInxex = i;
                        Soldier = SoldierTurn[TurnInxex];
                        _Boards[Soldier].VisibleCube();
                    }
                    else
                    {
                        int t = SoldierTurn[i];
                        _Boards[SoldierTurn[i]].Clear();
                    }
                }
            })).Start();
     
            }
        }
        private void DoSetOperator(object obj)
        {
            _logic.SetOperator(obj);
            for (int i = 0; i < _operatorBut.Length; i++)
            {
                string o = obj.ToString();
                if (_operatorBut[i].Uid == o.ToString())
                {
                    char op = o == ":" ? 's' : o[0];
                    _operatorBut[i].Background = System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\Number\" + op + ".png";
                }
                else
                {
                    _operatorBut[i].Background = string.Empty;
                }
                NotifyPropertyChanged("LOperator" + i);
            }
        }
        private void DoTapAnswer(object obj)
        {
            if (Question == null)
                return;
            if (IsQuestion)//&& (MiceLogic.GetMouseRotation() == MiceName[Soldier]|| !MiceLogic.IsMouse())
            {
                Common.StaticVar.isTimerRedRun = false;
                string answer = _Boards[Soldier].GetAnswer();

                bool isTrue = answer == (Question[4].Question == @"Resources\BS.Items\TrueBut.jpg" ? "1" : "0");
                PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory +
                 @"Resources\Audio\" + (isTrue ? "Victory.wav" : "Fault.wav"));

                if (Ladders.ContainsKey(SoldierIndex[Soldier]) && isTrue)
                {
                    SoldierIndex[Soldier] = Ladders[SoldierIndex[Soldier]];
                    if (SoldierIndex[Soldier] >= 120)
                    {
                        PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory
                            + @"Resources\Audio\StructuralWin.wav");
                        WhitTime(3000, ref RunGame);
                        ResatGame();
                        return;
                    }
                }
                else if (Ropes.ContainsKey(SoldierIndex[Soldier]) && !isTrue)
                {
                    SoldierIndex[Soldier] = Ropes[SoldierIndex[Soldier]];
                }
                SoldierList[Soldier].Width = SoldierStep[SoldierIndex[Soldier], 0];
                SoldierList[Soldier].FontSize = SoldierStep[SoldierIndex[Soldier], 1];
                NotifyPropertyChanged("SoldierX" + Soldier);
                NotifyPropertyChanged("SoldierY" + Soldier);
                SoldierList[Soldier].visibility = System.Windows.Visibility.Collapsed;
                NotifyPropertyChanged("QuestionVisible" + Soldier);
                NextTurn();
                IsQuestion = false;
                for (int i = 0; i < VisibilityCubeList.Length; i++)
                {
                    if (Soldier == i)
                        _Boards[i].VisibleCube();
                    else
                        _Boards[i].Clear();
                }
            }
        }
        private void DoSetLimit(object obj)
        {
            string limit = obj.ToString();
            int l = int.Parse(limit);
            _logic.SetLimit(l);
            for (int i = 0; i < _limitBut.Length; i++)
            {
                if (_limitBut[i].Uid == limit)
                {
                    _limitBut[i].Background = System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\Number\l" + LimitText[l] + ".png";
                }
                else
                {
                    _limitBut[i].Background = string.Empty;
                }
                NotifyPropertyChanged("LLimit" + i);
            }
        }
        private void DoNextStep(object obj)
        {
            if (IsQuestion || !IsStartGame || TurnInxex == -1)
            {
                if (IsQuestion)
                    DoTapAnswer(0);
                return;
            }
            if (obj.ToString() != Soldier.ToString())
                return;
            new Thread(new ThreadStart(() =>
            {
                IsQuestion = true;
                int num = _Boards[Soldier].TapCube();
                int preStep = SoldierIndex[Soldier];
                SoldierIndex[Soldier] = SoldierIndex[Soldier] + num;
                if (SoldierIndex[Soldier] > 119)
                {
                    PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Audio\StructuralWin.wav");
                    _Boards[Soldier].GameWin();
                    SoldierIndex[Soldier] = 121;
                    WhitTime(1000, ref RunGame);
                    ResatGame();
                    return;
                }
                for (int i = preStep; i <= SoldierIndex[Soldier]; i++)
                {
                    SoldierList[Soldier].Width = SoldierStep[i, 0];
                    SoldierList[Soldier].FontSize = SoldierStep[i, 1];
                    NotifyPropertyChanged("SoldierX" + Soldier);
                    NotifyPropertyChanged("SoldierY" + Soldier);
                    WhitTime(250, ref RunGame);
                }
                IsQuestion = Ladders.ContainsKey(SoldierIndex[Soldier]) || Ropes.ContainsKey(SoldierIndex[Soldier]);
                if (!IsQuestion)
                {
                    NextTurn();
                    for (int i = 0; i < VisibilityCubeList.Length; i++)
                    {
                        if (Soldier == i)
                            _Boards[i].VisibleCube();
                        else
                            _Boards[i].Clear();
                    }
                    IsQuestion = false;
                }
                else
                {
                    UrlPlay = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Audio\do.wav";
                    Question = _logic.NewGame()[0];
                    SoldierList[Soldier].visibility = System.Windows.Visibility.Visible;
                    NotifyPropertyChanged("QuestionVisible" + Soldier);
                    _Boards[Soldier].SetQuestion(Question[3].Question);
                    Common.StaticVar.isTimerRedRun = true;
                    TBTimerColor = System.AppDomain.CurrentDomain.BaseDirectory
                                + @"Resources\BS.Items\UCTimerGreen.png";
                    NotifyPropertyChanged("TBTimerColor");
                    int timeWate = int.Parse(Timer);
                    string point = "45,0";
                    if (TimerBut[0].Background.Contains("TimerControl0.png"))
                    {
                        TBTimer = point;
                        NotifyPropertyChanged("TBTimer");
                        while (RunGame && Common.StaticVar.isTimerRedRun)
                            Thread.Sleep(90);
                    }
                    else
                    {
                        double time = 0;
                        for (; RunGame && Common.StaticVar.isTimerRedRun && time < 361; time += 3)
                        {
                            Thread.Sleep(9 * timeWate);
                            point += " " + (45 + 45 * Math.Sin(time / 45.0)) + ',' + (45 - 45 * Math.Cos(time / 45.0));
                            TBTimer = point;
                            NotifyPropertyChanged("TBTimer");

                        }
                        Common.StaticVar.isTimerRedRun = false;
                        if (time >= 361)
                            DoTapAnswer(Soldier.ToString() + 2);
                    }
                    DoTapAnswer(Soldier);
                }
            })).Start();
        }
        private void ResatGame()
        {
            Thread.Sleep(99);
            base.SetNewGameBut(false);
            gameRun = true;
            IsStartGame = RunGame = false;
            NotifyPropertyChanged(nameof(gameRun));
            for (int i = 0; i < SoldierIndex.Length; i++)
            {
                SoldierIndex[i] = 0;
                SoldierList[i].Width = SoldierStep[SoldierIndex[i], 0];
                SoldierList[i].FontSize = SoldierStep[SoldierIndex[i], 1];
                NotifyPropertyChanged("SoldierX" + i);
                NotifyPropertyChanged("SoldierY" + i);
            }
            SoldierList[Soldier].visibility = System.Windows.Visibility.Collapsed;
            NotifyPropertyChanged("QuestionVisible" + Soldier);
            TurnInxex = -1;
            for (int i = 0; i < VisibilityCubeList.Length; i++)
                _Boards[i].Clear();
            BackgroundNewGame = String.Empty;
            NotifyPropertyChanged(nameof(BackgroundNewGame));
            gameRun = true;
            IsStartGame = false;
        }
        void IPageVM.load()
        {
            base.GameSettings();
            base.NotAlaweVolumZiro();
            MiceLogic.Run();
            MiceLogic.NewMouseSplitter();
            DoSetLimit(0);
            DoSetOperator('+');
            base.Settings();
            ResatGame();
            base.SetBut();
        }
        int index = 0;
        private void ChackLaddersAndRopes(object obj)
        {
            new Thread(new ThreadStart(() =>
            {
                int[] keys = new int[] { 2, 9, 11, 15, 18, 22, 30, 34, 49, 70, 81, 82, 91 };
                if (index == Ladders.Count)
                    index = 0;
                int p = keys[index];
                SoldierList[0].Width = SoldierStep[p, 0];
                SoldierList[0].FontSize = SoldierStep[p, 1];
                NotifyPropertyChanged(nameof(SoldierX0));
                NotifyPropertyChanged(nameof(SoldierY0));
                Thread.Sleep(2000);
                p = Ladders[keys[index]];
                SoldierList[0].Width = SoldierStep[p, 0];
                SoldierList[0].FontSize = SoldierStep[p, 1];
                NotifyPropertyChanged("SoldierX0");
                NotifyPropertyChanged("SoldierY0");
                index++;
            })).Start();
        }
    }
}
