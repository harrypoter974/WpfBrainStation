using CL.BS.Contract;
using CL.BS.HebrewManager.Engine.Reading;
using CL.BS.HebrewManager.Interface.Reading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.HebrewManager.Manager.Reading
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IManager))]
    #endregion MEF
    public class HeReading2Manager : IManager, IHeReading2Manager
    {
        private HeReading2Engine _logic = new HeReading2Engine();
        private int _index = 1;
        string IManager.ManagerName
        {
            get
            {
                return "HeReading2Manager";
            }
        }

        int IHeReading2Manager.GetPageIndex()
        {
            return _index;
        }

        void IHeReading2Manager.SetPageIndex(object index)
        {
            this._index =int.Parse(index.ToString());
        }

        int IHeReading2Manager.GetPape()
        {////( logic.GetPageIndex()-2)* (Words.Length / 2) + Ran.Next(Words.Length/2);
            return _logic.GetPape(_index);
        }
    }
}
