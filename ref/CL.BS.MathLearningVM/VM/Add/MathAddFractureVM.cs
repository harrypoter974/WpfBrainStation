using CL.BS.Contract;
using CL.BS.MathLearningManager.Interface.Add;
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
  public  class MathAddFractureVM : BaseStepVM,  IPageVM
    {
        IMathAddFractureManger logic =(IMathAddFractureManger)
          SupportHandlerManager.Base.GetManager("IMathAddFractureManger");
        public MathAddFractureVM()
        {
            AnswerBut = new RelayCommand(DoAnswerBut);
        }

        private void DoAnswerBut(object obj)
        {
            base.SwitchAnswerButton();
        }
        public override string Name
        {
            get
            {
                return "MathAddFractureVM";
            }
        }
    }
}
