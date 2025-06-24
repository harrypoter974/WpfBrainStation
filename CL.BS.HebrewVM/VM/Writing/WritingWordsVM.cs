using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
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
    public class WritingWordsVM : BaseLernPage, IPageVM
    {
        Common.GeneralFunctions _logic = new Common.GeneralFunctions();
        private Dictionary<string, string[]> _words;
        private int _wordIndex = -1;
        private bool _isFont = true;
        public string IsFont { get; set; }
        public string ButtonFont { get; set; }
        public string BackgroundPic { get; set; }
        public ICommand SetGroup { get; set; }
        public ICommand SwitchFont { get; set; }
        public string BackgroundSwitchIsCard { get; set; }
        public override string Name
        {
            get
            {
                return "WritingWordsVM";
            }
        }

        public WritingWordsVM()
        {
            _words = new Dictionary<string, string[]>();
            _words.Add("Animals", new string[] { "cat", "Donkey", "Lion", "sheep", "cow", "camel" });
            _words.Add("vehicle", new string[] { "train", "car", "boat", "truck", "motorcycle", "bus" });
            _words.Add("Fruit", new string[] { "locust", "Apple", "lemon", "an_orange", "Pomegranate", "fig" });
            _words.Add("Swimsuit", new string[] { "scarf", "undershirt", "Sweater", "Coat", "pants", "shirt" });

            SetGroup = new RelayCommand(DoSetGroup);
            AnswerBut = new RelayCommand(DoAnswerBut);
            SwitchFont = new RelayCommand(DoSwitchFont);
            DoSwitchFont(0);
        }

        private void DoAnswerBut(object obj)
        {
            if (_wordIndex != -1)
            {
                if (base.IsQuestionMode)
                {
                    SetWordIndex();
                    new Thread(new ThreadStart(() =>
                    {
                        string grop = _words[Common.GlobalVar.Group][_wordIndex] == "lemon" ? "ComplexSyllable\\":"General\\";
                        PlayList(new string[] {    Common.StaticVar.inline.PlayName(),
               Common.StaticVar.inline.IsBoy? @"Resources\Audio\He\General\Write.wav" :@"Resources\Audio\He\General\written.wav",
            @"Resources\Audio\He\"+grop +  _words[Common.GlobalVar.Group][_wordIndex] + ".wav"});
                    })).Start();
                }
                SetBackground();
                base.SwitchAnswerButton(); 
            }
        }

        private void DoSwitchFont(object obj)
        {
            _isFont = !_isFont;
            ButtonFont = System.AppDomain.CurrentDomain.BaseDirectory
                 + @"Resources\BS.Items\" + (_isFont ? "ButtonWriting.png":  "ButtonCard.png");
            IsFont = _isFont ? "Visible" : "Hidden";
            NotifyPropertyChanged("ButtonFont");
            NotifyPropertyChanged("IsFont");
        }

        private void DoSetGroup(object group)
        {
            Common.GlobalVar.Group = group.ToString();
            base.IsQuestionMode = true;
            SetWordIndex();
            SetBackground();
        }

        void IPageVM.load()
        {
            base.Settings();
            if (!Common.StaticVar.inline.IsBoy)
            {
                messagePic = System.AppDomain.CurrentDomain.BaseDirectory
                 + @"Resources\Lang\He\Words\openMessage.png";
            }
            else
                messagePic = string.Empty;
            NotifyPropertyChanged("messagePic");
            SetWordIndex();
            SetBackground();
        }

        private void SetWordIndex()
        {
            _wordIndex = _logic.GetIndex(6);
        }

        private void SetBackground()
        {
            string word = _words[Common.GlobalVar.Group][_wordIndex];
            if (_isFont) {
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory
             + @"Resources\Lang\He\Words\"
          + Common.GlobalVar.Group + '\\' + (base.IsQuestionMode ? "" : "a") + word + ".jpg";
            }
            else
            {
                BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory
        + @"Resources\Lang\He\Words\"
     + Common.GlobalVar.Group + '\\' + word + ".jpg";
                IsFont = base.IsQuestionMode ? "Visible" : "Hidden";
                NotifyPropertyChanged("IsFont");
            }
            NotifyPropertyChanged("BackgroundPic");
        }
    }
}
