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
        EnSyllableEngen logic = new EnSyllableEngen();
        string IManager.ManagerName =>"EnSyllableManager";
        string Syllable = string.Empty;
        void IEnSyllableManager.SetSyllable(string syllable)
        {
           Syllable=syllable;
        }

        string IEnSyllableManager.GetSyllable()
        {
            return Syllable;
        }

        string IEnSyllableManager.GetWord(object obj)
        {            
          return  logic.GetWord( Syllable, obj);
        }
    }
}
