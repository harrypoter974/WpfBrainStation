using CL.BS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BS.Items.VM
{
    class HeSettingsLettersVM: BaseSettingsLetters
    {
        public string TitlePic { get; set; }
        public ICommand IsManuscript { get; set; }
        public string IsManuscriptBut { get; set; }
        public HeSettingsLettersVM(object name )
        {
          List < string> s = StaticVar.inline._HeLetterList;
            for (int i = 0; i < LetterList.Length; i++)
            {
                if (i < CL.BS.Common.StaticVar.HeLeters.Length)
                {
                    LetterList[i] = new ViewObject()
                    {
                        Letter = string.Format(@"{0}Resources\Lang\He\{1}\{2}.png"
    , System.AppDomain.CurrentDomain.BaseDirectory, StaticVar.inline._HeIsManuscript ?
    "ManuscriptLetters" : "BlackLetters", StaticVar.HeLeters[i]),
                        Background = s.Contains(CL.BS.Common.StaticVar.HeLeters[i]) ? StaticVar.Green : "Transparent"
                    };
                }
                else
                    LetterList[i] = new ViewObject();

            }
            IsManuscript = new RelayCommand(DoIsManuscript);
            Clear = new RelayCommand(DoClear);
            letterType = new RelayCommand(DoletterType);
            TitlePic = System.AppDomain.CurrentDomain.BaseDirectory
               + @"Resources\Languages\Hebrew\Game\" + name+ ".jpg";
            NotifyPropertyChanged("TitlePic");
            SetWin();
        }

        internal bool Have5()
        {
            return StaticVar.inline._HeLetterList.Count >=5|| StaticVar.inline._HeLetterList.Count==0;
        }

        private void DoIsManuscript(object obj)
        {
            bool b = !StaticVar.inline._HeIsManuscript;
            StaticVar.inline._HeIsManuscript = b;
            SetWin();
        }

        private void SetWin()
        {
            IsManuscriptBut = StaticVar.inline._HeIsManuscript ? string.Empty :
                System.AppDomain.CurrentDomain.BaseDirectory +  @"Resources\BS.Items\IsManuscriptBut.png"  ;
            NotifyPropertyChanged(nameof(IsManuscriptBut));
            for (int i = 0; i < CL.BS.Common.StaticVar.HeLeters.Length; i++)
            {
                LetterList[i].Letter = string.Format(@"{0}Resources\Lang\He\{1}\{2}.png"
, System.AppDomain.CurrentDomain.BaseDirectory,StaticVar.inline._HeIsManuscript ?
"ManuscriptLetters" : "BlackLetters",  StaticVar.HeLeters[i]);
//StaticVar.HeLetersList);
                NotifyPropertyChanged("letterPic" + i);
            }  
        }
        private void DoletterType(object obj)
        {
            if (_lockLetter)
                return;
            _lockLetter = true;
            int i= 0;
            string num = obj.ToString();
            for ( ; i < CL.BS.Common.StaticVar.HeLeters.Length; i++)
            {
                if (CL.BS.Common.StaticVar.HeLeters[i] == num)
                    break;
            }
            if (LetterList[i].Background == StaticVar.Green)
            {
                LetterList[i].Background = "Transparent";
                StaticVar.inline._HeLetterList.Remove(obj.ToString());
            }
            else
            {
                LetterList[i].Background = StaticVar.Green;
                StaticVar.inline._HeLetterList.Add(obj.ToString());
            }
            NotifyPropertyChanged("letter" + i);
            _lockLetter = false;
        }

        private void DoClear(object obj)
        {
            base.ClearLetter();
            StaticVar.inline._HeLetterList =new List<string>(StaticVar.HeLetersList);
        }
    }
}
