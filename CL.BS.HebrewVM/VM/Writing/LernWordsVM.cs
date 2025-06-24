using BS.Items;
using CL.BS.Contract;
using CL.BS.HebrewManager.Interface.Writing;
using CL.BS.MEF;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.HebrewVM.VM.Writing
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class LernWordsVM : BaseLernPage, IPageVM
    {
        public override string Name => nameof(LernWordsVM);
        public ICommand SetWords { get; set; }
        private ILernWordsManager _logic = (ILernWordsManager)
SupportHandlerManager.Base.GetManager("LernWordsManager");
        WinWordList _win;
        public LernWordsVM()
        {
            SetWords = new RelayCommand(DoSetWords);
        }

        private void DoSetWords(object obj)
        {
            _win = new WinWordList(_logic.GeTAllWords());
            _win.Closed += Win_Closed;
            _win.ShowDialog();
        }

        private void Win_Closed(object sender, EventArgs e)
        {
            _logic.SetAllWords(_win.GetWords());
        }
    }
}
