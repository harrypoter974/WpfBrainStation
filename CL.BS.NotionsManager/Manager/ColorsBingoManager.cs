using CL.BS.Contract;
using CL.BS.Model;
using CL.BS.NotionsManager.Engine;
using CL.BS.NotionsManager.Interface;
using CL.BS.VMCommon;
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
    public class ColorsBingoManager : IColorsBingoManager, IManager
    {
        ColorsBingoEngine _logic = new ColorsBingoEngine();
        string IManager.ManagerName => "ColorsBingoManager";

        void IBingoManager.DoChangeMode(bool b)
        {
           
        }

        bool IBingoManager.EndGame()
        {
            return _logic.EndGame();
        }

        string IColorsBingoManager.GetAnswer()
        {
            return _logic.GetAnswer();
        }

        string IColorsBingoManager.GetQuestion()
        {
           return _logic.GetQuestion();
        }

        List<GameObject>[] IBingoManager.NewGame()
        {
            return _logic.GetMathQuestion();
        }
    }
}
