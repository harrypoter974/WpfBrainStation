using CL.BS.Contract;
using CL.BS.EnglishManager.Engen;
using CL.BS.EnglishManager.Interface;
using CL.BS.Model;
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
    public class EnMemoryLetterManager : IEnMemoryLetterManager, IManager
    {
        private EnMemoryLetterEngen _logic=new EnMemoryLetterEngen();
        string IManager.ManagerName =>"EnMemoryLetterManager";

        bool IMemoryManager.EndGame(bool ToFill)
        {
            return _logic.EndGame(ToFill);
        }

        List<GameObject>[]  IMemoryManager.GetNewGame(int num)
        {
          return _logic.GetNewGame(num );
        }

        string IMemoryManager.GetQuestion()
        {
          return _logic.GetQuestion();
        }
    }
}
