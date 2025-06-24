using BS.BingoBoard.VM;
using BS.Items;
using CL.BS.Contract;
using CL.BS.EnglishManager.Interface;
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

namespace CL.BS.HebrewVM.Game.BS.EnglishVM.Game
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
 public   class EnMemoryLetterVM : BaseMemoryAutoGameVM,  IPageVM
    {
        public override string Name { get { return nameof(EnMemoryLetterVM); } }
        public ICommand OpenMenu { get; set; }

        public EnMemoryLetterVM()
        {
            Logic = (IEnMemoryLetterManager)
           SupportHandlerManager.Base.GetManager("EnMemoryLetterManager");
            for (int i = 0; i < Boards.Length; i++) 
                Boards[i] = new MemoryLetterBoardVM() { GameName = nameof(EnMemoryLetterVM), Language = "E" };           
//Height="326.4" Width="668.8"
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.425;
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.49;
            NotifyPropertyChanged(nameof(BoardWidth));
            NotifyPropertyChanged(nameof(BoardHeight));
            AnswerBut = new RelayCommand(StopeGame);
            OpenMenu = new RelayCommand(DoOpenMenu);
            NewGame = new RelayCommand(DoNewGame);
            Timer = "10";
            NumLetterLimit = new string[] {"3","4","6","8" };
            SetLettersNum = new RelayCommand(DoSetLettersNumNum);
            DoSetLettersNumNum(-1);
        }


        private void DoOpenMenu(object obj)
        {
            base.SetOpenMenuButBlue(true);
            MiceLogic.OnClosing();
            MiceLogic.Close();
            MiceLogic.Dispose();
            WinEnSettingsLetters win =
              new WinEnSettingsLetters();
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
            base.CardMaxNum = Common.StaticVar.inline._EnLetterList.Length;
        }

        void IPageVM.load()
        {
            base.GameSettings();
            base.CardMaxNum = Common.StaticVar.inline._EnLetterList.Length;
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
                base.SetNewGameBut(false);
            }
            else
            {
                gameRun = false;
                NotifyPropertyChanged(nameof(gameRun));
                base.SetNewGameBut(true);
                _letter = Logic.GetNewGame(base.GetNumLetterLimit());
                for (int i = 0; i < Boards.Length; i++)
                {
                    Boards[i].SetNumLetterLimit(base.GetNumLetterLimit());
                    Boards[i].Clear();
                    Boards[i].SetBoard(_letter[i]);
                    Boards[i].SetSoldierPosition(false);
                }
                RunGame = true;
                StartGame();
            }
        }
        
      
        public override void ResetGame()
        {
            RunGame = false;
            ISFerstGame = true;
            for (int i = 0; i < Boards.Length; i++)
            {
                Boards[i].SetSoldierPosition(false);
                Boards[i].ClearQuestion();
            }
        }

        public override void InnerStartGame()
        {
            if (Boards[0].QuestionIsAnswer())
            {
                for (int i = 0; i < Boards.Length; i++)
                {
                    Boards[i].Clear();
                    Boards[i].QuestionIsAnswer();
                }
                Thread.Sleep(1000);
            }
            Answer = Logic.GetQuestion();
            PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory +
                            @"Resources\Audio\En\Letters\" + Answer + ".wav");

            for (int i = 0; i < Boards.Length; i++)
                Boards[i].SetQuestion(Answer);
            base.TimerRun();
            if (!RunGame)
                return;
            ListBoards = new bool[4];

            for (int i = 0; i < Boards.Length; i++)
            {
                ListBoards[i] = Boards[i].CheckBoard(Answer);
                if (Logic.EndGame(false))
                {
                    if (ListBoards[i])
                    {
                        Boards[i].SetSoldierPosition(true);
                        haveWin = ListBoards[i];
                    }
                }
            }
        }
    }
}
