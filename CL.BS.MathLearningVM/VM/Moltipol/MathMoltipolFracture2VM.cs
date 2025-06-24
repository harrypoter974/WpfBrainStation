using CL.BS.Common;
using CL.BS.Contract;
using CL.BS.MathLearningVM.VM.Exercise;
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
    public class MathMoltipolFracture2VM : MathComplexVM, IPageVM
    {
        public override string Name => nameof(MathMoltipolFracture2VM);
        public MathMoltipolFracture2VM()
        {
            for (int i = 0; i < Boards.Length; i++)
            {
                Boards[i] = new BoardExerciseFractureVM(_logic);
                ((BoardExerciseFractureVM)Boards[i]).SetOperator("x");
            }
            Return = new RelayCommand(DoReturn);
            TBTitle = System.AppDomain.CurrentDomain.BaseDirectory
                       + @"Resources\Math\Exercise\MoltipolFracture.jpg";
            NotifyPropertyChanged(nameof(TBTitle));
            ImageMenuVisibility = System.Windows.Visibility.Hidden.ToString();
            NotifyPropertyChanged(nameof(ImageMenuVisibility));

        }

        private void DoReturn(object level)
        {
            if (base.CanExit)
            {
                if (level.ToString() == "l")
                    DoGoToPage("MathMoltipolFractureVM");
                else
                    DoGoToPage("MenuMoltipolVM");
            }
        }
    }
}
