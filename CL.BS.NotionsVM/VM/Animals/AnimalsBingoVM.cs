using BS.BingoBoard.VM;
using CL.BS.Contract;
using CL.BS.MEF;
using CL.BS.Model;
using CL.BS.NotionsManager.Interface;
using CL.BS.VMCommon;
using MultipleMice;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace CL.BS.NotionsVM.VM.Animals
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class AnimalsBingoVM : BaseAutoGameVM, IPageVM
    {

        public override string Name
        {
            get
            {
                return nameof  (AnimalsBingoVM);
            }
        }
        public string GameTitle { get; set; }
        public ICommand GoToMenu { get; set; }
        public ICommand SwitchLanguage { get; set; }
        public string LanguageBut0 { get { return LanguageBut[0].Background; } set { LanguageBut[0].Background = value; } }
        public string LanguageBut1 { get { return LanguageBut[1].Background; } set { LanguageBut[1].Background = value; } }
        public string LanguageBut2 { get { return LanguageBut[2].Background; } set { LanguageBut[2].Background = value; } }
        protected SoldierObject[] LanguageBut = new SoldierObject[3];
        public AnimalsBingoVM()
        {
            Logic = (IAnimalsManager)
        SupportHandlerManager.Base.GetManager("AnimalsManager");
            SetPlayer = new RelayCommand(DoSetLevel);
            GoToMenu = new RelayCommand(DoGoToMenu);
            NewGame = new RelayCommand(DoNewGame);
            AnswerBut = new RelayCommand(StopeGame);
            for (int i = 0; i < Boards.Length; i++)  
                Boards[i] = new BingoVocabularyBoardVM();
          
            SwitchLanguage = new RelayCommand(DoSwitchLanguage);
            for (int i = 0; i < LanguageBut.Length; i++)
                LanguageBut[i] = new SoldierObject();
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.342;
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight *0.491 ;
            NotifyPropertyChanged(nameof(BoardWidth) );
            NotifyPropertyChanged(nameof(BoardHeight));         
        
            TimerIndex = 2;
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
                "GBIN", string.Empty, ((BingoVocabularyBoardVM)Boards[0]).Language);
        }
        void IPageVM.load()
        {
            Common.MiceKiller.KillAllMices(true);
            LanguageBut2 = System.AppDomain.CurrentDomain.BaseDirectory +
                        @"Resources\Notions\Animals\AnimalStitle0.png";
            LanguageBut[0].Background = LanguageBut[1].Background = string.Empty;
            for (int i = 0; i < LanguageBut.Length; i++)
                NotifyPropertyChanged("LanguageBut"+i);
            GameTitle = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Notions\GameTitle\" + 
                Common.StaticVar.BingoGroup+ ".jpg";
            NotifyPropertyChanged(nameof(GameTitle) );
            base.GameSettings();
            base.NotAlaweVolumZiro();
            MiceLogic.Run();
            MiceLogic.NewMouseSplitter();
            for (int i = 0; i < Boards.Length; i++) {
                Boards[i].SetMouse(MiceLogic, MiceName[i]);
            }
            ResetGame();
            base.SetBut();
            DoSetLevel(-1);
            DoSwitchLanguage(0);
            _GameName = Common.StaticVar.BingoGroup;
            //{ switch (
            //    case "Clothing":          "AAAB"; break;
            //    case "Animals":            _GameName= "AABB"; break;
            //    case "Body":               _GameName= "AACB"; break;
            //    case "Vehicles":          _GameName = "AADL"; break;
            //    case "Fruit":              _GameName= "AAEB"; break;
            //    case "Food":               _GameName= "AAFB"; break;
            //    case "kitchenware":        _GameName= "AAGB"; break;
            //    case "Colors2":            _GameName= "AAHB"; break;
            //    case "Shapes":             _GameName= "AAIB"; break;
            //    case "Tools":              _GameName= "AAJB"; break;
            //    case "Family":             _GameName= "AAKB"; break;
            //    case "MusicalLnstruments": _GameName= "AALB"; break;
            //    case "Professions":        _GameName= "AAMB"; break;
            //    case "Vegetables":         _GameName= "AANB"; break;
            //    default:
            //        _GameName= "AACL";
            //        break;
            //}
            for (int i = 0; i < Boards.Length; i++)
               Boards[i].GameName  = _GameName;
            _StartGameTime = DateTime.Now;
        }

        private void DoSetLevel(object obj)
        {
            if (obj.ToString() == "-1" || MiceLogic.IsMouseRotation())
            {
                bool b = obj.ToString() == "1"|| obj.ToString() == "-1";
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
            ((IAnimalsManager)Logic).SwitchLanguage(lan[l]);

            for (int i = 0; i < Boards.Length; i++)
               Boards[i].Language = lan[l][0].ToString();
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
                List<GameObject>[] b = Logic.NewGame();
                for (int i = 0; i < Boards.Length; i++)
                {
                    Boards[i].SetSoldierPosition(false);
                    Boards[i].SetBoard(b[i]);
                }
                RunGame = true;
                StartGame();
            }
        }

        public override void InnerStartGame()
        {
           base.Answer = ((IAnimalsManager)Logic).GetAnswer();
            PlayUrl( ((IAnimalsManager)Logic).PlayItem());
            string q = ((IAnimalsManager)Logic).GetQuestion();
            for (int i = 0; i < Boards.Length; i++) { 
                Boards[i].ClearQuestion();
                Boards[i].SetQuestion(base.Answer);
            }
            base.TimerRun();
            if (!RunGame)
                return;
            bool[] lb = new bool[4];
            for (int i = 0; i < Boards.Length; i++)
            {
                lb[i] = Boards[i].CheckBoard(q);
                if (!haveWin)
                    haveWin = lb[i];
                Boards[i].SetAnswer(base.Answer);
            }
            //if(!haveWin)
            //    WaitTimerRun(1);
        }

        public override void ResetGame()
        {
            base.SetNewGameBut(false);
            RunGame = false;
            gameRun = true;
            for (int i = 0; i < Boards.Length; i++)
            {
                Boards[i].SetSoldierPosition(false);
                Boards[i].Clear();
            }
        }

        private void DOSetTime(object obj)
        {
            if (MiceLogic.IsMouseRotation())
            {
                TimerBut[TimerIndex].Background = string.Empty;
                NotifyPropertyChanged("TimerBut" + TimerIndex);
                int ti = int.Parse(obj.ToString());
                TimerBut[ti].Background = System.AppDomain.CurrentDomain.BaseDirectory
                    + @"Resources\Number\" + TimerList[ti] + "b.png";
                NotifyPropertyChanged("TimerBut" + ti);
                Timer = TimerList[ti];
                TimerIndex = ti;
            }
        } 
    }
}
