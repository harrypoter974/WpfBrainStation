
using BS.BingoBoard.VM;
using CL.BS.Contract;
using CL.BS.GameManager.Interface;
using CL.BS.MEF;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Input;

namespace CL.BS.GameVM
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class LaddersAndRopesVM : BaseCubeGameVM, IPageVM
    {
        public override string Name =>nameof(LaddersAndRopesVM);
        public LaddersAndRopesBoardVM Board_0 { get { return _Boards[0]; } set {_Boards[0] = value; } }
        public LaddersAndRopesBoardVM Board_1 { get { return _Boards[1]; } set {_Boards[1] = value; } }
        public LaddersAndRopesBoardVM Board_2 { get { return _Boards[2]; } set {_Boards[2] = value; } }
        public LaddersAndRopesBoardVM Board_3 { get { return _Boards[3]; } set {_Boards[3] = value; } }
        private LaddersAndRopesBoardVM[] _Boards=new LaddersAndRopesBoardVM[4]; 
        private IQuickThinkingManager _logic ;
        private int[,] SoldierStep = new int[,] { {6,17 }, {8,17 }, { 9, 17 }, { 10, 17 }
           , { 11, 17 }, { 12, 17 } , { 13, 17 }, { 15, 17 }, { 16, 17}
      , { 18, 17 }, { 19, 17 }, { 21, 17 }, { 22, 17 }, { 23, 17 }, { 24, 17 }, { 25, 17 }
        , { 25, 15}, {24, 15 }, { 23, 15 }, { 22, 15 }, { 21, 15 }, { 19, 15 }, { 18, 15 }
 , {16, 15 },   { 15, 15 }, { 13, 15 }, { 12, 15 }, { 11, 15 }, { 10, 15 } , { 9, 15} , { 8, 15 }
   , { 8, 13 } , { 9, 13 }, { 10, 13}, { 11, 13}, { 12, 13}, { 13, 13},{ 15, 13}, { 16, 13}
       , { 18, 13 }, { 19, 13 },{ 21, 13 },{ 22, 13 },{ 23, 13 },{24, 13},{ 25, 13}
        ,{ 25, 12 },{ 24, 12 },{ 23, 12 },{ 22, 12 },{21,12},{19,12},{18,12},{16,12}
 ,{15,12},{13,12},{12,12},{11,12},{10,12},{9,12},{8,12}
            ,{8,11},{9,11},{10,11},{11,11},{12,11},{13,11},{15,11}
            ,{16,11},{18,11},{19,11},{21,11},{22,11},{23,11},{24,11},{25,11}
            ,{25,10},{24,10},{23,10},{22,10},{21,10},{19,10},{18,10},{16,10},{15,10},{13,10}
        ,{12,10},{11,10},{10,10},{9,10},{8,10}
            ,{8,8},{9,8},{10,8},{11,8},{12,8},{13,8},{15,8},{16,8}
            ,{18,8},{19,8},{21,8},{22,8},{23,8},{24,8},{25,8}    
            ,{25,6},{24,6},{23,6},{22,6},{21,6},{19,6},{18,6},{16,6},{15,6},{13,6}
        ,{12,6},{11,6},{10,6},{9,6},{8,6}   };
  
        private Dictionary<int, int> Ladders = new Dictionary<int, int>();
        private Dictionary<int, int> Ropes = new Dictionary<int, int>();
        public LaddersAndRopesVM()
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
            if (!gameRun)//||IsStartGame
                return;
            if (RunGame)
                ResatGame();
            else
            {
                new Thread(new ThreadStart(() =>
                {
                    base.SetNewGameBut(true);
                    gameRun = IsQuestion = false;
                    IsStartGame = RunGame = true;
                    BackgroundNewGame = System.AppDomain.CurrentDomain.BaseDirectory
           + @"Resources\BS.Items\buttonNewGame.png";
                    NotifyPropertyChanged(nameof(BackgroundNewGame));
                    NotifyPropertyChanged(nameof(gameRun));
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
                        catch (Exception)
                        {
                        }
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


        private void DoTapAnswer(object obj)
        {
            if (Question == null)
                return;
            if (IsQuestion)//&& (MiceLogic.GetMouseRotation() == MiceName[Soldier]|| !MiceLogic.IsMouse())
            {
                Common.StaticVar.isTimerRedRun = false;
                string answer =_Boards[Soldier].GetAnswer();
              
                bool isTrue =  answer==( Question[4].Question == @"Resources\BS.Items\TrueBut.jpg" ? "1":"0");
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
                SoldierList[Soldier].Width    = SoldierStep[SoldierIndex[Soldier], 0];
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

        private void DoNextStep(object obj)
        {
            if (IsQuestion||!IsStartGame|| TurnInxex==-1)// || (MiceLogic.GetMouseRotation() != MiceName[Soldier]&&MiceLogic.IsMouse())
            {
                //if (IsQuestion)
                //    DoTapAnswer(0);
                return;
            }
            if (obj.ToString() != Soldier.ToString())
                return;
            new Thread(new ThreadStart(() =>
            {
                IsQuestion = true;
                int num =_Boards[Soldier].TapCube();
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
                    SoldierList[Soldier].Width =    SoldierStep[i, 0];
                    SoldierList[Soldier].FontSize = SoldierStep[i, 1];
                    NotifyPropertyChanged("SoldierX" +Soldier);
                    NotifyPropertyChanged("SoldierY" +Soldier);
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
                    _Boards[Soldier].SetQuestion( Question[3].Question) ;                   
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
            gameRun =true;
            IsStartGame = RunGame=false;
            NotifyPropertyChanged(nameof(gameRun));
            for (int i = 0; i < SoldierIndex.Length; i++)
            {
                SoldierIndex[i] = 0;
                SoldierList[i].Width = SoldierStep[SoldierIndex[i], 0];
                SoldierList[i].FontSize = SoldierStep[SoldierIndex[i], 1];
                NotifyPropertyChanged("SoldierX"+i);
                NotifyPropertyChanged("SoldierY"+i);
            }
            SoldierList[Soldier].visibility = System.Windows.Visibility.Collapsed;
            NotifyPropertyChanged("QuestionVisible" + Soldier);
            TurnInxex =-1; 
            for (int i = 0; i < VisibilityCubeList.Length; i++)
                _Boards[i].Clear();
            BackgroundNewGame =String.Empty;
            NotifyPropertyChanged(nameof(BackgroundNewGame));
            gameRun = true;
            IsStartGame = false;
        }
        void IPageVM.load()
        {
            if (Common.StaticVar.IsGarden)
            {
                _logic = (IQuickThinkingManager)
       SupportHandlerManager.Base.GetManager("JudaismManager");
            }
            else
            {
                _logic = (IQuickThinkingManager)
                  SupportHandlerManager.Base.GetManager("QuickThinkingManager");
            }
            base.GameSettings();
            base.NotAlaweVolumZiro();
            MiceLogic.Run();
            MiceLogic.NewMouseSplitter();
            ((IQuickThinkingManager)_logic).SetLimit(0);
            base.Settings();
            ResatGame();
            base.SetBut();
        }
        int index = 0;
        private void ChackLaddersAndRopes(object obj)
        {
            new Thread(new ThreadStart(() =>
            {
                int[] keys = new int[] {2,9,11,15,18,22,30,34,49,70,81,82,91};
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
