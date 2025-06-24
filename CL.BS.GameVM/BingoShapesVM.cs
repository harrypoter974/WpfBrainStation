using BS.BingoBoard.VM;
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

namespace CL.BS.GameVM
{

    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class BingoShapesVM : BaseAutoGameVM, IPageVM
    {
        public override string Name => nameof(BingoShapesVM);
        public BingoShapesVM()
        {
            for (int i = 0; i < Boards.Length; i++)
                Boards[i] = new BingoVocabularyBoardVM();
            Logic = (IBingoShapesManager)
            SupportHandlerManager.Base.GetManager("BingoShapesManager");
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.342;
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.491;
            NotifyPropertyChanged(nameof(BoardWidth));
            NotifyPropertyChanged(nameof(BoardHeight));
            NewGame = new RelayCommand(DoNewGame);
            AnswerBut = new RelayCommand(StopeGame);
        }
        void IPageVM.load()
        {
            Common.MiceKiller.KillAllMices(true);           
            base.GameSettings();
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
        public override void ResetGame()
        {
            base.ResetGame();
            for (int i = 0; i < Boards.Length; i++)
            {
                Boards[i].Clear();
            }
        }
        private void StopeGame(object sender)
        {
            if (gameRun)
            {
                base.DoExitBut(0);
            }
            else
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
                base.SetNewGameBut(true);
                List<GameObject>[] b = Logic.NewGame();
                for (int i = 0; i < Boards.Length; i++)
                {
                    Boards[i].SetSoldierPosition(false);
                    Boards[i].SetBoard(b[i]);
                }
                RunGame = true;
                StartGame();
            }
        }

        public override void InnerStartGame()
        {
            string[] q = ((IBingoShapesManager)Logic).GetQuestion();
            base.Answer=q[0];
            for (int i = 0; i < Boards.Length; i++)
            {
                Boards[i].ClearQuestion();
                Boards[i].SetQuestion(base.Answer);
            }
            base.TimerRun();
            if (!RunGame)
                return;
            bool[] lb = new bool[4];
            for (int i = 0; i < Boards.Length; i++)
            {
                lb[i] = Boards[i].CheckBoard(q[1]);
                if (!haveWin)
                    haveWin = lb[i];
                Boards[i].SetAnswer(base.Answer);
            }
        }
    }
}
