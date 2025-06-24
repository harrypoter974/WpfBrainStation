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
    public class WritingEnWordDayVM: BaseWordsVM
    {
        private Common.GeneralFunctions _logic = new Common.GeneralFunctions();
        public override string Name => "WritingEnWordDayVM";
        private string[] _words = new string[] { "Sunday", "Monday", "Tuesday", "Wednesday"
            , "Thursday", "Friday", "Saturday" };

        public WritingEnWordDayVM() : base("DayOfTheWeek")
        {
            ChangeWord = new RelayCommand(DoChangeWord);
            PicWord = "";
        }
        
        private void DoChangeWord(object day)
        {
            if (!base.IsQuestionMode)
                DoAnswerBut(0);
            int i = int.Parse(day.ToString());
            base.SelectedWord = _words[i];
            PicWord = (i + 1).ToString();
            LstWords = new List<ItemObject>();
            TextWords = string.Empty;
            NotifyPropertyChanged("TextWords");
            NotifyPropertyChanged("LstWords");
            NotifyPropertyChanged("PicWord");
        }

        protected override void ChooseWord()
        {
            DoChangeWord(_logic.GetIndex(_words.Length));
        }
    }
}
