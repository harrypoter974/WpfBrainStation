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
    public abstract class BaseBoardSyllablesVM : BasePageVM
    {
        public override string Name => "";
        public ICommand MouseMove { get; set; }
        public ICommand MouseDown { get; set; }
        public ICommand MouseUp { get; set; }
        public string Niqqud0 { get { return NiqqudList[0].Background; } set {NiqqudList[0].Background = value; }}
        public string Niqqud1 { get { return NiqqudList[1].Background; } set {NiqqudList[1].Background = value; }}
        public string Niqqud2 { get { return NiqqudList[2].Background; } set { NiqqudList[2].Background = value; } }
        protected LetterObject[] NiqqudList = new LetterObject[3];
        public string smailyPic { get; set; }
        public string VisibilityCard { get; set; }
        public int Column { get; set; }
        public int Row { get; set; }
        public string PicCard { get; set; }
        protected int IndexPage = 0;
        public string Letter { get; set; }
        public string TextCard {   get; set; }
        protected string[] Signals;

        public BaseBoardSyllablesVM()
        {
            for (int i = 0; i < NiqqudList.Length; i++)
                NiqqudList[i] = new LetterObject();
            MouseMove = new RelayCommand(DoMouseMove);
        }

        private void DoMouseMove(object obj)
        {
            string[] n = obj.ToString().Split('_');
            Row = int.Parse(n[1]);
            Column = int.Parse(n[0]);
            NotifyPropertyChanged(nameof(Row));
            NotifyPropertyChanged(nameof(Column));
        }
        internal void BaseClear()
        {
            TextCard = string.Empty;
            VisibilityCard = "Collapsed";
            NotifyPropertyChanged(nameof( VisibilityCard));
            NotifyPropertyChanged( nameof( TextCard)); 
            smailyPic = string.Empty;
            NotifyPropertyChanged(nameof(smailyPic));
            for (int i = 0; i < NiqqudList.Length; i++)
            {
                NiqqudList[i].Background = string.Empty;
                NotifyPropertyChanged("Niqqud" + i);
            }
        }
        public abstract void SetBord(string p,string letter, string location);


        internal abstract void ChackAnswer(string a);

    }
}
