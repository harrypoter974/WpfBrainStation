using CL.BS.Contract;
using CL.BS.MathLearningManager.Interface.Comper;
using CL.BS.MEF;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CL.BS.MathLearningVM.Comper
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class BaseMathComperVM : BaseLernPage, IPageVM
    {
        public string TextResult { get; set; }


        private int _goNext = 0;
        protected IMathComperManager _logic = (IMathComperManager)
 SupportHandlerManager.Base.GetManager("MathComperManager");
        private Random _ran = new Random(DateTime.Now.Millisecond);
        public override string Name => "";

        public virtual void AskQuestion(){}//do nafing

        protected void QuestionPlay()
        {
            new Thread(new ThreadStart(() =>
            {
                PlayList(new string[] { Common.StaticVar.inline.PlayName(),
Common.StaticVar.inline.IsBoy?@"Resources\Audio\He\General\putItDown.wav":@"Resources\Audio\He\General\put_it_down.wav",
@"Resources\Audio\He\General\card.wav",@"Resources\Audio\He\General\big.wav" ,
@"Resources\Audio\He\General\Equal.wav" ,@"Resources\Audio\He\General\or.wav",
@"Resources\Audio\He\General\small.wav"   });
            })).Start();
        }

        public BaseMathComperVM()
        {
            AnswerBut = new RelayCommand(DoAnswerBut);
        }

        private void DoAnswerBut(object obj)
        {
            AskQuestion();
        }

        protected bool GoNext()
        {
            if (_goNext == 2)
            {
                _goNext = 0;
                DoGoToPage("MathComperVM2");// + Common.StaticVar.ComperGameIndex
                Common.StaticVar.ComperGameIndex = Common.StaticVar.ComperGameIndex == 3 ? 1 : Common.StaticVar.ComperGameIndex + 1;
                return true;
            }
            else
            {
                _goNext++;
                return false;
            }
        }

        internal void ComperLoad()
        {
            base.Settings();
            TextResult = string.Empty;
            NotifyPropertyChanged("TextResult");
            if (!base.IsQuestionMode)
                base.SwitchAnswerButton();
            if (!Common.StaticVar.inline.IsBoy)
            {
                messagePic = System.AppDomain.CurrentDomain.BaseDirectory
                  + @"Resources\Math\Comper\message.png";
                NotifyPropertyChanged("messagePic");
            }
        }
    }
}
