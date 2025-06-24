using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.EnglishManager.Interface.Recognition
{
    public interface IEnLetterRecognitionManager
    {
        string[] SetQuestion();
        string GetLetter();
        void ClearList();
    }
}
