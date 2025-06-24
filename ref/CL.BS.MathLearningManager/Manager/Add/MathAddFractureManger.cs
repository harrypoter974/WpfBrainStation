using CL.BS.Contract;
using CL.BS.MathLearningManager.Interface.Add;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningManager.Manager.Add
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IManager))]
    #endregion MEF
    public class  MathAddFractureManger: IManager,IMathAddFractureManger
    {
        string IManager.ManagerName => "MathAddFractureManger";
    }
}
