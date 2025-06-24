using BS.Items.Properties;
using CL.BS.Contract;
using CL.BS.HebrewManager.Interface.Recognition;
using CL.BS.MEF;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CL.BS.HebrewVM.VM.Recognition
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class RecognaseLeters1VM : RecognaseLeters, IPageVM
    {
        private IRecognaseLetersManager _logic = (IRecognaseLetersManager)
SupportHandlerManager.Base.GetManager("RecognaseLetersManager");
        public ICommand OpenMenu { get; set; }
        public ICommand TypeLetter { get; set; }
        public ICommand selectAPlayer { get; set; }
        public ICommand levelChange { get; set; }
        public string levelChangePic { get; set; }
        public string Text0 { get { return _letterList[0].Background; } set { _letterList[0].Background = value; } }
        public string Text1 { get { return _letterList[1].Background; } set { _letterList[1].Background = value; } }
        public string Text2 { get { return _letterList[2].Background; } set { _letterList[2].Background = value; } }
        public string Text3 { get { return _letterList[3].Background; } set { _letterList[3].Background = value; } }


        public Visibility HappySmily0 { get { return _letterList[0].ItemsVisible; } set { _letterList[0].ItemsVisible = value; } }
        public Visibility HappySmily1 { get { return _letterList[1].ItemsVisible; } set { _letterList[1].ItemsVisible = value; } }
        public Visibility HappySmily2 { get { return _letterList[2].ItemsVisible; } set { _letterList[2].ItemsVisible = value; } }
        public Visibility HappySmily3 { get { return _letterList[3].ItemsVisible; } set { _letterList[3].ItemsVisible = value; } }
        public Visibility SadSmily0 { get { return _letterList[0].LineVisible; } set { _letterList[0].LineVisible = value; } }
        public Visibility SadSmily1 { get { return _letterList[1].LineVisible; } set { _letterList[1].LineVisible = value; } }
        public Visibility SadSmily2 { get { return _letterList[2].LineVisible; } set { _letterList[2].LineVisible = value; } }
        public Visibility SadSmily3 { get { return _letterList[3].LineVisible; } set { _letterList[3].LineVisible = value; } }

        public string LetterPic { get; set; }
        public string OpenMenuBut { get; set; }
        public string SadSmily { get; set; }
        public string HappySmily { get; set; }
        public double KeyboardWidth { get; set; }
        public double KeyboardHeight { get; set; }
        private string _letter = string.Empty;
        private bool _isEndLetter = false;
        private string[] _Question;
        protected ItemObject[] _letterList = new ItemObject[4];
        public override string Name
        {
            get
            {
                return "RecognaseLeters1VM";
            }
        }

        public RecognaseLeters1VM()
        {
            for (int i = 0; i < _letterList.Length; i++)
                _letterList[i] = new ItemObject() { ItemsVisible = Visibility.Hidden, LineVisible = Visibility.Hidden };
            OpenMenu = new RelayCommand(DoOpenMenu);
            TypeLetter = new RelayCommand(DoTypeLetter);
            selectAPlayer = new RelayCommand(DoselectAPlayer);
            AnswerBut = new RelayCommand(DoAnswerBut);
            OpenMenu = new RelayCommand(DoOpenMenu);
            levelChange = new RelayCommand(DolevelChange);

            KeyboardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.27;
            KeyboardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.06;
            NotifyPropertyChanged(nameof(KeyboardWidth));
            NotifyPropertyChanged(nameof(KeyboardHeight));
            SadSmily = System.AppDomain.CurrentDomain.BaseDirectory
                 + @"Resources\BS.Items\SadSmily.png";
            HappySmily = System.AppDomain.CurrentDomain.BaseDirectory
                 + @"Resources\BS.Items\HappySmily.png";
            NotifyPropertyChanged(nameof( SadSmily));
            NotifyPropertyChanged(nameof(HappySmily));
        }

        private void DolevelChange(object obj)
        {
            _isEndLetter = !_isEndLetter;
            if (_isEndLetter)
            {
                levelChangePic = System.AppDomain.CurrentDomain.BaseDirectory
                 + @"Resources\Lang\He\Recognition\closingLetter.jpg";
            }
            else
                levelChangePic = string.Empty;
            NotifyPropertyChanged("levelChangePic");
        }

        private void DoTypeLetter(object obj)
        {
            _letter = obj.ToString();
        }

        private void DoselectAPlayer(object obj)
        {
            int sp = int.Parse(obj.ToString());
            _letterList[sp].Background =String.Format(@"{0}Resources\Lang\He\BlackLetters\{1}.png"
, System.AppDomain.CurrentDomain.BaseDirectory , _letter);
            NotifyPropertyChanged("Text" + sp);

        }
        private void DoOpenMenu(object obj)
        {
           WinHeSettingsLetters win= new WinHeSettingsLetters(obj);
            OpenMenuBut = System.AppDomain.CurrentDomain.BaseDirectory
            + @"Resources\BS.Items\ChooseLetters.jpg";
            NotifyPropertyChanged("OpenMenuBut");
            win.Closed += Win_Closed;
            win.ShowDialog();
            _logic.ClearList();
        }

        private void Win_Closed(object sender, EventArgs e)
        {
            _logic.SetLetter();
              OpenMenuBut = string.Empty;
            NotifyPropertyChanged("OpenMenuBut");
        }

        void IPageVM.load()
        {
            base.Settings();
            new Thread(new ThreadStart(() =>
            {
                PlayList(_logic.PlayMessage());
            })).Start();
        }

        private void DoAnswerBut(object obj)
        {
            if (Common.StaticVar.PlayMode)
                return;
            if (base.IsQuestionMode)
            {
                _Question = _logic.SetQuestion(_isEndLetter);
                LetterPic = System.AppDomain.CurrentDomain.BaseDirectory 
                    + @"Resources\Lang\He\Recognition\Image\"
+ _Question[0] + ".png";
                if (!File.Exists(LetterPic))
                    return;
                NotifyPropertyChanged("LetterPic");
                for (int i = 0; i < _letterList.Length; i++)
                {
                    _letterList[i].Background = string.Empty;
                    _letterList[i].ItemsVisible = _letterList[i].LineVisible = Visibility.Hidden;
                    NotifyPropertyChanged("SadSmily" + i);
                    NotifyPropertyChanged("HappySmily" + i);
                    NotifyPropertyChanged("Text" + i);
                }
            }
            else
            {
                new Thread(new ThreadStart(() =>
                {
                PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory + _Question[1]);
                })).Start();
                LetterPic = System.AppDomain.CurrentDomain.BaseDirectory
     + @"Resources\Lang\He\Recognition\Words\"+ _Question[0] + ".png";
                NotifyPropertyChanged("LetterPic");
                string l = _Question[0].ToString();
                if (_isEndLetter)
                {
                    switch (l)
                    {
                        case "מ": l = "ם"; break;
                        case "נ": l = "ן"; break;
                        case "צ":l = "ץ"; break;
                        case "פ": l = "ף"; break;
                        case "כ": l = "ך"; break;
                        default:
                            break;
                    }
                }
                for (int i = 0; i < _letterList.Length; i++)
                {
                    string[] letter = _letterList[i].Background.Split('\\');
                    if (letter[letter.Length-1].Split('.')[0] == l.Remove(l.Length - 1, 1))
                    {
                        _letterList[i].ItemsVisible = Visibility.Visible;
                        _letterList[i].LineVisible = Visibility.Hidden;
                        NotifyPropertyChanged("SadSmily" + i);
                        NotifyPropertyChanged("HappySmily" + i);
                    }
                    else
                    {

                        _letterList[i].ItemsVisible = Visibility.Hidden;
                        _letterList[i].LineVisible = Visibility.Visible;
                        NotifyPropertyChanged("SadSmily" + i);
                        NotifyPropertyChanged("HappySmily" + i);
                    }
                    _letterList[i].Background = String.Format(@"{0}Resources\Lang\He\BlackLetters\{1}.png"
, System.AppDomain.CurrentDomain.BaseDirectory, l); 
                    NotifyPropertyChanged("Text" + i);
                }
            }
            base.SwitchAnswerButton();
        }
    }
}
