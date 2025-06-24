using BS.BingoBoard.VM;
using CL.BS.Contract;
using CL.BS.MEF;
using CL.BS.ShapesManager.Interface;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CL.BS.ShapesVM.VM.Game
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class ShapeMemoryVM : BaseMemoryAutoGameVM, IPageVM
    {
        public override string Name { get {return nameof(ShapeMemoryVM); }}
        public ShapeMemoryVM()
        {
            Logic = (IShapesGameManager)
  SupportHandlerManager.Base.GetManager("ShapesGameManager");
            BoardWidth = SystemParameters.PrimaryScreenWidth * 0.498;
            BoardHeight = SystemParameters.PrimaryScreenHeight * 0.429;
            NotifyPropertyChanged(nameof(BoardWidth));
            NotifyPropertyChanged(nameof(BoardHeight));
            for (int i = 0; i < Boards.Length; i++)
            {
                Boards[i] = new MemoryLetterBoard7VM();
            }
            Timer = "9";
            TimerIndex = 2;
            AnswerBut = new RelayCommand(StopeGame);
            NewGame = new RelayCommand(DoNewGame);
            SetPlayer = new RelayCommand(DOSetPlayer);
            SetLettersNum = new RelayCommand(doSetLettersNum);
            NumLetterLimit = new string[] { "3", "4", "5", "6" };
            doSetLettersNum(-1);
            DOSetPlayer(10);
        }
        void IPageVM.load()
        {
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

        protected void doSetLettersNum(object obj)
        {
            int n = int.Parse(obj.ToString());
            if (MiceLogic.IsMouseRotation() || n == -1)
            {
                n = n == -1 ? 0 : n;
                if (int.Parse(NumLetterLimit[n]) > CardMaxNum && CardMaxNum > 0)
                {
                    doSetLettersNum(n - 1);
                    return;
                }
                NumLetterBut[LimitIndex].Background = string.Empty;
                NotifyPropertyChanged("NumLetterBut" + LimitIndex);
                LimitIndex = n;
                NumLetterBut[LimitIndex].Background = System.AppDomain.CurrentDomain.BaseDirectory
                + @"Resources\Number\" + NumLetterLimit[LimitIndex] + "b.png";
                NotifyPropertyChanged("NumLetterBut" + LimitIndex);
            }
        }
        private void DOSetPlayer(object obj)
        {
            bool b = obj.ToString() == "1" || obj.ToString() == "-1";
            if (b)
            {
                PlayerBut[1].Background = System.AppDomain.CurrentDomain.BaseDirectory
             + @"Resources\BS.Items\Image.png";
                PlayerBut[0].Background = string.Empty;
            }
            else
            {
                PlayerBut[0].Background = System.AppDomain.CurrentDomain.BaseDirectory
                   + @"Resources\BS.Items\Word.png";
                PlayerBut[1].Background = string.Empty;
            }
           ((IShapesGameManager) Logic).DoChangeMode(b);
            NotifyPropertyChanged(nameof(PlayerBut0));
            NotifyPropertyChanged(nameof(PlayerBut1));
        }


        private void StopeGame(object obj)
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
                ResetGame();
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
                    Boards[i].SetSoldierPosition(false);
                    Boards[i].SetBoard(_letter[i]);
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
                WhitTime(1000, ref RunGame);
            }
            WhitAntilPlayStop(ref RunGame);
            string[][] q = ((IShapesGameManager)Logic).GetMemoryQuestion();
            if (PlayerBut[0].Background == string.Empty)
                PlayList(q[1]);
            for (int i = 0; i < Boards.Length && RunGame; i++)
                Boards[i].SetQuestion(q[0][0]);
            WhitAntilPlayStop(ref RunGame);
            Answer = q[2][0];
            base.TimerRun();
            if (!RunGame)
                return;
            if (PlayerBut[0].Background!= string.Empty)
                PlayList(q[1]);
            ListBoards = new bool[4];
            //  PlayerBut[0].Background == string.Empty ? q.Replace(".jpg", ".png") : q.Replace(".png", ".jpg");

            for (int i = 0; i < Boards.Length && RunGame; i++)
            {
                ListBoards[i] = Boards[i].CheckBoard(Answer);
                if (ListBoards[i] && Logic.EndGame(false))
                {
                    Boards[i].SetSoldierPosition(true);
                    haveWin = ListBoards[i];
                }
            }
            //WaitTimerRun(2);
            for (int i = 0; i < Boards.Length && RunGame; i++)
                Boards[i].SetAnswer("");
        }


        public override void ResetGame()
        {
            base.SetNewGameBut(false);
            RunGame = false;
            gameRun = true;
            for (int i = 0; i < Boards.Length; i++)
            {
                Boards[i].SetSoldierPosition(false);
                Boards[i].ClearQuestion();
            }
        }
    }
}
