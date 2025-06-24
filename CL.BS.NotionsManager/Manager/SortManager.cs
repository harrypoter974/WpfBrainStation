using CL.BS.Contract;
using CL.BS.NotionsManager.Engine;
using CL.BS.NotionsManager.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.NotionsManager.Manager
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IManager))]
    #endregion MEF
    public class SortManager : ISortManager, IManager
    {

        SortEngine _logic = new SortEngine();
        string IManager.ManagerName => "SortManager";

        bool ISortManager.ChackAnswer(object obj, out int[] location, out string pic)
        {
           return _logic.ChackAnswer( obj, out  location, out  pic);
        }

        bool ISortManager.EndGame()
        {
            return _logic.EndGame();
        }

        int ISortManager.GetDimension()
        {
           return _logic.GetDimension();
        }

        int[] ISortManager.GetLocation(object obj)
        {
            return _logic.GetLocation(obj);
        }

        string[,] ISortManager.GetNewGame()
        {

            return _logic.GetNewGame();
        }

        string ISortManager.GetQuestion()
        {
            return _logic.GetQuestion();
        }

        bool[] ISortManager.GetWiners(int point1, int point2, int point3, int point4)
        {
            return _logic.GetWiners( point1,  point2,  point3,  point4);
        }

        void ISortManager.SetDimension(int d)
        {
           _logic.SetDimension(d);
        }
    }
}
