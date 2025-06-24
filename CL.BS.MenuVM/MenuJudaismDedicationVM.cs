using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.HebrewVM.Game.BS.MenuVM
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class MenuJudaismDedicationVM : BaseMenuVM, IPageVM
    {
        public override string Name
        {
            get
            {
                return "MenuJudaismDedicationVM";
            }
        }
        private int _indexPage = 0;
        public string BackgroundPic { get; set; }
        public MenuJudaismDedicationVM()
        {
            GOHome = new RelayCommand(DoGoToJudaism);
        }

        private void DoGoToJudaism(object obj)
        {
            _indexPage++;
            if (_indexPage==3)
            {
                DoGoToPage("MenuJudaismVM");
            }
            BackgroundPic = string.Format(@"{0}Resources\T\Window{1}.jpg", System.AppDomain.CurrentDomain.BaseDirectory, _indexPage);
            NotifyPropertyChanged(nameof(BackgroundPic));   
        }

        void IPageVM.load()
        {
            _indexPage = 0;
            base.Settings();
            BackgroundPic = string.Format(@"{0}Resources\T\Window{1}.jpg", System.AppDomain.CurrentDomain.BaseDirectory, _indexPage);
            NotifyPropertyChanged(nameof(BackgroundPic));   
        }
    }
}
