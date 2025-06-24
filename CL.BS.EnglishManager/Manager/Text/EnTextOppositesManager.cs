using CL.BS.Contract;
using CL.BS.EnglishManager.Engen.Text;
using CL.BS.EnglishManager.Interface.Text;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.EnglishManager.Manager.Text
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IManager))]
    #endregion MEF
    public class EnTextOppositesManager : IEnTextOppositesManager,IManager
    {
        string IManager.ManagerName => "EnTextOppositesManager";
        private EnTextOppositesEngen _logic = new EnTextOppositesEngen();

        string IEnTextOppositesManager.GetText(ref List<LetterObject>[] lineList, bool isAnswer)
        {
           return _logic.GetText(ref lineList,isAnswer);
        }

        void IEnTextOppositesManager.SetIndex(object obj)
        {
           _logic.SetIndex(obj);
        }

        void IEnTextOppositesManager.SetLevel(object level)
        {
            _logic.SetLevel(level);
        }
    }
}
