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
using System.Windows.Input;

namespace CL.BS.NotionsVM.VM.Clock
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class ClockBingoAnalogVM : BaseAutoGameVM, IPageVM
    {
        public override void ResetGame()
        {
            RunGame = false;
            for (int i = 0; i < Boards.Length; i++)
            {
                Boards[i].SetSoldierPosition(false);
                Boards[i].Clear();
            }
        }
        public string IsWholeHoursBut { get; set; }
        public ICommand IsWholeHours { get; set; }
        public override string Name
        {
            get
            {
                return nameof(ClockBingoAnalogVM);
            }
        }

        public ClockBingoAnalogVM()
        {
            Logic = (IClockBingoManager)
    SupportHandlerManager.Base.GetManager("ClockBingoManager");
            NewGame = new RelayCommand(DoNewGame);
            IsWholeHours = new RelayCommand(DoIsWholeHours);
            for (int i = 0; i < Boards.Length; i++) {
                Boards[i] = new ClockBingoAnalogBoardVM();
            }
            Timer = "9";
            TimerIndex = 2;
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.35;
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.4;
            NotifyPropertyChanged(nameof(BoardWidth));
            NotifyPropertyChanged(nameof(BoardHeight));
            AnswerBut = new RelayCommand(StopeGame);          
        }
        
        void IPageVM.load()
        {
            IsWholeHoursBut = ((IClockBingoManager)Logic).SetIsWholeHours(true);
            NotifyPropertyChanged(nameof(IsWholeHoursBut));
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

        private void DoIsWholeHours(object obj)
        {
            IsWholeHoursBut = ((IClockBingoManager)Logic).SetIsWholeHours();
            NotifyPropertyChanged(nameof(IsWholeHoursBut));
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
                base.SetNewGameBut(true);
                List<GameObject>[] b = Logic.NewGame();
                for (int i = 0; i < Boards.Length; i++)
                {
                    Boards[i].SetSoldierPosition(false);
                    Boards[i].Clear();
                    Boards[i].SetBoard(b[i + 1]);
                }
                RunGame = true;
                StartGame();
            }
        }
      

        public override void InnerStartGame()
        {
            int[] q = ((IClockBingoManager)Logic).GetQuestion();
            for (int i = 0; i < Boards.Length; i++)
                Boards[i].SetQuestion(q[0] + ":" + q[1]);
            Answer = ((IClockBingoManager)Logic).GetAnswer();
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
            PlayList(((IClockBingoManager)Logic).PlayHour(q[0], q[1]));
        }
    }
}
