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
    public class BingoNumVM : BaseAutoGameVM, IPageVM
    {
        public override string Name
        {
            get
            {
                return nameof(BingoNumVM);
            }
        }
        private int _Limit = 0;
        public BingoNumVM()
        {
            Logic = (IBingoNumManager)
SupportHandlerManager.Base.GetManager("BingoNumManager");
            NewGame = new RelayCommand(DoNewGame);
            for (int i = 0; i < Boards.Length; i++) {
                Boards[i] = new BingoLetterBoardVM();
            }
            // Height="290.4" Width="405"
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.3;
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.38;
            NotifyPropertyChanged(nameof(BoardWidth) );
            NotifyPropertyChanged(nameof(BoardHeight));
            SetPlayer = new RelayCommand(DoSetLimit);
            AnswerBut = new RelayCommand(StopeGame);
        }

        private void DoSetLimit(object obj)
        {
            PlayerBut[_Limit].Background = string.Empty;
            NotifyPropertyChanged("PlayerBut" + _Limit);
           _Limit= int.Parse(obj.ToString());
            int limit = new int[] { 10, 40, 100 }[_Limit];
            PlayerBut[_Limit].Background = System.AppDomain.CurrentDomain.BaseDirectory
                                 + @"Resources\Number\l" + limit + ".png";
            NotifyPropertyChanged("PlayerBut" + _Limit);
            ((IBingoNumManager)Logic).SetLimit(limit);
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
            ((IBingoNumManager)Logic).SwitchLanguage("He");
            DoSetLimit(0);
        }
        void IPageVM.disload()
        {
            base.disload(); 
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
            string[] play = ((IBingoNumManager)Logic).GetQuestion();
            if (play.Length==1)
                PlayUrl (play[0]) ;  
            else
                PlayList(play);
            WhitAntilPlayStop(ref RunGame);
            for (int i = 0; i < Boards.Length; i++)
                Boards[i].ClearQuestion();
            Answer = ((IBingoNumManager)Logic).GetAnswer();
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
