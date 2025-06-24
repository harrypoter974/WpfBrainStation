using CL.BS.Contract;
using CL.BS.UserInformationVM.BaseClass;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.UserInformationVM
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class EndDataEntryVM : BaseUserInformationVM, IPageVM
    {
        public override string Name => nameof(EndDataEntryVM);
        public EndDataEntryVM()
        {
            for (int i = 0; i < Bords.Length; i++)
                Bords[i] = new EndDataEntryBordVM(i);
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.383;
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.463;
            NotifyPropertyChanged(nameof( BoardWidth));
            NotifyPropertyChanged(nameof(BoardHeight));
        }
    }
}
