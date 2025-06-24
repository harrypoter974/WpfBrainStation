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

namespace CL.BS.NotionsVM.VM.Animals
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class ShadowGameVM : BaseAutoGameVM, IPageVM
    {
        public override string Name =>nameof(ShadowGameVM);
        public string LanguageBut0 { get { return LanguageBut[0].Background; } set { LanguageBut[0].Background = value; } }
        public string LanguageBut1 { get { return LanguageBut[1].Background; } set { LanguageBut[1].Background = value; } }
        public string LanguageBut2 { get { return LanguageBut[2].Background; } set { LanguageBut[2].Background = value; } }
        protected SoldierObject[] LanguageBut = new SoldierObject[3];
        public string GameTitle { get; set; }
        public ICommand GoToMenu { get; set; }
        public ICommand SwitchLanguage { get; set; }
        public ShadowGameVM()
        {
            Logic = (IShadowGameManager)
       SupportHandlerManager.Base.GetManager("ShadowGameManager");
            //SetPlayer = new RelayCommand(DoSetLevel);
            GoToMenu = new RelayCommand(DoGoToMenu);
            NewGame = new RelayCommand(DoNewGame);
            AnswerBut = new RelayCommand(StopeGame);
            SwitchLanguage = new RelayCommand(DoSwitchLanguage);
            for (int i = 0; i < Boards.Length; i++)
                Boards[i] = new ShadowBoardVM();
            for (int i = 0; i < LanguageBut.Length; i++)
                LanguageBut[i] = new SoldierObject();
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.443;
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.433;
            NotifyPropertyChanged(nameof( BoardWidth));
            NotifyPropertyChanged(nameof(BoardHeight));
            TimerIndex = 2;
        }

        void IPageVM.load()
        {
            ((IShadowGameManager)Logic).Reset();
            ShadowResetGame();
            base.SetBut();
            GameTitle = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Notions\GameTitle\" +
                Common.StaticVar.BingoGroup + "Shadow.jpg";
            NotifyPropertyChanged(nameof(GameTitle));
            base.GameSettings();
            base.NotAlaweVolumZiro();
            MiceLogic.Run();
            MiceLogic.NewMouseSplitter();
            for (int i = 0; i < Boards.Length; i++)
            {
                Boards[i].SetMouse(MiceLogic, MiceName[i]);
            }
            Common.MiceKiller.KillAllMices(true); 
             _GameName =Common.StaticVar.BingoGroup;
            //{switch ()
            //    case "Clothing": "AAAB" break;
            //    case "Animals": _GameName = "AABB"; break;
            //    case "Body": _GameName = "AACB"; break;
            //    case "Vehicles": _GameName = "AADL"; break;
            //    case "Fruit": _GameName = "AAEB"; break;
            //    case "Food": _GameName = "AAFB"; break;
            //    case "kitchenware": _GameName = "AAGB"; break;
            //    case "Colors2": _GameName = "AAHB"; break;
            //    case "Shapes": _GameName = "AAIB"; break;
            //    case "Tools": _GameName = "AAJB"; break;
            //    case "Family": _GameName = "AAKB"; break;
            //    case "MusicalLnstruments": _GameName = "AALB"; break;
            //    case "Professions": _GameName = "AAMB"; break;
            //    case "Vegetables": _GameName = "AANB"; break;
            //    default:
            //        _GameName = "AACL";
            //        break;
            //}
            for (int i = 0; i < Boards.Length; i++)
                ((ShadowBoardVM)Boards[i]).GameName = _GameName;
            _StartGameTime = DateTime.Now;
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
                ShadowResetGame();
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


        private void DoSwitchLanguage(object obj)
        {
            int l = int.Parse(obj.ToString());
            Common.StaticVar.LanguageIndex = l;
            string[] lan = new string[] { "He", "En", "Ar" };
            for (int i = 0; i < LanguageBut.Length; i++)
            {
                if (l == i)
                {
                    LanguageBut[i].Background = System.AppDomain.CurrentDomain.BaseDirectory +
                        @"Resources\Notions\Animals\AnimalStitle" + i + ".png";
                }
                else
                    LanguageBut[i].Background = string.Empty;
                NotifyPropertyChanged("LanguageBut" + i);
            }
            ((IShadowGameManager)Logic).SwitchLanguage(lan[l]);
            for (int i = 0; i < Boards.Length; i++)
                ((ShadowBoardVM)Boards[i]).Language = lan[l][0].ToString();
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
                        return;
                    PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory
                    + @"Resources\Audio\Start.wav");
                    WhitAntilPlayStop(ref RunGame);
                    InnerStartGame();
                    if (haveWin )//|| Logic.EndGame()
                    {
                        bool is5 = false;
                        WhitAntilPlayStop(ref RunGame);
                        for (int i = 0; i < Boards.Length; i++)
                        {
                            bool b = Boards[i].Is5Position();
                            if (b)
                            {
                                PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Audio\EndWin.wav");
                                Boards[i].GameWin();
                                is5 = b;
                            }
                        }
                        if (haveWin && !is5)
                        {
                            PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Audio\StructuralWin.wav");
                            for (int i = 0; i < Boards.Length; i++)
                                Boards[i].Clear();
                        }
                        if (is5)
                        {
                            ShadowResetGame();
                            haveWin = true;
                        }
                        else
                        {//Set new board ,the game is not finished yet and there will be more rounds.
                            WaitTimerRun(haveWin ? 8 : 3);
                            if (!RunGame)
                                return;
                            haveWin = false;
                            WhitAntilPlayStop(ref RunGame);
                        }
                    }
                }
                gameRun = true;
                NotifyPropertyChanged( nameof(gameRun));
            })).Start();
        }
        public override void InnerStartGame()
        {
            List<GameObject> board = Logic.NewGame()[0];
            for (int i = 0; i < Boards.Length; i++)
                Boards[i].SetBoard(board);
            TimerRun();
            bool[] lb = new bool[4];
            PlayUrl(((IShadowGameManager)Logic).PlayShadow(board[4].Question));
            for (int i = 0; i < Boards.Length; i++)
            {
                lb[i] = Boards[i].CheckBoard(string.Empty);
                if (!haveWin)
                    haveWin = lb[i];
            }
            if (MiceLogic.IsMouseRotation())
            {
                gameRun = false;
                NotifyPropertyChanged( nameof(gameRun));
                if (!RunGame)
                {
                    base.SetNewGameBut(true);
                    List<GameObject> b = Logic.NewGame()[0];
                    for (int i = 0; i < Boards.Length; i++)
                    {
                        Boards[i].SetSoldierPosition(false);
                        Boards[i].SetBoard(b);
                    }
                    RunGame = true;
                    StartGame();
                }
            }
        }
    void IPageVM.disload()
        {
            Common.StaticVar.PlayMode = RunGame = gameRun = false;
            MiceLogic.OnClosing();
            MiceLogic.Close();
            MiceLogic.Dispose();
            NotAlaweVolumZiro();
            Common.MiceKiller.KillAllMices(false);
            Database.DatabaseManager.Inline.SaveGame(_StartGameTime, DateTime.Now, _GameName,
                "GSUI", "", ((ShadowBoardVM)Boards[0]).Language);
        }
        private void ShadowResetGame()
        {
            base.SetNewGameBut(false);
            Common.StaticVar.PlayMode =  false;
            gameRun = true;
            NotifyPropertyChanged(nameof(gameRun));
            ResetGame();
            for (int i = 0; i < Boards.Length; i++)
            {
                Boards[i].RestartClear();
                Boards[i].SetSoldierPosition(false);
            }
        }
        private void DoGoToMenu(object obj)
        {
            switch (Common.StaticVar.BingoGroup)
            {
                case "Animals": DoExitFromPage("MenuHeGeneralAnimalVM"); break;
                case "Body": DoExitFromPage("MenuHeGeneralBodyVM"); break;
                case "Clothing": DoExitFromPage("MenuHeGeneralClothingVM"); break;
                case "Colors2": DoExitFromPage("MenuHeGeneralColorsVM"); break;
                case "Family": DoExitFromPage("MenuHeGeneralFamilyVM"); break;
                case "Fruit": DoExitFromPage("MenuHeGeneralFruitVM"); break;
                case "Food": DoExitFromPage("MenuHeGeneralFoodVM"); break;
                case "kitchenware": DoExitFromPage("MenuHeGeneralkitchenwareVM"); break;
                case "MusicalLnstruments": DoExitFromPage("MenuHeGeneralMusicalVM"); break;
                case "Professions": DoExitFromPage("MenuHeGeneralProfessionalsVM"); break;
                case "Shapes": DoExitFromPage("MenuHeGeneralShapesVM"); break;
                case "Tools": DoExitFromPage("MenuHeGeneralToolsVM"); break;
                case "Vegetables": DoExitFromPage("MenuHeGeneralVegetablesVM"); break;
                case "Vehicles": DoExitFromPage("MenuHeGeneralVehiclesVM"); break;
                default:
                    DoExitFromPage("MenuVocabularyBingoVM");
                    break;
            }

        }
    }
}
