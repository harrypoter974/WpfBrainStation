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
    public class ColorsManager : IManager,IColorsManager
    {
     private   ColorsEngine Logic = new ColorsEngine();
        string IManager.ManagerName => "ColorsManager";
        private string GropeIndex = "0";
        string IColorsManager.PlayColor(int PageInxex, object colorIndex)
        {
           return Logic.PlayColor(PageInxex,colorIndex);
        }

        void IColorsManager.setGrope(object gropeIndex)
        {
            GropeIndex=gropeIndex.ToString();
        }
    }
}
