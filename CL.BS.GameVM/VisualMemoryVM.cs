using CL.BS.Contract;
using CL.BS.GameManager.Interface;
using CL.BS.MEF;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.GameVM
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class VisualMemoryVM : BaseAutoGameVM, IPageVM
    {
        public string LimiteBut0 { get { return _buts[0].Background; } set { _buts[0].Background = value; } }
        public string LimiteBut1 { get { return _buts[1].Background; } set { _buts[1].Background = value; } }
        public string LimiteBut2 { get { return _buts[2].Background; } set { _buts[2].Background = value; } }
        private ItemObject[] _buts = new ItemObject[4];
        private int _index = 0;
        public ICommand SetLimite { get; set; }
        public ICommand TapAnswer { get; set; }
        public override string Name => "VisualMemoryVM";

        public VisualMemoryVM()
        {
            
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.415;
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.384;
            NotifyPropertyChanged(nameof(BoardWidth) );
            NotifyPropertyChanged( nameof(BoardHeight));
            Logic = (IVisualMemoryManager)
            SupportHandlerManager.Base.GetManager("VisualMemoryManager");
            NewGame = new RelayCommand(DoNewGame);
            AnswerBut = new RelayCommand(StopeGame);
            for (int i = 0; i < Boards.Length; i++)
                Boards[i] = new BoardVisualMemoryVM();
            for (int i = 0; i < _buts.Count(); i++)
                _buts[i] = new ItemObject();
            SetLimite = new RelayCommand(DoSetLimite);
            DoSetTime(-1);
            DoSetLimite(0);
        }

        private void DoSetLimite(object obj)
        {
            _buts[_index].Background = string.Empty;
            NotifyPropertyChanged("LimiteBut" + _index);
            _index = int.Parse(obj.ToString());
            _buts[_index].Background = ((CL.BS.GameManager.Interface.IVisualMemoryManager)Logic).SetLimit(_index);
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

                RunGame = true;
                gameRun = false;
                NotifyPropertyChanged(nameof(gameRun) );

                base.SetNewGameBut(true);
                for (int i = 0; i < Boards.Length; i++)
                    Boards[i].SetSoldierPosition(false);

                StartGame();
            }
        }
    

        public override void InnerStartGame()
        {
            List<GameObject>[] board = Logic.NewGame();
            for (int i = 0; i < Boards.Length; i++)
            {
                Boards[i].SetBoard(board[i]);
            }
            WaitTimerRun(6);
            for (int i = 0; i < Boards.Length; i++)
                Boards[i].RestartClear();
        
            Answer = ((CL.BS.GameManager.Interface.IVisualMemoryManager)Logic).GetQuestion();
            Common.StaticVar.isTimerRedRun = true;
            PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory
                + @"Resources\Audio\Start.wav");
            for (int i = 0; i < Boards.Length; i++)
                Boards[i].SetQuestion(Answer);
            base.TimerRun();
            if (!RunGame)
                return;
            bool[] lb = new bool[4];
            for (int i = 0; i < Boards.Length; i++)
            {
                lb[i] = Boards[i].CheckBoard(Answer);
                Boards[i].SetAnswer(Answer);
            }
            haveWin = false;
            for (int j = 0; j < lb.Length; j++)
                if (lb[j])
                    haveWin = lb[j];
            if (haveWin)
                for (int j = 0; j < Boards.Length; j++)
                    Boards[j].ClearQuestion();
        }

        void IPageVM.load()
        {
            BackgroundNewGame = string.Empty;
            base.GameSettings();
            base.NotAlaweVolumZiro();
            MiceLogic.Run();
            MiceLogic.NewMouseSplitter();
            for (int i = 0; i < Boards.Length; i++)
                Boards[i].SetMouse(MiceLogic, MiceName[i]);
            ResetGame();
            base.SetBut();
        }

        public override void ResetGame()
        {
            base.SetNewGameBut(false);
            base.ResetGame();
            gameRun = true;
            NotifyPropertyChanged(nameof(gameRun) );
            for (int i = 0; i < Boards.Length; i++)
            {
                Boards[i].ClearQuestion();
                Boards[i].SetSoldierPosition(false);
            }
        }

    }
}
