using BS.BingoBoard.VM;
using CL.BS.Contract;
using CL.BS.MEF;
using CL.BS.Model;
using CL.BS.VMCommon;
using MultipleMice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CL.BS.GameVM
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class MemoryVM : BaseAutoGameVM, IPageVM
    {
        public string GameTitle { get; set; }
        public ICommand _GoHome { get; set; }
        public string LimiteBut0 { get { return _buts[0].Background; } set { _buts[0].Background = value; } }
        public string LimiteBut1 { get { return _buts[1].Background; } set { _buts[1].Background = value; } }
        public string LimiteBut2 { get { return _buts[2].Background; } set { _buts[2].Background = value; } }
        private ItemObject[] _buts = new ItemObject[4];
        private int _index = 0;
        private bool _ferstQuestion = false;
        public ICommand SetLimite { get; set; }
        public ICommand TapAnswer { get; set; }
        public override string Name =>nameof(MemoryVM) ;

        public MemoryVM()
        {
            _GoHome = new RelayCommand(DoGoHome);
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.27;
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.39;
            NotifyPropertyChanged(nameof(BoardWidth));
            NotifyPropertyChanged(nameof(BoardHeight));
            Logic = (IBingoManager)
            SupportHandlerManager.Base.GetManager("MemoryManager");
            NewGame = new RelayCommand(DoNewGame);
            AnswerBut = new RelayCommand(StopeGame);
            for (int i = 0; i < Boards.Length; i++)
                Boards[i] = new MemoryViewBoardVM();
            for (int i = 0; i < _buts.Count(); i++)
                _buts[i] = new ItemObject();
            SetLimite = new RelayCommand(DoSetLimite);
            Timer = "12";
        }

        private void DoSetLimite(object obj)
        {
            DoSetTime(obj);
            _buts[_index].Background = string.Empty;
            NotifyPropertyChanged("LimiteBut" + _index);
            _index = int.Parse(obj.ToString());
            _buts[_index].Background = ((CL.BS.GameManager.Interface.IMemoryManager)Logic).SetLimit(_index);
            NotifyPropertyChanged("LimiteBut" + _index);
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
                List<GameObject>[] board = Logic.NewGame();
                for (int i = 0; i < Boards.Length; i++)
                {
                    Boards[i].RestartClear();
                    Boards[i].SetBoard(board[i]);
                    Boards[i].SetSoldierPosition(false);
                }
                RunGame = _ferstQuestion = true;
                StartGame();
            }

        }

        public override void InnerStartGame()
        {
            if (_ferstQuestion)
            {
                _ferstQuestion = false;
                //WaitTimerRun(12);
                for (int i = 0; i < Boards.Length; i++)
                    Boards[i].RestartClear();
            }
            Answer = ((CL.BS.GameManager.Interface.IMemoryManager)Logic).GetQuestion();
            Common.StaticVar.isTimerRedRun = true;
            PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory
                + @"Resources\Audio\Start.wav");
            for (int i = 0; i < Boards.Length; i++)
                Boards[i].SetQuestion(Answer);

            TimerRun();
            if (!RunGame)
                return;
            TBTimer = string.Empty;
            NotifyPropertyChanged("TBTimer");
            bool[] lb = new bool[4];
            for (int i = 0; i < Boards.Length; i++)
            {
                lb[i] = Boards[i].CheckBoard(Answer);
                Boards[i].SetAnswer(Answer);
            }
            haveWin = false;
            for (int j = 0; j < lb.Length; j++)
                if (lb[j])
                {
                    haveWin = lb[j];
                    _ferstQuestion = true;
                }
            if (haveWin)
                for (int j = 0; j < Boards.Length; j++)
                    Boards[j].Clear();
            if (Logic.EndGame())
                _ferstQuestion = true;
        }


        void IPageVM.load()
        {
            if (Common.StaticVar.IsGarden)
                GameTitle = System.AppDomain.CurrentDomain.BaseDirectory  + @"Resources\Game\Memory\Title.png";
            else
                GameTitle = string.Empty;
            NotifyPropertyChanged("GameTitle");
            BackgroundNewGame = string.Empty;
            base.NotAlaweVolumZiro();
            MiceLogic.Run();
            MiceLogic.NewMouseSplitter();
            for (int i = 0; i < Boards.Length; i++)
                Boards[i].SetMouse(MiceLogic, MiceName[i]);
            ResetGame();
            base.GameSettings();
            base.SetBut();
        }

        public override void ResetGame()
        {
            base.ResetGame();
            gameRun = true;
            NotifyPropertyChanged("gameRun");
            for (int i = 0; i < Boards.Length; i++)
            {
                Boards[i].ClearQuestion();
                Boards[i].SetSoldierPosition(false);
            }
            base.SetNewGameBut(false);
        }

        private void DoGoHome(object obj)
        {
            if (Common.StaticVar.IsGarden)
            {
                DoGoToPage( "MenuHeGeneralGameVM");
            }
            else
            {
                DoGoToPage("MenuGameVM");
            }
        }
    }
}
