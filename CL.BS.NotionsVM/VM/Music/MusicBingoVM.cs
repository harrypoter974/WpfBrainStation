using BS.BingoBoard.VM;
using CL.BS.Contract;
using CL.BS.MEF;
using CL.BS.Model;
using CL.BS.NotionsManager.Interface;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.NotionsVM.VM.Music
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class MusicBingoVM : BaseAutoGameVM, IPageVM
    {
        public override string Name =>nameof(MusicBingoVM);
        public MusicBingoVM()
        {

            Logic = (IMusicBingoManager)
SupportHandlerManager.Base.GetManager("MusicBingoManager");
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.342;
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.491;
            NotifyPropertyChanged(nameof(BoardWidth));
            NotifyPropertyChanged(nameof(BoardHeight));
            NewGame = new RelayCommand(DoNewGame);
            AnswerBut = new RelayCommand(StopeGame);
            for (int i = 0; i < Boards.Length; i++)
            {
                Boards[i] = new BingoVocabularyBoardVM();
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
                ResetGame();
                base.SetNewGameBut(false);
            }
            else
            {
                gameRun = false;
                NotifyPropertyChanged(nameof(gameRun) );

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
            string q = ((IMusicBingoManager)Logic).GetQuestion();
            PlayUrl(string.Format(
 @"{0}Resources\Audio\Music\{1}.wav", System.AppDomain.CurrentDomain.BaseDirectory, q));
            for (int i = 0; i < Boards.Length; i++)
            {
                Boards[i].ClearQuestion();
                Boards[i].SetQuestion(base.Answer);
            }
            base.TimerRun();
            if (!RunGame)
                return;
            PlayUrl(string.Format(
 @"{0}Resources\Audio\Music\Ex_{1}.wav", System.AppDomain.CurrentDomain.BaseDirectory, q));
            bool[] lb = new bool[4];
            for (int i = 0; i < Boards.Length; i++)
            {
                lb[i] = Boards[i].CheckBoard("T"+q+ ".png");
                if (!haveWin)
                    haveWin = lb[i];
                Boards[i].SetAnswer(base.Answer);
            }
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
            RunGame = false;
            gameRun = true;
            for (int i = 0; i < Boards.Length; i++)
            {
                Boards[i].SetSoldierPosition(false);
                Boards[i].Clear();
            }
        }
    }
}
