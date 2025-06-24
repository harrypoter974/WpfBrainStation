using CL.BS.Contract;
using CL.BS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.VMCommon
{
    public class BaseMemoryAutoGameVM : BaseAutoGameVM
    {
        /// <summary>
        /// This class is controlled on memory like the BaseAutoGameVM 
        /// that it inherit's from BaseAutoGameVM but overrides the MemoryStartGame
        /// because they are diffrent from the progress of the game.
        /// </summary>

        protected string[] NumLetterLimit;
        protected int CardMaxNum = 8;
        protected int LimitIndex = 0;
        protected bool ISFerstGame = true;
        public override string Name => "";
        public ICommand SetLettersNum { get; set; }
        public string NumLetterBut0 { get { return NumLetterBut[0].Background; } set { NumLetterBut[0].Background = value; } }
        public string NumLetterBut1 { get { return NumLetterBut[1].Background; } set { NumLetterBut[1].Background = value; } }
        public string NumLetterBut2 { get { return NumLetterBut[2].Background; } set { NumLetterBut[2].Background = value; } }
        public string NumLetterBut3 { get { return NumLetterBut[3].Background; } set { NumLetterBut[3].Background = value; } }
        protected SoldierObject[] NumLetterBut = new SoldierObject[4];
        public IMemoryManager Logic;
        protected List<GameObject>[] _letter;
        protected bool[] ListBoards;

        public BaseMemoryAutoGameVM()
        {
            for (int i = 0; i < NumLetterBut.Length; i++)
                NumLetterBut[i] = new SoldierObject();
            SetPlayer = new RelayCommand(DoMemorySetPlayer);
            SetLettersNum = new RelayCommand(DoSetLettersNum);
        }

        protected void DoMemorySetPlayer(object obj)
        {
            base.DoSetPlayer(obj);
            CloseOpenPic();
        }

        protected void DoSetLettersNum(object obj)
        {
            if (MiceLogic.IsMouseRotation())
            {
                int n = int.Parse(obj.ToString());
                if (int.Parse(NumLetterLimit[n]) > CardMaxNum && CardMaxNum > 0)
                {
                    DoSetLettersNum(n - 1);
                    return;
                }
                NumLetterBut[LimitIndex].Background = string.Empty;
                NotifyPropertyChanged("NumLetterBut" + LimitIndex);
                LimitIndex = n;
                NumLetterBut[LimitIndex].Background = System.AppDomain.CurrentDomain.BaseDirectory
                + @"Resources\BS.Items\" + CL.BS.Common.StaticVar.LevelButton[LimitIndex] + ".png";
                NotifyPropertyChanged("NumLetterBut" + LimitIndex);
            }
        }

        protected void DoSetLettersNumNum(object obj)
        {
            string num = obj.ToString();
            if (MiceLogic.IsMouseRotation() || num == "-1")
            {

                num = num == "-1" ? "0" : num;
                int n = int.Parse(num);
                if (int.Parse(NumLetterLimit[n]) > CardMaxNum && n > 0 && CardMaxNum > 0)
                {
                    DoSetLettersNumNum(n - 1);
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
        public override void StartGame()
        {
            Common.GlobalVar.IAnsweredFirst = false;
            haveWin = false;
            new Thread(new ThreadStart(() =>
            {
                base.WaitTimerRun(10);
                while (!haveWin && RunGame)
                {
                    InnerStartGame();
                    if (Logic.EndGame(false))
                    {
                        int[] bordPoint = new int[4];
                        for (int i = 0; i < Boards.Length && RunGame; i++)
                            bordPoint[i] = Boards[i].AccruedPoints;
                  
                        for (int i = 0; i < Boards.Length && RunGame; i++)
                        {
                            Boards[i].SetAnswer("");
                        }
                        WhitAntilPlayStop(ref RunGame);
                        bool isWinEnd = false;
                        for (int i = 0; i < Boards.Length; i++)
                        {
                            bool b = Boards[i].Is5Position();
                            if (b)
                            {
                                PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Audio\EndWin.wav");
                                Boards[i].GameWin();
                                isWinEnd = b;
                                BackgroundNewGame = string.Empty;
                                NotifyPropertyChanged(nameof(BackgroundNewGame));
                            }
                        } 
                        if (haveWin&&!isWinEnd)
                        {
                            PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory
                            + @"Resources\Audio\StructuralWin.wav");
                        }
                        for (int i = 0; i < Boards.Length && RunGame; i++)
                           Boards[i].SetBoard(_letter[i]);
                        if (isWinEnd)
                        {
                            ResetGame();
                            haveWin = true;
                        }
                        else
                        {//Set the board game.
                            base.WaitTimerRun(3);
                            if (!RunGame)
                                break;
                            PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory
                                + @"Resources\Audio\Start.wav");
                            _letter = Logic.GetNewGame(GetNumLetterLimit());
                            for (int i = 0; i < Boards.Length && RunGame; i++)
                            {
                                Boards[i].Clear();
                                Boards[i].SetBoard(_letter[i]);
                            }
                            haveWin = false;
                            base.WaitTimerRun(10);
                            if (!RunGame)
                                break;
                        }
                    }
                    else
                    {
                        base.WaitTimerRun(3);
                        if (!RunGame)
                            break;
                    }
                }
                gameRun = true;
                NotifyPropertyChanged("gameRun");
            })).Start();
        }

        protected void CloseOpenPic()
        {
            if (ISFerstGame)
            {
                ISFerstGame = false;
            }
        }

    
        public int GetNumLetterLimit()
        {
           return int.Parse(NumLetterLimit[LimitIndex]);
        }
    }
}
