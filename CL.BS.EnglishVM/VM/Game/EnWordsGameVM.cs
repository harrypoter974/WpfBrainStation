using BS.BingoBoard.VM;
using CL.BS.Contract;
using CL.BS.EnglishManager.Interface;
using CL.BS.MEF;
using CL.BS.Model;
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
    public class EnWordsGameVM : BaseAutoGameVM, IPageVM
    {
        public string Grope0 { get { return Grope[0].Background; } set { Grope[0].Background = value; } }
        public string Grope1 { get { return Grope[1].Background; } set { Grope[1].Background = value; } }
        public string Grope2 { get { return Grope[2].Background; } set { Grope[2].Background = value; } }
        public string Grope3 { get { return Grope[3].Background; } set { Grope[3].Background = value; } }
        private LetterObject[] Grope = new LetterObject[4];
        public ICommand SetLevelNum { get; set; }
        public ICommand SetGrope { get; set; }

        public override string Name
        {
            get
            {
                return nameof(EnWordsGameVM);
            }
        }
        public EnWordsGameVM()
        {
             Logic = (IEnWordsGameManager)
              SupportHandlerManager.Base.GetManager("IEnWordsGameManager");
            NewGame = new RelayCommand(DoNewGame);
            SetGrope = new RelayCommand(DoSetGrope);
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.34;
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.49;
            NotifyPropertyChanged(nameof(BoardWidth));
            NotifyPropertyChanged(nameof(BoardHeight));
            AnswerBut = new RelayCommand(StopeGame);
            for (int i = 0; i < Grope.Length; i++)
                Grope[i] = new LetterObject();
            //for (int i = 0; i < LevelBut.Length; i++)
            //    LevelBut[i] = new ViewObject();
            for (int i = 0; i < Boards.Length; i++) 
                Boards[i] = new WordsGameBoardVM() { GameName = nameof(EnWordsGameVM), Language = "E" };
            TimerList = new string[] { "3", "6", "9" , "12"};
            // Height="375.2" Width="464"

        }

     

        void IPageVM.load()
        {
            base.GameSettings();
            BackgroundNewGame = string.Empty;
            base.NotAlaweVolumZiro();
            DoSetGrope("0");
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
                RunGame = true;
                List<GameObject>[] bord = Logic.NewGame();
                for (int i = 0; i < Boards.Length; i++)
                {
                    Boards[i].SetBoard(bord[i]);
                    Boards[i].SetSoldierPosition(false);
                }
                base.SetNewGameBut(true);
                StartGame();
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

        public override void InnerStartGame()
        {
            Answer = ((IEnWordsGameManager)Logic).GetQuestion();
            for (int i = 0; i < Boards.Length; i++)
            {
                Boards[i].ClearQuestion();
                Boards[i].SetQuestion(Answer);
            }
            string[] a = ((IEnWordsGameManager)Logic).GetAnswer();
            Answer = a[1];
            base.TimerRun();
            if (!RunGame)
                return;
            bool[] lb = new bool[4];
            for (int i = 0; i < Boards.Length; i++)
            {
                Boards[i].SetAnswer(a[1]);
                lb[i] = Boards[i].CheckBoard(a[1]);
                if (!haveWin)
                    haveWin = lb[i];
            }
            PlayUrl(a[0]);
            WhitAntilPlayStop(ref RunGame);
        }

        private void DoSetGrope(object gropeIndex)
        {
            Grope[((IEnWordsGameManager)Logic).GetGropeIndex()].Background = string.Empty;
            NotifyPropertyChanged("Grope" + ((IEnWordsGameManager)Logic).GetGropeIndex());
            int g = int.Parse(gropeIndex.ToString());
            Grope[g].Background = ((IEnWordsGameManager)Logic).SetGrope(g);
            NotifyPropertyChanged("Grope" + ((IEnWordsGameManager)Logic).GetGropeIndex());
        }
    }
}
