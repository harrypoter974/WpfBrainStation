using CL.BS.Common;
using CL.BS.Contract;
using CL.BS.MEF;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using CL.BS.Model;
using CL.BS.VMCommon;
using System.ComponentModel.Composition;
using System.Windows.Controls;
using System.Windows.Input;
using UserInformationManager.Interface;

namespace CL.BS.UserInformationVM
{
    #region MEF
    [Export(typeof(IPageVM))]
    #endregion MEF
    public class  MenuNameVM: BaseMenuVM, IPageVM
    {
        private IMenuNameManager _logic = (IMenuNameManager)
    SupportHandlerManager.Base.GetManager("MenuNameManager");

        private string _preLetter = string.Empty;
        public override string Name => "MenuNameVM";
        private const string NAME_MESEG = "בחרת את : ";
        public string TextName { get; set; }
        public string GirlTitle { get; set; }
        public ICommand SelectName { get; set; }
        public ICommand SelectLetter { get; set; }
        public List<GameObject> LstName { get; set; }
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
        protected LetterObject[] LetterList = new LetterObject[Common.StaticVar.HeLetersList.Length - 5];

        public MenuNameVM()
        {
            SelectLetter = new VMCommon.RelayCommand(DoSelectLetter);
            for (int i = 0; i < LetterList.Length; i++)
                LetterList[i] =new LetterObject { Uid =Common.StaticVar.HeLetersList[i] };
            SelectName = new VMCommon.RelayCommand(DoSelectName);
        }

        void IPageVM.load()
        {
            base.Settings();
            LstName = new List<GameObject>();
            NotifyPropertyChanged("LstName");
            if (string.IsNullOrEmpty( StaticVar.inline.Name))
                TextName = "בחר שם";
            else
                TextName = NAME_MESEG + StaticVar.inline.Name.Replace("Nickname\\","");
            StaticVar.inline.IsBoy = StaticVar.SelectBoy == "Boy";
            GirlTitle = StaticVar.inline.IsBoy ? string.Empty : System.AppDomain.CurrentDomain.BaseDirectory+
                "Resources\\BS.Items\\GirlTitle.jpg";
            NotifyPropertyChanged("GirlTitle");
            NotifyPropertyChanged("TextName");
        }

        private void DoSelectLetter(object letter)
        {
            LstName = new List<GameObject>();
            foreach (string name in _logic.GetName(letter)) {
                GameObject b = new GameObject()  { Question=name  };
                LstName.Add(b);
            }
            NotifyPropertyChanged("LstName");

            string l = letter.ToString();
            for (int i = 0; i < LetterList.Length; i++)
            {
                if (LetterList[i].Uid==_preLetter)
                {
                    LetterList[i].Background = string.Empty;
                    NotifyPropertyChanged("LLetter" + ( i));
                }
                if (LetterList[i].Uid == l)
                {
                    LetterList[i].Background = System.AppDomain.CurrentDomain.BaseDirectory +
                        @"Resources\Languages\Hebrew\BlueLetters\B" +l+".png";
                    NotifyPropertyChanged("LLetter" + (i));
                }
            }
            _preLetter = l;
        }

        private void DoSelectName(object sender)
        {
            if (sender.ToString() == "Error")
                return;
            GameObject newBut = (GameObject)sender;

            TextName = NAME_MESEG + newBut.Question;
            NotifyPropertyChanged("TextName");
            if (_preLetter == "nickname")
            {
                StaticVar.inline.Name = "Nickname\\" + newBut.Question;
            }
            else
                StaticVar.inline.Name = newBut.Question;
            PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory + StaticVar.inline.PlayName());
        }
    }
}
