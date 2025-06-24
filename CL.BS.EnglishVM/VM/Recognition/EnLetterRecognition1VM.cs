using BS.Items;
using CL.BS.Contract;
using CL.BS.Database;
using CL.BS.EnglishManager.Interface.Recognition;
using CL.BS.MEF;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CL.BS.HebrewVM.Game.BS.EnglishVM.Recognition
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class EnLetterRecognition1VM : BaseLernPage, IPageVM
    {
        public ICommand OpenMenu { get; set; }
        public ICommand TypeLetter { get; set; }
        public ICommand selectAPlayer { get; set; }
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
        public string SadSmily   { get; set; }
        public string HappySmily { get; set; }
        public double KeyboardWidth { get; set; }
        public double KeyboardHeight { get; set; }
        private string _letter = string.Empty;
        private string[] _Question;
        protected ItemObject[] _letterList = new ItemObject[4];
        public override string Name
        {
            get
            {
                return nameof(EnLetterRecognition1VM);
            }
        }
        IEnLetterRecognitionManager _logic = (IEnLetterRecognitionManager)
   SupportHandlerManager.Base.GetManager("EnLetterRecognitionManager");

        public EnLetterRecognition1VM()
        {
            for (int i = 0; i < _letterList.Length; i++)
                _letterList[i] = new ItemObject() { ItemsVisible=Visibility.Hidden,LineVisible=Visibility.Hidden};
            AnswerBut = new RelayCommand(DoAnswerBut);
            OpenMenu = new RelayCommand(DoOpenMenu);
            TypeLetter = new RelayCommand(DoTypeLetter);
            selectAPlayer = new RelayCommand(DoselectAPlayer);
            KeyboardWidth = System.Windows.SystemParameters.PrimaryScreenWidth *0.27 ;
            KeyboardHeight = System.Windows.SystemParameters.PrimaryScreenHeight *0.06 ;
            NotifyPropertyChanged(nameof(KeyboardWidth));
            NotifyPropertyChanged(nameof(KeyboardHeight));
            SadSmily = System.AppDomain.CurrentDomain.BaseDirectory
                 + @"Resources\BS.Items\SadSmily.png";
            HappySmily = System.AppDomain.CurrentDomain.BaseDirectory
                 + @"Resources\BS.Items\HappySmily.png";
            NotifyPropertyChanged(nameof(SadSmily));
             NotifyPropertyChanged(nameof(HappySmily));

        }

        private void DoTypeLetter(object obj)
        {
            _letter=obj.ToString().ToUpper();
        }

        private void DoselectAPlayer(object obj)
        {
           int sp=int.Parse(obj.ToString());
            _letterList[sp].Background = _letter;
            NotifyPropertyChanged("Text" + sp);

        }

        private void DoOpenMenu(object obj)
        {
            WinEnSettingsLetters win = new WinEnSettingsLetters();
            OpenMenuBut = System.AppDomain.CurrentDomain.BaseDirectory
                 + @"Resources\BS.Items\ChooseLetters.jpg";
            NotifyPropertyChanged(nameof(OpenMenuBut));
            win.Closed += Win_Closed;
            win.ShowDialog();
            _logic.ClearList();
        }

        private void Win_Closed(object sender, EventArgs e)
        {
            OpenMenuBut = string.Empty;
            NotifyPropertyChanged(nameof(OpenMenuBut));
        }

        private void DoAnswerBut(object obj)
        {
            if (Common.StaticVar.PlayMode)
                return;
            if (base.IsQuestionMode)
            {
                _Question = _logic.SetQuestion();
                LetterPic = System.AppDomain.CurrentDomain.BaseDirectory +
                 @"Resources\Lang\En\Recognition\Image\"
+ _Question[0] + ".jpg";                      
                NotifyPropertyChanged(nameof(LetterPic));
                for (int i = 0; i < _letterList.Length; i++)
                {
                    _letterList[i].Background=string.Empty;
                    _letterList[i].ItemsVisible=_letterList[i].LineVisible= Visibility.Hidden;
                    NotifyPropertyChanged("SadSmily" + i);
                    NotifyPropertyChanged("HappySmily" + i);
                    NotifyPropertyChanged("Text" + i);
                }
            }
            else
            { 
                new Thread(new ThreadStart(() =>
                {  PlayUrl(_Question[1]);})).Start();
                LetterPic = System.AppDomain.CurrentDomain.BaseDirectory +
            @"Resources\Lang\En\Recognition\Words\" + _Question[0] + ".png";
                NotifyPropertyChanged(nameof(LetterPic));
                string l = _logic.GetLetter();
                for (int i = 0; i < _letterList.Length; i++)
                {
                    if (_letterList[i].Background == l)
                    {
                        _letterList[i].ItemsVisible =  Visibility.Visible;
                        _letterList[i].LineVisible = Visibility.Hidden;
                        NotifyPropertyChanged("SadSmily" + i);
                        NotifyPropertyChanged("HappySmily" + i);
                    }
                    else
                    {

                        _letterList[i].ItemsVisible = Visibility.Hidden ;
                        _letterList[i].LineVisible =Visibility.Visible;
                        NotifyPropertyChanged("SadSmily" + i);
                        NotifyPropertyChanged("HappySmily" + i);
                    }
                    _letterList[i].Background = l;
                    NotifyPropertyChanged("Text"+i);
                }
            }
            base.SwitchAnswerButton();
        }
        void IPageVM.load()
        {
            _startTime=DateTime.Now;
            base.Settings();
        }
        void IPageVM.disload()
        {
            DatabaseManager.Inline.SaveActivity(4, _startTime, DateTime.Now,
           Name, "LERM", "", "E", 0);
        }
    }
}
