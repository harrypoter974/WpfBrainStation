using CL.BS.Common;
using CL.BS.Contract;
using CL.BS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.EnglishVM.Words
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class WritingEnWordSeasonsVM: BaseWordsVM
    {
        private Common.GeneralFunctions _logic = new Common.GeneralFunctions();
        public override string Name => "WritingEnWordSeasonsVM";

        public WritingEnWordSeasonsVM() : base("Seasons")
        {
            ChangeWord = new RelayCommand(DoChangeWord); WordList = new string[] { "Summer", "Spring", "Autumn", "Winter"};
        }

        private void DoChangeWord(object season)
        {
            if (!base.IsQuestionMode)
                DoAnswerBut(0);
            base.SelectedWord = season.ToString();
            PicWord = System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\Lang\En\Seasons\" + season + ".jpg";
            LstWords = new List<ItemObject>();
            TextWords = string.Empty;
            NotifyPropertyChanged("TextWords");
            NotifyPropertyChanged("LstWords");
            NotifyPropertyChanged("PicWord");
        }
        protected override void ChooseWord()
        {
            DoChangeWord(WordList[_logic.GetIndex(WordList.Length)]);
        }
    }
}
