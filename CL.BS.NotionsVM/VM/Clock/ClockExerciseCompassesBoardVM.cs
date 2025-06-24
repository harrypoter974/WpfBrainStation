using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CL.BS.MEF;
using CL.BS.NotionsManager.Interface;
using CL.BS.VMCommon;


namespace CL.BS.NotionsVM.VM.Clock
{
    public class ClockExerciseCompassesBoardVM : BaseLernPage
    {
        public override string Name =>nameof(ClockExerciseCompassesBoardVM) ;
        public double BoardHeight { get; set; }
        public double BoardWidth { get; set; }
        private IClockManager _logic = (IClockManager)
 SupportHandlerManager.Base.GetManager("ClockManager");
        private bool _isMinute = false;
        public ICommand ChangeLevel { get; set; }
        public ICommand MoveMinutes { get; set; }
        public bool IsMoveMinutes =true;
        public string VisibilityNeedle { get; set; }
        public string MoveMinutesBut { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }
        public string IsMinuteBut { get; set; }
        public string TClock { get; set; }
        private string[] _answer;
        public string HappySmily { get; set; }
        private Dictionary <int,int> _Minute = new Dictionary<int,int>();
        public ClockExerciseCompassesBoardVM()
        {
            _Minute.Add(0, 0);
            _Minute.Add(360, 0);
            _Minute.Add(90, 7);
            _Minute.Add(180, 14);
            _Minute.Add(270, 21);
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.425;// 0.463
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.474;//0.491
            NotifyPropertyChanged(nameof(BoardWidth));
            NotifyPropertyChanged(nameof(BoardHeight));
            TClock = string.Empty;
            VisibilityNeedle = Visibility.Hidden.ToString();;
            NotifyPropertyChanged(nameof(VisibilityNeedle));
            AnswerBut = new RelayCommand(DoAnswerBut);
            ChangeLevel = new RelayCommand(DoChangeLevel);
            HappySmily = string.Empty;
            NotifyPropertyChanged(nameof(HappySmily));
            MouseMove = new RelayCommand(DoMouseMove);
            MoveMinutes = new RelayCommand(DoMoveMinutes);
            DoMoveMinutes(0);
            Minute = Hour = 0;
        }

        private void DoMoveMinutes(object obj)
        {
            IsMoveMinutes = !IsMoveMinutes;
            MoveMinutesBut =IsMoveMinutes ?  string.Format(@"{0}Resources\Notions\Clock\MoveMinutesBut.png"
,System.AppDomain.CurrentDomain.BaseDirectory)   : String.Empty;
            NotifyPropertyChanged(nameof(MoveMinutesBut));
        }

        private void DoMouseMove(object obj)
        {
            if (base.IsQuestionMode)
                return;
            int t = int.Parse(obj.ToString());
            if (IsMoveMinutes)
            {
                Minute = t * 30;
                if (_Minute.ContainsKey(Minute))
                    Hour =(Hour/30) *30 + _Minute[Minute];
                Minute = Minute == 360 ? 0 : Minute;
            }
            else
            {
                Hour = t * 30+ _Minute[Minute];
            }
            NotifyPropertyChanged(nameof(Minute));
            NotifyPropertyChanged(nameof(Hour));
        }

        private void DoChangeLevel(object obj)
        {
            if (Common.StaticVar.PlayMode)
                return;
            if (!base.IsQuestionMode)
                DoAnswerBut(0);
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
            NotifyPropertyChanged(nameof(IsMinuteBut) );
            //_logic.SwitchIsMinute();
        }

        private void DoAnswerBut(object obj)
        {
            if (Common.StaticVar.PlayMode)
                return;
            if (base.IsQuestionMode)
            {
                string tClock;
                VisibilityNeedle = Visibility.Hidden.ToString();
                //  PlayList()
                _answer = _logic.GetQuestion(_isMinute, out tClock);
                TClock = tClock;
                NotifyPropertyChanged("TClock");
                HappySmily = string.Empty;
                NotifyPropertyChanged(nameof(HappySmily));
            }
            else
            {
                VisibilityNeedle = Visibility.Visible.ToString();
                int[] answer = new int[] { int.Parse(_answer[3]),int.Parse(_answer[4])};
                bool IsRightTime = Hour== answer[0] && Minute == answer[1];                
                HappySmily = string.Format(@"{0}\Resources\BS.Items\{1}Smily.png"
, System.AppDomain.CurrentDomain.BaseDirectory, IsRightTime ? "Happy" : "Sad");
                NotifyPropertyChanged(nameof(HappySmily));
                Hour = answer[0];
                Minute = answer[1];
                NotifyPropertyChanged(nameof(Hour));
                NotifyPropertyChanged(nameof(Minute));
            }
            base.SwitchAnswerButton();
            NotifyPropertyChanged(nameof(VisibilityNeedle));
        }
    }
}
