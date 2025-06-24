
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
    public class HeOpenLetterVM : BaseAutoGameVM, IPageVM
    {
        public override string Name
        {
            get
            {
                return nameof(HeOpenLetterVM);
            }
        }
        public ICommand OpenMenu { get; set; }

        public HeOpenLetterVM()
        {
            Logic = (IHeOpenLetterManager)
SupportHandlerManager.Base.GetManager("HeOpenLetterManager");
            NewGame = new RelayCommand(DoNewGame);
            for (int i = 0; i < Boards.Length; i++) {
                Boards[i] = new BingoOpenLetterBoardVM(false);
            }
            //  Height="375.2" Width="392.8"
             BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.49;
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.288;          
            NotifyPropertyChanged(nameof(BoardWidth));
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
              new WinHeSettingsLetters("");
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
                RunGame = true;
                StartGame();
            }
        }

        public override void InnerStartGame()
        {
            for (int i = 0; i < Boards.Length; i++)
                Boards[i].ClearQuestion();
            string q = ((IHeOpenLetterManager)Logic).GetQuestion();
            for (int i = 0; i < Boards.Length; i++)
                Boards[i].SetQuestion(q);
            string[] a = ((IHeOpenLetterManager)Logic).GetAnswer();
            Answer = a[1];
            base.TimerRun();
            if (!RunGame)
                return;
            bool[] lb = new bool[4];
            for (int i = 0; i < Boards.Length; i++)
            {
                Boards[i].SetAnswer(a[1]);
                lb[i] = Boards[i].CheckBoard(a[2]);
                if (!haveWin)
                    haveWin = lb[i];
            }
            PlayUrl(a[0]);
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
