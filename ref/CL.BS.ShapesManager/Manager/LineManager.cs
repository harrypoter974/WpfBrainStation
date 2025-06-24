using CL.BS.Contract;
using CL.BS.ShapesManager.Engine;
using CL.BS.ShapesManager.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.ShapesManager.Manager
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IManager))]
    #endregion MEF
    public class LineManager : IManager,ILineManager
    {
        private LineEngine logic = new LineEngine();
        string IManager.ManagerName => "LineManager";

        string[] ILineManager.GetPlayList(char v, int lineIndex)
        {
         return   logic.GetPlayList(v,lineIndex);
        }
    }
}
