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
     class JudaismCongratulationsMemoryManager : IJudaismCongratulationsMemoryManager, IManager
    {
       private JudaismCongratulationsMemoryEngen _logic = new JudaismCongratulationsMemoryEngen();

        public JudaismCongratulationsMemoryManager()
        {
        }

        string IManager.ManagerName => "JudaismCongratulationsMemoryManager";

        bool IMemoryManager.EndGame(bool ToFill)
        {
            return _logic.EndGame();
        }

        //void IMemoryManager.DoChangeMode(bool b)
        //{
        //    _logic.DoChangeMode(b);
        //}

        //bool IMemoryManager.EndGame()
        //{
        //   return _logic.EndGame();
        //}

        string IJudaismCongratulationsMemoryManager.GetAnswer()
        {
            return _logic.GetAnswer();
        }

        List<GameObject>[] IMemoryManager.GetNewGame(int num)
        {
            return _logic.NewGame(num);
        }

        GameObject IJudaismCongratulationsMemoryManager.GetQuestion()
        {
            return _logic.GetQuestion();
        }

        string IMemoryManager.GetQuestion()
        {
            return _logic.GetQuestion().Question;
        }
    }
}
