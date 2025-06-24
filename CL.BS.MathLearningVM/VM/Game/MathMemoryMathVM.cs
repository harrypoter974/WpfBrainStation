using BS.BingoBoard.VM;
using CL.BS.Contract;
using CL.BS.MathLearningManager.Interface.Game;
using CL.BS.MathLearningManager.Manager.Game;
using CL.BS.MEF;
using CL.BS.Model;
using CL.BS.VMCommon;
using MultipleMice;
using System.Threading;
using System.Windows.Input;

namespace CL.BS.MathLearningVM.VM.Game
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class MathMemoryMathVM : BaseMemoryAutoGameVM, IPageVM
    {
        public override string Name
        {
            get
            {
                return "MathMemoryMathVM";
            }
        }
        private string[] _limitText = { "10", "40", "100" };
        public string LOperator0 { get { return _operatorBut[0].Background; } set { _operatorBut[0].Background = value; } }
        public string LOperator1 { get { return _operatorBut[1].Background; } set { _operatorBut[1].Background = value; } }
        public string LOperator2 { get { return _operatorBut[2].Background; } set { _operatorBut[2].Background = value; } }
        public string LOperator3 { get { return _operatorBut[3].Background; } set { _operatorBut[3].Background = value; } }
        private LetterObject[] _operatorBut = new LetterObject[4];
        public string LLimit0 { get { return _limitBut[0].Background; } set { _limitBut[0].Background = value; } }
        public string LLimit1 { get { return _limitBut[1].Background; } set { _limitBut[1].Background = value; } }
        public string LLimit2 { get { return _limitBut[2].Background; } set { _limitBut[2].Background = value; } }
        private LetterObject[] _limitBut = new LetterObject[3];
        public ICommand SetLimit { get; set; }
        public ICommand SetOperator { get; set; }

        void IPageVM.load()
        {
            ISFerstGame = true;
            base.GameSettings();
            base.NotAlaweVolumZiro();
            DoMemorySetPlayer(3);
            MiceLogic.Run();
            MiceLogic.NewMouseSplitter();
            for (int i = 0; i < Boards.Length; i++)
            {
                Boards[i].SetMouse(MiceLogic, MiceName[i]);
            }
            ResetGame();
            base.SetBut();
        }

        public MathMemoryMathVM()
        {
            Logic = (MathMemoryMathManager)
  SupportHandlerManager.Base.GetManager("MathMemoryMathManager");
            NewGame = new RelayCommand(DoNewGame);
            SetLimit = new RelayCommand(DoSetLimit);
            SetOperator = new RelayCommand(DoSetOperator);
            AnswerBut = new RelayCommand(StopeGame);
            SetLettersNum = new RelayCommand(DSetLettersNum);
            NumLetterLimit =new string[] { "3", "4", "6", "8" };
            for (int i = 0; i < Boards.Length; i++)
            {
                Boards[i] = new MemoryLetterBoardVM();
            }
            // Height="326.4" Width="668.8"
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.49;
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.425;
            NotifyPropertyChanged("BoardWidth");
            NotifyPropertyChanged("BoardHeight");
            for (int i = 0; i < _limitBut.Length; i++)
                _limitBut[i] = new LetterObject() { Uid = i.ToString() };
            string[] Operator = { "+", "-", "x", ":" };
            for (int i = 0; i < _operatorBut.Length; i++)
                _operatorBut[i] = new LetterObject() { Uid = Operator[i] };
            DoSetLimit(0);
            DoSetOperator('+');
        }

        private void DSetLettersNum(object obj)
        {
            if (MiceLogic.IsMouseRotation())
            {
                int n = int.Parse(obj.ToString());
                if (int.Parse(NumLetterLimit[n]) > CardMaxNum && CardMaxNum > 0)
                {
                    DSetLettersNum(n - 1);
                    return;
                }
                NumLetterBut[LimitIndex].Background = string.Empty;
                NotifyPropertyChanged("NumLetterBut" + LimitIndex);
                LimitIndex = n;
                NumLetterBut[LimitIndex].Background = System.AppDomain.CurrentDomain.BaseDirectory
                + @"Resources\Number\" + NumLetterLimit[LimitIndex] + "b.png";
                NotifyPropertyChanged("NumLetterBut" + LimitIndex);
            }
        }
        private void DoSetLimit(object obj)
        {
            ((IMathMemoryMathManager)Logic).SetLimit(obj);
            string limit = obj.ToString();
            for (int i = 0; i < _limitBut.Length; i++)
            {
                if (_limitBut[i].Uid == limit)
                {
                    _limitBut[i].Background = System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\Number\l" + _limitText[int.Parse(limit)] + ".png";
                }
                else
                {
                    _limitBut[i].Background = string.Empty;
                }
                NotifyPropertyChanged("LLimit" + i);
            }
        }

        private void DoSetOperator(object obj)
        {
            ((IMathMemoryMathManager)Logic).SetOperator(obj);
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
        
        public override void ResetGame()
        {
            base.SetNewGameBut(false);
            RunGame = false;
            for (int i = 0; i < Boards.Length; i++)
            {
                Boards[i].SetSoldierPosition(false);
                Boards[i].ClearQuestion();
            }
        }
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
                ResetGame();
            else
            {
                gameRun = false;
                NotifyPropertyChanged(nameof(gameRun));


                base.SetNewGameBut(true);
                _letter = Logic.GetNewGame(base.GetNumLetterLimit());
                for (int i = 0; i < Boards.Length; i++)
                {
                    Boards[i].SetNumLetterLimit(base.GetNumLetterLimit());
                    Boards[i].Clear();
                    Boards[i].SetBoard(_letter[i]);
                    Boards[i].SetSoldierPosition(false);
                }
                RunGame = true;
                StartGame();
            }
        }

        public override void InnerStartGame()
        {
            if (Boards[0].QuestionIsAnswer())
            {
                for (int i = 0; i < Boards.Length && RunGame; i++)
                {
                    Boards[i].Clear();
                    Boards[i].QuestionIsAnswer();
                }
                Thread.Sleep(1000);
            }
            Answer = Logic.GetQuestion();
            PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory +
                     @"\Resources\Audio\He\Letters\" + Answer + ".wav");

            for (int i = 0; i < Boards.Length && RunGame; i++)
                Boards[i].SetQuestion(Answer);
            base.TimerRun();
            if (!RunGame)
                return;
            ListBoards = new bool[4];
            for (int i = 0; i < Boards.Length && RunGame; i++)
            {
                ListBoards[i] = Boards[i].CheckBoard(Answer);
                if (ListBoards[i]&&Logic.EndGame(false))
                {
                    Boards[i].SetSoldierPosition(true);
                    haveWin = ListBoards[i];
                }
            }
        }
    }
}
