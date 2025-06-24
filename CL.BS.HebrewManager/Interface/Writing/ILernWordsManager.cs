using CL.BS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.HebrewManager.Interface.Writing
{
    public interface ILernWordsManager
    {
        string SetGroup(object obj);
        string GetBackground();
        void SetWord(object obj);
        string getWordPlay(bool isHe=true);
        string getWord();
        List<Model.ItemObject> GeTAllWords();
        void SetAllWords(List<ItemObject> itemObjects);
    }
}
