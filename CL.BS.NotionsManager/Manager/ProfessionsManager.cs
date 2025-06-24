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
    public class ProfessionsManager : IProfessionsManager, IManager
    {
        string IManager.ManagerName => "ProfessionsManager";
        ProfessionsEngine _logic = new ProfessionsEngine();
        string IProfessionsManager.PlayProfession(int shape, int language)
        {
           return _logic.PlayProfession( shape, language);
        }
    }
}
