using CL.BS.Contract;
using CL.BS.MathLearningManager.Interface.Exercise;
using CL.BS.MathLearningVM.VM.Exercise;
using CL.BS.MEF;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningVM.Add
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class MathAddComplexVM : MathComplexVM, IPageVM
    {
        public override string Name => nameof(MathAddComplexVM);
        public MathAddComplexVM()
        {            
            _logic = (IMathComplexManager)
SupportHandlerManager.Base.GetManager("MathAddComplexManager");
            for (int i = 0; i < Boards.Length; i++)
                Boards[i] = new BoardExercise1VM(_logic);
            Return = new RelayCommand(DoReturn);
            ImageMenuVisibility = System.Windows.Visibility.Hidden.ToString();
            NotifyPropertyChanged(nameof(ImageMenuVisibility));

        }

        void IPageVM.load()
        {
            base.Settings();
            for (int i = 0; i < Boards.Length; i++)
                Boards[i].SetLimitTo1();
            _logic.SetLevel(0);
            TBTitle = string.Format(@"{0}Resources\Math\Exercise\Add.jpg",
     System.AppDomain.CurrentDomain.BaseDirectory);
            NotifyPropertyChanged("TBTitle");
        }

        private void DoReturn(object level)
        {
            if(base.CanExit)
                DoGoToPage("MenuAddVM"); 
        }
    }
}
