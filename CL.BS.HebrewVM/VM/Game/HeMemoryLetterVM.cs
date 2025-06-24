using BS.BingoBoard.VM;
using BS.Items.Properties;
using CL.BS.Contract;
using CL.BS.HebrewManager.Interface.Game;
using CL.BS.MEF;
using CL.BS.VMCommon;
using MultipleMice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.HebrewVM.Game
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public  class HeMemoryLetterVM : BaseMemoryAutoGameVM,  IPageVM
    {
        public override string Name
        {
            get
            {
                return "HeMemoryLetterVM";
            }
        }
        public ICommand OpenMenu { get; set; }

        public HeMemoryLetterVM()
        {
            Logic = (IMemoryManager)
     SupportHandlerManager.Base.GetManager("HeMemoryLetterManager");
            NewGame = new RelayCommand(DoNewGame);
            for (int i = 0; i < Boards.Length; i++) {
                Boards[i] = new MemoryLetterBoardVM();
            }
            NumLetterLimit = new string[] {"3", "4", "6", "8" };            
          //  Height = "326.4" Width = "668.8"
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.49;
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.425;
            NotifyPropertyChanged("BoardWidth");
            NotifyPropertyChanged("BoardHeight");
            AnswerBut = new RelayCommand(StopeGame);
            OpenMenu = new RelayCommand(DoOpenMenu);
            SetLettersNum = new RelayCommand(DoSetLettersNumNum);
            DoSetLettersNumNum(-1);
        }

        private void DoOpenMenu(object obj)
        {
            if (BackgroundNewGame != string.Empty)
                return;
            base.SetOpenMenuButBlue(true);
            MiceLogic.OnClosing();
            MiceLogic.Close();
            MiceLogic.Dispose();
            WinHeSettingsLetters win = new WinHeSettingsLetters("");
            win.Closed += Win_Closed;
            win.ShowDialog();
        }

        private void Win_Closed(object sender, EventArgs e)
        {
            base.SetOpenMenuButBlue(false);
            base.NotAlaweVolumZiro();
            MiceLogic.Run();
            MiceLogic.NewMouseSplitter();
            for (int i = 0; i < Boards.Length; i++)
                Boards[i].SetMouse(MiceLogic, MiceName[i]);
            base.CardMaxNum = Common.StaticVar.inline._HeLetterList.Count;
        }
               
   
        void IPageVM.load()
        {
            base.CardMaxNum = Common.StaticVar.inline._HeLetterList.Count;
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
                base.SetNewGameBut(true);
                int l = base.GetNumLetterLimit();
                //if (l == 8)
                //    l = 7;
                _letter = Logic.GetNewGame(l);
                for (int i = 0; i < Boards.Length; i++)
                {
                    Boards[i].SetNumLetterLimit(l);
                    Boards[i].Clear();
                    Boards[i].SetBoard(_letter[i]);
                    Boards[i].SetSoldierPosition(false);
                }
                RunGame = true;
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
            Answer = Logic.GetQuestion();
            PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory +
                   @"Resources\Audio\He\Letters\" + Answer + ".wav");
            string a = string.Format(@"{0}Resources\Lang\He\{1}\{2}.png"
, System.AppDomain.CurrentDomain.BaseDirectory, Common.StaticVar.inline._HeIsManuscript ?
"ManuscriptLetters" : "BlackLetters", Common.GeneralFunctions.NoDagesh(Answer));
            for (int i = 0; i < Boards.Length && RunGame; i++)
                Boards[i].SetQuestion(a);
            WhitAntilPlayStop(ref RunGame);
            base.TimerRun();
            if (!RunGame)
                return;
            ListBoards = new bool[4];
            for (int i = 0; i < Boards.Length && RunGame; i++)
            {
                ListBoards[i] = Boards[i].CheckBoard(a);
                if (ListBoards[i]&&Logic.EndGame(false))
                {
                    Boards[i].SetSoldierPosition(true);
                    haveWin = ListBoards[i];
                }
            }
        }

        public override void ResetGame()
        {
            base.SetNewGameBut(false);
            RunGame = false;
            ISFerstGame = true;
            for (int i = 0; i < Boards.Length; i++)
            {
                Boards[i].SetSoldierPosition(false);
                Boards[i].ClearQuestion();
            }
        }
    }
}
