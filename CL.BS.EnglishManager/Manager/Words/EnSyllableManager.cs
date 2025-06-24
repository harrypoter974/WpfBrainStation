using CL.BS.Contract;
using CL.BS.EnglishManager.Engen.Words;
using CL.BS.EnglishManager.Interface.Words;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.EnglishManager.Manager.Words
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IManager))]
    #endregion MEF
    public class EnSyllableManager : IEnSyllableManager, IManager
    {
        private EnSyllableEngen _logic = new EnSyllableEngen();
        private string _syllable = string.Empty;
        string IManager.ManagerName =>"EnSyllableManager";

        void IEnSyllableManager.SetSyllable(string syllable)
        {
           _syllable=syllable;
        }

        string IEnSyllableManager.GetSyllable()
        {
            return _syllable;
        }

        string IEnSyllableManager.GetWord(object obj)
        {            
          return  _logic.GetWord( _syllable, obj);
        }
    }
}
