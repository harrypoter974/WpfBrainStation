using CL.BS.Contract;
using CL.BS.Common;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CL.BS.VMCommon;

namespace CL.BS.JudaismVM.VM.Agenda
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class TwelveVersesVM : BaseMenuVM, IPageVM
    {//        
        public override string Name => "TwelveVersesVM";
        public ICommand ShowVerse { get; set; }
        public TwelveVersesVM()
        {
            ShowVerse = new Common.RelayCommand(DoShowVers);
        }
        void IPageVM.load()
        {
            base.Settings();
            Common.StaticVar.TransferVar = 4;
            PlayUrl(string.Format(@"{0}Resources\Audio\He\Judaism\The twelve verses.wav",
                System.AppDomain.CurrentDomain.BaseDirectory));
        }
        private void DoShowVers(object obj)
        {
            Common.StaticVar.TransferVar = obj;
            DoGoToPage("ShowVerseVM");
        }
    }
}
