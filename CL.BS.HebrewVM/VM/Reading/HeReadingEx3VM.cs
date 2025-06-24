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
    public class HeReadingEx3VM : BaseLernPage, IPageVM
    {
        private string[,,] _words = new string[,,] { {
                {"ב", "ל", "חולם","ן",""} ,
                {"פ", "י" ,"ל","חולם","ן" },
                {"ח", "ל", "חולם","ן","" },
                {"ו", "י", "ל","חולם","ן" },
                {"מ", "ל", "חולם","ן",""} }
            , { {"ק", "ר", "חולם","ן","" },
                {"ע", "פ" ,"ר","חולם","ן" },
                {"ד", "חולם", "נ","ג","" },
                {"ב", "ר", "חולם","ן","" },
                {"ד", "חולם", "ר","חולם","ן"} }
            , { {"ל", "י", "מ","חולם","ן" },
                {"ר", "י" ,"מ","חולם","ן" },
                {"א", "ר", "מ","חולם","ן" },
                {"ח", "ל", "מ","חולם","ן"} ,
                {"א", "ר", "נ","ב לא דגושה","" }}
            , { {"ח", "ר", "צ","ן",""},
                {"ח", "ר" ,"ג לא דגושה","חולם","ל" },
                {"ס", "ג לא דגושה", "חולם","ל","" },
                {"ס", "כ", "ר","",""},
                {"ס", "מ", "ל","","" }}
            , {{"ק", "ר", "ח","",""} ,
                {"פ", "ר" ,"ח","","" },
                {"ת", "נ", "י","ן","" },
                {"ת", "נ", "שורוק","ר",""},
                {"ק", "ר", "ש","","" } }};
        public string BackgroundPic { get; set; }
        public ICommand PlaySyllable { get; set; }
        public ICommand SwitchIndex { get; set; }
        private IHeReading3Manager _logic = (IHeReading3Manager)
SupportHandlerManager.Base.GetManager("HeReading3Manager");
        public string LLetter0 { get { return _lLetter[0].Text; } set { _lLetter[0].Text = value; } }
        public string LLetter1 { get { return _lLetter[1].Text; } set { _lLetter[1].Text = value; } }
        public string LLetter2 { get { return _lLetter[2].Text; } set { _lLetter[2].Text = value; } }
        public string LLetter3 { get { return _lLetter[3].Text; } set { _lLetter[3].Text = value; } }
        public string LLetter4 { get { return _lLetter[4].Text; } set { _lLetter[4].Text = value; } }
        private LetterObject[] _lLetter = new LetterObject[5];
        private int _pageIndex = 0;
        public override string Name
        {
            get
            {
                return "HeReadingEx3VM";
            }
        }

        public HeReadingEx3VM()
        {
            PlaySyllable = new RelayCommand(DoPlaySyllable);
            AnswerBut = new RelayCommand(DoAnswerBut);
            SwitchIndex = new RelayCommand(DoSwitchPage);
            for (int i = 0; i < _lLetter.Length; i++)
                _lLetter[i] = new LetterObject();


        }

        void IPageVM.load()
        {
            base.Settings();
            _pageIndex = 0;
            SetBackground(true);
            if (!Common.StaticVar.inline.IsBoy)
            {
                messagePic = System.AppDomain.CurrentDomain.BaseDirectory
                 + @"Resources\Lang\He\ExerciseReading3\ExMessage3.jpg";
            }
            else
                messagePic = string.Empty;
            NotifyPropertyChanged("messagePic");
        }

        private void DoPlaySyllable(object syllable)
        {
            PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\Audio\He\" + _logic.GetSyllable(syllable) + ".wav");

        }

        private void DoAnswerBut(object o)
        {
            if (base.IsQuestionMode)
            {
                _pageIndex = _logic.GetPageIndex();
                SetBackground();
                new Thread(new ThreadStart(() =>
                { 
                PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory 
                + @"Resources\Audio\He\ComplexSyllable\" + _logic.getWord(_pageIndex, false) + ".wav");
                })).Start();
            }
            else
            {
                for (int i = 0; i < _words.GetLength(1); i++)
                {
                    if (_words[_logic.GetIndex(), _pageIndex, i] == string.Empty)
                        break;
                    _lLetter[i].Text = System.AppDomain.CurrentDomain.BaseDirectory
             + @"Resources\Lang\He\BlackLetters\" + _words[_logic.GetIndex(), _pageIndex, i] + ".png";
                    NotifyPropertyChanged("LLetter" + i);
                }
            }
            base.SwitchAnswerButton();
        }

        private void DoSwitchPage(object obj)
        {
            _logic.SetIndex(obj);
            if (!base.IsQuestionMode)
                base.SwitchAnswerButton();
            SetBackground(true);
        }

        private void SetBackground(bool isUplode=false)
        {
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory
             + @"Resources\Lang\He\ExerciseReading3\Exercise" + _logic.GetIndex() +( isUplode?string.Empty: _pageIndex.ToString() )+ ".jpg";
            NotifyPropertyChanged("BackgroundPic");
            for (int j = 0; j < _lLetter.Length; j++)
            {
                _lLetter[j].Text = string.Empty;
                NotifyPropertyChanged("LLetter" + j);
            }
        }
    }
}
