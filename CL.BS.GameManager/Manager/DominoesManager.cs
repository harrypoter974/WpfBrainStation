using CL.BS.Contract;
using CL.BS.GameManager.Interface;
using CL.BS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.GameManager.Manager
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IManager))]
    #endregion MEF
    public class DominoesManager : IDominoesManager, IManager
    {
        public string ManagerName => "DominoesManager";

  
    }
}
