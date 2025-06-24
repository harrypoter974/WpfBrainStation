using CL.BS.Contract;
using CL.BS.EnglishManager.Interface.Text;
using CL.BS.MEF;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.EnglishVM.Text
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class EnWritingLettersMenuVM : BaseLernPage, IPageVM
    {
        public ICommand OpenLetter { get; set; }
        private IEnWriteLetterManager _logic = (IEnWriteLetterManager)
          SupportHandlerManager.Base.GetManager("EnWriteLetterManager");
        public override string Name
        {
            get
            {
                return "EnWritingLettersMenuVM";
            }
        }

        public EnWritingLettersMenuVM()
        {
            OpenLetter = new RelayCommand(DoOpenLetter);
        }

        void IPageVM.load()
        {
            base.Settings();
            if (!Common.StaticVar.inline.IsBoy)
            {
                messagePic = System.AppDomain.CurrentDomain.BaseDirectory
                 + @"Resources\Lang\He\Writing\messageMenu.png";
            }
            else
                messagePic = string.Empty;
            NotifyPropertyChanged("messagePic");
        }

        private void DoOpenLetter(object letter)
        {
            _logic.SetLetter(letter);
            base.DoGoToPage("EnWriteLetterVM");
        }
    }
}
