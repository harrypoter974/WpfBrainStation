using CL.BS.Contract;
using CL.BS.JudaismManager.Engen;
using CL.BS.JudaismManager.Interface;
using CL.BS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.JudaismManager.Manager
{
    #region MEF
    [Export(typeof(IManager))]
    internal
    #endregion MEF
    class JudaismCongratulationsBingoManager : IJudaismCongratulationsBingoManager, IManager
    {
      private  JudaismCongratulationsBingoEngen _logic = new JudaismCongratulationsBingoEngen();

        public JudaismCongratulationsBingoManager()
        {
        }

        string IManager.ManagerName => "JudaismCongratulationsBingoManager";

        void IBingoManager.DoChangeMode(bool b)
        {
            _logic.DoChangeMode(b);
        }

        bool IBingoManager.EndGame()
        {
            return _logic.EndGame();
        }

        string IJudaismCongratulationsBingoManager.GetAnswer()
        {
            return _logic.GetAnswer();
        }

        GameObject IJudaismCongratulationsBingoManager.GetQuestion()
        {
            return _logic.GetQuestion();
        }

        List<GameObject>[] IBingoManager.NewGame()
        {
            return _logic.NewGame();
        }
    }
}
