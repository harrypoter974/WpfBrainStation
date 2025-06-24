using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.NotionsManager.Interface
{
    public interface IColorsManager
    {
        string PlayColor(int colorIndex, int language);
        string GetQuestion();
        object[] GetAnswer();
        string[] PlayQuestion(int iw);
        void setGrope(object gropeIndex);
        int GetGrope();
        void ClearList();
    }
}
