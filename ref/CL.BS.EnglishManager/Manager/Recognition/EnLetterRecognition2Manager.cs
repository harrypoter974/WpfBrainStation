using CL.BS.Contract;
using CL.BS.EnglishManager.Engen.Recognition;
using CL.BS.EnglishManager.Interface.Recognition;
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
    public class EnLetterRecognition2Manager : IEnLetterRecognition2Manager, IManager
    {
        EnLetterRecognition2Engen logic = new EnLetterRecognition2Engen();
        string IManager.ManagerName => "EnLetterRecognition2Manager";
    }
}
