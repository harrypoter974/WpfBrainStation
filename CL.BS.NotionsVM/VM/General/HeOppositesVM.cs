using BS.BingoBoard.VM;
using CL.BS.Contract;
using CL.BS.MEF;
using CL.BS.Model;
using CL.BS.NotionsManager.Interface;
using CL.BS.VMCommon;
using CL.BS.VMCommon.Mice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace CL.BS.NotionsVM.VM.General
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class HeOppositesVM : BaseLernPage, IPageVM
    {
        private IHeOppositesManager _logic = (IHeOppositesManager)
SupportHandlerManager.Base.GetManager("HeOppositesManager");
        protected IMiceManager MiceLogic = new MiceManager();// TouchManager  ();
        private string[] _playList =new string[0];
        public ICommand OpenInstructions { get; set; }
        public ICommand TapAnswer { get; set; }
        public ICommand StartGame { get; set; }
        public ICommand SwitchLanguage { get; set; }
        public string BackgroundNewGame { get; set; }
        public bool NotGameRun { get; set; }
        private int _playerIndex = 3;
        private string[] MiceName = new string[] { "C", "D", "B", "A" };
        private string AnswerIndex ;
        public string BackgroundPic { get; set; }
        public string LanguageBut0 { get { return LanguageBut[0].Background; } set { LanguageBut[0].Background = value; } }
        public string LanguageBut1 { get { return LanguageBut[1].Background; } set { LanguageBut[1].Background = value; } }
        public string LanguageBut2 { get { return LanguageBut[2].Background; } set { LanguageBut[2].Background = value; } }
        protected SoldierObject[] LanguageBut = new SoldierObject[3];
        public double BoardHeight { get; set; }
        public double BoardWidth { get; set; }
        public TrafficLightsBoardVM Board0 { get { return Boards[0]; } set { Boards[0] = value; } }
        public TrafficLightsBoardVM Board1 { get { return Boards[1]; } set { Boards[1] = value; } }
        public TrafficLightsBoardVM Board2 { get { return Boards[2]; } set { Boards[2] = value; } }
        public TrafficLightsBoardVM Board3 { get { return Boards[3]; } set { Boards[3] = value; } }
        public TrafficLightsBoardVM[] Boards = new TrafficLightsBoardVM[4];
        public override string Name => "HeOppositesVM";

        public HeOppositesVM()
        {
            for (int i = 0; i < LanguageBut.Length; i++)
                LanguageBut[i] = new SoldierObject();
            AnswerBut = new RelayCommand(StopGame);
            StartGame = new RelayCommand(DoStartGame);
            TapAnswer = new RelayCommand(DoTapAnswer);
            SwitchLanguage = new RelayCommand(DoSwitchLanguage);
            for (int i = 0; i < Boards.Length; i++)
                Boards[i] =new TrafficLightsBoardVM(i,4, MiceName[i]);
            OpenInstructions = new RelayCommand(DoOpenInstructions);

            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.135;
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.267;
            NotifyPropertyChanged("BoardWidth");
            NotifyPropertyChanged("BoardHeight");
            LanguageBut[0].Background = System.AppDomain.CurrentDomain.BaseDirectory +
               @"Resources\Notions\Animals\AnimalStitle0.png" ;
            NotifyPropertyChanged("LanguageBut0" );
        }

        private void DoSwitchLanguage(object obj)
        {
            _logic.SwitchLanguage( obj);
            string lan = obj.ToString();
            for (int l = 0; l < LanguageBut.Length; l++)
            {
                LanguageBut[l].Background = lan == l.ToString() ? System.AppDomain.CurrentDomain.BaseDirectory +
                  @"Resources\Notions\Animals\AnimalStitle" + l + ".png" : string.Empty;
                NotifyPropertyChanged("LanguageBut" + l);
            }
        }

        private void DoStartGame(object obj)
        {

            new Thread(new ThreadStart(() =>
                {
                    BackgroundNewGame = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\BS.Items\buttonNewGame.png";
                    BackgroundAnswerButton = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\BS.Items\stopRedIcon.png";
                    NotifyPropertyChanged("BackgroundAnswerButton");
                    NotifyPropertyChanged("BackgroundNewGame");
                    NotGameRun = false;
                    NotifyPropertyChanged("NotGameRun");
                    while (!NotGameRun)
                    {
                        while (Common.StaticVar.PlayMode)
                            Thread.Sleep(100);
                        for (int i = 0; i < Boards.Length; i++)
                            Boards[i].SetBoardPic(_playerIndex);

                        SetBackground();
                        _playList = _logic.GetQuestion();
                        PlayList(_playList);
                        base.IsQuestionMode = false;
                        AnswerIndex = string.Empty;
                        while (AnswerIndex == string.Empty)
                        {
                            Thread.Sleep(250);
                        }
                        if (AnswerIndex == _logic.GetAnswer().ToString())
                        {
                            if (Boards[_playerIndex].SetSoldierPosition(true))
                            {
                                PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Audio\EndWin.wav");
                                Boards[_playerIndex].GameWin();
                                break;
                            }
                        }
                        _playerIndex = _playerIndex < 3 ? _playerIndex + 1 : 0;
                    }
                    ResetGame();
                })).Start();

        }

        private void DoTapAnswer(object obj)
        {
            if(MiceLogic.GetMouseRotation()== MiceName[ _playerIndex])
                AnswerIndex = obj.ToString();
        }

        void IPageVM.load()
        {
            _logic.load();
            base.Settings();
            if (!Common.StaticVar.inline.IsBoy)
            {
                messagePic = System.AppDomain.CurrentDomain.BaseDirectory +
                   @"Resources\Notions\Opposites\message.png";
            }
            else
                messagePic = string.Empty;
            NotifyPropertyChanged("messagePic");
            SetBackground();
            ResetGame();

            MiceLogic.Run();
            MiceLogic.NewMouseSplitter();
            Common.MiceKiller.KillAllMices(true);
        }

        private void DoOpenInstructions(object obj)
        {

            if (obj.ToString() == "Colse" || BackgroundPic.Contains("Instructions.jpg"))
            {
                BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\Notions\Opposites\oposites" + _logic.GetIndex() + ".jpg";
            }
            else
            {
                BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory
     + @"Resources\Notions\Opposites\Instructions.jpg";
            }
            NotifyPropertyChanged("BackgroundPic");
        }

        private void StopGame(object obj)
        {
            ResetGame();
        }

        private void ResetGame()
        {
            NotGameRun = true;
            NotifyPropertyChanged("NotGameRun");
            BackgroundNewGame = BackgroundAnswerButton = string.Empty;
            NotifyPropertyChanged("BackgroundAnswerButton");
            NotifyPropertyChanged("BackgroundNewGame");
            for (int i = 0; i < Boards.Length; i++)
                Boards[i].SetSoldierPosition(false);
        }

        private void SetBackground()
        {
            BackgroundAnswerButton = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\BS.Items\stopRedIcon.png";
            NotifyPropertyChanged("BackgroundAnswerButton");
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\Notions\Opposites\oposites" + _logic.GetIndex()+ ".jpg";
            NotifyPropertyChanged("BackgroundPic");
        }

        private void switchAnswerButton()
        {
            IsQuestionMode = !IsQuestionMode;
            if (IsQuestionMode)
                BackgroundAnswerButton = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\BS.Items\GShowTask.png";
            else
                BackgroundAnswerButton = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\BS.Items\BShowSolution.png";
            NotifyPropertyChanged("BackgroundAnswerButton");
        }
        void IPageVM.disload()
        {
            MiceLogic.OnClosing();
            MiceLogic.Close();
            MiceLogic.Dispose();
            Common.MiceKiller.KillAllMices(false);
        }
    }
}
