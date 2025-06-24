using BS.BingoBoard.View;
using BS.BingoBoard.VM;
using BS.Items;
using CL.BS.Contract;
using CL.BS.EnglishManager.Interface;
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
using System.Windows.Forms;
using System.Windows.Input;

namespace CL.BS.HebrewVM.Game.BS.EnglishVM.Game
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class EnBingoLetterVM : BaseAutoGameVM, IPageVM
    {

        public ICommand OpenMenu { get; set; }
        WinEnSettingsLetters _win;

        public override string Name
        {
            get
            {
                return nameof(EnBingoLetterVM);
            }
        }

        public EnBingoLetterVM()
        {
            Logic = (IEnBingoLetterManager)
                SupportHandlerManager.Base.GetManager("EnBingoLetterManager");
           // AnswerBut = new RelayCommand(DoAnswerBut);
            NewGame   = new RelayCommand(DoNewGame);
            //SetSize   = new RelayCommand(DoSetSize);
            for (int i = 0; i < Boards.Length; i++) {
                Boards[i] = new BingoLetterBoardVM() { GameName= nameof(EnBingoLetterVM),Language ="E"};
            }
            //DoSetSize("big");Height="290.4" Width="405"
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.3;
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.38;
            NotifyPropertyChanged(nameof(BoardWidth));
            NotifyPropertyChanged(nameof(BoardHeight));
            AnswerBut = new RelayCommand(StopeGame);
            OpenMenu = new RelayCommand(DoOpenMenu);
            Timer = "10";
        }
        private void DoOpenMenu(object obj)
        {
            base.SetOpenMenuButBlue(true);
            MiceLogic.OnClosing();
            MiceLogic.Close();
            MiceLogic.Dispose();
           _win = new WinEnSettingsLetters();
            _win.Closed += Win_Closed;
            _win.ShowDialog();
        }

        private void Win_Closed(object sender, EventArgs e)
        {
            ((IEnBingoLetterManager)Logic).SetSize(_win.IsBig());
            base.SetOpenMenuButBlue(false);
            base.NotAlaweVolumZiro();
            MiceLogic.Run();
            MiceLogic.NewMouseSplitter();
            for (int i = 0; i < Boards.Length; i++)
                Boards[i].SetMouse(MiceLogic, MiceName[i]);
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
                RunGame = true;
                StartGame();
            }
        }
        public override void InnerStartGame()
        {
             PlayUrl(((IEnBingoLetterManager)Logic).GetQuestion());
            WhitAntilPlayStop(ref RunGame);
            for (int i = 0; i < Boards.Length; i++)
                Boards[i].ClearQuestion();
            Answer = ((IEnBingoLetterManager)Logic).GetAnswer();
            base.TimerRun();
            if (!RunGame)
                return;
            bool[] lb = new bool[4];
            for (int i = 0; i < Boards.Length; i++)
            {
                Boards[i].SetAnswer(Answer);
                lb[i] = Boards[i].CheckBoard(Answer);
                if (!haveWin)
                    haveWin = lb[i];
            }
        }

        void IPageVM.load()
        {
            base.GameSettings();
            BackgroundNewGame = string.Empty;
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
            RunGame = false;
            for (int i = 0; i < Boards.Length; i++)
            {
                Boards[i].SetSoldierPosition(false);
                Boards[i].Clear();
            }
        }
    }
}
