using CL.BS.Contract;
using CL.BS.EnglishManager.Engen.Notions;
using CL.BS.EnglishManager.Interface.Notions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.EnglishManager.Manager.Notions
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IManager))]
    #endregion MEF
    public class EnColorManager : IEnColorManager, IManager
    {
        private string ColorIndex = "0";
        EnColorEngen logic = new EnColorEngen(); 
        string IManager.ManagerName =>"EnColorManager";

        string IEnColorManager.GetColorIndex()
        {
            return ColorIndex;
        }

        string IEnColorManager.GetColorWord(object index)
        {
            return logic.GetColorWord(ColorIndex,index);
        }

        void IEnColorManager.SetColorIndex(object index)
        {
            ColorIndex = index.ToString();
        }
    }
}
