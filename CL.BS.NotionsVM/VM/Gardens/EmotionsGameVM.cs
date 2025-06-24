using BS.BingoBoard.VM;
using CL.BS.Contract;
using CL.BS.MEF;
using CL.BS.Model;
using CL.BS.NotionsManager.Interface;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.NotionsVM.VM.Gardens
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class EmotionsGameVM : BaseAutoGameVM, IPageVM
    {
        public string LanguageBut0 { get { return LanguageBut[0].Background; } set { LanguageBut[0].Background = value; } }
        public string LanguageBut1 { get { return LanguageBut[1].Background; } set { LanguageBut[1].Background = value; } }
        public string LanguageBut2 { get { return LanguageBut[2].Background; } set { LanguageBut[2].Background = value; } }
        protected SoldierObject[] LanguageBut = new SoldierObject[3];
        protected int _language = 0;
        public ICommand SwitchLanguage { get; set; }
        public override string Name =>nameof(EmotionsGameVM);
        public EmotionsGameVM()
        {
            for (int i = 0; i < LanguageBut.Length; i++)
                LanguageBut[i] = new SoldierObject();
            Logic = (IEmotionsGameManager)
SupportHandlerManager.Base.GetManager("EmotionsGameManager");
            NewGame = new RelayCommand(DoNewGame);
            AnswerBut = new RelayCommand(StopeGame);
            //SetPlayer = new RelayCommand(DoSetLevel);
            for (int i = 0; i < Boards.Length; i++)
                Boards[i] = new ShadowBoardVM();
            // Height="288.8" Width="484" 
            //TimerList = new string[] { "4", "8", "16" };
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.443;
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.433;
            NotifyPropertyChanged(nameof(BoardWidth));
            NotifyPropertyChanged(nameof(BoardHeight));

            TimerIndex = 2;
            SwitchLanguage = new RelayCommand(DoSwitchLanguage);
            DoSwitchLanguage(0);
        }

        private void DoSwitchLanguage(object obj)
        {
            _language = int.Parse(obj.ToString());
            for (int i = 0; i < LanguageBut.Length; i++)
            {
                if (_language == i)
                {
                    LanguageBut[i].Background = System.AppDomain.CurrentDomain.BaseDirectory +
                        @"Resources\Notions\Animals\AnimalStitle" + i + ".png";
                }
                else
                    LanguageBut[i].Background = string.Empty;
                NotifyPropertyChanged("LanguageBut" + i);
            }
            for (int i = 0; i < Boards.Length; i++)
                ((ShadowBoardVM)Boards[i]).Language = "HEA"[_language].ToString();
        }
        void IPageVM.disload()
        {
            disload();
            Database.DatabaseManager.Inline.SaveGame(_StartGameTime, DateTime.Now, _GameName,"","","");
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
            _GameName = "AGAL";
            for (int i = 0; i<Boards.Length; i++)
                ((ShadowBoardVM) Boards[i]).GameName = _GameName;
            _StartGameTime = DateTime.Now;
        }
        public override void ResetGame()
        {
            base.SetNewGameBut(false);
            RunGame = false;
            for (int i = 0; i < Boards.Length; i++)
            {
                Boards[i].RestartClear();
                Boards[i].SetSoldierPosition(false);
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
                base.SetNewGameBut(true);
                List<GameObject>[] b = Logic.NewGame();
                for (int i = 0; i < Boards.Length; i++)
                {
                    Boards[i].RestartClear();
                    Boards[i].SetSoldierPosition(false);
                }
                RunGame = true;
                StartGame();
            }
        }

        public override void StartGame()
        {
            Common.GlobalVar.IAnsweredFirst = true;
            haveWin = false;
            new Thread(new ThreadStart(() =>
            {
                while (!haveWin && RunGame)
                {
                    WaitTimerRun(3);
                    if (!RunGame)
                        break;
                    PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory
                    + @"Resources\Audio\Start.wav");
                    WhitAntilPlayStop(ref RunGame);
                    InnerStartGame();
                    if (haveWin)//|| Logic.EndGame()
                    {
                        bool is5 = false;
                        WhitAntilPlayStop(ref RunGame);
                        for (int i = 0; i < Boards.Length; i++)
                        {
                            bool b = Boards[i].Is5Position();
                            if (b)
                            {
                                Common.StaticVar.PlayMode = false;
                                PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Audio\EndWin.wav");
                                Boards[i].GameWin();
                                is5 = b;
                                ResetGame();
                            }
                        }
                        if (haveWin && !is5)
                        {
                            Common.StaticVar.PlayMode = false;
                            PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Audio\StructuralWin.wav");
                            for (int i = 0; i < Boards.Length; i++)
                                Boards[i].Clear();
                        }
                        if (is5)
                        {
                          //  ShadowResetGame();
                            haveWin = true;
                        }
                        else
                        {//Set new board ,the game is not finished yet and there will be more rounds.
                            WaitTimerRun(haveWin ? 8 : 3);
                            if (!RunGame)
                                break;
                            haveWin = false;
                            WhitAntilPlayStop(ref RunGame);
                        }
                    }
                }
                gameRun = true;
                NotifyPropertyChanged(nameof(gameRun) );
            })).Start();
        }

        public override void InnerStartGame()
        {
            List<GameObject> board = Logic.NewGame()[0];
            PlayUrl(((IEmotionsGameManager)Logic).PlayEmotions(board[4].Answer, _language));
            for (int i = 0; i < Boards.Length; i++)
                Boards[i].SetBoard(board);
            base.TimerRun(); 
            if (!RunGame)
                return;
            PlayUrl(((IEmotionsGameManager)Logic).PlayEmotions(board[4].Question, _language));
            bool[] lb = new bool[4];
            for (int i = 0; i < Boards.Length; i++)
            {
                lb[i] = Boards[i].CheckBoard(string.Empty);
                if (!haveWin)
                    haveWin = lb[i];
            }
            if (!RunGame)
                return;
            if (MiceLogic.IsMouseRotation())
            {
                gameRun = false;
                NotifyPropertyChanged(nameof(gameRun) );
                if (!RunGame)
                {
                    base.SetNewGameBut(true);
                    List<GameObject>[] b = Logic.NewGame();
                    for (int i = 0; i < Boards.Length; i++)
                    {
                        Boards[i].SetSoldierPosition(false);
                        Boards[i].SetBoard(b[0]);
                    }
                    RunGame = true;
                    StartGame();
                }
            }
        }
    }
}
