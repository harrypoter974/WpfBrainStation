using CL.BS.Contract;
using CL.BS.EnglishManager.Interface.Notions;
using CL.BS.MEF;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.EnglishVM.Notions
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class EnColorMenuVM : BaseLernPage, IPageVM
    {
        public ICommand ShowGrope { get; set; }
        public override string Name
        {
            get
            {
                return nameof(EnColorMenuVM);
            }
        }
        IEnColorManager _logic = (IEnColorManager)
SupportHandlerManager.Base.GetManager("EnColorManager");

        public EnColorMenuVM()
        {
            ShowGrope = new RelayCommand(DoShowGrope);
        }

        void IPageVM.load()
        {
            base.Settings();
            if (!Common.StaticVar.inline.IsBoy)
            {
                messagePic = System.AppDomain.CurrentDomain.BaseDirectory
                 + @"Resources\Notions\Colors\openMessage.png";
            }
            else
                messagePic = string.Empty;
            NotifyPropertyChanged(nameof(messagePic));
        }

        public void DoShowGrope(object index)
        {
            _logic.SetColorIndex(index);
            base.DoGoToPage(nameof(EnColorVM));
        }
    }
}
