using CL.BS.Contract;
using CL.BS.Model;
using CL.BS.ShapesManager.Engine;
using CL.BS.ShapesManager.Interface;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.ShapesManager.Manager
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IManager))]
    #endregion MEF
    public class ShapesGameManager : IManager, IShapesGameManager
    {
        private ShapeGameEngine _logic = new ShapeGameEngine();
        string IManager.ManagerName => "ShapesGameManager";

        void IBingoManager.DoChangeMode(bool b)
        {
           _logic.SwichMode(b);
        }

        bool IBingoManager.EndGame()
        {
            return _logic.EndGame();
        }

        bool IMemoryManager.EndGame(bool ToFill)
        {
            return _logic.EndGame();
        }

        string[][] IShapesGameManager.GetAnswer()
        {
            return _logic.GetAnswer();
        }

        string[][] IShapesGameManager.GetMemoryQuestion()
        {
            return _logic.GetManagerQuestion();
        }

        List<GameObject>[] IMemoryManager.GetNewGame(int num)
        {
            return _logic.NewGame(num); 
        }

        

        string IMemoryManager.GetQuestion()
        {
            return _logic.GetQuestion();
        }


        List<GameObject>[] IBingoManager.NewGame()
        {
            return _logic.NewGame();
        }
    }
}
