using BS.BingoBoard.VM;
using CL.BS.Contract;
using CL.BS.MEF;
using CL.BS.Model;
using CL.BS.NotionsManager.Interface;
using CL.BS.VMCommon;
using MultipleMice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CL.BS.NotionsVM.VM.Colors
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class ColorsBingoVM : BaseAutoGameVM, IPageVM
    {
        public override string Name => nameof(ColorsBingoVM);
        
        public ColorsBingoVM()
        {
            Logic = (IColorsBingoManager)
SupportHandlerManager.Base.GetManager("ColorsBingoManager");
            NewGame = new RelayCommand(DoNewGame);
            AnswerBut = new RelayCommand(StopeGame);
            SetTime = new RelayCommand(DoSetLevel);
            for (int i = 0; i < Boards.Length; i++) {
                Boards[i] = new BingoPicBoardVM();
            }
            TimerList = new string[] {  "3", "7", "12" };
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.354;
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.38;
            NotifyPropertyChanged(nameof(BoardWidth));
            NotifyPropertyChanged(nameof(BoardHeight));
        }

        void IPageVM.load()
        {
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

        private void DoSetLevel(object obj)
        {
            if (MiceLogic.IsMouseRotation())
            {
                TimerBut[TimerIndex].Background = string.Empty;
                NotifyPropertyChanged("TimerBut" + TimerIndex);
                int ti = int.Parse(obj.ToString());
                TimerBut[ti].Background = System.AppDomain.CurrentDomain.BaseDirectory
                    + @"Resources\BS.Items\" + Common.StaticVar.LevelButton[ti] + ".png";
                NotifyPropertyChanged("TimerBut" + ti);
                Timer = TimerList[ti];
                TimerIndex = ti;
            }
        }

        private void StopeGame(object sender)
        {
            base.DoExitBut(0);
            if (gameRun)
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
                    Boards[i].SetBoard(b[i + 1]);
                }
                RunGame = true;
                StartGame();
            }
        }

        public override void InnerStartGame()
        {
            for (int i = 0; i < Boards.Length; i++)
                Boards[i].ClearQuestion();
            PlayUrl(((IColorsBingoManager )Logic).GetQuestion());
            Answer = ((IColorsBingoManager) Logic).GetAnswer();
            base.TimerRun();
            if (!RunGame)
                return;
            bool[] lb = new bool[4];
            for (int i = 0; i < Boards.Length; i++)
            {
                lb[i] = Boards[i].CheckBoard(Answer);
                if (!haveWin)
                    haveWin = lb[i];
                Boards[i].SetAnswer(Answer);
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
    }
}
