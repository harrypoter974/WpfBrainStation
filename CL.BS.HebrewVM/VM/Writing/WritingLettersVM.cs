using CL.BS.Contract;
using CL.BS.HebrewManager.Interface.Writing;
using CL.BS.MEF;
using CL.BS.VMCommon;
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
    public class WritingLettersVM : BaseLernPage, IPageVM
    {
        private IWritingLettersManager _logic = (IWritingLettersManager)
SupportHandlerManager.Base.GetManager("WritingLettersManager");
        public ICommand OpenLetter { get; set; }
        public ICommand SwitchPage { get; set; }
        public string ButtonFont { get; set; }
        public override string Name
        {
            get
            {
                return "WritingLettersVM";
            }
        }

        public WritingLettersVM()
        {
            OpenLetter = new RelayCommand(DoOpenLetter);
            SwitchPage = new RelayCommand(DoSwitchPage);
         
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
            DoGoToPage("WritingLetterVM");            
        }

        private void DoSwitchPage(object obj)
        {
            _logic.SwitchFont();
            ButtonFont = _logic.SwitchFontButton();
            NotifyPropertyChanged("ButtonFont");
        }
    }
}
