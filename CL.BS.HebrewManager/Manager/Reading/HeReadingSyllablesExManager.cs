using CL.BS.Contract;
using CL.BS.HebrewManager.Engine.Reading;
using CL.BS.HebrewManager.Engine.Recognition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.HebrewManager.Interface.Recognition
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IManager))]
    #endregion MEF
    public class HeReadingSyllablesExManager : IManager, IHeReadingSyllablesExManager
    {
        private HeReadingSyllablesExEngine _logic = new HeReadingSyllablesExEngine();
        private int _seriesIndex = 1;
        string IManager.ManagerName
        {
            get
            {
                return "HeReadingSyllablesExManager";
            }
        }

        string IHeReadingSyllablesExManager.GetAnswer()
        {
              return _logic.GetAnswer();
        }

        string[] IHeReadingSyllablesExManager.GetAnswer(int v)
        {
            return _logic.GetAnswer(v);
        }

        string[] IHeReadingSyllablesExManager.GetOpenSentens()
        {
            return _logic.GetOpenSentens() ;
        }

        string[] IHeReadingSyllablesExManager.GetQuestion()
        {
            return _logic.GetQuestion();
        }
        string[] IHeReadingSyllablesExManager.GetQuestion(bool isEx0)
        {
            return _logic.GetQuestion(isEx0);
        }

        string[] IHeReadingSyllablesExManager.GetQuestion3(int grope)
        {
            return _logic.GetQuestion(grope);
        }

        int IHeReadingSyllablesExManager.GetSeriesIndex()
        {
            return _seriesIndex;
        }

        void IHeReadingSyllablesExManager.SetSeriesIndex(object obj)
        {
            _seriesIndex=int.Parse(obj.ToString());
        }

        string[] IHeReadingSyllablesExManager.GetOpenSentens3()
        {
            return _logic.GetOpenSentens3();
        }
    }
}
