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
    #endregion MEF
     class JudaismCollectManager : IJudaismCollectManager, IManager
    {
        string IManager.ManagerName => "JudaismCollectManager";
        private JudaismCollectEngen _logic = new JudaismCollectEngen();
        void IBingoManager.DoChangeMode(bool b)
        {
            throw new NotImplementedException();
        }

        bool IBingoManager.EndGame()
        {
            return true;
        }

        List<GameObject>[] IBingoManager.NewGame()
        {
            return _logic.NewGame();
        }

        public string GetQuestion()
        {
            return _logic.GetQuestion();
        }
        public bool ChackQuestion(string question)
        {
            return _logic.ChackQuestion(question);
        }
    }
}
