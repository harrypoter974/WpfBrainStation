using CL.BS.Contract;
using CL.BS.MathLearningManager.Interface.Moltipol;
using CL.BS.MEF;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningVM.VM.Moltipol
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class PowerVM : VMCommon.BaseLernPage, IPageVM
    {
        public string INumAnswer { get; set; }
        public string NumText { get; set; }
        public string ResultNum1 { get; set; }
        public string ResultNum0 { get; set; }
        public override string Name => "PowerVM";
        private IPowerManager _logic = (IPowerManager)
SupportHandlerManager.Base.GetManager("PowerManager");

        public PowerVM()
        {
            AnswerBut = new RelayCommand(DoAnswerBut);
        }

        private void DoAnswerBut(object obj)
        {
            if (Common.StaticVar.PlayMode)
                return;
            if (base.IsQuestionMode)
            {
                string s = "";
                PlayList(_logic.GetQuestion(ref s));
                NumText = s;
                string[] r = _logic.GetAnswer();
                if (r[1] == string.Empty)
                {
                    INumAnswer = string.Empty;
                }
                else
                {
                    INumAnswer = System.AppDomain.CurrentDomain.BaseDirectory +
                    @"Resources\BS.Items\Num2.png";
                }
                NotifyPropertyChanged("INumAnswer");
                NotifyPropertyChanged("NumText");
                ResultNum1 = ResultNum0 = string.Empty;
            }
            else
            {
                string[] s = _logic.GetAnswer();
                ResultNum1 = s[0];
                ResultNum0 = s[1];
            }
            NotifyPropertyChanged("ResultNum1");
            NotifyPropertyChanged("ResultNum0");
            base.SwitchAnswerButton();
        }
    }
}
