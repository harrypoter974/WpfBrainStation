using CL.BS.Contract;
using CL.BS.HebrewManager.Engine.Game;
using CL.BS.HebrewManager.Interface.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.HebrewManager.Manager.Game
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IManager))]
    #endregion MEF
    public class HeLottoManager : IHeLottoManager, IManager
    {
        private HeLottoEngen _logic = new HeLottoEngen();
        string IManager.ManagerName => "HeLottoManager";

        public string[] GetAnswer()
        {
            return _logic.GetAnswer();
        }

        public string GetQuestion()
        {
            return _logic.GetQuestion();
        }

        public void Refresh()
        {
            _logic.Refresh();
        }

        public void SetNum(object obj)
        {
            _logic.SetNum(obj);
        }
    }
}
