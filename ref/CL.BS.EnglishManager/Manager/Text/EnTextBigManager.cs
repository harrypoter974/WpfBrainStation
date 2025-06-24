using CL.BS.Contract;
using CL.BS.EnglishManager.Engen.Text;
using CL.BS.EnglishManager.Interface.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.EnglishManager.Manager.Text
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IManager))]
    #endregion MEF
    public class EnTextBigManager : IEnTextBigManager, IManager
    {
        EnTextBigEngen logic = new EnTextBigEngen();
        string IManager.ManagerName =>"EnTextBigManager";
    }
}
