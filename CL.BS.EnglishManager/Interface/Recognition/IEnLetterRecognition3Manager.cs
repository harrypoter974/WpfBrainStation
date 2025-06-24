using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.EnglishManager.Interface.Recognition
{
    public interface IEnLetterRecognition3Manager
    {
        List<LetterObject> SetQuestion();
        List<LetterObject> GetAnswer(ref string letter);
        string SetDomain(object obj);
    }
}
