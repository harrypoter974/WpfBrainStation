using BS.BingoBoard.VM;
using BS.Items;
using CL.BS.Contract;
using CL.BS.JudaismManager.Interface;
using CL.BS.MEF;
using CL.BS.Model;
using CL.BS.VMCommon;
using System.Collections.Generic;

namespace CL.BS.JudaismVM.VM
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public  class JudaismCongratulationsMemoryVM : BaseMemoryAutoGameVM, IPageVM
    {
        public override string Name => "JudaismCongratulationsMemoryVM";
        public JudaismCongratulationsMemoryVM()
        {
            Logic = (IJudaismCongratulationsMemoryManager)
              SupportHandlerManager.Base.GetManager("JudaismCongratulationsMemoryManager");
            for (int i = 0; i < Boards.Length; i++)
            {
                Boards[i] = new JudaismCongratulationsMemoryBoardVM();
            }
            NumLetterLimit = new string []{ "3", "4", "5" };
            NewGame = new RelayCommand(DoNewGame);
            AnswerBut = new RelayCommand(StopeGame);
            SetLettersNum = new RelayCommand(SDoSetBrahotNum);
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.416;
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.433;
            NotifyPropertyChanged("BoardWidth");
            NotifyPropertyChanged("BoardHeight");
        }

        private void SDoSetBrahotNum(object obj)
        {
            if (MiceLogic.IsMouseRotation()||obj.ToString()=="-1")
            {
                int n = int.Parse(obj.ToString());
                if (-1 == n)
                    n = 0;
                if (int.Parse(NumLetterLimit[n]) > CardMaxNum && CardMaxNum > 0)
                {
                    DoSetLettersNum(n - 1);
                    return;
                }
                NumLetterBut[LimitIndex].Background = string.Empty;
                NotifyPropertyChanged("NumLetterBut" + LimitIndex);
                LimitIndex = n;
                NumLetterBut[LimitIndex].Background = System.AppDomain.CurrentDomain.BaseDirectory
            + @"Resources\BS.Items\" + CL.BS.Common.StaticVar.LevelButton[LimitIndex] + ".png";
                NotifyPropertyChanged("NumLetterBut" + LimitIndex);
            }
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
                    _letter = Logic.GetNewGame(new[] { 3,4,5}[LimitIndex]);
                    for (int i = 0; i < Boards.Length; i++)
                    {
                        Boards[i].SetBoard(_letter[i]);
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
            if (((JudaismCongratulationsMemoryBoardVM)Boards[0]).getIsFirst())
            {
                for (int i = 1; i < Boards.Length && RunGame; i++)
                {
                    ((JudaismCongratulationsMemoryBoardVM)Boards[i]).getIsFirst();
                }
            }
            GameObject q = ((IJudaismCongratulationsMemoryManager)Logic).GetQuestion();
            for (int i = 0; i < Boards.Length; i++)
            {
                Boards[i].ClearQuestion();
                Boards[i].SetAnswer(q.Answer);
                Boards[i].SetQuestion(q.Question);
            }
            Answer = ((IJudaismCongratulationsMemoryManager)Logic).GetAnswer();
            base.TimerRun();
            if (!RunGame)
                return;
            bool[] lb = new bool[4];
            for (int i = 0; i < Boards.Length; i++)
            {
             //   Boards[i].SetAnswer(a);
                lb[i] = Boards[i].CheckBoard(Answer);
                if (!haveWin)
                    haveWin = lb[i];
            }
        //    PlayUrl(a[0]);
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
            SDoSetBrahotNum(-1);
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
