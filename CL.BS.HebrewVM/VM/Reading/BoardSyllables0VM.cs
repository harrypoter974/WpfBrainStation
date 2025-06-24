using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.HebrewVM.VM.Reading
{
    public class BoardSyllables0VM : BaseBoardSyllablesVM
    {
        public string Letter0 { get { return LetterList[0].Background; } set { LetterList[0].Background = value; } }
        public string Letter1 { get { return LetterList[1].Background; } set { LetterList[1].Background = value; } }
        public string Letter2 { get { return LetterList[2].Background; } set { LetterList[2].Background = value; } }
        public string Letter3 { get { return LetterList[3].Background; } set { LetterList[3].Background = value; } }
        public string Letter4 { get { return LetterList[4].Background; } set { LetterList[4].Background = value; } }
        public string Letter5 { get { return LetterList[5].Background; } set { LetterList[5].Background = value; } }
        public string Letter6 { get { return LetterList[6].Background; } set { LetterList[6].Background = value; } }
        public string Letter7 { get { return LetterList[7].Background; } set { LetterList[7].Background = value; } }
        public string Letter8 { get { return LetterList[8].Background; } set { LetterList[8].Background = value; } }
        protected LetterObject[] LetterList = new LetterObject[9];
        private string[][] Letters;
        public BoardSyllables0VM()
        {
            Letters = new string[3][];
            Letters[0] = new string[] { "Yodh", "Teth", "Heth", "Zayin", "Dalet", "Gimel", "Vet","Bet","alef"};
            Letters[1] = new string[] { "Resh", "Samekh", "Nun", "Mem", "Lamedh", "Haph", "Kaph", "Waw", "He" };
            Letters[2] = new string[] { String.Empty, "Taw", "Sin", "Shin", "Qoph", "Tsade", "pe_", "Pe", "Ayin" };
            for (int i = 0; i < LetterList.Length; i++)
                LetterList[i] = new LetterObject();
            MouseUp = new RelayCommand(DoMouseUp);
            MouseDown = new RelayCommand(DoMouseDown);
        }


        private void DoMouseUp(object obj)
        {
            Letter = String.Format(@"{0}\Resources\Lang\He\WhiteLetters\{1}.png",
             System.AppDomain.CurrentDomain.BaseDirectory,TextCard );  
            NotifyPropertyChanged(nameof(Letter));
            VisibilityCard = "Collapsed";
            NotifyPropertyChanged(nameof(VisibilityCard));
        }
        public override void SetBord(string p, string letter, string location)
        {
            BaseClear();
            IndexPage =int.Parse( p);
            Signals = Letters[IndexPage];
            for (int i = 0; i < Letters[0].Length; i++)
            {
                LetterList[i].Background = String.Format(@"{0}\Resources\Lang\He\WhiteLetters\{1}.png",
             System.AppDomain.CurrentDomain.BaseDirectory, Signals[i]);
                NotifyPropertyChanged("Letter" + i);               
            }
            Letter = string.Empty  ;
            NotifyPropertyChanged(nameof(Letter));
            int loc=int.Parse(location);
            NiqqudList[loc].Background = letter;
            NotifyPropertyChanged("Niqqud" + loc);
        }


        private void DoMouseDown(object obj)
        {
            string[] n = obj.ToString().Split('_');
            Row = int.Parse(n[1]);
            Column = int.Parse(n[0]);
            TextCard = Signals[int.Parse(n[2])];
            PicCard = String.Format(@"{0}\Resources\Lang\He\WhiteLetters\{1}.png",
             System.AppDomain.CurrentDomain.BaseDirectory, TextCard);
            NotifyPropertyChanged(nameof(Row) );
            NotifyPropertyChanged(nameof(Column));
            NotifyPropertyChanged(nameof(PicCard));
            VisibilityCard = "Visible";
            NotifyPropertyChanged(nameof(VisibilityCard));
        }
        internal override void ChackAnswer(string a)
        {
            a = a.Trim();
            bool b = TextCard == a;
            smailyPic = string.Format(@"{0}\Resources\BS.Items\{1}Smily.png"
, System.AppDomain.CurrentDomain.BaseDirectory, b ? "Happy" : "Sad");
            NotifyPropertyChanged(nameof(smailyPic));
            TextCard = a;
            NotifyPropertyChanged(nameof(TextCard));
        }

        internal void Clear()
        {
            BaseClear();
        }
    }
}
