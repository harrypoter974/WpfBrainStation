using CL.BS.Contract;
using CL.BS.EnglishManager.Engen;
using CL.BS.EnglishManager.Interface;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.EnglishManager.Manager
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IManager))]
    #endregion MEF
    public class EnLottoManager : IEnLottoManager, IManager
    {
        private EnLottoEngen _logic = new EnLottoEngen();
        string IManager.ManagerName => "EnLottoManager";

        string[] IEnLottoManager.GetAnswer()
        {
            return _logic.GetAnswer();
        }

        string IEnLottoManager.GetQuestion()
        {
            return _logic.GetQuestion();
        }

        void IEnLottoManager.Refresh()
        {
            _logic = new EnLottoEngen();
        }

        void IEnLottoManager.SetNum(object obj)
        {
            _logic.SetNum(obj);
        }
    }
}
