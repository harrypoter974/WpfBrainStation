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
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.MathLearningVM.VM.Game
{

    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class BingoQuestionsVM : BaseAutoGameVM, IPageVM
    {
        public string ButChangeMode { get; set; }
        public ICommand ChangeMode { get; set; }
        public ICommand SetLimit { get; set; }
        public string LLimit0 { get { return _limitBut[0].Background; } set { _limitBut[0].Background = value; } }
        public string LLimit1 { get { return _limitBut[1].Background; } set { _limitBut[1].Background = value; } }
        public string LLimit2 { get { return _limitBut[2].Background; } set { _limitBut[2].Background = value; } }
        private LetterObject[] _limitBut = new LetterObject[3];
        private string[] _limitText = { "", "10", "40", "100" };
        public override string Name
        {
            get
            {
                return nameof(BingoQuestionsVM) ;
            }
        }

        void IPageVM.load()
        {
            base.GameSettings();
            DoSetLimit(1);
            base.NotAlaweVolumZiro();
            MiceLogic.Run();
            MiceLogic.NewMouseSplitter();
            for (int i = 0; i < Boards.Length; i++)
            {
                Boards[i].SetMouse(MiceLogic, MiceName[i]);
            }
            ResetGame();
            base.SetBut();
        }

        public BingoQuestionsVM()
        {
            base.Logic = (IBingoQuestionsManager)
   SupportHandlerManager.Base.GetManager("BingoQuestionsManager");
            NewGame = new RelayCommand(DoNewGame);
            SetLimit = new RelayCommand(DoSetLimit);
            ChangeMode = new RelayCommand(DoChangeMode);
            TimerList = new string[] { "5", "10", "15", "20" };
            TimerBut[3].Background = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Number\20b.png";
            NotifyPropertyChanged(nameof(TimerBut3) );
            for (int i = 0; i < Boards.Length; i++)
            {
                Boards[i] = new BingoPicBoardVM();
                Boards[i].SetQuestion(true.ToString());
            }
            string[] limit = { "1", "2", "3" };
            for (int i = 0; i < _limitBut.Length; i++)
                _limitBut[i] = new LetterObject() { Uid = limit[i] };
            //  Height="288.8" Width="484"
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.385;
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.38;
            NotifyPropertyChanged(nameof(BoardWidth));
            NotifyPropertyChanged(nameof(BoardHeight));
            AnswerBut = new RelayCommand(StopeGame);
        }

        private void DoChangeMode(object obj)
        {
            bool b = ButChangeMode == string.Empty;
            ButChangeMode = b ? System.AppDomain.CurrentDomain.BaseDirectory
              + @"Resources\Math\Exercise\ButChangeMode.jpg" : string.Empty;
            Logic.DoChangeMode(b);
            NotifyPropertyChanged(nameof(ButChangeMode));
            for (int i = 0; i < Boards.Length; i++)
            {
                Boards[i].SetQuestion(b.ToString());
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
            {
                base.SetNewGameBut(false);
                ResetGame();
            }
            else
            {
                gameRun = false;
                NotifyPropertyChanged(nameof(gameRun));

                base.SetNewGameBut(true);
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
            RunGame = false;
            for (int i = 0; i < Boards.Length; i++)
            {
                Boards[i].SetSoldierPosition(false);
                Boards[i].Clear();
            }
        }

        private void DoSetLimit(object obj)
        {
            (
                  (IBingoQuestionsManager)Logic).SetLimit(obj);
            string limit = obj.ToString();
            for (int i = 0; i < _limitBut.Length; i++)
            {
                if (_limitBut[i].Uid == limit)
                {
                    _limitBut[i].Background = System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\Number\" + "אבג"[int.Parse(limit)-1] + ".png";
                }
                else
                {
                    _limitBut[i].Background = string.Empty;
                }
                NotifyPropertyChanged("LLimit" + i);
            }
        }
     
        public override void InnerStartGame()
        {
            string q = ((IBingoQuestionsManager)Logic).GetQuestion();
            for (int i = 0; i < Boards.Length; i++)
            {
                Boards[i].ClearQuestion();
                Boards[i].SetAnswer(q);
            }
            Answer = ((IBingoQuestionsManager)Logic).GetAnswer();
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
