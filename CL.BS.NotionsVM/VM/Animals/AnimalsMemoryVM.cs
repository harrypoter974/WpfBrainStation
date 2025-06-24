using BS.BingoBoard.VM;
using CL.BS.Contract;
using CL.BS.MEF;
using CL.BS.Model;
using CL.BS.NotionsManager.Interface;
using CL.BS.VMCommon;
using MultipleMice;
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
    public class AnimalsMemoryVM : BaseMemoryAutoGameVM, IPageVM
    {
        public override string Name
        {
            get
            {
                return "AnimalsMemoryVM";
            }
        }
        public string GameTitle { get; set; }

        public ICommand SwitchLanguage { get; set; }
        public string LanguageBut0 { get { return LanguageBut[0].Background; } set { LanguageBut[0].Background = value; } }
        public string LanguageBut1 { get { return LanguageBut[1].Background; } set { LanguageBut[1].Background = value; } }
        public string LanguageBut2 { get { return LanguageBut[2].Background; } set { LanguageBut[2].Background = value; } }
        protected SoldierObject[] LanguageBut = new SoldierObject[3];
        public ICommand GoToMenu { get; set; }
        public AnimalsMemoryVM()
        {
            Logic = (IAnimalsManager)
          SupportHandlerManager.Base.GetManager("AnimalsManager");
            NewGame = new RelayCommand(DoNewGame);
            AnswerBut = new RelayCommand(StopeGame);
            SetLettersNum = new RelayCommand(doSetLettersNum);
            SetPlayer = new RelayCommand(DoSetLevel);
            GoToMenu = new RelayCommand(DoGoToMenu);
            SwitchLanguage = new RelayCommand(DoSwitchLanguage);
            for (int i = 0; i < LanguageBut.Length; i++)
                LanguageBut[i] = new SoldierObject();
            NumLetterLimit = new string[] { "3", "4", "5" };
            doSetLettersNum(-1);
            for (int i = 0; i < Boards.Length; i++) {
                Boards[i] = new MemoryLetterBoard7VM();//MemoryVocabularyBoardVM
            }
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.44;
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.41;
            NotifyPropertyChanged(nameof(BoardWidth));
            NotifyPropertyChanged(nameof(BoardHeight));
            RefreshWinBut = System.AppDomain.CurrentDomain.BaseDirectory
  + @"Resources\BS.Items\GreenRefreshWin.png";
            NotifyPropertyChanged(nameof(RefreshWinBut));
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
        void IPageVM.disload()
        {
            disload();
            Database.DatabaseManager.Inline.SaveGame(_StartGameTime, DateTime.Now, _GameName,
                "GMEM", "", ((MemoryLetterBoard7VM)Boards[0]).Language);
        }

        void IPageVM.load()
        {
            Common.MiceKiller.KillAllMices(true);
            LanguageBut2 = System.AppDomain.CurrentDomain.BaseDirectory +
                 @"Resources\Notions\Animals\AnimalStitle0.png";
            LanguageBut[0].Background = LanguageBut[1].Background = string.Empty;
            for (int i = 0; i < LanguageBut.Length; i++)
                NotifyPropertyChanged("LanguageBut" + i);
            GameTitle = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Notions\GameTitle\" +
                Common.StaticVar.BingoGroup + "Memory.jpg";
            NotifyPropertyChanged(nameof(GameTitle) );
            ISFerstGame = true;
            base.GameSettings();
            base.NotAlaweVolumZiro();
            DoMemorySetPlayer(3);
            MiceLogic.Run();
            MiceLogic.NewMouseSplitter();
            for (int i = 0; i < Boards.Length; i++) {
                Boards[i].SetMouse(MiceLogic, MiceName[i]);
            }
            ResetGame();
            base.SetBut();
            DoSetLevel(-1);
            ((IAnimalsManager)Logic).ResetMemoryList();
            DoSwitchLanguage(0);
            NumLetterLimit = new string[] { "3", "4", "5", "6" };
            _GameName =Common.StaticVar.BingoGroup;
            //{ switch ()
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
                ((MemoryLetterBoard7VM)Boards[i]).GameName = _GameName;
            _StartGameTime = DateTime.Now;
        }

        private void DoSwitchLanguage(object obj)
        {
            int l = int.Parse(obj.ToString());
            Common.StaticVar.LanguageIndex = l;
            string[] lan = new string[] {"He", "En",  "Ar" };
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
            ((IAnimalsManager)Logic).SwitchLanguage(lan[l]);

            for (int i = 0; i < Boards.Length; i++)
                ((MemoryLetterBoard7VM)Boards[i]).Language = lan[l][0].ToString();
        }


        protected void doSetLettersNum(object obj)
        {
                int n = int.Parse(obj.ToString());
            if (MiceLogic.IsMouseRotation()||n==-1)
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

        private void DoSetLevel(object obj)
        {
            if (obj.ToString() == "-1" || MiceLogic.IsMouseRotation())
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
                ((IBingoManager)Logic).DoChangeMode(b);
                NotifyPropertyChanged(nameof(PlayerBut0));
                NotifyPropertyChanged(nameof(PlayerBut1));
            }
        }

 

        public override void ResetGame()
        {
            RunGame = false;
            gameRun = true;
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
                base.SetNewGameBut(false);
                ResetGame();
            }
            else
            {
                gameRun = false;
                NotifyPropertyChanged(nameof(gameRun));

                base.SetNewGameBut(true);
                _letter = ((IAnimalsManager)Logic).GetNewGame(base.GetNumLetterLimit());
                for (int i = 0; i < Boards.Length; i++)
                {
                    Boards[i].SetNumLetterLimit(base.GetNumLetterLimit());
                    Boards[i].SetSoldierPosition(false);
                    Boards[i].SetBoard(_letter[i]);
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
            }
            Answer = ((IAnimalsManager)Logic).GetAnswer();  
            PlayUrl(((IAnimalsManager)Logic).PlayItem());
            string q = ((IAnimalsManager)Logic).GetQuestion();
            for (int i = 0; i < Boards.Length && RunGame; i++)
                Boards[i].SetQuestion(q);
            base.TimerRun();
            if (!RunGame)
                return;      
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
    }
}
