using CL.BS.Contract;
using CL.BS.HebrewManager.Engine.Recognition;
using CL.BS.HebrewManager.Interface.Recognition;
using CL.BS.Model;
using CL.BS.VMCommon;
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
    public class RecognaseLeters3Manager : IManager, IRecognaseLeters3Manager
    {
        string IManager.ManagerName => "RecognaseLeters3Manager";
        private RecognaseLeters3Engine _logic = new RecognaseLeters3Engine();

        List<LetterObject> IRecognaseLeters3Manager.GetAnswer(ref string letter)
        {
            return _logic.GetAnswer(ref  letter);
        }

        List<LetterObject> IRecognaseLeters3Manager.SetQuestion()
        {
            return _logic.SetQuestion();
        }

        string[] IRecognaseLeters3Manager.GetInstructions()
        {
          return    _logic.GetInstructions();
        }

        string IRecognaseLeters3Manager.SetDomain(object obj)
        {
           return _logic.SetDomain( obj);
        }
    }
}
