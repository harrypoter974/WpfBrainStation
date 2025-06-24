using CL.BS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.HebrewVM.VM.Reading
{
    public class BoardSyllables1VM: BaseBoardSyllablesVM
    {
        public string BackgroundPic { get; set; }
        private string[][] Niqqud;
        string _location;
        public BoardSyllables1VM()
        {
            Niqqud = new string[2][];
            Niqqud[0] = new string[] {  @"Resources\Lang\He\WhiteLetters\kubuts.png"
              ,  @"Resources\Lang\He\WhiteLetters\holamDot.png"
            ,  @"Resources\Lang\He\WhiteLetters\hirik.png",  @"Resources\Lang\He\WhiteLetters\tsere.png" ,
                            @"Resources\Lang\He\WhiteLetters\kamats.png"};
            Niqqud[1] = new string[] {@"Resources\Lang\He\WhiteLetters\shuruk.png"
              ,  @"Resources\Lang\He\WhiteLetters\holam male.png"
            ,  @"Resources\Lang\He\WhiteLetters\hirik.png",  @"Resources\Lang\He\WhiteLetters\segol.png" ,
                            @"Resources\Lang\He\WhiteLetters\patah.png" };
            MouseUp = new RelayCommand(DoMouseUp);
            MouseDown = new RelayCommand(DoMouseDown);
            BackgroundPic = String.Format(@"{0}\Resources\Lang\He\Niqqud\Niqqud1.png",
          System.AppDomain.CurrentDomain.BaseDirectory, IndexPage);
            NotifyPropertyChanged(nameof(BackgroundPic));
        }

        private void DoMouseDown(object obj)
        {
            for (int i = 0; i < NiqqudList.Length; i++)
            {
                NiqqudList[i].Background = string.Empty;
                NotifyPropertyChanged("Niqqud" + i);
            }
            string[] n = obj.ToString().Split('_');
            Row = int.Parse(n[1]);
            Column = int.Parse(n[0]);
            PicCard= TextCard = Signals[int.Parse(n[2])];
            NotifyPropertyChanged(nameof(Row));
            NotifyPropertyChanged(nameof(Column));
            NotifyPropertyChanged(nameof(PicCard));
            VisibilityCard = "Visible";
            NotifyPropertyChanged(nameof(VisibilityCard));
        }
        private void DoMouseUp(object obj)
        {
            int loc = int.Parse( obj.ToString());
            TextCard = TextCard;//.Replace("Niqqud", "WhiteLetters");
            NiqqudList[loc].Background = TextCard;
            NotifyPropertyChanged("Niqqud" + loc);
            VisibilityCard = "Collapsed";
            NotifyPropertyChanged(nameof( VisibilityCard));
        }
        public override void SetBord(string p, string letter, string location)
        {
            BaseClear();
            IndexPage =int.Parse(p);
            Signals =new  string[ Niqqud[IndexPage].Length];
            for (int i = 0; i < Signals.Length; i++)
                Signals[i] = System.AppDomain.CurrentDomain.BaseDirectory+ Niqqud[IndexPage][i];  
            BackgroundPic = String.Format(@"{0}\Resources\Lang\He\Niqqud\Niqqud{1}.png",
             System.AppDomain.CurrentDomain.BaseDirectory,IndexPage);
            NotifyPropertyChanged(nameof(BackgroundPic));
            Letter = letter; 
            NotifyPropertyChanged(nameof(Letter));
            _location = location;

        }
        internal override void ChackAnswer(string a)
        {
            bool b = TextCard == a;
            for (int i = 0; i < NiqqudList.Length; i++)
            {
                NiqqudList[i].Background = string.Empty;
                NotifyPropertyChanged("Niqqud" + i);
            }
            smailyPic = string.Format(@"{0}\Resources\BS.Items\{1}Smily.png"
, System.AppDomain.CurrentDomain.BaseDirectory, b ? "Happy" : "Sad");
            NotifyPropertyChanged("smailyPic");
            TextCard = a;
            int loc = int.Parse(_location);
            NiqqudList[loc].Background = TextCard;
            NotifyPropertyChanged("Niqqud" + loc);
        }
        internal void Clear()
        {
        }
    }
}
