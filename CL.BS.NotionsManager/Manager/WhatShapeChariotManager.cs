using CL.BS.Contract;
using CL.BS.Model;
using CL.BS.NotionsManager.Engine;
using CL.BS.NotionsManager.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.NotionsManager.Manager
{

    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IManager))]
    #endregion MEF
    public class WhatShapeChariotManager : IWhatShapeChariotManager, IManager
    {
        public string ManagerName =>nameof(WhatShapeChariotManager);
        WhatShapeChariotEngine _logic = new WhatShapeChariotEngine();
        List<GameObject>[] IWhatShapeChariotManager.GetQuestion()
        {
           return _logic.GetQuestion();
        }
    }
}
