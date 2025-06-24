using CL.BS.Common;
using CL.BS.Contract;
using CL.BS.MathLearningManager.Interface.Exercise;
using CL.BS.MathLearningVM.VM.Exercise;
using CL.BS.MEF;
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
    public class MathMaltipolComplex2VM : MathComplexVM, IPageVM
    {
        public override string Name => nameof(MathMaltipolComplex2VM);
        public MathMaltipolComplex2VM()
        {
            _logic = (IMathComplexManager)
           SupportHandlerManager.Base.GetManager("MathMoltipolComplexManager");
            for (int i = 0; i < Boards.Length; i++)
                Boards[i] = new BoardExercise2VM(_logic);
            Return = new RelayCommand(DoReturn);
            ImageMenuVisibility = System.Windows.Visibility.Visible.ToString();
            NotifyPropertyChanged("ImageMenuVisibility");
        }
        void IPageVM.load()
        {
            base.Settings();
            for (int i = 0; i < Boards.Length; i++)
                Boards[i].SetLimitTo1();
            _logic.SetLevel(1);
            TBTitle = string.Format(@"{0}Resources\Math\Exercise\MaltipolComplex.jpg",
     System.AppDomain.CurrentDomain.BaseDirectory);
            NotifyPropertyChanged("TBTitle");
        }



        private void DoReturn(object level)
        {
            if (base.CanExit)
                DoGoToPage("MenuMoltipolVM");
        }
    }
}
