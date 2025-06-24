using CL.BS.Contract;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Windows.Input;

namespace CL.BS.HebrewVM.VM.Reading
{
    public class BoardHeReadingExVM : BaseLernPage, IPageVM
    {
        public override string Name => "BoardHeReadingExVM";
        public string Letter0 { get { return LetterList[0].Background; } set { LetterList[0].Background = value; } }
        public string Letter1 { get { return LetterList[1].Background; } set { LetterList[1].Background = value; } }
        public string Letter2 { get { return LetterList[2].Background; } set { LetterList[2].Background = value; } }
        public string Letter3 { get { return LetterList[3].Background; } set { LetterList[3].Background = value; } }
        public string Letter4 { get { return LetterList[4].Background; } set { LetterList[4].Background = value; } }
        public string Letter5 { get { return LetterList[5].Background; } set { LetterList[5].Background = value; } }
        public string Letter6 { get { return LetterList[6].Background; } set { LetterList[6].Background = value; } }
        public string Letter7 { get { return LetterList[7].Background; } set { LetterList[7].Background = value; } }
        public string Letter8 { get { return LetterList[8].Background; } set { LetterList[8].Background = value; } }
        public string Letter9 { get { return LetterList[9].Background; } set { LetterList[9].Background = value; } }

        public string ALetter0 { get { return LetterList[0].Text; } set { LetterList[0].Text = value; } }
        public string ALetter1 { get { return LetterList[1].Text; } set { LetterList[1].Text = value; } }
        public string ALetter2 { get { return LetterList[2].Text; } set { LetterList[2].Text = value; } }
        public string ALetter3 { get { return LetterList[3].Text; } set { LetterList[3].Text = value; } }
        public string ALetter4 { get { return LetterList[4].Text; } set { LetterList[4].Text = value; } }
        protected LetterObject[] LetterList = new LetterObject[10]; 
        public ICommand MouseDown { get; set; }
        public ICommand MouseUp { get; set; }
        public int Column { get; set; }
        public int Row { get; set; }
        public string BackgroundPic { get; set; }
        public string PicWord { get; set; }
        public string SadSmily { get; set; }
        public string HappySmily { get; set; }
        protected int IndexPage = 0;
        private string[][] Letters;
        private int _wordLength=0;
        private int _pageIndex = 0;
        public BoardHeReadingExVM()
        {
            Letters = new string[7][];
            Letters[0] = new string[] {string.Empty , "pe_", "NunFinal", "Mem", "Lamedh", "Yodh", "Heth", "Holam", "Waw", "Bet" };  //{string.Empty ,"פ לא דגושה", "ן", "מ", "ל", "י", "ח", "חולם", "ו", "ב"  };
            Letters[1] = new string[] { "Resh", "Qoph", "Pe", "Ayin", "NunFinal", "Nun", "Holam", "Dalet", "Gimel_", "Bet" };           //{ "ר", "ק", "פ", "ע", "ן", "נ", "חולם", "ד", "ג לא דגושה", "ב" };
            Letters[2] = new string[] { "Resh", "NunFinal", "Nun", "Mem", "Lamedh", "Yodh", "Heth", "Holam", "Vet", "alef" };           //{ "ר", "ן", "נ", "מ", "ל", "י", "ח", "חולם", "ב לא דגושה", "א" };
            Letters[3] = new string[] { "Resh", "Tsade", "Samekh", "NunFinal", "Mem", "Lamedh", "Haph", "Heth", "Holam", "Gimel_" };           //{ "ר", "צ", "ס", "ן", "מ", "ל", "כ", "ח", "חולם", "ג לא דגושה" };
            Letters[4] = new string[] { "Taw", "Shin", "Resh", "Qoph", "Pe", "NunFinal", "Nun", "Yodh", "Heth", "shuruk" };                   //{ "ת", "ש", "ר", "ק", "פ", "ן", "נ", "י", "ח", "שורוק" };
            Letters[5] = new string[] { string.Empty , "Resh", "Pe", "NunFinal", "Zayin", "He", "Dalet", "Gimel_", "Gimel", "Bet" };     //{ string.Empty , "ר", "פ", "ן", "ז", "ה", "ד", "ג לא דגושה", "ג", "ב"};
            Letters[6] = new string[] { "Taw", "Sin", "Qoph", "PeFinal", "Tsade", "Samekh", "Lamedh", "Kaph", "Waw", "Vet" };            //{ "ת", "סין", "ק", "ף", "צ", "ס", "ל", "כ", "ו", "ב לא דגושה" };
            for (int i = 0; i < LetterList.Length; i++)
                LetterList[i] = new LetterObject();
            MouseMove = new RelayCommand(DoMouseMove);
            MouseUp = new RelayCommand(DoMouseUp);
            MouseDown = new RelayCommand(DoMouseDown);
            BackgroundPic = string.Format(@"{0}Resources\Lang\He\ExerciseReading3\UCBoardHeReadingEx5.png",
System.AppDomain.CurrentDomain.BaseDirectory);
            NotifyPropertyChanged(nameof(BackgroundPic));
        }

