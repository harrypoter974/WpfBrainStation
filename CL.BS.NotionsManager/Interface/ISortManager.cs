using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.NotionsManager.Interface
{
    public interface ISortManager
    {
        void SetDimension(int d);
        int GetDimension();
        string[,] GetNewGame();
        string GetQuestion();
        bool EndGame();
        bool ChackAnswer(object obj, out int[] location, out string pic);
        bool[] GetWiners(int point1, int point2, int point3, int point4);
        int[] GetLocation(object obj);
    }
}
