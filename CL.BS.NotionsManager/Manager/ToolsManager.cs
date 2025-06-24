using CL.BS.Contract;
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
    public class ToolsManager : IToolsManager, IManager
    {
        string IManager.ManagerName => "ToolsManager";
        private ToolsEngine _logic = new ToolsEngine();

        string IToolsManager.PlayTool(int item, int language)
        {
            return _logic.PlayTool( item,language);
        }
    }
}
