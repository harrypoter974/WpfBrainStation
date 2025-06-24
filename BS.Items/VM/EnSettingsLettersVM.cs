using CL.BS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BS.Items.VM
{
    class EnSettingsLettersVM: BaseSettingsLetters
    {
        private string _enLeters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public ICommand IsBig { get; set; }
        public string IsBigBut { get; set; }
        public EnSettingsLettersVM()
        {
            if (StaticVar.inline._EnLetterList.Count() == 0)
                StaticVar.inline._EnLetterList = _enLeters.ToLower();
            string s = StaticVar.inline._EnLetterList;
            if (!StaticVar.inline._IsBigEnLetter)
                s = s.ToLower();
            char l = StaticVar.inline._IsBigEnLetter?'A':'a';
            for (int i = 0; i < LetterList.Length; i++,l++)
            {
                LetterList[i] = new ViewObject() {Uid= l,Background =s.Contains(l.ToString().ToLower())
                    ? StaticVar.Green : "Transparent", Letter=  l.ToString()};
            }
            Clear= new RelayCommand(DoClear);
            letterType= new RelayCommand(DoletterType);
            IsBig = new RelayCommand(DoIsBig);
            IsBigBut = StaticVar.inline._IsBigEnLetter ? string.Empty:System.AppDomain.CurrentDomain.BaseDirectory +
                                   @"Resources\BS.Items\IsBigBut.png"  ;
            NotifyPropertyChanged(nameof(IsBigBut));
        }

        internal bool Have5()
        {
            return StaticVar.inline._EnLetterList.Length >= 5;
        }

        private void DoIsBig(object obj)
        {
            bool b = !StaticVar.inline._IsBigEnLetter;
            StaticVar.inline._IsBigEnLetter=b ;
            IsBigBut=b? string.Empty  :System.AppDomain.CurrentDomain.BaseDirectory +
                                   @"Resources\BS.Items\IsBigBut.png";   
            NotifyPropertyChanged(nameof(IsBigBut) );
            char l = StaticVar.inline._IsBigEnLetter?'A':'a';
            for (int i = 0; i <26; i++,l++)
            {
                LetterList[i].Letter =   l.ToString();
                NotifyPropertyChanged("letterPic"+i);
            }   
            
        }

        private void DoletterType(object obj)
        {
            if (_lockLetter)
                return;
            _lockLetter = true;
            int i = int.Parse(obj.ToString());
            if (LetterList[i].Background == StaticVar.Green)
            {
                LetterList[i].Background = "Transparent";
                string s = StaticVar.inline._EnLetterList;
                StaticVar.inline._EnLetterList = s.Replace(_enLeters[i].ToString().ToLower(), string.Empty);
            }
            else
            {
                LetterList[i].Background = StaticVar.Green;
                StaticVar.inline._EnLetterList += _enLeters[i].ToString().ToLower();
            }
            NotifyPropertyChanged("letter" + i);
            _lockLetter = false;
        }

        private void DoClear(object obj)
        {
            base.ClearLetter();
            StaticVar.inline._EnLetterList = _enLeters.ToLower();
        }
    }
}
