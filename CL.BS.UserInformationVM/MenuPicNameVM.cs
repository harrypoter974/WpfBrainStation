using CL.BS.Contract;
using CL.BS.Database;
using CL.BS.UserInformationVM.BaseClass;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.UserInformationVM
{
    #region MEF
    [Export(typeof(IPageVM))]
    #endregion MEF
    public class MenuPicNameVM : BaseUserInformationVM, IPageVM
    {
        public override string Name => nameof(MenuPicNameVM) ;
        public ICommand SelectName { get; set; }
        public MenuPicNameVM()
        {
            for (int i = 0; i < Bords.Length; i++)
                Bords[i] = new PicNameBordVM(i);
            SelectName = new VMCommon.RelayCommand(DoSelectName);
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.383;
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.463;
            NotifyPropertyChanged(nameof(BoardWidth));
            NotifyPropertyChanged(nameof(BoardHeight));
        }

        private void DoSelectName(object obj)
        {
    //        DatabaseManager.Inline.SetUsers(4,"UK", "Hogsmeade"
    //, "peter_drive", "Hogwarts", 4, 770,"Gryffindor" ,1, 
    // new int[] { 0,1,2,3});
            DatabaseManager.Inline.SaveLesson(0);
        }
    }
}
