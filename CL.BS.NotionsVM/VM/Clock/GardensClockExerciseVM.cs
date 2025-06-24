using CL.BS.Common;
using CL.BS.Contract;
using CL.BS.MEF;
using CL.BS.NotionsManager.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.NotionsVM.VM.Clock
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class GardensClockExerciseVM : LearningClockVM, IPageVM
    { 
        public override string Name
        {
            get
            {
                return nameof(GardensClockExerciseVM);
            }
        }
        public int Hour { get; set; }
        private string[] _hourPlay;
        public ICommand RePlay { get; set; }
        public string VisibilityNeedle { get; set; }
        public string TClock { get; set; }
        private IClockManager _logic = (IClockManager)
        SupportHandlerManager.Base.GetManager("ClockManager");

        public GardensClockExerciseVM()
        {
            TClock = string.Empty;
            AnswerBut = new RelayCommand(DoAnswerBut);
            RePlay = new RelayCommand(DoRePlay);
        }

        void IPageVM.load()
        {
            _hourPlay = new string[0];
            base.Settings();
            if (!Common.StaticVar.inline.IsBoy)
                messagePic = "Visible";
            else
                messagePic = "Hidden";
            NotifyPropertyChanged(nameof(messagePic));
        }

        private void DoRePlay(object obj)
        {
            if (!Common.StaticVar.PlayMode)
                PlayList(_hourPlay);
        }

        private void DoAnswerBut(object obj)
        {
            if (Common.StaticVar.PlayMode)
                return;
            if (base.IsQuestionMode)
            {
                string tClock;
                _logic.GetQuestion(false, out tClock);
               
                VisibilityNeedle = "Hidden";
                int[] answer = _logic.getAnswer();
                Hour = answer[0];
                if (Hour == 0)
                    TClock = "12:00";
                else
                    TClock = (Hour/30)+":00";
                NotifyPropertyChanged("TClock");
                string n;
                if (Hour/30==2)
                {
                    n = "two";
                }
                else if(Hour / 30>10)
                {
                    n = (Hour / 30).ToString();
                }
                else
                {
                    n = "n" + (Hour / 30);
                }
                _hourPlay = new string[] {Common.StaticVar.inline.PlayName(),(Common.StaticVar.inline.IsBoy ?
                    @"Resources\Audio\He\time\intention.wav" : @"Resources\Audio\He\time\directional.wav"),
 @"Resources\Audio\He\time\theHandsOfTheClock.wav", @"Resources\Audio\He\Num\"+n+".wav" };
                PlayList(_hourPlay);
            }
            else
            {
                VisibilityNeedle = "Visible";
                NotifyPropertyChanged(nameof(Hour));
            }
            base.SwitchAnswerButton();
          NotifyPropertyChanged(nameof(VisibilityNeedle));
        }
    }
}
