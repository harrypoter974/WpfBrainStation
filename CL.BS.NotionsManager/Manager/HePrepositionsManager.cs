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
    public class HePrepositionsManager : IHePrepositionsManager, IManager
    {
        string IManager.ManagerName => "HePrepositionsManager";
        private HePrepositionsEngine _logic = new HePrepositionsEngine();

       string IHePrepositionsManager.GetAnswer()
        {
            return _logic.GetAnswer();
        }

        string[] IHePrepositionsManager.GetQuestion()
        {
            return _logic.GetQuestion();
        }

        void IHePrepositionsManager.load(int indexPage)
        {
            _logic.load(indexPage);
        }

    

        string IHePrepositionsManager.GetPlay(object obj)
        {
           return _logic.GetPlay(obj);
        }

        public void SwitchLanguage(object obj)
        {
            _logic.SwitchLanguage(obj);
        }

        void IHePrepositionsManager.SwitchLanguage(object obj)
        {
            _logic.SwitchLanguage(obj);
        }

        int IHePrepositionsManager.GetIndex()
        {
          return  _logic.GetIndex();
        }

        string IHePrepositionsManager.GetLanguage()
        {
            return _logic.GetLanguage();
        }
    }
}
