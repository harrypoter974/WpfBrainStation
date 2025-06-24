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
using System.Windows.Input;

namespace CL.BS.HebrewVM.Game.BS.EnglishVM.Game
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
  public  class EnBingoOpenLetterVM : BaseAutoGameVM,  IPageVM
    {
        public override string Name
        {
            get
            {
                return nameof(EnBingoOpenLetterVM);
            }
        }
        public ICommand OpenMenu { get; set; }
        private bool _isBigEnLetter;
        public EnBingoOpenLetterVM()
        {
            Logic = (IEnBingoOpenLetterManager)
 SupportHandlerManager.Base.GetManager("EnBingoOpenLetterManager");
            NewGame = new RelayCommand(DoNewGame);
            for (int i = 0; i < Boards.Length; i++) {
                Boards[i] = new BingoOpenLetterBoardVM() { GameName =nameof(EnBingoOpenLetterVM) , Language = "E" };
            }
            //Height="375.2" Width="392.8" 
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.288;
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.489;
            NotifyPropertyChanged(nameof(BoardWidth) );
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
            WinEnSettingsLetters win =
              new WinEnSettingsLetters();
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
            {
                ResetGame();
            }
            else
            {
                gameRun = false;
                NotifyPropertyChanged(nameof(gameRun));
                RunGame = true;
                base.SetNewGameBut(true);
                List<GameObject>[] board = Logic.NewGame();
                for (int i = 0; i < Boards.Length; i++)
                {
                    Boards[i].SetBoard(board[i]);
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

        public override void InnerStartGame()
        {

            string q = ((IEnBingoOpenLetterManager)Logic).GetQuestion();
            for (int i = 0; i < Boards.Length; i++)
            {
                Boards[i].ClearQuestion();
                Boards[i].SetQuestion(q);
            }
            string[] a = ((IEnBingoOpenLetterManager)Logic).GetAnswer();
            Answer = a[1];
            base.TimerRun();
            if (!RunGame)
                return;
            bool[] lb = new bool[4];
            for (int i = 0; i < Boards.Length; i++)
            {
                Boards[i].SetAnswer(a[1]);
                lb[i] = Boards[i].CheckBoard(a[1]);
                if (!haveWin)
                    haveWin = lb[i];
            }
            PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory + a[0]);
            WhitAntilPlayStop(ref RunGame);
        }  

        void IPageVM.load()
        {
            _isBigEnLetter = Common.StaticVar.inline._IsBigEnLetter;
            Common.StaticVar.inline._IsBigEnLetter = true;
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
        void IPageVM.disload()
        {
             Common.StaticVar.inline._IsBigEnLetter=_isBigEnLetter;
            disload();
        }
    }
}
