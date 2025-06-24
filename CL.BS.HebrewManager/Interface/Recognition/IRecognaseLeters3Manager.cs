using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.HebrewManager.Interface.Recognition
{
    public interface IRecognaseLeters3Manager
    {
        List<LetterObject> GetAnswer(ref string letter);
        List<LetterObject> SetQuestion();
        string[] GetInstructions();
        string SetDomain(object obj);
    }
}
