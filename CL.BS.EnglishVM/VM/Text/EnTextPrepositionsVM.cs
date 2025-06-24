using CL.BS.Contract;
using CL.BS.EnglishManager.Interface.Text;
using CL.BS.EnglishVM.VM.Text;
using CL.BS.MEF;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CL.BS.EnglishVM.Text
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
  public  class EnTextPrepositionsVM : BaseTextVM,  IPageVM
    {
        public override string Name
        {
            get
            {
                return nameof(EnTextPrepositionsVM);
            }
        }
        private IEnTextPrepositionsManager _logic = (IEnTextPrepositionsManager)
SupportHandlerManager.Base.GetManager("EnTextPrepositionsManager");

        public EnTextPrepositionsVM()
        {
            AnswerBut = new RelayCommand(DoAnswerBut);
            ChangeWord = new RelayCommand(DoChangeWord);
            SetLevel = new RelayCommand(DoSetLevel);
        }

        private void DoSetLevel(object level)
        {
            _logic.SetLevel(level);
            base.SetLevelBack(level);
        }

        private void DoChangeWord(object obj)
        {
            if (Common.StaticVar.PlayMode||!base.IsQuestionMode)
                return;
            _logic.SetIndex(obj);
            PicBackground = System.AppDomain.CurrentDomain.BaseDirectory +
             @"Resources\Lang\En\Prepositions\writing" + obj + ".jpg";
            NotifyPropertyChanged(nameof(PicBackground));
        }

        private void DoAnswerBut(object obj)
        {
            if (Common.StaticVar.PlayMode)
                return;
            if (base.IsQuestionMode)
            {
                new Thread(new ThreadStart(() =>
                {
                    UrlPlay = _logic.GetText(ref base.LineList, true);
                    base.SetText();
                    Thread.Sleep((int)(1000.0 * (2.1 - Speed)));
                    _logic.GetText(ref base.LineList, false);
                    base.SetText();
                })).Start();
            }
            else
            {
                _logic.GetText(ref base.LineList, true);
                base.SetText();
            }
            base.SwitchAnswerButton();
        }
    }
}
