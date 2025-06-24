using BS.Items;
using CL.BS.Contract;
using CL.BS.EnglishVM.VM.Text;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.EnglishVM.Text
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class EnTextSmallVM : BaseTextVM, IPageVM
    {
        public override string Name
        {
            get
            {
                return nameof(EnTextSmallVM);
            }
        }

        public EnTextSmallVM()
        {
            AnswerBut = new RelayCommand(DoAnswerBut);
            OpenMenu = new RelayCommand(DoOpenMenu);
        }

        private void DoOpenMenu(object obj)
        {
            base.OpenMenuWin(true);
        }

        private void DoAnswerBut(object obj)
        {
            base.FillAnswerBut();
        }
    }
}
