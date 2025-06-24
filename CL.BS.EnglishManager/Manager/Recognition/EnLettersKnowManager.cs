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
    public class EnLettersKnowManager : IEnLettersKnowManager, IManager
    {
        private EnLettersKnowEngen _logic = new EnLettersKnowEngen();
        string IManager.ManagerName =>"EnLettersKnowManager";
        private string _letter = "A";

        string IEnLettersKnowManager.GetLetter()
        {
           return _letter;
        }

        string IEnLettersKnowManager.GetWord(char index, object i)
        {
           return _logic.GetWord(index, i);
        }

        void IEnLettersKnowManager.SetLetter(object letter)
        {
            this._letter = letter.ToString().ToUpper();
        }
    }
}
