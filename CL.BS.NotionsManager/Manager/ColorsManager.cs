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
    public class ColorsManager : IManager,IColorsManager
    {

        private   ColorsEngine _logic = new ColorsEngine();
        string IManager.ManagerName => "ColorsManager";
        string IColorsManager.PlayColor(int colorIndex, int language)
        {
           return _logic.PlayColor( colorIndex,language);
        }


        string IColorsManager.GetQuestion()
        {
           return _logic.GetQuestion();
        }

        object[] IColorsManager.GetAnswer()
        {
           return _logic.GetAnswer();
        }

        string[] IColorsManager.PlayQuestion(int iw)
        {
            return _logic.PlayQuestion( iw);
        }

        void IColorsManager.setGrope(object gropeIndex)
        {
            _logic.setGrope(gropeIndex);
        }

        int IColorsManager.GetGrope()
        {
          return  _logic.GetGrope();
        }

        void IColorsManager.ClearList()
        {
           _logic.ClearList();
        }
    }
}