        private void DoMouseMove(object obj)
        {
            string[] n = obj.ToString().Split('_');
            Row = int.Parse(n[1]);
            Column = int.Parse(n[0]);
            NotifyPropertyChanged(nameof(Row));
            NotifyPropertyChanged(nameof(Column));
        }

        private void DoMouseUp(object obj)
        {
            int loc = int.Parse(obj.ToString());
            //if (loc==4)
            //    return;
            LetterList[loc].Text = PicCard.Replace("BlackLetters", "WhiteLetters");
            NotifyPropertyChanged("ALetter" + loc);
            VisibilityCard = "Collapsed";
            NotifyPropertyChanged(nameof(VisibilityCard));
        }

        private void DoMouseDown(object obj)
        {
            string[] n = obj.ToString().Split('_');
            Row = int.Parse(n[1]);
            Column = int.Parse(n[0]);
            int num = int.Parse(n[2]);
            if ( Letters[_pageIndex][num]==string.Empty)//num > _wordLength||
                return;
            PicCard = string.Format(@"{0}Resources\Lang\He\WhiteLetters\{1}.png",
                System.AppDomain.CurrentDomain.BaseDirectory, Letters[_pageIndex][num]);
            NotifyPropertyChanged(nameof(Row));
            NotifyPropertyChanged(nameof(Column));
            NotifyPropertyChanged(nameof(PicCard));
            VisibilityCard = "Visible";
            NotifyPropertyChanged(nameof(VisibilityCard));
        }
        public void SetBoard(int pageIndex,string word,int wordLength)
        {
            for (int i = 0; i < 5; i++)
            {
                LetterList[i].Text = string.Empty;
                NotifyPropertyChanged("ALetter" + i);
            }
            if (pageIndex >4)
            {
                BackgroundPic = string.Format(@"{0}Resources\Lang\He\ExerciseReading3\BoardReading{1}.png",
  System.AppDomain.CurrentDomain.BaseDirectory, pageIndex);
            NotifyPropertyChanged(nameof(BackgroundPic));
            }
            else
            {
                for (int i = 0; i < LetterList.Length; i++)
                {
                    LetterList[i].Background = string.Format(@"{0}Resources\Lang\He\WhiteLetters\{1}.png",
  System.AppDomain.CurrentDomain.BaseDirectory, Letters[pageIndex][i]);
                    NotifyPropertyChanged("Letter" + i);
                }
            }
            _wordLength = wordLength;
            _pageIndex = pageIndex;
            PicWord = word;
            HappySmily= SadSmily = string.Empty;
            NotifyPropertyChanged(nameof(PicWord));
            NotifyPropertyChanged(nameof(HappySmily));
            NotifyPropertyChanged(nameof(SadSmily));
        }
        public void CheckBord(string[] word)
        {
            bool b = true; 
            for (int i = 2; i < word.Length&&b; i++)
            {
                string[] wl = LetterList[i-2].Text.Split('\\');
                string l = wl[wl.Length - 1].Split('.')[0];
                b = l.Replace("_", String.Empty) == word[i].Replace("_",String.Empty);
            }
            if (_pageIndex>5)
            {

                HappySmily = string.Format(@"{0}\Resources\BS.Items\{1}Smily.png"
    , System.AppDomain.CurrentDomain.BaseDirectory, b ? "Happy" : "Sad");
                NotifyPropertyChanged(nameof(HappySmily));
            }
            else
            {
                HappySmily = b ? string.Format(@"{0}\Resources\BS.Items\HappySmily.png"
    , System.AppDomain.CurrentDomain.BaseDirectory) : string.Format(@"{0}\Resources\BS.Items\SadSmily.png"
    , System.AppDomain.CurrentDomain.BaseDirectory);
                NotifyPropertyChanged(nameof(HappySmily));
            }
        }
        public void Clear(int pageIndex)
        {

            for (int i = 0; i < 5; i++)
            {
                LetterList[i].Text = string.Empty;
                NotifyPropertyChanged("ALetter" + i);
            }
            if (pageIndex > 4)
            {
                BackgroundPic = string.Format(@"{0}Resources\Lang\He\ExerciseReading3\BoardReading{1}.png",
  System.AppDomain.CurrentDomain.BaseDirectory, pageIndex);
                NotifyPropertyChanged(nameof(BackgroundPic));
            }
            else
            {
                for (int i = 0; i < LetterList.Length; i++)
                {
                    LetterList[i].Background = string.Format(@"{0}Resources\Lang\He\WhiteLetters\{1}.png",
  System.AppDomain.CurrentDomain.BaseDirectory, Letters[pageIndex][i]);
                    NotifyPropertyChanged("Letter" + i);
                }
                NotifyPropertyChanged(nameof(BackgroundPic));
            }
            _pageIndex = pageIndex;
            VisibilityCard = "Collapsed";
            PicWord =  HappySmily = SadSmily = string.Empty;
            NotifyPropertyChanged(nameof(PicWord));
            NotifyPropertyChanged(nameof(HappySmily));
            NotifyPropertyChanged(nameof(SadSmily));
            NotifyPropertyChanged(nameof(VisibilityCard));
        }

    }
}
