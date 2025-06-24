using BS.Items;
using CL.BS.Contract;
using CL.BS.MathLearningManager.Interface.Exercise;
using CL.BS.MEF;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CL.BS.MathLearningVM.VM.Exercise
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class MathExercise2VM : MathComplexVM, IPageVM
    {
        public override string Name => "MathExercise2VM";        
        public MathExercise2VM()
        {
            _logic = (IMathComplexManager)
   SupportHandlerManager.Base.GetManager("MathExercise2Manager");
            for (int i = 0; i < Boards.Length; i++)
                Boards[i] = new BoardExercise2VM(_logic);

            TBTitle = System.AppDomain.CurrentDomain.BaseDirectory
                       + @"Resources\Math\Exercise\SummaryExercise.jpg";
            NotifyPropertyChanged(nameof(TBTitle));
            Return = new RelayCommand(DoReturn);
        }

        void IPageVM.load()
        {
            base.Settings();
            for (int i = 0; i < Boards.Length; i++)
                Boards[i].SetLimitTo1();
            _logic.SetLevel(0);
        }
        private void DoReturn(object level)
        {
            if (base.CanExit)
                DoGoToPage("MenuMathSummaryVM");
        }
    }
}
