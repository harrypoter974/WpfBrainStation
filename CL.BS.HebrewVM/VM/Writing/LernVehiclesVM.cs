using CL.BS.Common;
using CL.BS.Contract;
using CL.BS.HebrewManager.Interface.Writing;
using CL.BS.MEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.HebrewVM.VM.Writing
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class LernVehiclesVM: OldLernWordsVM, IPageVM
    {
        private ILernWordsManager _logic = (ILernWordsManager)
SupportHandlerManager.Base.GetManager("LernWordsManager");
        public new ICommand SetGroup { get; set; }
        public override string Name
        {
            get
            {
                return "LernVehiclesVM";
            }
        }

        public LernVehiclesVM()
        {
            SetGroup = new RelayCommand(doSetGroup);
        }

        void IPageVM.load()
        {
            base.Settings();
            if (!Common.StaticVar.inline.IsBoy)
            {
                messagePic = System.AppDomain.CurrentDomain.BaseDirectory
                 + @"Resources\Lang\He\Words\openMessage.png";
            }
            else
                messagePic = string.Empty;
            NotifyPropertyChanged("messagePic");
            DoSetGroup("vehicle");
        }

        private void doSetGroup(object obj)
        {
            _logic.SetGroup(obj);
            DoGoToPage("LernWordsVM");
        }
    }
}
