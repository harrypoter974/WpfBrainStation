using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.NotionsVM.VM.Clock
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class MonthsVM : BaseItemPage, IPageVM
    {
        public override string Name => nameof(MonthsVM);

        public MonthsVM()
        {
            ShowItem = new RelayCommand(DoShowPerson);
        }

        void IPageVM.load()
        {
            ListWordVisible();
            if (!Common.StaticVar.inline.IsBoy)
                messagePic = "Visible";
            else
                messagePic = "Hidden";
            NotifyPropertyChanged(nameof(messagePic));
        }

        private void DoShowPerson(object obj)
        {
            if (Common.StaticVar.PlayMode)
                return;
            PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory +
                        @"Resources\Audio\He\time\" + obj + ".wav");
        }
    }
}
