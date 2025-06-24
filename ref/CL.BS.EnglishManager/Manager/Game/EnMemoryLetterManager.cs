using CL.BS.Contract;
using CL.BS.EnglishManager.Engen;
using CL.BS.EnglishManager.Interface;
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
        EnMemoryLetterEngen logic=new EnMemoryLetterEngen();
        string IManager.ManagerName =>"EnMemoryLetterManager";
    }
}
