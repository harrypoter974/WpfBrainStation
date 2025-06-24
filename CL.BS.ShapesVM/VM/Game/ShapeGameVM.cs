using CL.BS.Contract;
using CL.BS.MEF;
using CL.BS.Model;
using CL.BS.ShapesManager.Interface;
using CL.BS.VMCommon;
using MultipleMice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace CL.BS.ShapesVM.VM.Game
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class ShapeGameVM : BaseAutoGameVM, IPageVM
    {         
        public override string Name
        {
            get
            {
                return nameof(ShapeGameVM) ;
            }
        }
        public ShapeGameVM()
        {
            Logic = (IShapesGameManager)
  SupportHandlerManager.Base.GetManager("ShapesGameManager");
            NewGame = new RelayCommand(DoNewGame);
            for (int i = 0; i < Boards.Length; i++) {
                Boards[i] = new ShapeGameBoardVM();
            }
            Timer ="9";
            TimerIndex = 2;
            AnswerBut = new RelayCommand(StopeGame);
            BoardWidth = SystemParameters.PrimaryScreenWidth * 0.341;
            BoardHeight = SystemParameters.PrimaryScreenHeight * 0.483;
            NotifyPropertyChanged(nameof(BoardWidth));
            NotifyPropertyChanged(nameof(BoardHeight));
            SetPlayer = new RelayCommand(DOSetPlayer);
            DOSetPlayer(0);
        }

        private void DOSetPlayer(object obj)
        {
            if ( MiceLogic.IsMouseRotation())
            {
                bool b = obj.ToString() == "1";
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
                Logic.DoChangeMode(b);
                NotifyPropertyChanged(nameof(PlayerBut0));
                NotifyPropertyChanged(nameof(PlayerBut1));
            }
        }

        void IPageVM.load()
        {
            base.GameSettings();
            base.NotAlaweVolumZiro();
            MiceLogic.Run();
            MiceLogic.NewMouseSplitter ();
            for (int i = 0; i < Boards.Length; i++) {
                Boards[i].SetMouse(MiceLogic, MiceName[i]);
            }
            ResetGame();
            base.SetBut();
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
                ResetGame();
            else
            {
                RunGame = true;
                gameRun = false;
                NotifyPropertyChanged(nameof(gameRun));
                base.SetNewGameBut(true);
                List<GameObject>[] b = Logic.NewGame();
                for (int i = 0; i < Boards.Length; i++)
                {
                    Boards[i].SetBoard(b[i]);
                    Boards[i].SetSoldierPosition(false);
                }
                StartGame();
            }
        }

        public override void InnerStartGame()
        {
            for (int i = 0; i < Boards.Length; i++)
                Boards[i].ClearQuestion();
            string q = ((IShapesGameManager)Logic).GetQuestion();
            //PlayUrl(q);
            for (int i = 0; i < Boards.Length; i++)
                Boards[i].SetQuestion(q);
            string[][] a = ((IShapesGameManager)Logic).GetAnswer();
            Answer = a[1][0];
            if (PlayerBut[0].Background == string.Empty)
                PlayList(a[0]);
            WhitAntilPlayStop(ref RunGame);
            base.TimerRun();
            if (!RunGame)
                return;
          if(  PlayerBut[0].Background!= string.Empty)
                PlayList(a[0]);
            bool[] lb = new bool[4];
            for (int i = 0; i < Boards.Length; i++)
            {
                Boards[i].SetAnswer(a[1][0]);
                lb[i] = Boards[i].CheckBoard(a[1][0]);
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
