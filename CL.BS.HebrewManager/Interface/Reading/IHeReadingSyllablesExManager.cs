using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.HebrewManager.Interface.Recognition
{
    public interface IHeReadingSyllablesExManager
    {
        string[] GetQuestion();        
   string[] GetQuestion3(int grope);
        string[]  GetQuestion(bool isEx0); 
        string[] GetAnswer(int v);
        string GetAnswer();
        string[] GetOpenSentens();
        void SetSeriesIndex(object obj);
        int GetSeriesIndex();
        string[] GetOpenSentens3();
    }
}
