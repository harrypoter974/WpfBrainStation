using CL.BS.MEF;
using CL.BS.Model;
using CL.BS.NotionsManager.Interface;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.NotionsVM.VM.Clock
{
    public class ClockExerciseDigitalBoardVM : BaseLernPage
    {
        public override string Name =>nameof(ClockExerciseDigitalBoardVM) ;
        private bool _isMinute = false, _is24 = false;
        public string But24End12 { get; set; }
        public ICommand ChangeLevel { get; set; }
        public ICommand MouseDown { get; set; }
        public ICommand MouseUp { get; set; }
        public ICommand Switch24to12 { get; set; }
        public int Column { get; set; }
        public int Row { get; set; }
        public string TClock { get; set; }
        public string HappySmily { get; set; }
        public string ALetter0 { get { return LetterList[0].Background; } set { LetterList[0].Background = value; } }
        public string ALetter1 { get { return LetterList[1].Background; } set { LetterList[1].Background = value; } }
        public string ALetter2 { get { return LetterList[2].Background; } set { LetterList[2].Background = value; } }
        public string ALetter3 { get { return LetterList[3].Background; } set { LetterList[3].Background = value; } }

        protected SoldierObject[] LetterList = new SoldierObject[4];
        public string IsMinuteBut { get; set; }
        private IClockManager _logic = (IClockManager)
     SupportHandlerManager.Base.GetManager("ClockManager");
        public double BoardHeight { get; set; }
        public double BoardWidth { get; set; }
        private string[] _answer;
        public ClockExerciseDigitalBoardVM()
        {
            for (int i = 0; i < LetterList.Length; i++)
                LetterList[i]=new SoldierObject();    
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth *0.424 ;// 0.463
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight *0.473 ;//0.491
            NotifyPropertyChanged( nameof(BoardWidth));
            NotifyPropertyChanged(nameof(BoardHeight));
            AnswerBut = new RelayCommand(_doAnswerBut);
            ChangeLevel = new RelayCommand(DoChangeLevel);
            MouseMove = new RelayCommand(DoMouseMove);
            MouseUp = new RelayCommand(DoMouseUp);
            MouseDown = new RelayCommand(DoMouseDown);
            Switch24to12 = new RelayCommand(DoSwitch24to12);
            
            HappySmily = string.Empty;
            NotifyPropertyChanged(nameof(HappySmily));
            But24End12 = string.Format(@"{0}Resources\Notions\Clock\{1}.png"
, System.AppDomain.CurrentDomain.BaseDirectory, _is24 ? "But12" : "But24");
            NotifyPropertyChanged(nameof(But24End12));
            _logic.Is24(_is24);
        }

        private void DoSwitch24to12(object obj)
        {
            _is24 = !_is24;
            But24End12 = string.Format(@"{0}Resources\Notions\Clock\{1}.png"
, System.AppDomain.CurrentDomain.BaseDirectory, _is24 ? "But12" : "But24");
            NotifyPropertyChanged(nameof(But24End12));
            _logic.Is24(_is24);
        }

        private void DoMouseMove(object obj)
        {
            string[] n = obj.ToString().Split('_');
            Row = int.Parse(n[1]);
            Column = int.Parse(n[0]);
            NotifyPropertyChanged(nameof(Row));
            NotifyPropertyChanged(nameof(Column));
        }

        private void DoMouseUp(object obj)
        {
            int loc = int.Parse(obj.ToString());
            LetterList[loc].Background = TextCard;
            NotifyPropertyChanged("ALetter" + loc);
            VisibilityCard = "Collapsed";
            NotifyPropertyChanged(nameof(VisibilityCard));
        }

        private void DoMouseDown(object obj)
        {
            if (base.IsQuestionMode)
                return;
            string[] n = obj.ToString().Split('_');
            Row = int.Parse(n[1]);
            Column = int.Parse(n[0]);
            TextCard = n[2].ToString();
            NotifyPropertyChanged(nameof(Row));
            NotifyPropertyChanged(nameof(Column));
            NotifyPropertyChanged(nameof(TextCard));
            VisibilityCard = "Visible";
            NotifyPropertyChanged(nameof(VisibilityCard));
        }

        private void DoChangeLevel(object obj)
        {
            if (Common.StaticVar.PlayMode)
                return;
            if (!base.IsQuestionMode)
                _doAnswerBut(0);
            if (_isMinute)
            {
                IsMinuteBut = string.Empty;
            }
            else
            {
                IsMinuteBut = System.AppDomain.CurrentDomain.BaseDirectory
               + @"Resources\BS.Items\IsMinuteBut.png";
            }
            _isMinute = !_isMinute;
            NotifyPropertyChanged(nameof(IsMinuteBut));
            //_logic.SwitchIsMinute();
        }

        private void _doAnswerBut(object obj)
        {
            if (Common.StaticVar.PlayMode)
                return;
            if (base.IsQuestionMode)
            {
                string q;
                // PlayList()
               _answer =  _logic.GetDigitalQuestion(_isMinute, out q);
                TClock = q;
                for (int i = 0; i < LetterList.Length; i++)
                    LetterList[i].Background = String.Empty;
                NotifyPropertyChanged(nameof(TClock));
                HappySmily = string.Empty;
                NotifyPropertyChanged(nameof(HappySmily));
                VisibilityCard = "Collapsed";
                NotifyPropertyChanged(nameof(VisibilityCard));
            }
            else
            {
                bool IsRightTime=true;
                for (int i = 5; IsRightTime&& i < LetterList.Length+5; i++)
                    IsRightTime=LetterList[i-5].Background == _answer[i];
                HappySmily = string.Format(@"{0}\Resources\BS.Items\{1}Smily.png"
, System.AppDomain.CurrentDomain.BaseDirectory, IsRightTime ? "Happy" : "Sad");
                NotifyPropertyChanged(nameof(HappySmily));
                for (int i =5; i < LetterList.Length+5; i++)
                    LetterList[i - 5].Background = _answer[i];
            }
            base.SwitchAnswerButton();
            for (int i = 0; i < LetterList.Length; i++)
            {
                NotifyPropertyChanged("ALetter"+i);
            }
        }
    }
}
