using CL.BS.Contract;
using CL.BS.EnglishManager.Engen.Recognition;
using CL.BS.EnglishManager.Interface.Recognition;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.EnglishManager.Manager.Recognition
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IManager))]
    #endregion MEF
    public class EnLetterRecognition3Manager : IEnLetterRecognition3Manager, IManager
    {
        string IManager.ManagerName =>"EnLetterRecognition3Manager";
        private EnLetterRecognition3Engen _logic = new EnLetterRecognition3Engen();

        List<LetterObject> IEnLetterRecognition3Manager.SetQuestion()
        {
           return _logic.SetQuestion();
        }

        List<LetterObject> IEnLetterRecognition3Manager.GetAnswer(ref string letter)
        {
            return _logic.GetAnswer(ref  letter);
        }

        string IEnLetterRecognition3Manager.SetDomain(object obj)
        {
            return _logic.SetDomain(obj);
        }
    }
}
