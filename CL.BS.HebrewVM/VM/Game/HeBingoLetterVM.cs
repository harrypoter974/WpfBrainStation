using BS.BingoBoard.VM;
using BS.Items.Properties;
using CL.BS.Contract;
using CL.BS.HebrewManager.Interface.Game;
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

namespace CL.BS.HebrewVM.Game
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class HeBingoLetterVM : BaseAutoGameVM, IPageVM
    {
        public override string Name
        {
            get
            {
                return nameof(HeBingoLetterVM);
            }
        }

        public HeBingoLetterVM()
        {
            Logic = (IHeBingoLetterManager)
        SupportHandlerManager.Base.GetManager("HeBingoLetterManager");
            NewGame = new RelayCommand(DoNewGame);
            for (int i = 0; i < Boards.Length; i++) 
                Boards[i] = new BingoLetterBoardVM();
            //Height="290.4" Width="405"
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth *0.3;
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight *  0.378;
            NotifyPropertyChanged(nameof(BoardWidth) );
            NotifyPropertyChanged(nameof(BoardHeight));
            AnswerBut = new RelayCommand(StopeGame);
            OpenMenu = new RelayCommand(DoOpenMenu);
        }

        private void DoOpenMenu(object obj)
        {
            if (BackgroundNewGame != string.Empty)
                return;
            base.SetOpenMenuButBlue(true);
            MiceLogic.OnClosing();
            MiceLogic.Close();
            MiceLogic.Dispose();
            WinHeSettingsLetters win =
              new WinHeSettingsLetters(string.Empty);
            win.Closed += Win_Closed;
            win.ShowDialog();
        }

        private void Win_Closed(object sender, EventArgs e)
        {
            base.SetOpenMenuButBlue(false);
            base.NotAlaweVolumZiro();
            MiceLogic.Run();
            MiceLogic.NewMouseSplitter();
            for (int i = 0; i < Boards.Length; i++)
                Boards[i].SetMouse(MiceLogic, MiceName[i]);
        }

        public ICommand OpenMenu { get; set; }

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
                RunGame = true;
                for (int i = 0; i < Boards.Length; i++)
                    Boards[i].SetSoldierPosition(false);
                base.SetNewGameBut(true);
                List<GameObject>[] board = Logic.NewGame();
                for (int i = 0; i < Boards.Length; i++)
                {
                    Boards[i].RestartClear();
                    Boards[i].SetBoard(board[i]);
                    Boards[i].SetSoldierPosition(false);
                }
                StartGame();
            }
        }

        public override void InnerStartGame()
        {
            PlayUrl(((IHeBingoLetterManager)Logic).GetQuestion());
            WhitAntilPlayStop(ref RunGame);
            for (int i = 0; i < Boards.Length; i++)
                Boards[i].ClearQuestion();
            Answer = ((IHeBingoLetterManager)Logic).GetAnswer();
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
