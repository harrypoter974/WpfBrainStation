using CL.BS.Contract;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using UserInformationManager.Engine;
using UserInformationManager.Interface;

namespace UserInformationManager.Manager
{
    #region MEF
    [Export(typeof(IManager))]
    #endregion MEF
    public class MenuNameManager:IMenuNameManager,IManager
    {
       private MenuNameEngine _logic = new MenuNameEngine();
        string IManager.ManagerName =>nameof(MenuNameManager) ;

        List<string> IMenuNameManager.GetName(object letter)
        {
            return _logic.GetName(letter);
        }
    }
}
