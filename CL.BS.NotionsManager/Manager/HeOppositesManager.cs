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
    public class HeOppositesManager : IHeOppositesManager, IManager
    {
        private OppositesEngin _logic = new OppositesEngin();
        string IManager.ManagerName => "HeOppositesManager";

        public HeOppositesManager()
        {
        }

        int IHeOppositesManager.GetAnswer()
        {
            return  _logic.GetAnswer();
        }

        int IHeOppositesManager.GetIndex()
        {
           return _logic.GetIndex();
        }

        string[] IHeOppositesManager.GetOppositPlay(int i)
        {
           return _logic.GetOppositPlay( i);
        }

        string[] IHeOppositesManager.GetQuestion()
        {
           return _logic.GetQuestion( );
        }

        void IHeOppositesManager.load()
        {
            _logic.load();
        }

        void IHeOppositesManager.SetIndex(object indx)
        {
            _logic.SetIndex(indx);
        }

        void IHeOppositesManager.SwitchLanguage(object obj)
        {
            _logic.SwitchLanguage(obj);
        }

        string IHeOppositesManager.GetLanguage()
        {
         return   _logic.GetLanguage();
        }
    }
}
