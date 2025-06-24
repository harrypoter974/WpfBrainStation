using CL.BS.Common;
using CL.BS.Contract;
using CL.BS.MathLearningVM.VM.Exercise;
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
    public class MathSpliteFracture2VM : MathComplexVM, IPageVM
    {
        public override string Name => nameof(MathSpliteFracture2VM);
        public MathSpliteFracture2VM()
        {   //            _logic = (IMathAddFractureManger)
            //SupportHandlerManager.Base.GetManager("MathAddFractureManger");
            for (int i = 0; i < Boards.Length; i++)
            {
                Boards[i] = new BoardExerciseFractureVM(_logic);
                ((BoardExerciseFractureVM)Boards[i]).SetOperator(":");
            }
            Return = new RelayCommand(DoReturn);
            TBTitle = System.AppDomain.CurrentDomain.BaseDirectory
                       + @"Resources\Math\Exercise\SpliteFracture.jpg";
            NotifyPropertyChanged(nameof(TBTitle));
            ImageMenuVisibility = System.Windows.Visibility.Hidden.ToString();
            NotifyPropertyChanged(nameof(ImageMenuVisibility));

        }

        private void DoReturn(object level)
        {
            if (base.CanExit)
            {
                if (level.ToString() == "l")
                    DoGoToPage("MathSpliteFractureVM");
                else
                    DoGoToPage("MenuSpliteVM");
            }
        }
    }
}

