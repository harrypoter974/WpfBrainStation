using CL.BS.Common;
using CL.BS.Contract;
using CL.BS.GameManager.Engen;
using CL.BS.Model;
using CL.BS.NotionsManager.Engine;
using CL.BS.VMCommon;
using MultipleMice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CL.BS.NotionsVM.VM.General
{
    public class GardenTriviaBoardVM : BasePageVM
    {
        private List<string> _answerList;
        private Random _ran = new Random(DateTime.Now.Millisecond);
        private string _riteAnswer;
        private int _indexAnswer;
        private int _arrowPosition, SoldierPosition;
        private string _soldierTipe;
        protected IMiceManager window;
        protected string Rotation;
        public string TBQuestion { get; set; }
        public string IQuestion { get; set; }
        public string TextQuestion { get; set; }
        public string TBAnswer0 { get { return _items[0].Text; } set { _items[0].Text = value; } }
        public string TBAnswer1 { get { return _items[1].Text; } set { _items[1].Text = value; } }
        public string TBAnswer2 { get { return _items[2].Text; } set { _items[2].Text = value; } }
        public string TBAnswer3 { get { return _items[3].Text; } set { _items[3].Text = value; } }
        public string TBPicAnswer0 { get { return _items[0].Background; } set { _items[0].Background = value; } }
        public string TBPicAnswer1 { get { return _items[1].Background; } set { _items[1].Background = value; } }
        public string TBPicAnswer2 { get { return _items[2].Background; } set { _items[2].Background = value; } }
        public string TBPicAnswer3 { get { return _items[3].Background; } set { _items[3].Background = value; } }
        public int Angle0 { get { return _items[0].Width; } set { _items[0].Width = value; } }
        public int Angle1 { get { return _items[1].Width; } set { _items[1].Width = value; } }
        public int Angle2 { get { return _items[2].Width; } set { _items[2].Width = value; } }
        public int Angle3 { get { return _items[3].Width; } set { _items[3].Width = value; } }
        public string BackAnswer0 { get { return _items[0].Uid; } set { _items[0].Uid = value; } }
        public string BackAnswer1 { get { return _items[1].Uid; } set { _items[1].Uid = value; } }
        public string BackAnswer2 { get { return _items[2].Uid; } set { _items[2].Uid = value; } }
        public string BackAnswer3 { get { return _items[3].Uid; } set { _items[3].Uid = value; } }

        public string RightAnswer0 { get { return _arrows[0].Background; } set { _arrows[0].Background = value; } }
        public string RightAnswer1 { get { return _arrows[1].Background; } set { _arrows[1].Background = value; } }
        public string RightAnswer2 { get { return _arrows[2].Background; } set { _arrows[2].Background = value; } }
        public string RightAnswer3 { get { return _arrows[3].Background; } set { _arrows[3].Background = value; } }

        public string TBSoldier0 { get { return Soldiers[0].Background; } set { Soldiers[0].Background = value; } }
        public string TBSoldier1 { get { return Soldiers[1].Background; } set { Soldiers[1].Background = value; } }
        public string TBSoldier2 { get { return Soldiers[2].Background; } set { Soldiers[2].Background = value; } }
        public string TBSoldier3 { get { return Soldiers[3].Background; } set { Soldiers[3].Background = value; } }
        public string TBSoldier4 { get { return Soldiers[4].Background; } set { Soldiers[4].Background = value; } }
        public string TBArrow0 { get { return Soldiers[0].Text; } set { Soldiers[0].Text = value; } }
        public string TBArrow1 { get { return Soldiers[1].Text; } set { Soldiers[1].Text = value; } }
        public string TBArrow2 { get { return Soldiers[2].Text; } set { Soldiers[2].Text = value; } }
        public string TBArrow3 { get { return Soldiers[3].Text; } set { Soldiers[3].Text = value; } }
        public string TBArrow4 { get { return Soldiers[4].Text; } set { Soldiers[4].Text = value; } }
        public string TBArrow5 { get { return Soldiers[5].Text; } set { Soldiers[5].Text = value; } }
        public string TBArrow6 { get { return Soldiers[6].Text; } set { Soldiers[6].Text = value; } }

        private LetterObject[] _items = new LetterObject[4];
        private LetterObject[] _arrows = new LetterObject[4];
        private LetterObject[] Soldiers = new LetterObject[7];
        public ICommand TapAnswer { get; set; }
        public Visibility WinUCBlinkBord { get; set; }
        public Visibility BaseWinBlink { get; set; }
        public override string Name =>nameof(GardenTriviaBoardVM) ;

        public GardenTriviaBoardVM()
        {
            TapAnswer = new VMCommon.RelayCommand(DoTapAnswer);
          
            for (int i = 0; i < _items.Length; i++)  {
                _items[i] = new LetterObject();
                _arrows[i] = new LetterObject();
            }
            for (int i = 0; i < Soldiers.Length; i++)
                Soldiers[i] = new LetterObject();
            WinUCBlinkBord = Visibility.Collapsed;
            NotifyPropertyChanged(nameof(WinUCBlinkBord));

        }

        private void DoTapAnswer(object obj)
        {
            if (Common.StaticVar.isTimerRedRun && window.IsMouseRotation(Rotation))
            {
                if (_indexAnswer != -1)
                {
                    _items[_indexAnswer].Uid = "";
                    NotifyPropertyChanged("BackAnswer" + _indexAnswer);
                }
                int indx = int.Parse(obj.ToString());
                _items[indx].Uid = System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\BS.Items\PoshButton.jpg";
                NotifyPropertyChanged("BackAnswer" + indx);
                _indexAnswer = indx;
            }
        }

        private void SetSoldierPosition()
        {
            Soldiers[_arrowPosition].Text = string.Empty;
            NotifyPropertyChanged("TBArrow" + _arrowPosition++);
            Soldiers[_arrowPosition].Text = System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\Pion\" + _soldierTipe;
            NotifyPropertyChanged("TBArrow" + _arrowPosition);
        }

        public void ResatGame()
        {
            Soldiers[_arrowPosition].Text = string.Empty;
            NotifyPropertyChanged("TBArrow" + _arrowPosition);
            _arrowPosition = 0;
            Soldiers[_arrowPosition].Text = System.AppDomain.CurrentDomain.BaseDirectory +
                 @"Resources\Pion\Arrow" + Rotation + ".png";
            NotifyPropertyChanged("TBArrow0");

            BaseWinBlink = Visibility.Hidden;
            NotifyPropertyChanged("BaseWinBlink");
            for (int i = 0; i < 4; i++)
            {
                _arrows[i].Background = _items[i].Background = _items[i].Uid = _items[i].Text = string.Empty;
                _items[i].Width = 0;
                NotifyPropertyChanged("RightAnswer" + i);
                NotifyPropertyChanged("BackAnswer" + i);
                NotifyPropertyChanged("TBAnswer" + i);
                NotifyPropertyChanged("TBPicAnswer" + i);
                NotifyPropertyChanged("Angle" + i);
            }
            TextQuestion = IQuestion = TBQuestion = string.Empty;
            NotifyPropertyChanged(nameof(TBQuestion));
            NotifyPropertyChanged(nameof(IQuestion));
            _indexAnswer = -1;

            Soldiers[SoldierPosition].Background = string.Empty;
            NotifyPropertyChanged("TBSoldier" + SoldierPosition);
            SoldierPosition = 0;
            Soldiers[0].Background = System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\Pion\" + Rotation + ".png";
            NotifyPropertyChanged(nameof(TBSoldier0));
        }

        public void SetQuestion(triviaQuestion q)
        {
            _riteAnswer = q.Answer[0];
            _answerList = GeneralFunctions.ShuffleList<string>(new List<string>(q.Answer));
            for (int i = 0; i < q.Answer.Length; i++)
            {
                string[]a = _answerList[i].Split(',');
                _items[i].Text = a[0];
                _items[i].Background = a[1];
                _items[i].Width =int.Parse( a[2]);
                _arrows[i].Background = string.Empty;
                NotifyPropertyChanged("TBAnswer" + i);
                NotifyPropertyChanged("TBPicAnswer" + i);
                NotifyPropertyChanged("Angle" + i);
                NotifyPropertyChanged("RightAnswer" + i);
            }
            TBQuestion = q.Question;
            NotifyPropertyChanged(nameof(TBQuestion));
            IQuestion = System.AppDomain.CurrentDomain.BaseDirectory + q.Pic ;
            TextQuestion = q.EndAdio;//Question Text
            NotifyPropertyChanged("IQuestion");
            NotifyPropertyChanged("TextQuestion");
            if (_indexAnswer != -1)
            {
                _items[_indexAnswer].Uid = "";
                NotifyPropertyChanged("BackAnswer" + _indexAnswer);
            }
            _indexAnswer = -1;
        }

        internal void DisappearSoldier()
        {
            Soldiers[_arrowPosition].Text = string.Empty;
            NotifyPropertyChanged("TBArrow" + _arrowPosition);
        }

        internal int ChackQuestion(string answer)
        {
            int winRes = 0;
            TBQuestion = answer;
            NotifyPropertyChanged("TBQuestion");
            for (int i = 0; i < _arrows.Length; i++)
            {
                if (_riteAnswer == _answerList[i])
                {
                    _arrows[i].Background = System.AppDomain.CurrentDomain.BaseDirectory +
                    @"Resources\Notions\Trivia\Arrow.png";
                    NotifyPropertyChanged("RightAnswer" + i);
                    break;
                }
            }   
            if (_indexAnswer != -1)
            {
                _items[_indexAnswer].Uid = "";
                NotifyPropertyChanged("BackAnswer" + _indexAnswer);
                if (_riteAnswer == _answerList[_indexAnswer])
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

        internal void ResatArrow()
        {
            if (_arrowPosition < 6)
                return;
            Soldiers[_arrowPosition].Text = string.Empty;
            NotifyPropertyChanged("TBArrow" + _arrowPosition);
            _arrowPosition = 0;
            Soldiers[0].Text = System.AppDomain.CurrentDomain.BaseDirectory +
        @"Resources\Pion\" + _soldierTipe;
            NotifyPropertyChanged(nameof(TBArrow0));
        }

        internal string[] DoWinUCBlinkBord()
        {
            for (int i = 0; i < 12; i++)
            {
                WinUCBlinkBord = i % 2 == 1 ? Visibility.Hidden : Visibility.Visible;
                NotifyPropertyChanged("WinUCBlinkBord");
                Thread.Sleep(250);
            }
            string name = "";
            switch (this.window.GetMouseRotation())
            {
                case "A": name = StaticVar.inline.NicknameA; break;
                case "B": name = StaticVar.inline.NicknameB; break;
                case "C": name = StaticVar.inline.NicknameC; break;
                case "D": name = StaticVar.inline.NicknameD; break;
            }
            return new string[] {  @"Resources\Audio\He\Good\Win"+name     + ".wav",
                @"Resources\Audio\He\Good\Win" + _ran.Next(8) + ".wav"};
        }

        internal bool SetSoldierPosition(bool soldierUp)
        {
            bool isEnd = false;
            if (soldierUp)
            {
                Soldiers[SoldierPosition].Background = string.Empty;
                NotifyPropertyChanged("TBSoldier" + SoldierPosition);
                SoldierPosition++;
                Soldiers[SoldierPosition].Background = System.AppDomain.CurrentDomain.BaseDirectory +
                    @"Resources\Pion\" + Rotation + ".png";
                NotifyPropertyChanged("TBSoldier" + SoldierPosition);
                if (SoldierPosition == 4) {
                    isEnd = true;
                    BaseWinBlink = Visibility.Visible;
                    NotifyPropertyChanged("BaseWinBlink");
                }
            }
            return isEnd;
        }

        internal void SetMouse(IMiceManager win, string rotation)
        {
            window = win;
            Rotation = rotation;
            _soldierTipe = "Arrow" + Rotation + ".png";
            Soldiers[0].Text = System.AppDomain.CurrentDomain.BaseDirectory +
           @"Resources\Pion\" + _soldierTipe;
            NotifyPropertyChanged("TBArrow0");
        }

        internal bool GetIsFirst()
        {
            return _indexAnswer != -1;
        }
    }
}
