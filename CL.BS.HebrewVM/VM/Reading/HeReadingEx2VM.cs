using CL.BS.Contract;
using CL.BS.HebrewManager.Interface.Reading;
using CL.BS.MEF;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace CL.BS.HebrewVM.VM.Reading
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class HeReadingEx2VM : BaseLernPage, IPageVM
    {
        private string[] _words = new string[] {
            "תו","כף","צב","סל","שק", "הר", "גן", "בז","פר" ,"דג"};
        private string[,] _wordsLetters = new string[,] {
                {"ת", "ו" },
                {"כ", "ף" },
                {"צ", "ב לא דגושה" } ,
                {"ס", "ל" },
                {"סין", "ק" },
                {"ה", "ר" } ,
                {"ג", "ן" },
                {"ב", "ז" },
                {"פ", "ר" },
                {"ד", "ג לא דגושה" } };
        private int _pageIndex = 0;
        public string BackgroundPic { get; set; }
        public string PageBut1 { get; set; }
        public string PageBut2 { get; set; }
        private IHeReading2Manager _logic = (IHeReading2Manager)
SupportHandlerManager.Base.GetManager("HeReading2Manager");
        public string LLetter0 { get { return _lLetter[0].Text; } set { _lLetter[0].Text = value; } }
        public string LLetter1 { get { return _lLetter[1].Text; } set { _lLetter[1].Text = value; } }
        private LetterObject[] _lLetter = new LetterObject[2];
        public ICommand SwitchIndex { get; set; }
        public override string Name
        {
            get
            {
                return "HeReadingEx2VM";
            }
        }

        public HeReadingEx2VM()
        {
            AnswerBut = new RelayCommand(DoAnswerBut);
            SwitchIndex = new RelayCommand(DoSwitchIndex);
            for (int i = 0; i < _lLetter.Length; i++)
            {
                _lLetter[i]=new LetterObject() {Uid=i.ToString() };
            }
        }

        void IPageVM.load()
        {
            base.Settings();
            SetBackground(true);
            if (!Common.StaticVar.inline.IsBoy)
            {
                messagePic = System.AppDomain.CurrentDomain.BaseDirectory
                 + @"Resources\Lang\He\ExerciseReading3\ExMessage2.jpg";
            }
            else
                messagePic = string.Empty;
            NotifyPropertyChanged("messagePic");
            SetPageBut(_logic.GetPageIndex());

        }

        private void DoSwitchIndex(object obj)
        {
            _logic.SetPageIndex(obj);
            if (!base.IsQuestionMode)
                base.SwitchAnswerButton();
            SetBackground(true);
            SetPageBut(obj);
        }

        private void SetPageBut(object obj)
        {
            if (obj.ToString() == "1")
            {
                PageBut1 = System.AppDomain.CurrentDomain.BaseDirectory
                   + @"Resources\Number\1b.png";
                PageBut2 = string.Empty;
            }
            else
            {
                PageBut1 = string.Empty;
                PageBut2 = System.AppDomain.CurrentDomain.BaseDirectory
                      + @"Resources\Number\2b.png";
            }

            NotifyPropertyChanged("PageBut1");
            NotifyPropertyChanged("PageBut2");
        }

        private void DoAnswerBut(object index)
        {
            if (base.IsQuestionMode)
            {
                PageBut1 =  PageBut2 = string.Empty; 

            NotifyPropertyChanged("PageBut1");
            NotifyPropertyChanged("PageBut2");
            SetBackground();
                new Thread(new ThreadStart(() =>
                { 
                PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory+@"Resources\Audio\He\OneSyllable\"
                 + _words[_pageIndex] + ".wav");
                })).Start();
            }
            else
            {
                _lLetter[0 ].Text =System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Lang\He\BlackLetters\"+ _wordsLetters[_pageIndex,1]+".png";
                _lLetter[1].Text = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Lang\He\BlackLetters\"+ _wordsLetters[_pageIndex, 0]+ ".png";
                NotifyPropertyChanged("LLetter" + _lLetter[0].Uid);
                NotifyPropertyChanged("LLetter"+  _lLetter[1].Uid);
            }
            base.SwitchAnswerButton();
        }

        private void SetBackground(bool isUpload=false)
        {
            _pageIndex = _logic.GetPape();
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory
                          + @"Resources\Lang\He\ExerciseReading3\" +(isUpload? "ExerciseOpen" : _words[_pageIndex]) + ".jpg";
            NotifyPropertyChanged("BackgroundPic");
            for (int i = 0; i < _lLetter.Length; i++)
            {
                _lLetter[i].Text = string.Empty;
                NotifyPropertyChanged("LLetter" + _lLetter[i].Uid);
            }
        }
    }
}
