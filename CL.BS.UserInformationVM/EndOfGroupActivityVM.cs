using CL.BS.Contract;
using CL.BS.UserInformationVM.BaseClass;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.UserInformationVM
{
    #region MEF
    [Export(typeof(IPageVM))]
    #endregion MEF
    public class EndOfGroupActivityVM : BaseUserInformationVM, IPageVM
    {
        public override string Name => nameof(EndOfGroupActivityVM);
        public EndOfGroupActivityVM()
        {
            for (int i = 0; i < Bords.Length; i++)
                Bords[i] = new EndOfGroupActivityBordVM(i);
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.461;
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.344;
            NotifyPropertyChanged(nameof(BoardWidth));
            NotifyPropertyChanged(nameof(BoardHeight));
        }
    }
}
