using CL.BS.Contract;
using CL.BS.Database;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.HebrewVM.Game.BS.EnglishVM.Recognition
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class BoardEnLetterRecognitionVM : BaseLernPage, IPageVM
    {
        public override string Name => nameof(BoardEnLetterRecognitionVM);
        public ICommand TypeLetter { get; set; }
        public string Text { get; set; }
        public string AnswerText { get; set; }
        public string SadSmily { get; set; }
        public string HappySmily { get; set; }
        public string BackgroundPic { get; set; }
        private int _LetterNum = 0, _LetterRightNum = 0;
        public BoardEnLetterRecognitionVM()
        {
            TypeLetter = new RelayCommand(DoTypeLetter);
            SetBackground();
        }

        private void DoTypeLetter(object obj)
        {
            Text=obj.ToString();
            if (Common.StaticVar.inline._IsBigEnLetter)
               Text= Text.ToUpper();
            else
                Text = Text.ToLower();
            NotifyPropertyChanged(nameof(Text));
        }

        internal void Clear()
        {
            HappySmily= SadSmily = AnswerText =Text=string.Empty;
            NotifyPropertyChanged(nameof(AnswerText));  
            NotifyPropertyChanged(nameof(Text));  
            NotifyPropertyChanged(nameof(SadSmily));  
            NotifyPropertyChanged(nameof(HappySmily));  
        }
        internal void SetBackground()
        {
            BackgroundPic = string.Format(@"{0}\Resources\Lang\En\Recognition\UCBoardEnLetterRecognition{1}.png"
, System.AppDomain.CurrentDomain.BaseDirectory, (((Common.StaticVar.inline._IsBigEnLetter ? 'U' : 'L'))));
            NotifyPropertyChanged(nameof(BackgroundPic));
        }
        internal void CheckAnswer(string letter)
        {
            bool answer = letter==Text;
            AnswerText = letter;
            _LetterNum++;
            if (answer)
            {
                HappySmily = string.Format(@"{0}\Resources\BS.Items\HappySmily.png"
, System.AppDomain.CurrentDomain.BaseDirectory);
                _LetterRightNum++;
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
        void IPageVM.load() {
            Settings();
            _startTime = DateTime.Now;
            _LetterRightNum= _LetterNum = 0;
        }
        void IPageVM.disload()
        {
            DatabaseManager.Inline.SaveActivity(4, _startTime, DateTime.Now,
           Name, "LERM", _LetterNum.ToString(), "E", 0);
        }
    }
}
