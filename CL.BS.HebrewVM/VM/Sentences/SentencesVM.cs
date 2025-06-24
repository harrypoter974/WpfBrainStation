using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.HebrewVM.VM.Sentences
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class SentencesVM : BaseLernPage, IPageVM
    {
        private int[] _sentencesConte = new int[] { 5, 2, 2 };
        private int _level = 1;
        private bool _isCard = true;
        private int _questionIndex = 0;
        public string BackgroundPic { get; set; }
        public string messagePicBig { get; set; }
        public string BackgroundSwitchIsCard { get; set; }
        public ICommand SwitchIsCard { get; set; }
        public ICommand ToLevel { get; set; }
        public override string Name
        {
            get
            {
                return "SentencesVM";
            }
        }

        public SentencesVM()
        {
            AnswerBut = new RelayCommand(DoAnswerBut);
            ToLevel = new RelayCommand(DoToLevel);
            SwitchIsCard = new RelayCommand(DoSwitchIsCard);
        }

        private void DoAnswerBut(object obj)
        {
            if (base.IsQuestionMode)
            {
                if (_questionIndex < _sentencesConte[_level - 1])
                    _questionIndex++;
                else
                    _questionIndex = 0;
            }
            base.SwitchAnswerButton();
            SetBackground();
        }

        private void DoToLevel(object level)
        {
           this._level =int.Parse( level.ToString());
            _questionIndex = 0;
            if (base.IsQuestionMode)
                base.SwitchAnswerButton();
            SetBackground();
            if (!Common.StaticVar.inline.IsBoy)
            {
                if (level == "3") {
                   messagePicBig = System.AppDomain.CurrentDomain.BaseDirectory
                 + @"Resources\Lang\He\Sentences\message3.png";
                    messagePic = string.Empty;
                }
                else
                {
                    messagePicBig = string.Empty;
     messagePic = System.AppDomain.CurrentDomain.BaseDirectory
                 + @"Resources\Lang\He\Sentences\message"+ level + ".png";
                }
                NotifyPropertyChanged("messagePic");
                NotifyPropertyChanged("messagePicBig");
            }
        }

        private void DoSwitchIsCard(object obj)
        {
            _isCard = !_isCard;
            if (_isCard)
            {
                BackgroundSwitchIsCard = string.Empty;            
            }
            else
            {
                BackgroundSwitchIsCard = System.AppDomain.CurrentDomain.BaseDirectory
                + @"Resources\Lang\He\Sentences\notCard.jpg";
            }
            NotifyPropertyChanged("BackgroundSwitchIsCard");
            SetBackground();
        }

        void IPageVM.load()
        {
            base.Settings();
            if (!Common.StaticVar.inline.IsBoy)
            {
                messagePic = System.AppDomain.CurrentDomain.BaseDirectory
                 + @"Resources\Lang\He\Sentences\message1.png";
            }
            else
                messagePic = string.Empty;
            NotifyPropertyChanged("messagePic");
            if (base.IsQuestionMode)
                base.SwitchAnswerButton();
            SetBackground();
            SetMessage();
        }

        private void SetMessage()
        {
            if (!Common.StaticVar.inline.IsBoy)
            {
                messagePic = System.AppDomain.CurrentDomain.BaseDirectory
                 + @"Resources\Lang\He\Sentences\message" + _level + ".png";
            }
            else
                messagePic = string.Empty;
            NotifyPropertyChanged("messagePic");
        }

        private void SetBackground()
        {
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory
            + @"Resources\Lang\He\Sentences\" + (base.IsQuestionMode ? 'a': 'q' ) +
            (_isCard || _level == 3 ? 'c' : 'w') + _level + _questionIndex + ".jpg";
            NotifyPropertyChanged("BackgroundPic");
        }
    }
}
