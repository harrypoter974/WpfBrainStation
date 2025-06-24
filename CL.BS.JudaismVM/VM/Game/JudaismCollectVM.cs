using BS.BingoBoard.VM;
using CL.BS.Contract;
using CL.BS.JudaismManager.Interface;
using CL.BS.MEF;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.JudaismVM.VM
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class JudaismCollectVM : BaseCollectGameVM, IPageVM
    {//wpf itemtemplate with button   BaseCollectGameVM
        public override string Name => "JudaismCollectVM";
        public JudaismCollectVM()
        {
            Logic = (IJudaismCollectManager)
      SupportHandlerManager.Base.GetManager("JudaismCollectManager");

            for (int i = 0; i < Boards.Length; i++)
                Boards[i] = new CollectBoardVM();
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.306;
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.296;
            NotifyPropertyChanged("BoardWidth");
            NotifyPropertyChanged("BoardHeight");
            NewGame = new RelayCommand(DoNewGame);
            AnswerBut = new RelayCommand(StopeGame);
        }

        private void StopeGame(object obj)
        {
            if (MiceLogic.IsMouseRotation() && BackgroundNewGame != string.Empty)
                ResetGame();
        }

        private void DoNewGame(object obj)
        {
            if (MiceLogic.IsMouseRotation())
            {
                gameRun = false;
                NotifyPropertyChanged("gameRun");
                if (!RunGame)
                {
                    RunGame = true;
                    for (int i = 0; i < Boards.Length; i++)
                    {
                        Boards[i].SetSoldierPosition(false);
                    }
                    base.SetNewGameBut(true);
                    RunGame = true;
                    base.StartGame();
                }
            }
        }

        public override void InnerStartGame()
        {
            new Thread(new ThreadStart(() =>
            {
                TimerVisibility = "Collapsed";
                NotifyPropertyChanged("TimerVisibility");
                List<GameObject>[] bord = Logic.NewGame();
                Lists = bord[0];
                NotifyPropertyChanged("Lists");
                NotifyPropertyChanged("TimerVisibility");
                _anser = ((IJudaismCollectManager)Logic).GetQuestion();
                for (int i = 0; i < Boards.Length; i++)
                {
                    Boards[i].SetQuestion(_anser);
                }
                WaitToAnser();
                TimerVisibility = "Visible";
                NotifyPropertyChanged("TimerVisibility");
            })).Start();
        }

        void IPageVM.load()
        {
            base.GameSettings();
            BackgroundNewGame = string.Empty;
            base.NotAlaweVolumZiro();
            MiceLogic.Run();
            MiceLogic.NewMouseSplitter();
            for (int i = 0; i < Boards.Length; i++)
                Boards[i].SetMouse(MiceLogic, MiceName[i]);
            ResetGame();
        }
    }
}
