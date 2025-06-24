using CL.BS.Contract;
using CL.BS.MEF;
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
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class ClockExerciseDigitalVM : BaseStepVM, IPageVM
    {
        public ClockExerciseDigitalVM()
        {
            IsMinuteBut = System.AppDomain.CurrentDomain.BaseDirectory
                  + @"Resources\BS.Items\IsMinuteBut.jpg";
            NotifyPropertyChanged("IsMinuteBut");
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
            IsMinute =!IsMinute;
            NotifyPropertyChanged("IsMinuteBut");
        }
        private void DoAnswerBut(object obj)
        {
            if (base.IsQuestionMode)
            {
                string q;
                PlayList(logic.GetQuestion(IsMinute,out q));
                TClock = q;
                TextMinute1 =string.Empty;
                TextMinute2=string.Empty;
                TextHour2  =string.Empty;
                TextHour1 = string.Empty;
                NotifyPropertyChanged("TClock");
            }
            else
            {
                string[] answer = logic.GetAnswer();
                TextHour2 =  answer[0];
                TextHour1 = answer [1];
                TextMinute2 =answer[2];
                TextMinute1 =answer[3];
            }
            base.SwitchAnswerButton();
            NotifyPropertyChanged("TextMinute1");
            NotifyPropertyChanged("TextMinute2");
            NotifyPropertyChanged("TextHour1");
            NotifyPropertyChanged("TextHour2");
        }
   private bool IsMinute = false;
        public ICommand ChangeLevel { get; set; }
        public ICommand AnswerBut { get; set; }
        public string TClock { get; set; }
        public string TextMinute1 { get; set; }
        public string TextMinute2 { get; set; }
        public string TextHour2   { get; set; }
        public string TextHour1   { get; set; }
        public string IsMinuteBut { get; set; }
        IClockManager logic = (IClockManager)
    SupportHandlerManager.Base.GetManager("ClockManager");
        public override string Name
        {
            get
            {
                return "ClockExerciseDigitalVM";
            }
        }
    }
}
