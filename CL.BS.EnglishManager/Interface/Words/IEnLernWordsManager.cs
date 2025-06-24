using CL.BS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.EnglishManager.Interface.Words
{
    public interface IEnLernWordsManager
    {
        string GetBackground();
        void SetWord(object obj);
        string getWordPlay(bool isHe = true);
        string getWord();
        List<ItemObject> GetAllWords();
        void SetAllWords(List<ItemObject> itemObjects);
        List<ItemObject> GeTAllWords();
    }
}
