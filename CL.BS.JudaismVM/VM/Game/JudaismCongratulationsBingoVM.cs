using BS.BingoBoard.VM;
using BS.Items;
using CL.BS.Contract;
using CL.BS.JudaismManager.Interface;
using CL.BS.MEF;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.JudaismVM.VM
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public   class JudaismCongratulationsBingoVM : BaseAutoGameVM, IPageVM
    {
        public override string Name => "JudaismCongratulationsBingoVM";
        public JudaismCongratulationsBingoVM()
        {
            Logic = (IJudaismCongratulationsBingoManager)
              SupportHandlerManager.Base.GetManager("JudaismCongratulationsBingoManager");
            for (int i = 0; i < Boards.Length; i++)
                Boards[i] = new JudaismCongratulationsBingoBoardVM();

            NewGame = new RelayCommand(DoNewGame);
            AnswerBut = new RelayCommand(StopeGame);
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.341;
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.556;
            NotifyPropertyChanged("BoardWidth");
            NotifyPropertyChanged("BoardHeight");
        }

        private void DoNewGame(object obj)
        {
            if (MiceLogic.IsMouseRotation())
            {
                gameRun = false;
                NotifyPropertyChanged("gameRun");
                if (!RunGame)
                {
                    RunGame = true;                  
                    List<GameObject>[] bord = Logic.NewGame();
                    for (int i = 0; i < Boards.Length; i++)
                    {
                        Boards[i].SetBoard(bord[i]);
                        Boards[i].SetSoldierPosition(false);
                    }
                    base.SetNewGameBut(true);
                    RunGame = true;
                    base.StartGame();
                }
            }
        }

        public override void InnerStartGame()
        {
            GameObject q = ((IJudaismCongratulationsBingoManager)Logic).GetQuestion();
            for (int i = 0; i < Boards.Length; i++)
            {
                Boards[i].ClearQuestion();
                Boards[i].SetAnswer(q.Answer);
                Boards[i].SetQuestion(q.Question);
            }
            Answer = ((IJudaismCongratulationsBingoManager)Logic).GetAnswer();
            base.TimerRun();
            if (!RunGame)
                return;
            bool[] lb = new bool[4];
            for (int i = 0; i < Boards.Length; i++)
            {
                // Boards[i].SetAnswer(a);
                lb[i] = Boards[i].CheckBoard(Answer);
                if (!haveWin)
                    haveWin = lb[i];
            }
            //  PlayUrl(a[0]);
            WhitAntilPlayStop(ref RunGame);
        }

        private void StopeGame(object obj)
        {
            if (MiceLogic.IsMouseRotation() && BackgroundNewGame != string.Empty)
            {
                ResetGame();
            }
        }

        void IPageVM.load()
        {
            base.GameSettings();
            BackgroundNewGame = string.Empty;
            base.NotAlaweVolumZiro();
            MiceLogic.Run();
            MiceLogic.NewMouseSplitter();
            for (int i = 0; i < Boards.Length; i++)
                Boards[i].SetMouse(MiceLogic, MiceName[i]);
            ResetGame();
        }

        public override void ResetGame()
        {
            RunGame = false;
            for (int i = 0; i < Boards.Length; i++)
            {
                Boards[i].SetSoldierPosition(false);
                Boards[i].ClearQuestion();
                Boards[i].Clear();
            }
            base.SetNewGameBut(false);
        }
    }
}
