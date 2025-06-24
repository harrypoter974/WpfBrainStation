using BS.BingoBoard.VM;
using CL.BS.Contract;
using CL.BS.MathLearningManager.Interface.Game;
using CL.BS.MEF;
using CL.BS.VMCommon;
using MultipleMice;
using System;
using System.Threading;
using System.Windows.Input;

namespace CL.BS.MathLearningVM.VM.Game
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class MathMemoryNumVM : BaseMemoryAutoGameVM, IPageVM
    {
        public override string Name
        {
            get
            {
                return nameof(MathMemoryNumVM) ;
            }
        }
        protected string _language = "He";

        private int _Limit = 0;
        public MathMemoryNumVM()
        {
            Logic = (IMathMemoryNumManager)
    SupportHandlerManager.Base.GetManager("MathMemoryNumManager");
            NewGame = new RelayCommand(DoNewGame);
            SetLettersNum = new RelayCommand(DoSetLettersNumNum);
            NumLetterLimit = new string[] {"3", "4", "6", "8" };
            for (int i = 0; i < Boards.Length; i++)
                Boards[i] = new MemoryLetterBoardVM();
           
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.49;
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.425;
            NotifyPropertyChanged(nameof(BoardWidth) );
            NotifyPropertyChanged(nameof( BoardHeight));
            SetPlayer = new RelayCommand(DoSetLimit);
            AnswerBut = new RelayCommand(StopeGame);
        }

        private void DoSetLimit(object obj)
        {
            PlayerBut[_Limit].Background = string.Empty;
            NotifyPropertyChanged("PlayerBut" + _Limit);
            _Limit = int.Parse(obj.ToString());
            int limit = new int[] { 10, 40, 100 }[_Limit];
            PlayerBut[_Limit].Background = System.AppDomain.CurrentDomain.BaseDirectory
                                 + @"Resources\Number\l" + limit + ".png";
            NotifyPropertyChanged("PlayerBut" + _Limit);
            ((IMathMemoryNumManager)Logic).SetLimit(limit);
        }

        void IPageVM.load()
        {
            ISFerstGame = true;
            base.GameSettings();
            base.NotAlaweVolumZiro();
            MiceLogic.Run();
            MiceLogic.NewMouseSplitter();
            DoSetLettersNumNum(-1);
            for (int i = 0; i < Boards.Length; i++) {
                Boards[i].SetMouse(MiceLogic, MiceName[i]);
            }
            ResetGame();
            base.SetBut();
            _language = "He";
            DoSetLimit(0);
        }


  

        public override void ResetGame()
        {
            base.SetNewGameBut(false);
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
            string[] p = ((IMathMemoryNumManager)Logic).Get_Question();
            Answer = Logic.GetQuestion(); 
            //if (_language=="He")
            //{
                if (p.Length == 1)
                    PlayUrl(p[0]);
               else
                   PlayList (p);    
            //}
            //else
            //    PlayUrl(string.Format(@"{0}Resources\Audio\{1}\Numbers\{2}.wav",
            //        System.AppDomain.CurrentDomain.BaseDirectory, _language, Answer));
            for (int i = 0; i < Boards.Length && RunGame; i++)
                Boards[i].SetQuestion(Answer);
            WhitAntilPlayStop(ref RunGame);
            base.TimerRun();
            if (!RunGame)
                return;
             ListBoards = new bool[4];
            for (int i = 0; i < Boards.Length && RunGame; i++)
            {
                ListBoards[i] = Boards[i].CheckBoard(Answer);
                if (ListBoards[i] && Logic.EndGame(false))
                {
                    Boards[i].SetSoldierPosition(true);
                    haveWin = ListBoards[i];
                }
            }
        }
    }
}
