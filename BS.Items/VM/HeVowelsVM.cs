using CL.BS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Items.VM
{
    internal class HeVowelsVM : BaseSettingsLetters
    {
        public HeVowelsVM()
        {
            string []s = StaticVar.inline.HeVowels;
            for (int i = 0; i < 9; i++)
            {
                LetterList[i] = new ViewObject()
                {
                    Background = StaticVar.inline._HeVowels.Contains<string>(s[i])? "Transparent"  :  "#7F32DFFF"
                };
            }
            Clear = new RelayCommand(DoClear);
            letterType = new RelayCommand(DoletterType);
        }

        internal bool IsMoreThen2(bool isMoreTenn3=false)
        {
            int num = 0;
            for (int i = 0; i < 9; i++)
            {
                if(LetterList[i]. Background =="Transparent" )
                    num++;
            }
            return isMoreTenn3?num>2: num >1;
        }

        private void DoClear(object obj)
        {
            StaticVar.inline._HeVowels = new List<string>(StaticVar.inline.HeVowels);
            for (int i = 0; i < 9; i++)
            {
                LetterList[i].Background = "#7F32DFFF";
            NotifyPropertyChanged("letter" + i);
            }
        }

        private void DoletterType(object obj)
        {
            int l=int.Parse(obj.ToString());
            if (StaticVar.inline._HeVowels.Contains<string>(StaticVar.inline.HeVowels[l])) {
                if(IsMoreThen2(true))
                    StaticVar.inline._HeVowels.Remove(StaticVar.inline.HeVowels[l]); 
            }
            else
                StaticVar.inline._HeVowels.Add(StaticVar.inline.HeVowels[l]);
            LetterList[l].Background = StaticVar.inline._HeVowels.Contains<string>(StaticVar.inline.HeVowels[l])
                ?"Transparent"  :   "#7F32DFFF";
            NotifyPropertyChanged("letter" + l);
        }
    }
}
