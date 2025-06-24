using CL.BS.Contract;
using CL.BS.EnglishManager.Engen.Game;
using CL.BS.EnglishManager.Interface.Game;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.EnglishManager.Manager.Game
{

    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IManager))]
    #endregion MEF
    public class EnMemoryWordsManager : IEnMemoryWordsManager, IManager
    {
        private EnMemoryWordsEngen _logic = new EnMemoryWordsEngen();
        string IManager.ManagerName =>nameof(EnMemoryWordsManager);

        bool IMemoryManager.EndGame(bool ToFill)
        {
            return _logic.EndGame(ToFill);
        }

        int IEnMemoryWordsManager.GetGropeIndex()
        {
            return _logic.GetGropeIndex();
        }

        string[] IEnMemoryWordsManager.getHint()
        {
            return _logic.GetHint();
        }

        List<GameObject>[] IMemoryManager.GetNewGame(int num)
        {
            return _logic.GetNewGame(num);
        }

        string IMemoryManager.GetQuestion()
        {
            return _logic.GetQuestion()[0];
        }

        string[] IEnMemoryWordsManager.getQuestion()
        {
            return _logic.GetQuestion();
        }

        void IEnMemoryWordsManager.ResetIndex()
        {
            _logic.ResetIndex();
        }

        string IEnMemoryWordsManager.SetGrope(int g)
        {
          return _logic.SetGrope(g);
        }
    }
}
