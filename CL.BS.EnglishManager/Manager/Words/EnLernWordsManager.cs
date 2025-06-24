using CL.BS.Contract;
using CL.BS.EnglishManager.Engen.Words;
using CL.BS.EnglishManager.Interface.Words;
using CL.BS.Model;
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
    public class EnLernWordsManager : IEnLernWordsManager, IManager
    {
        string IManager.ManagerName => nameof(EnLernWordsManager);
         private EnLernWordsEngen _logic = new EnLernWordsEngen();
        string IEnLernWordsManager.GetBackground()
        {
          return _logic.GetBackground();
        }

        string IEnLernWordsManager.getWord()
        {
            return _logic.getWord();
        }

        string IEnLernWordsManager.getWordPlay(bool isHe)
        {
           return _logic.getWordPlay(isHe);
        }

        void IEnLernWordsManager.SetWord(object obj)
        {
           _logic.SetWord(obj);
        }

        List<ItemObject> IEnLernWordsManager.GetAllWords()
        {
           return _logic.GeTAllWords();
        }

        void IEnLernWordsManager.SetAllWords(List<ItemObject> itemObjects)
        {
             _logic.SetAllWords(itemObjects);
        }

        List<ItemObject> IEnLernWordsManager.GeTAllWords()
        {
            return _logic.GeTAllWords();
        }
    }
}
