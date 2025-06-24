using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.BS.Model;
using CL.BS.VMCommon;

namespace CL.BS.HebrewManager.Interface.Writing
{
    public interface IWritingLettersManager
    {
        void SetLetter(object letter);
        string GetLetter();
        string SwitchFontButton();
        string SwitchFontOpenPage();
        void SwitchFont();
        List<LetterObject> WriteName(string tBLastName);
        bool SetLetter(ref string back, char v1, int j);
    }
}
