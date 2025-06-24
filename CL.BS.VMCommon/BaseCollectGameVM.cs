using CL.BS.Model;
using CL.BS.VMCommon.Mice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.VMCommon
{
    public abstract class BaseCollectGameVM : BaseAutoGameVM
    {
        public List<GameObject> Lists { get; set; }
        public ICommand ImageCollect { get; set; }
        public string TimerVisibility { get; set; }
        protected string _anser;
        protected bool GameEnd = false,NoOneAnser=false;

        public BaseCollectGameVM()
        {
           // MiceLogic = new MiceManager();
            TimerBut[0].Background = string.Format(
                @"{0}Resources\BS.Items\TimerControl0.png", System.AppDomain.CurrentDomain.BaseDirectory);
            ImageCollect = new RelayCommand(DoImageCollect);
        }

        protected void WaitToAnser()
        {
            NoOneAnser = true;
            while (NoOneAnser)
            {
                System.Threading.Thread.Sleep(100);
            }
        }

        private void DoImageCollect(object obj)
        {
            if (obj.ToString() == "Error")
                return;
            string question = ((GameObject)obj).Question;
            if (question == string.Empty)
                return;
            List<GameObject> l = new List<GameObject>();
            for (int i = 0; i < Lists.Count(); i++)
            {
                if (Lists[i].Question != question)
                {
                    l.Add(Lists[i]);
                }
                else
                {
                    l.Add(new GameObject());
                    for (int j = 0; j < MiceName.Length; j++)
                    {
                        if (MiceName[j] == MiceLogic.GetMouseRotation() && Lists[i].Uid != null)
                        {
                            NoOneAnser = false;
                            GameEnd = Boards[j].CheckBoard(Lists[i].Question);
                        }
                    }
                }
            }
            Lists = l;
            NotifyPropertyChanged("Lists");
        }
     
        public override void StartGame()
        {
            ///This method manages the game move from the start to the
            ///end of the game or until someone wins. 
            ///RunGame check's if the game continues or stops.
            ///haveWin check's if someone wins.
            ///The game contain's some rounds and it check's who wins in each round.
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
                    if (GameEnd || Logic.EndGame())//haveWin
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
                        if (GameEnd && !is5)
                        {
                            PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Audio\StructuralWin.wav");
                        }
                        if (is5)
                        {
                            ResetGame();
                            haveWin = true;
                        }
                        else
                        {//Set new board ,the game is not finished yet and there will be more rounds.
                            WaitTimerRun(haveWin ? 8 : 3);
                            if (!RunGame)
                                break;
                            List<GameObject>[] board = Logic.NewGame();
                            for (int i = 0; i < Boards.Length; i++)
                                Boards[i].SetBoard(board[i]);
                            haveWin = false;
                            WhitAntilPlayStop(ref RunGame);
                        }
                    }
                }
                gameRun = true;
                NotifyPropertyChanged("gameRun");
            })).Start();

        }
    }
}
