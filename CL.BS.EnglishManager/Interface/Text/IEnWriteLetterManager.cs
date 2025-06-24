using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.BS.Model;
using CL.BS.VMCommon;

namespace CL.BS.EnglishManager.Interface.Text
{
    public interface IEnWriteLetterManager
    {
        void SetLetter(object letter);
        string GetLetter();
        List<ItemObject> WriteName(string tBFirstName);
        bool SetLetter(ref string back, char v, int j, bool isBig);
        int EndLetter();
    }
}
