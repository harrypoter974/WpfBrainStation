using CL.BS.Contract;
using CL.BS.HebrewManager.Engine.Writing;
using CL.BS.HebrewManager.Interface.Writing;
using CL.BS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.HebrewManager.Manager.Writing
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IManager))]
    #endregion MEF
    public class LernWordsManager : IManager, ILernWordsManager
    {
        string IManager.ManagerName => "LernWordsManager";
        private LernWordsEngine _logic = new LernWordsEngine();
        string ILernWordsManager.SetGroup(object obj)
        {
          return  _logic.SetGroup(obj);
        }

        string ILernWordsManager.GetBackground()
        {
         return _logic.GetBackground();
        }

        void ILernWordsManager.SetWord(object obj)
        {
            _logic.SetWord(obj);
        }

        string ILernWordsManager.getWord()
        {
            return _logic.getWord();
        }

        string ILernWordsManager.getWordPlay(bool isHe = true)
        {
            return _logic.getWordPlay(isHe);
        }

        List<ItemObject> ILernWordsManager.GeTAllWords()
        {
            return _logic.GeTAllWords();
        }

        void ILernWordsManager.SetAllWords(List<ItemObject> itemObjects)
        {
            _logic.SetAllWords(itemObjects);
        }
    }
}
