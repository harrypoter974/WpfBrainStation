
using CL.BS.Contract;
using CL.BS.EnglishManager.Engen.Text;
using CL.BS.EnglishManager.Interface.Text;
using CL.BS.MEF;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.EnglishVM.Text
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class WritingEnNameVM : BaseLernPage, IPageVM
    {
        public ICommand OpenLetter { get; set; }
        public ICommand AddLetter { get; set; }
        public ICommand WriteFirst { get; set; }
        public ICommand WriteLast { get; set; }
        public ICommand SwitchTB { get; set; }
        public List<ItemObject> LstTextFirst { get; set; }
        public List<ItemObject> LstTextLast { get; set; }
        public string TBFirstName { get; set; }
        public string TBLastName { get; set; }
        public string LastBut { get; set; }
        public string FirstBut { get; set; }
        public double Speed { get; set; }
        private bool _isFirstBT = true;
        private IEnWriteLetterManager _logic = (IEnWriteLetterManager)
   SupportHandlerManager.Base.GetManager("EnWriteLetterManager");
        public override string Name
        {
            get
            {
                return "WritingEnNameVM";
            }
        }

        public WritingEnNameVM()
        {
            OpenLetter = new RelayCommand(DoOpenLetter);
            AddLetter = new RelayCommand(DoAddLetter);
            SwitchTB  = new RelayCommand(DoSwitchTB );
            WriteFirst= new RelayCommand(DoWriteFirst);
            WriteLast = new RelayCommand(DoWriteLast);
            TBFirstName =  TBLastName = string.Empty;
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
            NotifyPropertyChanged("messagePic");
        }

        private void DoSwitchTB(object obj)
        {
            _isFirstBT = obj.Equals("0");
        }

        private void DoOpenLetter(object letter)
        {
            _logic.SetLetter(letter);
            base.DoGoToPage("EnWriteLetterVM");
        }

        private void DoAddLetter(object letter)
        {
            string s = _isFirstBT ? TBFirstName : TBLastName;
            if (letter.ToString() == "0")
            {
                //string ns = string.Empty;
                //for (int i = 0; i < s.Length - 1; i++)
                //    ns += s[i];
                if (s.Length > 0)
                    s = s.Remove(s.Length - 1, 1);
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
            LstTextFirst =  _logic.WriteName(TBFirstName);
            NotifyPropertyChanged("LstTextFirst");
             FirstBut= System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\BS.Items\ButtonV.png";
            NotifyPropertyChanged("FirstBut");
            new Thread(new ThreadStart(() =>
            {
                string name = TBFirstName.ToUpper();
                for (int i = 0; i < LstTextFirst.Count(); i++)
                {                   
                    for ( int j=  0;; j++)
                    {
                        Thread.Sleep((int)(150.0 * (9.5 - Speed)));
                        string back = string.Empty;
                        if (_logic.SetLetter(ref back, TBFirstName[i], j,i==0) ||
                        (i == 0 && Common.StaticVar.inline.LettrStop[name[i]] < j))
                            break;
                        LstTextFirst[i] = new ItemObject { Background = back };
                        LstTextFirst = new List<ItemObject>(LstTextFirst);
                        NotifyPropertyChanged("LstTextFirst");
                    }
                }
                for (int i = 0; i < LstTextFirst.Count(); i++)
                {
                    LstTextFirst[i] = new ItemObject { Background =string.Empty};
                }
                LstTextFirst = new List<ItemObject>(LstTextFirst);
                NotifyPropertyChanged("LstTextFirst");
                FirstBut = string.Empty;
                NotifyPropertyChanged("FirstBut");
            })).Start();
        }

        private void DoWriteLast(object obj)
        {
            LstTextLast = _logic.WriteName(TBLastName);           
            NotifyPropertyChanged("LstTextLast");
            LastBut = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\BS.Items\ButtonV.png";
            NotifyPropertyChanged("LastBut");
            string name = TBLastName.ToUpper();
            new Thread(new ThreadStart(() =>
            {
                for (int i = 0; i < LstTextLast.Count(); i++)
                {
                    for ( int j = 0; ; j++)
                    {
                        Thread.Sleep((int)(150.0 * (9.5 - Speed)));
                        string back = string.Empty;
                        if (_logic.SetLetter(ref back, TBLastName[i], j,i==0)||
                        (i==0&& Common.StaticVar.inline.LettrStop[name[i]]<j))
                            break;
                        LstTextLast[i] = new ItemObject { Background = back };
                        LstTextLast = new List<ItemObject>(LstTextLast);
                        NotifyPropertyChanged("LstTextLast");
                    }
                }
                for (int i = 0; i < LstTextLast.Count(); i++)
                {
                    LstTextLast[i] = new ItemObject { Background = string.Empty };
                }
                LstTextLast = new List<ItemObject>(LstTextLast);
                NotifyPropertyChanged("LstTextLast");
                LastBut = string.Empty;
                NotifyPropertyChanged("LastBut");
            })).Start();          
        }
    }
}
