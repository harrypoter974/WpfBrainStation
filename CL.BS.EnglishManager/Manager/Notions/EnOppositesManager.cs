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
    public class EnOppositesManager : IEnOppositesManager, IManager
    {
        private EnOppositesEngen _logic = new EnOppositesEngen();
        string IManager.ManagerName => "EnOppositesManager";
        private static Random _run = new Random(DateTime.Now.Millisecond);
        private string _pageIndex = _run.Next(6).ToString();

        string IEnOppositesManager.GetIndex()
        {
            return _pageIndex;
        }

        void IEnOppositesManager.SetIndex(object index)
        {
            _pageIndex = index.ToString();
        }

        string[] IEnOppositesManager.GetOppositPlay(int index)
        {
            return _logic.GetWord(_pageIndex); 
        }

        void IEnOppositesManager.load()
        {
            _logic.load();
        }

        string[] IEnOppositesManager.GetQuestion()
        {
            return _logic.GetQuestion(int.Parse(_pageIndex));
        }

        object[] IEnOppositesManager.GetAnswer()
        {
           return _logic.GetAnswer();
        }

   
    }
}
