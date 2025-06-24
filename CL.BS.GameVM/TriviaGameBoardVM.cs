using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CL.BS.Common;
using CL.BS.Contract;
using CL.BS.GameManager.Engen;
using CL.BS.Model;
using CL.BS.VMCommon;
using MultipleMice;

namespace CL.BS.GameVM
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class TriviaGameBoardVM : BasePageVM
    {

        private Random _ran = new Random(DateTime.Now.Millisecond);
        private string _riteAnswer;
        private int _indexAnswer;
        private int _arrowPosition, _soldierPosition;
        private string _soldierTipe;
        protected IMiceManager Window;
        protected string Rotation;
        public string TBQuestion { get; set; }
        public string IQuestion { get; set; }
        public string TBAnswer0 { get { return _items[0].Answer; } set { _items[0].Answer = value; } }
        public string TBAnswer1 { get { return _items[1].Answer; } set { _items[1].Answer = value; } }
        public string TBAnswer2 { get { return _items[2].Answer; } set { _items[2].Answer = value; } }
        public string TBAnswer3 { get { return _items[3].Answer; } set { _items[3].Answer = value; } }
        public string BackAnswer0 { get { return _items[0].Question; } set { _items[0].Question = value; } }
        public string BackAnswer1 { get { return _items[1].Question; } set { _items[1].Question = value; } }
        public string BackAnswer2 { get { return _items[2].Question; } set { _items[2].Question = value; } }
        public string BackAnswer3 { get { return _items[3].Question; } set { _items[3].Question = value; } }
        public string TBSoldier0 { get { return _soldiers[0].Background; } set { _soldiers[0].Background = value; } }
        public string TBSoldier1 { get { return _soldiers[1].Background; } set { _soldiers[1].Background = value; } }
        public string TBSoldier2 { get { return _soldiers[2].Background; } set { _soldiers[2].Background = value; } }
        public string TBSoldier3 { get { return _soldiers[3].Background; } set { _soldiers[3].Background = value; } }
        public string TBSoldier4 { get { return _soldiers[4].Background; } set { _soldiers[4].Background = value; } }
        public string TBArrow0 { get { return _items[0].Uid; } set { _items[0].Uid = value; } }
        public string TBArrow1 { get { return _items[1].Uid; } set { _items[1].Uid = value; } }
        public string TBArrow2 { get { return _items[2].Uid; } set { _items[2].Uid = value; } }
        public string TBArrow3 { get { return _items[3].Uid; } set { _items[3].Uid = value; } }
        public string TBArrow4 { get { return _items[4].Uid; } set { _items[4].Uid = value; } }
        public string TBArrow5 { get { return _items[5].Uid; } set { _items[5].Uid = value; } }
        public string TBArrow6 { get { return _items[6].Uid; } set { _items[6].Uid = value; } }
        private GameObject[] _items = new GameObject[7];
        private SoldierObject[] _soldiers = new SoldierObject[7];
        public ICommand TapAnswer { get; set; }
        public Visibility WinUCBlinkBord { get; set; }
        public override string Name => "TriviaGameBoardVM";

        public TriviaGameBoardVM()
        {
            TapAnswer = new VMCommon.RelayCommand(DoTapAnswer);
            for (int i = 0; i < _items.Length; i++)
                _items[i] = new GameObject();
            for (int i = 0; i < _soldiers.Length; i++)
                _soldiers[i] = new SoldierObject();
            WinUCBlinkBord = Visibility.Collapsed;
            NotifyPropertyChanged("WinUCBlinkBord");
        }

        internal bool GetIsFirst()
        {
            return _indexAnswer != -1;
        }

        private void DoTapAnswer(object obj)
        {
            if (Common.StaticVar.isTimerRedRun  && Window.IsMouseRotation( Rotation))
            {
                if (_indexAnswer != -1)
                {
                    _items[_indexAnswer].Question = "";
                    NotifyPropertyChanged("BackAnswer" + _indexAnswer);
                }
                int indx = int.Parse(obj.ToString());
                _items[indx].Question = System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\BS.Items\PoshButton.jpg";
                NotifyPropertyChanged("BackAnswer" + indx);
                _indexAnswer = indx;
            }
        }

        private void SetSoldierPosition()
        {
            _items[_arrowPosition].Uid = string.Empty;
            NotifyPropertyChanged("TBArrow" + _arrowPosition++);
            _items[_arrowPosition].Uid = System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\Pion\" + _soldierTipe;
            NotifyPropertyChanged("TBArrow" + _arrowPosition);
        }

        public void ResatGame()
        {
            _items[_arrowPosition].Uid = string.Empty;
            NotifyPropertyChanged("TBArrow" + _arrowPosition);
            _arrowPosition = 0;
            _items[_arrowPosition].Uid = System.AppDomain.CurrentDomain.BaseDirectory +
                 @"Resources\Pion\Arrow" + Rotation + ".png";
            NotifyPropertyChanged("TBArrow0");
            for (int i = 0; i <4; i++)
            {
              _items[i].Question =  _items[i].Answer = string.Empty;
                NotifyPropertyChanged("TBAnswer" + i);
                NotifyPropertyChanged("BackAnswer" + i);
            }
           IQuestion = TBQuestion = string.Empty;
            NotifyPropertyChanged("TBQuestion");
            NotifyPropertyChanged("IQuestion");
            _indexAnswer = -1;

            _soldiers[_soldierPosition].Background = string.Empty;
            NotifyPropertyChanged("TBSoldier" + _soldierPosition);
            _soldierPosition=0;
            _soldiers[0].Background = System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\Pion\" + Rotation + ".png";
            NotifyPropertyChanged("TBSoldier0" );
        }

        public void SetQuestion(triviaQuestion q)
        {
            _riteAnswer = q.Answer[0];
            List<string> al = GeneralFunctions.ShuffleList<string>( new List<string>( q.Answer));
            for (int i = 0; i < q.Answer.Length; i++)
            {
                _items[i].Answer = al[i];
                NotifyPropertyChanged("TBAnswer" + i);
            }
            TBQuestion = q.Question;
            NotifyPropertyChanged("TBQuestion");
            IQuestion =  System.AppDomain.CurrentDomain.BaseDirectory +
                   @"Resources\Game\triva\" + q.Pic + ".jpg";
            NotifyPropertyChanged("IQuestion");
            if (_indexAnswer != -1)
            {
                _items[_indexAnswer].Question = "";
                NotifyPropertyChanged("BackAnswer" + _indexAnswer);
            }
            _indexAnswer = -1;
        }

        internal void DisappearSoldier()
        {
           _items[_arrowPosition].Uid = string.Empty;
            NotifyPropertyChanged("TBArrow" + _arrowPosition);
        }

        internal int ChackQuestion(string answer)
        {
            int winRes = 0;
            TBQuestion = answer;
            NotifyPropertyChanged("TBQuestion");
            if (_indexAnswer != -1)
            {
                _items[_indexAnswer].Question = "";
                NotifyPropertyChanged("BackAnswer" + _indexAnswer);
                if (_riteAnswer == _items[_indexAnswer].Answer)
                {
                    SetSoldierPosition();
                    winRes = 1;
                    if (_arrowPosition == 6)
                        winRes = 2;
                }
            }           
            _indexAnswer = -1;
            
            return winRes;
        }

        internal void DoWinUCBlinkBord()
        {
            //new Thread(new ThreadStart(() =>  {
            for (int i = 0; i < 12; i++)
            {
                WinUCBlinkBord = i % 2 == 1 ? Visibility.Hidden : Visibility.Visible;
                NotifyPropertyChanged("WinUCBlinkBord");
                Thread.Sleep(250);
            }
            //})).Start();
            string name = "";
            switch (this.Window.GetMouseRotation())
            {
                case "A": name = StaticVar.inline.NicknameA; break;
                case "B": name = StaticVar.inline.NicknameB; break;
                case "C": name = StaticVar.inline.NicknameC; break;
                case "D": name = StaticVar.inline.NicknameD; break;
            }
            PlayList(new string[] {  @"Resources\Audio\He\Good\Win"+name     + ".wav",
                @"Resources\Audio\He\Good\Win" + _ran.Next(8) + ".wav"});
        }

        internal void ResatArrow()
        {
            _items[_arrowPosition].Uid = string.Empty;
            NotifyPropertyChanged("TBArrow" + _arrowPosition++);
            _arrowPosition = 0;
            _items[0].Uid = System.AppDomain.CurrentDomain.BaseDirectory +
        @"Resources\Pion\" + _soldierTipe;
            NotifyPropertyChanged("TBArrow0");
        }

        internal bool SetSoldierPosition(bool soldierUp)
        {
            bool isEnd = false;
            if (soldierUp)
            {
                _soldiers[_soldierPosition].Background = string.Empty;
                NotifyPropertyChanged("TBSoldier" + _soldierPosition);
                _soldierPosition++;
                _soldiers[_soldierPosition].Background = System.AppDomain.CurrentDomain.BaseDirectory +
                    @"Resources\Pion\" + Rotation + ".png";
                NotifyPropertyChanged("TBSoldier" + _soldierPosition);
                if (_soldierPosition == 4)
                    isEnd = true;
            }
            return isEnd;
        }

        internal void SetMouse(IMiceManager win, string rotation)
        {
            Window = win;
            Rotation = rotation;
            _soldierTipe= "Arrow" + Rotation+ ".png";
            _items[0].Uid = System.AppDomain.CurrentDomain.BaseDirectory +
           @"Resources\Pion\" + _soldierTipe;
            NotifyPropertyChanged("TBArrow0");
        }
    }
}
