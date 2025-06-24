using BS.BingoBoard.VM;
using CL.BS.Contract;
using CL.BS.MEF;
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

namespace CL.BS.NotionsVM.VM.Colors
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class ColorsMemoryVM : BaseMemoryAutoGameVM, IPageVM
    {
        public override string Name => "ColorsMemoryVM";

        public ColorsMemoryVM()
        {
            Logic = (IColorsMemoryManager)
    SupportHandlerManager.Base.GetManager("ColorsMemoryManager");
            NewGame = new RelayCommand(DoNewGame);
            AnswerBut = new RelayCommand(StopeGame);
            SetTime = new RelayCommand(DoSetLevel);
            TimerList = new string[] { "3", "7", "12" };
            SetTime = new RelayCommand(DoSetLevel);
            NumLetterLimit = new string[] { "3", "4", "5" };
            for (int i = 0; i < Boards.Length; i++)
            {
                Boards[i] = new MemoryLetterBoard7VM();
            }
            //   Width="667.2" Height="347.2"            
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.47;
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.43;
            NotifyPropertyChanged("BoardWidth");
            NotifyPropertyChanged("BoardHeight");
        }

        void IPageVM.load()
        {
            ISFerstGame = true;
            base.GameSettings();
            base.NotAlaweVolumZiro();
            ResetGame();
            base.SetBut();
            DoMemorySetPlayer(3);
            MiceLogic.Run();
            MiceLogic.NewMouseSplitter();
            for (int i = 0; i < Boards.Length; i++)
            {
                Boards[i].SetMouse(MiceLogic, MiceName[i]);
            }
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
                LimitIndex = TimerIndex = ti;
            }
        }

   

        public override void ResetGame()
        {
            RunGame = false;
            for (int i = 0; i < Boards.Length; i++)
            {
                Boards[i].SetSoldierPosition(false);
                Boards[i].ClearQuestion();
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
                RunGame = true;
                gameRun = false;
                NotifyPropertyChanged(nameof(gameRun));

                base.SetNewGameBut(true);
                _letter = Logic.GetNewGame(base.GetNumLetterLimit());
                for (int i = 0; i < Boards.Length; i++)
                {
                    Boards[i].SetNumLetterLimit(base.GetNumLetterLimit());
                    Boards[i].SetBoard(_letter[i]);
                    Boards[i].SetSoldierPosition(false);
                }
                StartGame();
            }
        }

        public override void InnerStartGame()
        {
            if (Boards[0].QuestionIsAnswer())
            {
                for (int i = 0; i < Boards.Length && RunGame; i++)
                {
                    Boards[i].Clear();
                    Boards[i].QuestionIsAnswer();
                }
                Thread.Sleep(1000);
            }
            string[] q = ((IColorsMemoryManager)Logic).GetQuestion();
            for (int i = 0; i < Boards.Length && RunGame; i++)
                Boards[i].SetQuestion(q[0]);
            PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory +
                        @"Resources\Audio\He\General\" + q[1] + ".wav");
            base.TimerRun();
            if (!RunGame)
                return;
            ListBoards = new bool[4];
            for (int i = 0; i < Boards.Length && RunGame; i++)
            {
                ListBoards[i] = Boards[i].CheckBoard(q[0]);
                if (ListBoards[i])
                {
                    Boards[i].SetSoldierPosition(true);
                    haveWin = ListBoards[i];
                }
            }

        }
    }
}
