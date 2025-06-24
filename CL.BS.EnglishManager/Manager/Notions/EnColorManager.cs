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
    public class EnColorManager : IEnColorManager, IManager
    {
        private string _colorIndex = "0";
        EnColorEngen _logic = new EnColorEngen(); 
        string IManager.ManagerName =>"EnColorManager";

        string IEnColorManager.GetColorIndex()
        {
            return _colorIndex;
        }

        string IEnColorManager.GetColorWord(object index)
        {
            return _logic.GetColorWord(_colorIndex,index);
        }

        string IEnColorManager.GetQuestion()
        {
            return _logic.GetQuestion();
        }

        string[] IEnColorManager.PlayQuestion()
        {
            return _logic.PlayQuestion();
        }

        void IEnColorManager.SetColorIndex(object index)
        {
            _colorIndex = index.ToString();
        }
    }
}
