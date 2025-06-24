using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.HebrewManager.Interface.Recognition
{
    public interface IRecognaseLetersManager
    {
        string[] SetQuestion(bool isLevel1);
        string GetLetter();
        string[] PlayMessage();
        void ClearList();
        void SetLetter();
    }
}
