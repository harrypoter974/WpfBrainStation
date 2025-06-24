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
    public class AngleManager : IManager,IAngleManager
    {
        string IManager.ManagerName => "AngleManager";
        private AngleEngine _logic = new AngleEngine();
     

        string[] IAngleManager.GetPlayList(char v, int angleIndex)
        {
           return _logic.GetPlayList(v,angleIndex);
        }
    }
}
