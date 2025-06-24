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
    public class HeReadingExTo4Manager : IManager, IHeReadingExTo4Manager
    {
        string IManager.ManagerName => "HeReadingExTo4Manager";
        private HeReadingEngine _logic = new HeReadingEngine();
        string[] IHeReadingExTo4Manager.GetAnswer()
        {
          return   _logic.GetAnswer();
        }

        string[] IHeReadingExTo4Manager.GetQuestion(int index)
        {
            return _logic.GetQuestion(index);
        }
    }
}
