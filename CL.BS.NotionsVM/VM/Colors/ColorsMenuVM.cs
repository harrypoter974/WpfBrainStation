using CL.BS.Contract;
using CL.BS.MEF;
using CL.BS.NotionsManager.Interface;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.NotionsVM.VM.Colors
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class ColorsMenuVM : BaseLernPage, IPageVM
    {
        public ICommand GoToGroup { get; set; }
        private IColorsManager logic = (IColorsManager)
         SupportHandlerManager.Base.GetManager("ColorsManager");
        public override string Name
        {
            get
            {
                return nameof(ColorsMenuVM) ;
            }
        }

        public ColorsMenuVM()
        {
            GoToGroup = new RelayCommand(DoGoToGroup);
        }

        private void DoGoToGroup(object obj)
        {
            logic.setGrope(obj);
            base.DoGoToPage(nameof(ColorsLearnGroupVM) );
        }
    }
}
