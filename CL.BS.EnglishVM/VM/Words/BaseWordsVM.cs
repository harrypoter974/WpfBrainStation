
using BS.Items;
using CL.BS.Contract;
using CL.BS.EnglishManager.Interface.Text;
using CL.BS.MEF;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.EnglishVM.Words
{
    public class BaseWordsVM : BaseLernPage, IPageVM
    {
        private IEnWriteLetterManager _logic = (IEnWriteLetterManager)
        SupportHandlerManager.Base.GetManager("EnWriteLetterManager");
        protected virtual void ChooseWord() { }
        protected string[] WordList;
        protected string GropeName;
        protected bool IsLarnMode = true;
        protected string SelectedWord = string.Empty;
        public string SliderColor { get; set; }
        public string TextWords { get; set; }
        public double Speed { get; set; }
        public string PicWord { get; set; }
        public override string Name => "";
        public ICommand ChangeWord { get; set; }
        public ICommand SwitchToLarne { get; set; }
        public string BackgroundToLarneButton { get; set; }
        public string BackgroundBordWords { get; set; }
        public string SelectedNum { get; set; }
        public string IsExercise { get; set; }
        public List<ItemObject> LstWords { get; set; }

        public BaseWordsVM(string GropeName)
        {
            this.GropeName = GropeName;
            AnswerBut = new RelayCommand(DoAnswerBut);
            SwitchToLarne = new RelayCommand(DoSwitchToLarneBackground);
            SliderColor = System.AppDomain.CurrentDomain.BaseDirectory +
                    @"Resources\BS.Items\SliderBlue.bmp";
            IsExercise = "Collapsed";
            NotifyPropertyChanged("SliderColor");
            NotifyPropertyChanged("IsExercise");
        }

        void IPageVM.load()
        {
            base.Settings();
            if (!Common.StaticVar.inline.IsBoy)
            {
                messagePic = System.AppDomain.CurrentDomain.BaseDirectory
                 + @"Resources\Lang\He\Writing\message.png";
            }
            else
                messagePic = string.Empty;
            NotifyPropertyChanged("messagePic");
            if (!base.IsQuestionMode)
                base.SwitchAnswerButton();
            ChooseWord();
        }

        protected void DoAnswerBut(object obj)
        {
            if (Common.StaticVar.PlayMode)
                return;
            if (false)
            {
                if (base.IsQuestionMode)
                {
                    if (string.IsNullOrEmpty(PicWord))
                        return;
                    new Thread(new ThreadStart(() =>
                    {
                        PleyInstructions();
                        base.SwitchAnswerButton();
                        BackgroundBordWords = string.Empty;
                        NotifyPropertyChanged("BackgroundBordWords");
                        LstWords = _logic.WriteName(SelectedWord);
                        NotifyPropertyChanged("LstWords");
                        for (int i = 0; !base.IsQuestionMode && i < SelectedWord.Length; i++)
                        {
                            for (int j = 0; !base.IsQuestionMode; j++)
                            {
                                Thread.Sleep((int)(150.0 * (5.6 - Speed)));
                                string back = string.Empty;
                                if (LstWords.Count() == 0 || _logic.SetLetter(ref back, SelectedWord[i], j, i == 0))
                                    break;
                                LstWords[i] = new ItemObject { Background = back };
                                LstWords = new List<ItemObject>(LstWords);
                                NotifyPropertyChanged("LstWords");
                            }
                        }
                        BackgroundBordWords = System.AppDomain.CurrentDomain.BaseDirectory
                    + @"Resources\BS.Items\WhiteBoardLong.jpg";
                        NotifyPropertyChanged("BackgroundBordWords");
                        if (!base.IsQuestionMode)
                            base.SwitchAnswerButton();
                    })).Start();
                }
                else
                    base.SwitchAnswerButton();
            }
            else//text revil
            {
                if (base.IsQuestionMode)
                {
                    //
                    new Thread(new ThreadStart(() =>
                    {
                        PleyInstructions();
                        base.SwitchAnswerButton();
                        TextWords = SelectedWord;
                        NotifyPropertyChanged("TextWords");
                        Thread.Sleep((int)(1000.0 * (5.2 - Speed)));
                        TextWords = string.Empty;
                        NotifyPropertyChanged("TextWords");
                    })).Start();
                }
                else
                {
                    base.SwitchAnswerButton();
                    new Thread(new ThreadStart(() =>
                    {
                        string word = TextWords = SelectedWord;
                        NotifyPropertyChanged("TextWords");
                        bool b = true;
                        WhitTime(5000, ref b);
                        if (word == SelectedWord)
                        {
                            PicWord = TextWords = string.Empty;
                            NotifyPropertyChanged("TextWords");
                            NotifyPropertyChanged("PicWord");
                        }
                    })).Start();
                }
            }
        }

        private void PleyInstructions()
        {
            string selectedWord = SelectedWord == "Light blue" ? "LightBlue" : SelectedWord;
            string word = GropeName == "Numbers" ? SelectedNum : selectedWord;
            PlayList(new string[]{ Common.StaticVar.inline.PlayName(),
                        @"Resources\Audio\En\Verbs\WriteShort.wav",
                        @"Resources\Audio\En\"+ GropeName+"\\"+ word + ".wav"});
           WhitAntilPlayStop (ref base.IsQuestionMode);
        }

        private void DoSwitchToLarneBackground(object obj)
        {
            if (Common.StaticVar.PlayMode)
                return;
            if(!base.IsQuestionMode)
                base.SwitchAnswerButton();

            IsLarnMode = !IsLarnMode;
            if (IsLarnMode)
            {
                BackgroundToLarneButton = string.Empty;
                TextWords = string.Empty;
                NotifyPropertyChanged("TextWords");
                SliderColor =
                System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\BS.Items\SliderBlue.bmp";
                IsExercise = "Collapsed";
                NotifyPropertyChanged("IsExercise");
            }
            else
            {
                LstWords = new List<ItemObject>();
                NotifyPropertyChanged("LstWords");
                BackgroundToLarneButton =
                System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\BS.Items\ToLarneButton.jpg";
                SliderColor =
                System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\BS.Items\SliderBlue.bmp";
                IsExercise = "Visible";
                NotifyPropertyChanged("IsExercise");
                BackgroundBordWords = System.AppDomain.CurrentDomain.BaseDirectory
                + @"Resources\BS.Items\WhiteBoardLong.jpg";
                NotifyPropertyChanged("BackgroundBordWords");
            }
            NotifyPropertyChanged("SliderColor");
            NotifyPropertyChanged("BackgroundToLarneButton");
        }
    }
}
