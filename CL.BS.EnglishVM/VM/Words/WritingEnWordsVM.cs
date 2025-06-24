
using BS.Items;
using CL.BS.Contract;
using CL.BS.EnglishManager.Interface.Words;
using CL.BS.MEF;
using CL.BS.VMCommon;
using System;
using System.Windows.Input;

namespace CL.BS.EnglishVM.Words
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class WritingEnWordsVM : BaseLernPage, IPageVM
    {
        public override string Name =>nameof(WritingEnWordsVM);
        private IEnLernWordsManager _logic = (IEnLernWordsManager)
  SupportHandlerManager.Base.GetManager("EnLernWordsManager");
        Common.GeneralFunctions ListLogic = new Common.GeneralFunctions();
        WinWordList _win;
        public ICommand SetWords { get; set; }
        public WritingEnWordsVM()
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
