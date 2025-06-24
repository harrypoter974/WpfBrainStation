using BS.BingoBoard.VM;
using CL.BS.Contract;
using CL.BS.MathLearningManager.Interface.Game;
using CL.BS.MEF;
using CL.BS.Model;
using CL.BS.VMCommon;
using MultipleMice;
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
    public class BingoMathVM : BaseAutoGameVM, IPageVM
    {
        private Random _ran = new Random(DateTime.Now.Millisecond);
        public string ButChangeMode { get; set; }
        public ICommand ChangeMode { get; set; }
        public ICommand SetLimit { get; set; }
        public ICommand SetOperator { get; set; }
        public string LOperator0 { get { return _operatorBut[0].Background; } set { _operatorBut[0].Background = value; } }
        public string LOperator1 { get { return _operatorBut[1].Background; } set { _operatorBut[1].Background = value; } }
        public string LOperator2 { get { return _operatorBut[2].Background; } set { _operatorBut[2].Background = value; } }
        public string LOperator3 { get { return _operatorBut[3].Background; } set { _operatorBut[3].Background = value; } }
        private ItemObject[] _operatorBut = new ItemObject[4];
        public string LLimit0 { get { return _limitBut[0].Background; } set { _limitBut[0].Background = value; } }
        public string LLimit1 { get { return _limitBut[1].Background; } set { _limitBut[1].Background = value; } }
        public string LLimit2 { get { return _limitBut[2].Background; } set { _limitBut[2].Background = value; } }
        private ItemObject[] _limitBut = new ItemObject[3];
        public override string Name
        {
            get
            {
                return nameof(BingoMathVM) ;
            }
        }

        void IPageVM.load()
        {
            base.GameSettings();
            DoSetLimit(1);         
            base.NotAlaweVolumZiro();
            DoSetOperator('+');
            MiceLogic.Run();
            MiceLogic.NewMouseSplitter();
            for (int i = 0; i < Boards.Length; i++)
            {
                Boards[i].SetMouse(MiceLogic, MiceName[i]);
            }
            ResetGame();
            base.SetBut();
        }

        public BingoMathVM()
        {
            base.Logic = (IBingoMathManager)
   SupportHandlerManager.Base.GetManager("BingoMathManager");
            NewGame = new RelayCommand(DoNewGame);
            SetLimit = new RelayCommand(DoSetLimit);
            SetOperator = new RelayCommand(DoSetOperator);
            ChangeMode = new RelayCommand(DoChangeMode);
            //SetTime= new RelayCommand(DOSetTime);
            TimerList = new string[] { "20", "15", "10" };
            for (int i = 0; i < Boards.Length; i++)
            {
                Boards[i] = new BingoPicBoardVM();
                Boards[i].SetQuestion(false.ToString());
            }
            string[] limit = { "1", "2", "3" };
            for (int i = 0; i < _limitBut.Length; i++)
                _limitBut[i] = new ItemObject() { Uid = limit[i] };
            string[] Operator = { "+", "-", "x", ":" };
            for (int i = 0; i < _operatorBut.Length; i++)
                _operatorBut[i] = new ItemObject() { Uid = Operator[i] };
            //  Height="288.8" Width="484"
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.355;
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.38;
            NotifyPropertyChanged(nameof(BoardWidth));
            NotifyPropertyChanged(nameof(BoardHeight));
            AnswerBut = new RelayCommand(StopeGame);
        }


        private void DoChangeMode(object obj)
        {
            bool b = ButChangeMode == string.Empty;
            ButChangeMode =b?  System.AppDomain.CurrentDomain.BaseDirectory
              + @"Resources\Math\Exercise\ButChangeMode.jpg" : string.Empty;
            Logic.DoChangeMode(b);
            NotifyPropertyChanged(nameof(ButChangeMode));
            for (int i = 0; i < Boards.Length; i++)
            {
                Boards[i].SetQuestion(b.ToString());
            }
        }

        private string[] LimitText = {"", "10", "40", "100" };
        private void StopeGame(object sender)
        {
            base.DoExitBut(0);
            if (!gameRun)
            {
                gameRun = true;
                NotifyPropertyChanged(nameof(gameRun));
            }
        }

        private void DoNewGame(object obj)
        {
            if (RunGame)
            {
                ResetGame();
            }
            else
            {
                gameRun = false;
                NotifyPropertyChanged(nameof(gameRun));

                base.SetNewGameBut(true);
                if (TimerIndex > 0)
                {
                    int m = _ran.Next(2);
                    ((IBingoMathManager)Logic).DoChangeMode(m == 0);//
                }
                else
                    ((IBingoMathManager)Logic).DoChangeMode(false);
                List<GameObject>[] b = Logic.NewGame();
                for (int i = 0; i < Boards.Length; i++)
                {
                    Boards[i].SetBoard(b[i]);
                    Boards[i].SetSoldierPosition(false);
                }
                RunGame = true;
                StartGame();
            }
        }

        public override void ResetGame()
        {
            base.SetNewGameBut(false);
            RunGame = false;
            for (int i = 0; i < Boards.Length; i++)
            {
                Boards[i].SetSoldierPosition(false);
                Boards[i].Clear();
            }
        }

        private void DoSetLimit(object obj)
        {
            ((IBingoMathManager)Logic).SetLimit(obj);
            string limit = obj.ToString();
            for (int i = 0; i < _limitBut.Length; i++)
            {
                if (_limitBut[i].Uid == limit)
                {
                    _limitBut[i].Background = System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\Number\l" + LimitText[int.Parse(limit)] + ".png";
                }
                else
                {
                    _limitBut[i].Background = string.Empty;
                }
                NotifyPropertyChanged("LLimit" + i);
            }
            int l = int.Parse(limit);
            for (int i = 0; i < Boards.Length; i++)
                Boards[i].SetNumLetterLimit(l);
        }

        private void DoSetOperator(object obj)
        {
           ((IBingoMathManager) Logic).SetOperator(obj);
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

        public override void InnerStartGame()
        {
            string q = ((IBingoMathManager)Logic).GetQuestion();
            for (int i = 0; i < Boards.Length; i++)
            {
                Boards[i].ClearQuestion();
                Boards[i].SetAnswer(q);
            }
            Answer = ((IBingoMathManager)Logic).GetAnswer();
            base.TimerRun();
            if (!RunGame)
                return;
            bool[] lb = new bool[4];
            for (int i = 0; i < Boards.Length; i++)
            {
                lb[i] = Boards[i].CheckBoard(Answer);
                if (!haveWin)
                    haveWin = lb[i];
            }
        }
    }
}
