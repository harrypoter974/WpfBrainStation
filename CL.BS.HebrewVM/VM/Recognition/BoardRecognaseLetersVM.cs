using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.HebrewVM.VM.Recognition
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class BoardRecognaseLetersVM : BaseLernPage, IPageVM
    {
        public override string Name => nameof(BoardRecognaseLetersVM);
        public ICommand TypeLetter { get; set; }
        public string Text { get; set; }
        public string AnswerText { get; set; }
        public string SadSmily { get; set; }
        public string HappySmily { get; set; }
        public string BackgroundPic { get; set; }
        public BoardRecognaseLetersVM()
        {
            TypeLetter = new RelayCommand(DoTypeLetter);
            SetBackground();
        }

        private void DoTypeLetter(object obj)
        {
            Text = string.Format(@"{0}Resources\Lang\He\{1}\{2}.png"
, System.AppDomain.CurrentDomain.BaseDirectory, Common.StaticVar.inline._HeIsManuscript ?
"ManuscriptLetters" : "BlackLetters", obj);
            NotifyPropertyChanged(nameof(Text));
        }

        internal void Clear()
        {
            HappySmily = SadSmily = AnswerText = Text = string.Empty;
            NotifyPropertyChanged(nameof(AnswerText));
            NotifyPropertyChanged(nameof(Text));
            NotifyPropertyChanged(nameof(SadSmily));
            NotifyPropertyChanged(nameof(HappySmily));
        }
        internal void SetBackground()
        {
            BackgroundPic = string.Format(@"{0}Resources\Lang\He\Recognition\BoardRecognaseLeters{1}.png"
, System.AppDomain.CurrentDomain.BaseDirectory, Common.StaticVar.inline._HeIsManuscript ? 'H' : 'R');
            NotifyPropertyChanged(nameof(BackgroundPic));
        }
        internal void CheckAnswer(string letter)
        {
            AnswerText = string.Format(@"{0}Resources\Lang\He\{1}\{2}.png"
, System.AppDomain.CurrentDomain.BaseDirectory, Common.StaticVar.inline._HeIsManuscript ?
"ManuscriptLetters" : "BlackLetters", letter);
            bool answer = Text.Contains(letter);///AnswerText == Text;
            if (answer)
            {
                HappySmily = string.Format(@"{0}\Resources\BS.Items\HappySmily.png"
, System.AppDomain.CurrentDomain.BaseDirectory);
            }
            else
            {
                SadSmily = string.Format(@"{0}\Resources\BS.Items\SadSmily.png"
, System.AppDomain.CurrentDomain.BaseDirectory);
            }
            NotifyPropertyChanged(nameof(AnswerText));
            NotifyPropertyChanged(nameof(Text));
            NotifyPropertyChanged(nameof(SadSmily));
            NotifyPropertyChanged(nameof(HappySmily));
        }
    }
}
