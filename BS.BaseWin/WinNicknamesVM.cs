using CL.BS.Common;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace BS.BaseWin
{
    internal class WinNicknamesVM : BaseMenuVM
    {
        private MouseSplitter win;

        public WinNicknamesVM(MouseSplitter win)
        {
            this.win = win;
            SelectLetter = new CL.BS.VMCommon.RelayCommand(DoSelectLetter);
            SwitchGender = new CL.BS.VMCommon.RelayCommand(DoSwitchGender);
            for (int i = 0; i < LetterList.Length; i++)
            {
                LetterList[i] = new ViewObject { Uid = CL.BS.Common.StaticVar.HeLeters[i] };
            }
            StaticVar.SelectBoy = "Boy";
        }

        private void DoSwitchGender(object obj)
        {
            StaticVar.IsBoy = StaticVar.SelectBoy != "Boy";
            StaticVar.SelectBoy = StaticVar.IsBoy ? "Boy" : "Girl";
            GirlTitle = StaticVar.IsBoy ? string.Empty : System.AppDomain.CurrentDomain.BaseDirectory +
      "Resources\\BS.Items\\GirlTitle.jpg";
            NotifyPropertyChanged("GirlTitle");
        }

        private void DoSelectLetter(object letter)
        {
            LstProduct = logic.GetName(letter);
            for (int i = 0; i < LstProduct.Count; i++)
                LstProduct[i].Click += DoSelectName;
            NotifyPropertyChanged("LstProduct");
            preBut = null;
            string l = letter.ToString();
            for (int i = 0; i < LetterList.Length; i++)
            {
                if (LetterList[i].Uid == PreLetter[0])
                {
                    LetterList[i].Background = string.Empty;
                    NotifyPropertyChanged("LLetter" + (i));
                }
                if (LetterList[i].Uid == l[0])
                {
                    LetterList[i].Background = System.AppDomain.CurrentDomain.BaseDirectory +
                        @"Resources\Languages\Hebrew\BlueLetters\B" + l + ".png";
                    NotifyPropertyChanged("LLetter" + (i));
                }
            }
            PreLetter = l;
        }
        private NameEngine logic = new NameEngine();
        private void DoSelectName(object sender, System.Windows.RoutedEventArgs e)
        {
            Button newBut = (Button)sender;
            if (preBut != null)
                preBut.Foreground = Brushes.Black;
            preBut = newBut;
            newBut.Foreground = Brushes.Orange;
            string name = newBut.Content.ToString();
            switch (this.win.currentMouse.Rotation.ToString())
            {
                case "A": TextNameA = StaticVar.NicknameA = name; break;
                case "B": TextNameB = StaticVar.NicknameB = name; break;
                case "C": TextNameC = StaticVar.NicknameC = name; break;
                case "D": TextNameD = StaticVar.NicknameD = name; break;
                default:
                    break;
            }
            NotifyPropertyChanged("TextName" + this.win.currentMouse.Rotation);
            StaticVar.Name = newBut.Content.ToString();
            StaticVar.IsBoy = StaticVar.SelectBoy == "Boy";
            PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory + StaticVar.PlayName());
        }
        private Button preBut;
        private string PreLetter = "q";
        public override string Name => "MenuNameVM";
        private const string NAME_MESEG = "בחרת את : ";
        public string TextNameA { get; set; }
        public string TextNameB { get; set; }
        public string TextNameC { get; set; }
        public string TextNameD { get; set; }
        public string GirlTitle { get; set; }
        public ICommand SelectLetter { get; set; }
        public ICommand SwitchGender { get; set; }
        public List<Button> LstProduct { get; set; }
        public string LLetter0 { get { return LetterList[0].Background; } set { LetterList[0].Background = value; } }
        public string LLetter1 { get { return LetterList[1].Background; } set { LetterList[1].Background = value; } }
        public string LLetter2 { get { return LetterList[2].Background; } set { LetterList[2].Background = value; } }
        public string LLetter3 { get { return LetterList[3].Background; } set { LetterList[3].Background = value; } }
        public string LLetter4 { get { return LetterList[4].Background; } set { LetterList[4].Background = value; } }
        public string LLetter5 { get { return LetterList[5].Background; } set { LetterList[5].Background = value; } }
        public string LLetter6 { get { return LetterList[6].Background; } set { LetterList[6].Background = value; } }
        public string LLetter7 { get { return LetterList[7].Background; } set { LetterList[7].Background = value; } }
        public string LLetter8 { get { return LetterList[8].Background; } set { LetterList[8].Background = value; } }
        public string LLetter9 { get { return LetterList[9].Background; } set { LetterList[9].Background = value; } }
        public string LLetter10 { get { return LetterList[10].Background; } set { LetterList[10].Background = value; } }
        public string LLetter11 { get { return LetterList[11].Background; } set { LetterList[11].Background = value; } }
        public string LLetter12 { get { return LetterList[12].Background; } set { LetterList[12].Background = value; } }
        public string LLetter13 { get { return LetterList[13].Background; } set { LetterList[13].Background = value; } }
        public string LLetter14 { get { return LetterList[14].Background; } set { LetterList[14].Background = value; } }
        public string LLetter15 { get { return LetterList[15].Background; } set { LetterList[15].Background = value; } }
        public string LLetter16 { get { return LetterList[16].Background; } set { LetterList[16].Background = value; } }
        public string LLetter17 { get { return LetterList[17].Background; } set { LetterList[17].Background = value; } }
        public string LLetter18 { get { return LetterList[18].Background; } set { LetterList[18].Background = value; } }
        public string LLetter19 { get { return LetterList[19].Background; } set { LetterList[19].Background = value; } }
        public string LLetter20 { get { return LetterList[20].Background; } set { LetterList[20].Background = value; } }
        public string LLetter21 { get { return LetterList[21].Background; } set { LetterList[21].Background = value; } }
        public string LLetter22 { get { return LetterList[22].Background; } set { LetterList[22].Background = value; } }
        protected ViewObject[] LetterList = new ViewObject[CL.BS.Common.StaticVar.HeLeters.Length - 5];

    }
}