using CL.BS.Contract;
using CL.BS.HebrewManager.Engine.Recognition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.HebrewManager.Interface.Recognition
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IManager))]
    #endregion MEF
    public class KnowLetterManager : IManager,IKnowLetterManager
    {
        string IManager.ManagerName => "KnowLetterManager";
           string _letter = "alef";
        private KnowLetterEngine _logic = new KnowLetterEngine();

        string IKnowLetterManager.GetLetter()
        {
           return _letter;
        }

        string IKnowLetterManager.SetLetter(object index)
        {

            _letter = index.ToString().Replace("Final",string.Empty);
            return _logic.GetWord(_letter,0);
        }

        string IKnowLetterManager.PlayWrod(object obj)
        {
            return _logic.GetWord(_letter, int.Parse(obj.ToString()));
        }
    }
}
