using CL.BS.Contract;
using CL.BS.MathLearningManager.Interface.Splite;
using CL.BS.MEF;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningVM.Splite
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class RootVM : BaseLernPage, IPageVM
    {
        public string NumText { get; set; }
        public string ResultNum { get; set; }
        public override string Name => "RootVM";
        private IRootManager _logic = (IRootManager)
SupportHandlerManager.Base.GetManager("RootManager");

        public RootVM()
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
                NotifyPropertyChanged("NumText");
                ResultNum = string.Empty;
            }
            else
            {
                ResultNum = _logic.GetAnswer();
            }
            NotifyPropertyChanged("ResultNum");
            base.SwitchAnswerButton();
        }
    }
}
