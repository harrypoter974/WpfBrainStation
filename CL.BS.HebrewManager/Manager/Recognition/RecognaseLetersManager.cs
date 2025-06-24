using CL.BS.Contract;
using CL.BS.HebrewManager.Engine.Recognition;
using CL.BS.HebrewManager.Interface.Recognition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.HebrewManager.Manager.Recognition
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IManager))]
    #endregion MEF
    public class RecognaseLetersManager : IManager, IRecognaseLetersManager
    {
        string IManager.ManagerName => "RecognaseLetersManager";
        private RecognaseLetersEngine _logic = new RecognaseLetersEngine();

        string IRecognaseLetersManager.GetLetter()
        {
            return _logic.GetLetter();
        }

        string[] IRecognaseLetersManager.SetQuestion(bool isLevel1)
        {
            return _logic.SetQuestion(isLevel1);
        }

        string[] IRecognaseLetersManager.PlayMessage()
        {
          return  _logic.PlayMessage() ;
        }

        void IRecognaseLetersManager.ClearList()
        {
        }

        void IRecognaseLetersManager.SetLetter()
        {
            _logic.SetLetter();
        }
    }
}
