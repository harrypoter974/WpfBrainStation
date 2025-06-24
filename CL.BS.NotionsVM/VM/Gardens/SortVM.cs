using BS.BingoBoard.VM;
using CL.BS.Contract;
using CL.BS.MEF;
using CL.BS.Model;
using CL.BS.NotionsManager.Interface;
using CL.BS.VMCommon;
using MultipleMice;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CL.BS.NotionsVM.VM.Gardens
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class SortVM : BaseAutoGameVM, IPageVM
    {
        private ISortManager _logic = (ISortManager)
SupportHandlerManager.Base.GetManager("SortManager");
        private object _location = string.Empty;
        private int _currentPlay = 0;
        private int _playerNum = 4;
        private Task _task;
        private string[] _colorPlayers = new string[] { "#FF00E2FF", "#FFED2224", "#FFFFF200", "#FF41AD48" };
        private SortBoardVM[] _tBoards = new SortBoardVM[4];
        private LetterObject[] _dimensionBut = new LetterObject[4];
        public SortBoardVM TBoard0 { get { return _tBoards[0]; } set { _tBoards[0] = value; } }
        public SortBoardVM TBoard1 { get { return _tBoards[1]; } set { _tBoards[1] = value; } }
        public SortBoardVM TBoard2 { get { return _tBoards[2]; } set { _tBoards[2] = value; } }
        public SortBoardVM TBoard3 { get { return _tBoards[3]; } set { _tBoards[3] = value; } }
        public string But00 { get { return Items[0, 0].Background; } set { Items[0, 0].Background = value; } }
        public string But01 { get { return Items[0, 1].Background; } set { Items[0, 1].Background = value; } }
        public string But02 { get { return Items[0, 2].Background; } set { Items[0, 2].Background = value; } }
        public string But03 { get { return Items[0, 3].Background; } set { Items[0, 3].Background = value; } }
        public string But10 { get { return Items[1, 0].Background; } set { Items[1, 0].Background = value; } }
        public string But11 { get { return Items[1, 1].Background; } set { Items[1, 1].Background = value; } }
        public string But12 { get { return Items[1, 2].Background; } set { Items[1, 2].Background = value; } }
        public string But13 { get { return Items[1, 3].Background; } set { Items[1, 3].Background = value; } }
        public string But20 { get { return Items[2, 0].Background; } set { Items[2, 0].Background = value; } }
        public string But21 { get { return Items[2, 1].Background; } set { Items[2, 1].Background = value; } }
        public string But22 { get { return Items[2, 2].Background; } set { Items[2, 2].Background = value; } }
        public string But23 { get { return Items[2, 3].Background; } set { Items[2, 3].Background = value; } }
        public string But30 { get { return Items[3, 0].Background; } set { Items[3, 0].Background = value; } }
        public string But31 { get { return Items[3, 1].Background; } set { Items[3, 1].Background = value; } }
        public string But32 { get { return Items[3, 2].Background; } set { Items[3, 2].Background = value; } }
        public string But33 { get { return Items[3, 3].Background; } set { Items[3, 3].Background = value; } }

        public string Border00 { get { return Items[0, 0].Uid; } set { Items[0, 0].Uid = value; } }
        public string Border01 { get { return Items[0, 1].Uid; } set { Items[0, 1].Uid = value; } }
        public string Border02 { get { return Items[0, 2].Uid; } set { Items[0, 2].Uid = value; } }
        public string Border03 { get { return Items[0, 3].Uid; } set { Items[0, 3].Uid = value; } }
        public string Border10 { get { return Items[1, 0].Uid; } set { Items[1, 0].Uid = value; } }
        public string Border11 { get { return Items[1, 1].Uid; } set { Items[1, 1].Uid = value; } }
        public string Border12 { get { return Items[1, 2].Uid; } set { Items[1, 2].Uid = value; } }
        public string Border13 { get { return Items[1, 3].Uid; } set { Items[1, 3].Uid = value; } }
        public string Border20 { get { return Items[2, 0].Uid; } set { Items[2, 0].Uid = value; } }
        public string Border21 { get { return Items[2, 1].Uid; } set { Items[2, 1].Uid = value; } }
        public string Border22 { get { return Items[2, 2].Uid; } set { Items[2, 2].Uid = value; } }
        public string Border23 { get { return Items[2, 3].Uid; } set { Items[2, 3].Uid = value; } }
        public string Border30 { get { return Items[3, 0].Uid; } set { Items[3, 0].Uid = value; } }
        public string Border31 { get { return Items[3, 1].Uid; } set { Items[3, 1].Uid = value; } }
        public string Border32 { get { return Items[3, 2].Uid; } set { Items[3, 2].Uid = value; } }
        public string Border33 { get { return Items[3, 3].Uid; } set { Items[3, 3].Uid = value; } }

        public string Dimension00 { get { return Items[0, 0].Text; } set { Items[0, 0].Text = value; } }
        public string Dimension01 { get { return Items[0, 1].Text; } set { Items[0, 1].Text = value; } }
        public string Dimension02 { get { return Items[0, 2].Text; } set { Items[0, 2].Text = value; } }
        public string Dimension03 { get { return Items[0, 3].Text; } set { Items[0, 3].Text = value; } }
        public string Dimension10 { get { return Items[1, 0].Text; } set { Items[1, 0].Text = value; } }
        public string Dimension11 { get { return Items[1, 1].Text; } set { Items[1, 1].Text = value; } }
        public string Dimension12 { get { return Items[1, 2].Text; } set { Items[1, 2].Text = value; } }
        public string Dimension13 { get { return Items[1, 3].Text; } set { Items[1, 3].Text = value; } }
        public string Dimension20 { get { return Items[2, 0].Text; } set { Items[2, 0].Text = value; } }
        public string Dimension21 { get { return Items[2, 1].Text; } set { Items[2, 1].Text = value; } }
        public string Dimension22 { get { return Items[2, 2].Text; } set { Items[2, 2].Text = value; } }
        public string Dimension23 { get { return Items[2, 3].Text; } set { Items[2, 3].Text = value; } }
        public string Dimension30 { get { return Items[3, 0].Text; } set { Items[3, 0].Text = value; } }
        public string Dimension31 { get { return Items[3, 1].Text; } set { Items[3, 1].Text = value; } }
        public string Dimension32 { get { return Items[3, 2].Text; } set { Items[3, 2].Text = value; } }
        public string Dimension33 { get { return Items[3, 3].Text; } set { Items[3, 3].Text = value; } }
        public string DimensionBut0 { get { return _dimensionBut[0].Background; } set { _dimensionBut[0].Background = value; } }
        public string DimensionBut1 { get { return _dimensionBut[1].Background; } set { _dimensionBut[1].Background = value; } }
        public string DimensionBut2 { get { return _dimensionBut[2].Background; } set { _dimensionBut[2].Background = value; } }
        public string DimensionBut3 { get { return _dimensionBut[3].Background; } set { _dimensionBut[3].Background = value; } }
        public string DimensionBut4 { get { return _dimensionBut[4].Background; } set { _dimensionBut[4].Background = value; } }
        public ICommand TubPic { get; set; }
        public ICommand BorderLeave { get; set; }
        public ICommand SetDimension { get; set; }
        public ICommand SetAnser { get; set; }
        public string TimerVisibility { get; set; }
        protected LetterObject[,] Items = new LetterObject[4, 4];
        public override string Name =>nameof(SortVM) ;

        public SortVM()
        {
            for (int i = 0; i < Items.GetLength(0); i++)
                for (int j = 0; j < Items.GetLength(1); j++)
                    Items[i, j] = new LetterObject();
            for (int i = 0; i < _dimensionBut.Length; i++)
                _dimensionBut[i] = new LetterObject();
            SetAnser   = new RelayCommand(DoTubPic);
            TubPic = new RelayCommand(DoSetAnser);
            AnswerBut = new RelayCommand(StopeGame);
            NewGame = new RelayCommand(DoNewGame);
            SetTime = new RelayCommand(Do_setTime);
            SetDimension = new RelayCommand(DoSetDimension);
            SetPlayer = new RelayCommand(_DoSetPlayer);
            for (int i = 0; i < _tBoards.Length; i++)
                _tBoards[i] = new SortBoardVM(MiceName[i]);
            _dimensionBut[0].Background = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\BS.Items\Easy.png";
            NotifyPropertyChanged(nameof(DimensionBut0));
            _dimensionBut[3].Text = System.AppDomain.CurrentDomain.BaseDirectory
                          + @"Resources\Number\4b.png";
            NotifyPropertyChanged(nameof(PlayerBut3));
            _playerNum = 4;
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth* 0.141;//
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.33 ;
            NotifyPropertyChanged(nameof(BoardWidth ));
            NotifyPropertyChanged(nameof(BoardHeight));
        }

        private void Do_setTime(object obj)
        {
            string t = obj.ToString();
            //set time of question
            if ( t != "0")
            {
                TimerBut[TimerIndex].Background = string.Empty;
                NotifyPropertyChanged("TimerBut" + TimerIndex);
                int ti;
                if (t == "-1")
                    ti = 3;
                else
                    ti = int.Parse(t);
                TimerBut[0].Background = System.AppDomain.CurrentDomain.BaseDirectory
                    + @"Resources\BS.Items\TimerControl" + ti + ".png";
                NotifyPropertyChanged(nameof(TimerBut0));
                Timer = TimerList[ti];
                TimerIndex = ti;
            }
        }

        void IPageVM.load()
        {
            PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory +
             @"Resources\Audio\He\Title\Sort.wav");
            _logic.GetNewGame();
            base.GameSettings();
            base.NotAlaweVolumZiro();
            MiceLogic.Run();
            MiceLogic.NewMouseSplitter();
            resetGame();
            base.SetBut();
            TimerVisibility = "Visible";
            NotifyPropertyChanged(nameof(TimerVisibility));
        }

        private void DoSetAnser(object obj)
        {
            if (!gameRun && MiceLogic.IsMouseRotation(MiceName[_currentPlay]))
            {
                int[] loc = _logic.GetLocation(obj);
                if(string.IsNullOrEmpty( Items[loc[0], loc[1]].Uid))
                    _location = obj;
                Common.StaticVar.isTimerRedRun = false;
            }
        }

        protected void _DoSetPlayer(object obj)
        {
            base.DoSetPlayer(obj);
            _tBoards[0].InPlay= BoardVisibility0 == Visibility.Visible;
            _tBoards[1].InPlay= BoardVisibility1 == Visibility.Visible;
            _tBoards[2].InPlay= BoardVisibility2 == Visibility.Visible;
            _tBoards[3].InPlay= BoardVisibility3 == Visibility.Visible;
        }

        private void DoSetDimension(object obj)
        {
            _dimensionBut[_logic.GetDimension()-1].Background = string.Empty;
            NotifyPropertyChanged("DimensionBut" + (_logic.GetDimension()-1));
            int d = int.Parse(obj.ToString());
            _logic.SetDimension(d);
            _dimensionBut[d].Background = System.AppDomain.CurrentDomain.BaseDirectory
        + @"Resources\BS.Items\" + CL.BS.Common.StaticVar.LevelButton[d] + ".png";
            NotifyPropertyChanged("DimensionBut" + d);
        }

        private void DoNewGame(object obj)
        {
            if (RunGame)
            {
                ResetGame();
            }
            else
            {
                RunGame = true;
                SetNewGameBut(true);
                gameRun = false;
                NotifyPropertyChanged(nameof(gameRun));
                TimerVisibility = PlayerIndex == 0 ? "Collapsed" : "Visible";
                NotifyPropertyChanged(nameof(TimerVisibility));
                SetBord();
                SetQuestion();
            }
        }

        private void SetBord()
        {
            _currentPlay = 3;
            string[,] pic = _logic.GetNewGame();
            for (int i = 0; i <3; i++)
            {
                if (pic[i, 0] == null)
                    continue;
                for (int j = 0; j < 4; j++)
                {
                    Items[i, j].Text = pic[i, j];
                    NotifyPropertyChanged("Dimension" + i + j);
                }
            }
            for (int i = 0; i < _tBoards.Length; i++)
            {
                _tBoards[i].Point = 0;
            }
        }

        private void SetQuestion()
        {
            new Thread(new ThreadStart(() =>
            {
                _tBoards[_currentPlay].SetQuestion(_logic.GetQuestion());
                TBTimerColor = System.AppDomain.CurrentDomain.BaseDirectory
                      + @"Resources\BS.Items\UCTimerGreen.png";
                NotifyPropertyChanged("TBTimerColor");
                if (TimerBut[0].Background.Contains("TimerControl0.png"))
                {
                    Common.StaticVar.isTimerRedRun = true;
                    while (Common.StaticVar.isTimerRedRun&& RunGame)
                        Thread.Sleep(30);
                    //for (int i = 0; i < 100&& RunGame; i++)
                    //    Thread.Sleep(10);
                }
                else
                {
                    int timeWate = PlayerIndex == 0 ? 600 : 200;
                    string point = "45,0";
                    for (double time = 0; BackgroundNewGame != string.Empty && time < 361&& RunGame &&
                    string.IsNullOrEmpty( _location.ToString()); time += 3)
                    {
                        Thread.Sleep(timeWate);
                        point += " " + (45 + 45 * Math.Sin(time / 45.0)) + ',' + (45 - 45 * Math.Cos(time / 45.0));
                        TBTimer = point;
                        NotifyPropertyChanged(nameof(TBTimer));
                    }
                }
                DoTubPic();
            })).Start();
        }

        private void DoTubPic()
        {
            int[] loc;
            string pic;
            bool b = _logic.ChackAnswer(this._location, out loc, out pic);
            //if (!string.IsNullOrEmpty(Items[loc[0], loc[1]].Uid))
            //    return;
            _location = string.Empty;
            if(RunGame)
                PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Audio\"+(b? "Victory.wav" : "Fault.wav"));
            if (b)
            {
                Items[loc[0], loc[1]].Uid = _colorPlayers[_currentPlay];
                NotifyPropertyChanged("Border" + loc[0] + loc[1]);
                _tBoards[_currentPlay].Point++;
            }
            else
            {
                if (_logic.GetDimension() ==1 && loc[0] == -1)
                {
                    for (int i = 0; i < Items.GetLength(0); i++)
                    {
                        if (string.IsNullOrEmpty(Items[i, loc[1]].Background))
                        {
                            loc[0] = i;
                            break;
                        }
                    }
                }
                if (_logic.GetDimension() == 1 && loc[1] == -1)
                {
                    for (int i = 0; i < Items.GetLength(1); i++)
                    {
                        if (string.IsNullOrEmpty(Items[loc[0], i].Background))
                        {
                            loc[1] = i;
                            break;
                        }
                    }
                }
            }
            Items[loc[0], loc[1]].Background = pic;
            NotifyPropertyChanged("But" + loc[0] + loc[1]);
            _tBoards[_currentPlay].SetQuestion(string.Empty);
            if (gameRun)
            {
                resetGame();
                SetNewGameBut(false);
                return;
            }
            if (_logic.EndGame())
            {
                _task = new Task(EndGameTask);
                _task.Wait(900);
                _task.Start();
            }
            else
            {
                List<int> playList = new List<int>(new int[] { 3, 2, 0, 1 });
                int i = playList.IndexOf(_currentPlay);
                do
                {
                    i = i == _playerNum - 1 ? 0 : i + 1;
                } while (!_tBoards[playList[i]].InPlay);
                _currentPlay = playList[i];
                SetQuestion();
            }
        }

        private void EndGameTask()
        {
            bool[] np = _logic.GetWiners(_tBoards[0].Point, _tBoards[1].Point, _tBoards[2].Point, _tBoards[3].Point);
            bool haveWin = false;
            for (int i = 0; i < _tBoards.Length; i++)
            {
                if (np[i])
                {
                    _tBoards[i].SetSoldierPosition(true);
                    haveWin = true;
                }
            }
            for (int i = 0; i < _tBoards.Length; i++)
            {
                if (_tBoards[i].Is5Position())
                {
                    Common.StaticVar.PlayMode = false;
                    PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Audio\EndWin.wav");
                    _task.Wait(1000);
                    //WhitAntilPlayStop(ref RunGame); 
                    resetGame();
                    SetNewGameBut(false);
                    return;
                }
                else if (haveWin)
                {
                    Common.StaticVar.PlayMode = false;
                    PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory
                       + @"Resources\Audio\StructuralWin.wav");
                    haveWin = false;
                }
            }           
            WhitAntilPlayStop(ref RunGame);
            for (int i = 0; i < 10 && RunGame; i++)
                Thread.Sleep(10);
            for (int i = 0; i < _tBoards.Length;i++)
                _tBoards[i].StoopBlink();
            for (int x = 0; x < Items.GetLength(0); x++)
            {
                for (int y = 0; y < Items.GetLength(1); y++)
                {
                    Items[x, y].Uid = Items[x, y].Background = Items[x, y].Text = string.Empty;
                    NotifyPropertyChanged("But" + x + y);
                    NotifyPropertyChanged("Border" + x + y);
                    NotifyPropertyChanged("Dimension" + x + y);
                }
            }
            SetBord();
            _task = new Task(SetQuestion);
            _task.Wait(4000);
            _task.Start();
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
        
        private void  resetGame()
        {
            base.SetNewGameBut(false);
            for (int x = 0; x < Items.GetLength(0); x++)
            {
                for (int y = 0; y < Items.GetLength(1); y++)
                {
                    Items[x, y].Uid = Items[x, y].Background = Items[x, y].Text = string.Empty;
                    NotifyPropertyChanged("But" + x + y);
                    NotifyPropertyChanged("Border" + x + y);
                    NotifyPropertyChanged("Dimension" + x + y);
                }
                _tBoards[x].SetSoldierPosition(false);
            }
        }
    }
}
