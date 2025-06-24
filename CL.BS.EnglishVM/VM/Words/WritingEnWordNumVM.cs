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
    public class WritingEnWordNumVM : BaseWordsVM
    {
        private Common.GeneralFunctions _logic = new Common.GeneralFunctions();
        public override string Name => "WritingEnWordNumVM";
        private static string[] _num = new string[] {  "zero", "one", "two", "three", "four", "five", "six", "seven"
            , "eight", "nine" ,
 "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" ,
 "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" ,"hundred"};

        public WritingEnWordNumVM() : base("Numbers")
        {
            ChangeWord = new RelayCommand(DoChangeWord);
            SelectedNum = "0";
        }

        private void DoChangeWord(object num)
        {
            if (!base.IsQuestionMode)
                DoAnswerBut(0);
            int i = int.Parse(num.ToString());
            base.SelectedWord = _num[i];
            int n = i;
            if (n > 20)
            {
                n = 20 + (n % 20) * 10;
            }
            SelectedNum = n.ToString();
            LstWords = new List<ItemObject>();
            TextWords = string.Empty;
            PicWord = n.ToString();
            NotifyPropertyChanged("PicWord");
            NotifyPropertyChanged("TextWords");
            NotifyPropertyChanged("LstWords");
            NotifyPropertyChanged("SelectedNum");
        }

        protected override void ChooseWord()
        {
            DoChangeWord(_logic.GetIndex(_num.Length));
        }
    }
}
