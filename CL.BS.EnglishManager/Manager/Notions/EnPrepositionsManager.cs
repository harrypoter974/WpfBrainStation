using CL.BS.Contract;
using CL.BS.EnglishManager.Engen.Notions;
using CL.BS.EnglishManager.Interface.Notions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.EnglishManager.Manager.Notions
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IManager))]
    #endregion MEF
    public class EnPrepositionsManager : IEnPrepositionsManager,IManager
    {
        private EnPrepositionsEngen _logic=new EnPrepositionsEngen();
        private static Random _run = new Random(DateTime.Now.Millisecond);
        private string _index =_run.Next(1,4 ).ToString();
        string IManager.ManagerName => "EnPrepositionsManager";

        object[] IEnPrepositionsManager.GetAnswer(int indexPage)
        {
           return _logic.GetAnswer(indexPage);
        }

        int IEnPrepositionsManager.GetIndex()
        {
           return int.Parse(_index);
        }

        string IEnPrepositionsManager.GetPlay(object index)
        {
            return _logic.GetPlay(index);
        }

        string[] IEnPrepositionsManager.GetQuestion(int indexPage)
        {
            return _logic.GetQuestion(indexPage);
        }

        bool IEnPrepositionsManager.IsNotGrope(object obj)
        {
           return (_index[0]+1)!=obj.ToString()[0];
        }

        void IEnPrepositionsManager.load(int indexPage)
        {
            _logic.load(indexPage);
        }


        void IEnPrepositionsManager.SetIndex(object index)
        {
            _index=index.ToString();
        }
    }
}
