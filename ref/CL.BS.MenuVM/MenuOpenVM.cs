using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.HebrewVM.Game.BS.MenuVM
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class MenuOpenVM : BaseStepVM,  IPageVM
    {
        public MenuOpenVM()
        {           
                Url = System.AppDomain.CurrentDomain.BaseDirectory + @"\Resources\Audio\He\Open.wav";
        }
        void IPageVM.disload()
        {
            Url = string.Empty;
        }
        public override string Name
        {
            get
            {
                return "MenuOpenVM";
            }
        }    
    }
}
