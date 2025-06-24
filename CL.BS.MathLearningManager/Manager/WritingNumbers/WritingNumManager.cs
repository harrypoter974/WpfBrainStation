using CL.BS.Contract;
using CL.BS.MathLearningManager.Interface.WritingNumbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningManager.Manager.WritingNumbers
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IManager))]
    #endregion MEF
    public class WritingNumManager : IManager,IWritingNumManager
    {
        string IManager.ManagerName => "WritingNumManager";
        private string _pageIndex = "0";

        void IWritingNumManager.SetNum(object obj)
        {
            _pageIndex=obj.ToString();
        }

        string IWritingNumManager.GetNum()
        {
            return _pageIndex;
        }
    }
}
