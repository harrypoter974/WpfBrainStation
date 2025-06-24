using CL.BS.Contract;
using CL.BS.EnglishManager.Engen.Text;
using CL.BS.EnglishManager.Interface.Text;
using CL.BS.Model;
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
    public class EnTextManager : IEnTextManager, IManager
    {
        private EnTextEngen _logic = new EnTextEngen();
        string IManager.ManagerName => "EnTextManager";

        void IEnTextManager.GetText(ref List<LetterObject>[] lineList, bool v)
        {
            _logic.GetText(ref lineList, v);
        }

        void IEnTextManager.SetFill(string textFile)
        {
            _logic.SetFill(textFile);
        }
    }
}
