using CL.BS.Contract;
using CL.BS.MathLearningManager.Interface.Recognaz;
using CL.BS.MEF;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.MathLearningVM.Recognaz
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class MathExRecognaz1VM : VMCommon.BaseLernPage, IPageVM
    {
        private IMathExRecognaz1Manager _logic = (IMathExRecognaz1Manager)
SupportHandlerManager.Base.GetManager("MathExRecognaz1Manager");
        public string TAnswer { get; set; }
        public string BackgroundPic { get; set; }
        public override string Name => "MathExRecognaz1VM";

        void IPageVM.load()
        {
            base.Settings();
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
              @"Resources\Math\Recognaz\Recognaz0.jpg";
            NotifyPropertyChanged("BackgroundPic");
            TAnswer = string.Empty;
            NotifyPropertyChanged("TAnswer");
        }

        public MathExRecognaz1VM()
        {
            AnswerBut =new  RelayCommand(DoAnswerBut);
        }

        private void DoAnswerBut(object obj)
        {
            if (base.IsQuestionMode)
            {
                string[] q =_logic.SetQuestion();
                BackgroundPic =System.AppDomain.CurrentDomain.BaseDirectory +
               @"Resources\Math\Recognaz\Recognaz" + q[1] + ".jpg";
                new Thread(new ThreadStart(() =>
                { PlayList( new string[] { Common.StaticVar.inline.PlayName(), q[2] }); })).Start();               
                NotifyPropertyChanged("BackgroundPic");
                TAnswer = string.Empty;

                if (!Common.StaticVar.inline.IsBoy)
                {
                    messagePic = q[3];
                }
                else
                    messagePic = string.Empty;
                NotifyPropertyChanged("messagePic");
            }
            else
            {
                TAnswer = _logic.GetAnswer();
            }
            base.SwitchAnswerButton();
          NotifyPropertyChanged("TAnswer");
        }
    }
}
