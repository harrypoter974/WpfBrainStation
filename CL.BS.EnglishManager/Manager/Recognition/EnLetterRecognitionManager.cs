using CL.BS.Contract;
using CL.BS.EnglishManager.Engen.Recognition;
using CL.BS.EnglishManager.Interface.Recognition;
using CL.BS.EnglishManager1.Engen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.EnglishManager.Manager.Recognition
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IManager))]
    #endregion MEF
    public class EnLetterRecognitionManager : IEnLetterRecognitionManager, IManager
    {
        private KnowLetterEngen _logic = new KnowLetterEngen();
        private char _letter;
        string IManager.ManagerName =>"EnLetterRecognitionManager";

        string IEnLetterRecognitionManager.GetLetter()
        {
            return _letter.ToString() ;
        }

        string[] IEnLetterRecognitionManager.SetQuestion()
        {
            string[] q = new string[2];
          q=  _logic.SetQuestion();
            if (q[0] == "X1")
            {
                q = new string[] { "X0", @"Resources\Audio\En\OpeningLetter\Xylophone" };
            }
            _letter = q[0][0];
            q[1] = System.AppDomain.CurrentDomain.BaseDirectory+q[1];
            return q;
        }

        void IEnLetterRecognitionManager.ClearList()
        {
           _logic.ClearList();
        }
    }
}
