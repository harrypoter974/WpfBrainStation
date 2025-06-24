using BS.BingoBoard.VM;
using CL.BS.Contract;
using CL.BS.MEF;
using CL.BS.Model;
using CL.BS.NotionsManager.Interface;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Input;

namespace CL.BS.NotionsVM.VM.Music
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class ScaleMemoryVM : BaseMemoryAutoGameVM, IPageVM
    {
        public override string Name
        {
            get
            {
                return nameof(ScaleMemoryVM);
            }
        }
        public ICommand PlaySounds { get; set; }
        public ScaleMemoryVM()
        {
            Logic = (IMemoryManager)(IScaleMemoryManager)
      SupportHandlerManager.Base.GetManager("ScaleMemoryManager");
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.497;
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.427;
            NotifyPropertyChanged(nameof(BoardWidth));
            NotifyPropertyChanged(nameof(BoardHeight));
            for (int i = 0; i < Boards.Length; i++)
                Boards[i] = new MemoryLetterBoardVM();
            AnswerBut = new RelayCommand(StopeGame);
            PlaySounds = new RelayCommand(DoPlaySounds);
            NewGame = new RelayCommand(DoNewGame);
            SetLettersNum = new RelayCommand(DSetLettersNum);
            NumLetterLimit = new string[] { "3", "4", "6", "8" };
            ResetGame();
            DSetLettersNum(0);
        }

        private void DoPlaySounds(object obj)
        {
            new Thread(new ThreadStart(() =>
            {
                RunGame = true;
                gameRun = false;
                NotifyPropertyChanged(nameof(gameRun));
                _letter = new List<GameObject>[1];
                _letter[0] = ((IScaleMemoryManager)Logic).PlaySounds();
                for (int i = 0; i < Boards.Length; i++)
                {
                    Boards[i].SetBoard(_letter[0]);
                    Boards[i].SetSoldierPosition(false);
                }
                for (int j = 0; j < _letter[0].Count(); j++)
                {

                    PlayUrl(_letter[0][j].Answer);
                    for (int i = 0; i < Boards.Length; i++)
                    {
                        Boards[i].SetQuestion(_letter[0][j].Question);
                    }
                    WhitAntilPlayStop(ref RunGame);
                }
                RunGame = false;
                gameRun = true;
                NotifyPropertyChanged("gameRun");
            })).Start();
        }

        protected void DSetLettersNum(object obj)
        {
            //if (MiceLogic.IsMouseRotation())
            //{ }
                int n = int.Parse(obj.ToString());
            int limit = int.Parse(NumLetterLimit[n]);
                if ( limit> CardMaxNum && CardMaxNum > 0)
                {
                    DoSetLettersNum(n - 1);
                    return;
                }
                NumLetterBut[LimitIndex].Background = string.Empty;
                NotifyPropertyChanged("NumLetterBut" + LimitIndex);
                LimitIndex = n;
                NumLetterBut[LimitIndex].Background = System.AppDomain.CurrentDomain.BaseDirectory
                + @"Resources\Number\" + "3468"[LimitIndex] + "b.png";
                NotifyPropertyChanged("NumLetterBut" + LimitIndex);
            for (int i = 0; i < Boards.Length; i++)
            {
                Boards[i].SetNumLetterLimit(limit);
            }

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
            {
                ResetGame();
            }
            else
            {
                gameRun = false;
                NotifyPropertyChanged(nameof(gameRun));
                RunGame = true;
                _letter = Logic.GetNewGame(GetNumLetterLimit());
                for (int i = 0; i < Boards.Length; i++)
                {
                    Boards[i].SetBoard(_letter[i]);
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
            string q = Logic.GetQuestion();
            Answer = String.Format(@"{0}Resources\Audio\Music\{1}.wav"
, System.AppDomain.CurrentDomain.BaseDirectory, q);
            string a = String.Format(@"{0}Resources\Notions\Music\{1}.png"
, System.AppDomain.CurrentDomain.BaseDirectory, q);
            if (Boards[0].QuestionIsAnswer())
            {
                for (int i = 0; i < Boards.Length; i++)
                {
                    Boards[i].Clear();
                    Boards[i].QuestionIsAnswer();
                }
            }
            else {
                base.WaitTimerRun(1);
                for (int i = 0; i < Boards.Length; i++)
                    Boards[i].SetQuestion(".jpg");
            }
            PlayUrl(Answer);
            base.TimerRun();
            if (!RunGame)
                return;
            bool[] lb = new bool[4];
            for (int i = 0; i < Boards.Length; i++)
            {
                //Boards[i].SetAnswer(a);
                lb[i] = Boards[i].CheckBoard(a);
                if (lb[i])
                {
                    Boards[i].SetSoldierPosition(true);
                }
                if (!haveWin)
                    haveWin = lb[i];
            }
            for (int i = 0; i < Boards.Length; i++)
            {
                Boards[i].SetQuestion(a);
            }
            WhitAntilPlayStop(ref RunGame);
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
    }
}
