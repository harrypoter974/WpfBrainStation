
using BS.BingoBoard.VM;
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

namespace CL.BS.HebrewVM.Game
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
  public  class HeWordGameVM : BaseAutoGameVM,  IPageVM
    {
        public override string Name
        {
            get
            {
                return nameof(HeWordGameVM);
            }
        }

        public HeWordGameVM()
        {
            Logic = (IHeWordGameManager)
SupportHandlerManager.Base.GetManager("HeWordGameManager");
            NewGame = new RelayCommand(DoNewGame);
            for (int i = 0; i < Boards.Length; i++) {
                Boards[i] = new WordsGameBoardVM();
            }
            //  Height="375.2" Width="464"
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.302;
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.489;
            NotifyPropertyChanged(nameof(BoardWidth));
            NotifyPropertyChanged(nameof(BoardHeight));
            AnswerBut = new RelayCommand(StopeGame);
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
                base.SetNewGameBut(false);
            }
            else
            {
                gameRun = false;
                NotifyPropertyChanged(nameof(gameRun));
                List<GameObject>[] b = Logic.NewGame();
                for (int i = 0; i < Boards.Length; i++)
                {
                    Boards[i].SetSoldierPosition(false);
                    Boards[i].SetBoard(b[i]);
                }
                base.SetNewGameBut(true);
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

        public override void InnerStartGame()
        {
            for (int i = 0; i < Boards.Length; i++)
                Boards[i].ClearQuestion();
            string q = ((IHeWordGameManager)Logic).GetQuestion();
            for (int i = 0; i < Boards.Length; i++)
                Boards[i].SetQuestion(q);
            string[] a = ((IHeWordGameManager)Logic).GetAnswer();
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
            PlayUrl(a[0]);
        }
       
        void IPageVM.load()
        {
            BackgroundNewGame = string.Empty;
            base.GameSettings();
            base.NotAlaweVolumZiro();
            MiceLogic.Run();
            MiceLogic.NewMouseSplitter();
            for (int i = 0; i < Boards.Length; i++) {
                Boards[i].SetMouse(MiceLogic, MiceName[i]);
            }
            ResetGame();
            base.SetBut();
        }
    }
}
