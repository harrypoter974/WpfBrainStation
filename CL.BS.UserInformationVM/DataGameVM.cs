using CL.BS.Contract;
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
    public class DataGameVM : BaseClass.BaseUserInformationVM, IPageVM
    {
        public override string Name => nameof(DataGameVM);
        public DataGameVM()
        {
            for (int i = 0; i < Bords.Length; i++)
                Bords[i] = new BaseClass.DataGameBordVM(i);
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.357;
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.463;
            NotifyPropertyChanged(nameof(BoardWidth));
            NotifyPropertyChanged(nameof(BoardHeight));
        }
    }
}
