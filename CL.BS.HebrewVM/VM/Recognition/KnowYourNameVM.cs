using CL.BS.Contract;
using CL.BS.HebrewManager.Interface.Recognition;
using CL.BS.MEF;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.HebrewVM.VM.Recognition
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class KnowYourNameVM : BaseLernPage, IPageVM
    {
        public string TBName  { get; set; }
        private IKnowLetterManager _logic = (IKnowLetterManager)
SupportHandlerManager.Base.GetManager("KnowLetterManager");
        public override string Name
        {
            get
            {
                return "KnowYourNameVM";
            }
        }

        void IPageVM.load() {
            base.Settings();
            TBName = Common.StaticVar.inline.Name;
            NotifyPropertyChanged("TBName");
            PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory + Common.StaticVar.inline.PlayName());

        }
    }
}
