using CL.BS.Contract;
using CL.BS.MathLearningManager.Interface.Add;
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
    public class MathAddFracture2VM : MathComplexVM, IPageVM
    {
        public override string Name => nameof(MathAddFracture2VM);
        public MathAddFracture2VM()
        {
            //            _logic = (IMathAddFractureManger)
            //SupportHandlerManager.Base.GetManager("MathAddFractureManger");
            for (int i = 0; i < Boards.Length; i++) {
                Boards[i] = new BoardExerciseFractureVM(_logic);
               ((BoardExerciseFractureVM)Boards[i]).SetOperator("+");
            }
            Return = new RelayCommand(DoReturn);
            TBTitle = System.AppDomain.CurrentDomain.BaseDirectory
                       + @"Resources\Math\Exercise\AddFracture.jpg";
            NotifyPropertyChanged(nameof(TBTitle));
            ImageMenuVisibility = System.Windows.Visibility.Hidden.ToString();
            NotifyPropertyChanged(nameof(ImageMenuVisibility));
        }

        private void DoReturn(object level)
        {
            if (base.CanExit)
            {
                if(level.ToString() == "l")
                    DoGoToPage("MathAddFractureVM");
                else
                    DoGoToPage("MenuAddVM");
            }
        }
    }
}
