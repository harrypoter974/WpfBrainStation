using CL.BS.Contract;
using CL.BS.MEF;
using CL.BS.NotionsManager.Interface;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CL.BS.NotionsVM.VM.Clock
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class ClockExerciseCompassesVM : BaseStepVM, IPageVM
    {
        public ClockExerciseCompassesVM()
        {
            TClock = string.Empty;
               IsMinuteBut = System.AppDomain.CurrentDomain.BaseDirectory
                  + @"Resources\BS.Items\IsMinuteBut.jpg";
            VisibilityNeedle = Visibility.Hidden.ToString();
            NotifyPropertyChanged("IsMinuteBut");
            NotifyPropertyChanged("VisibilityNeedle");
            AnswerBut = new RelayCommand(DoAnswerBut);
            ChangeLevel = new RelayCommand(DoChangeLevel);
        }
        private void DoChangeLevel(object obj)
        {
            if (IsMinute )
            {
                IsMinuteBut = System.AppDomain.CurrentDomain.BaseDirectory
               + @"Resources\BS.Items\IsMinuteBut.jpg";
            }
            else
            {
                IsMinuteBut = string.Empty;
            }
            IsMinute = !IsMinute;
            NotifyPropertyChanged("IsMinuteBut");
        }
        private void DoAnswerBut(object obj)
        {
            if (base.IsQuestionMode)
            {
                string tClock;
                VisibilityNeedle = Visibility.Hidden.ToString();
                PlayList(logic.GetQuestion(IsMinute, out tClock));
                TClock = tClock;
                NotifyPropertyChanged("TClock");
            }
            else
            {
                VisibilityNeedle = Visibility.Visible.ToString();
                int[] answer = logic.getAnswer();
                Hour = answer[0]; 
                Minute = answer[1];
                NotifyPropertyChanged("Hour");
                NotifyPropertyChanged("Minute");
            }
            base.SwitchAnswerButton();
            NotifyPropertyChanged("VisibilityNeedle");
        }
        IClockManager logic = (IClockManager)
 SupportHandlerManager.Base.GetManager("ClockManager");
        public override string Name
        {
            get
            {
                return "ClockExerciseCompassesVM";
            }
        }
        private  bool IsMinute = false;
        public ICommand ChangeLevel { get; set; }
        public ICommand AnswerBut { get; set; }
        public string VisibilityNeedle { get; set; }

        public int Hour { get; set; }
        public int Minute { get; set; }
        public string IsMinuteBut { get; set; }
        public string TClock { get; set; }
    }
}
