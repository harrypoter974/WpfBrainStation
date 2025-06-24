
using CL.BS.Contract;
using CL.BS.HebrewManager.Interface.Writing;
using CL.BS.MEF;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.IO;
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
    public class WritingNameVM : BaseLernPage, IPageVM
    {
        public ICommand OpenLetter { get; set; }
        public ICommand TypeLetter { get; set; }
        public ICommand WriteFirst { get; set; }
        public ICommand WriteLast { get; set; }
        public ICommand SwitchTB { get; set; }
        public ICommand SwitchFont { get; set; }
        public List<LetterObject> LstTextFirst { get; set; }
        public List<LetterObject> LstTextLast { get; set; }
        public string TBFirstName { get; set; }
        public string TBLastName { get; set; }
        public string LastBut { get; set; }
        public string FirstBut { get; set; }
        public string ButtonFont { get; set; }
        public double Speed { get; set; }
        private bool _isFirstBT = true;
        private IWritingLettersManager logic = (IWritingLettersManager)
SupportHandlerManager.Base.GetManager("WritingLettersManager");
    
        public override string Name
        {
            get
            {
                return "WritingNameVM";
            }
        }

        public WritingNameVM()
        {
            OpenLetter = new RelayCommand(DoOpenLetter);
            TypeLetter = new RelayCommand(DoAddLetter);
            SwitchTB = new RelayCommand(DoSwitchTB);
            WriteFirst = new RelayCommand(DoWriteFirst);
            WriteLast = new RelayCommand(DoWriteLast);
            SwitchFont = new RelayCommand(DoSwitchFont);
            TBFirstName = TBLastName = string.Empty;
        }

        void IPageVM.load()
        {
            base.Settings();
            if (!Common.StaticVar.inline.IsBoy)
            {
                messagePic = System.AppDomain.CurrentDomain.BaseDirectory
                 + @"Resources\Lang\He\Writing\message.png";
            }
            else
                messagePic = string.Empty;
            ButtonFont = logic.SwitchFontButton();
            NotifyPropertyChanged("ButtonFont");
            NotifyPropertyChanged("messagePic");
        }

        private void DoSwitchTB(object obj)
        {
            _isFirstBT = obj.Equals("0");
        }

        private void DoOpenLetter(object letter)
        {
            logic.SetLetter(letter);
            base.DoGoToPage("WritingLetterVM");
        }

        private void DoAddLetter(object letter)
        {
            string s = _isFirstBT ? TBFirstName : TBLastName;
            if (letter.ToString() == "0")
            {
                //string ns = string.Empty;
                //for (int i = 0; i < s.Length - 1; i++)
                //    ns += s[i];
               if(s.Length>0)
                    s = s.Remove(s.Length - 1, 1); ;
            }
            else if (s == string.Empty)
                s = letter.ToString().ToUpper();
            else
                s += letter;
            if (_isFirstBT)
            {
                TBFirstName = s;
                NotifyPropertyChanged("TBFirstName");
            }
            else
            {
                TBLastName = s;
                NotifyPropertyChanged("TBLastName");

            }
        }

        private void DoWriteFirst(object obj)
        {
            LstTextFirst = logic.WriteName(TBFirstName);
            NotifyPropertyChanged("LstTextFirst");
            FirstBut = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\BS.Items\ButtonV.png";
            NotifyPropertyChanged("FirstBut");
            new Thread(new ThreadStart(() =>
            {
                for (int i = LstTextFirst.Count() -1; i >=0; i--)
                {
                    for (int j = 0; ; j++)
                    {
                        Thread.Sleep((int)(150.0 * (2.5 - Speed)));
                        string back = string.Empty;
                        if (logic.SetLetter(ref back, TBFirstName[LstTextFirst.Count()-1-i], j) )
                            break;
                        LstTextFirst[i] = new LetterObject { Background = back };
                        LstTextFirst = new List<LetterObject>(LstTextFirst);
                        NotifyPropertyChanged("LstTextFirst");
                    }
                }
                for (int i = 0; i < LstTextFirst.Count(); i++)
                {
                    LstTextFirst[i] = new LetterObject { Background = string.Empty };
                }
                LstTextFirst = new List<LetterObject>(LstTextFirst);
                NotifyPropertyChanged("LstTextFirst");
                FirstBut = string.Empty;
                NotifyPropertyChanged("FirstBut");
            })).Start();
        }

        private void DoWriteLast(object obj)
        {
            LstTextLast = logic.WriteName(TBLastName);
            NotifyPropertyChanged("LstTextLast");
            LastBut = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\BS.Items\ButtonV.png";
            NotifyPropertyChanged("LastBut");
            new Thread(new ThreadStart(() =>
            {
                for (int i =LstTextLast.Count()-1; i >=0 ; i--)
                {
                    for (int j = 0; ; j++)
                    {
                        Thread.Sleep((int)(150.0 * (2.5 - Speed)));
                        string back = string.Empty;
                        if (logic.SetLetter(ref back, TBLastName[LstTextLast.Count() - 1 - i], j) )
                            break;
                        LstTextLast[i] = new LetterObject { Background = back };
                        LstTextLast = new List<LetterObject>(LstTextLast);
                        NotifyPropertyChanged("LstTextLast");
                    }
                }
                for (int i = 0; i < LstTextLast.Count(); i++)
                {
                    LstTextLast[i] = new LetterObject { Background = string.Empty };
                }
                LstTextLast = new List<LetterObject>(LstTextLast);
                NotifyPropertyChanged("LstTextLast");
                LastBut = string.Empty;
                NotifyPropertyChanged("LastBut");
            })).Start();
        }

        private void DoSwitchFont(object obj)
        {
            logic.SwitchFont();
            ButtonFont = logic.SwitchFontButton();
            NotifyPropertyChanged("ButtonFont");
        }
    }
}
