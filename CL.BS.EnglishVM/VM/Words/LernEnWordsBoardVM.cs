using BS.Items;
using CL.BS.Common;
using CL.BS.Contract;
using CL.BS.EnglishManager.Interface.Words;
using CL.BS.HebrewManager.Interface.Writing;
using CL.BS.MEF;
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
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class LernEnWordsBoardVM  : BaseLernPage
    {

        private IEnLernWordsManager _logic = (IEnLernWordsManager)
SupportHandlerManager.Base.GetManager( "EnLernWordsManager");
        public double BoardHeight { get; set; }
        public double BoardWidth { get; set; }
        public string HappySmily { get; set; }
        public string TextColor { get; set; }
        public string TextWords { get; set; }
        public string AnswerText { get; set; }
        public double Speed { get; set; }
        public string BackgroundPic { get; set; }
        public string BackgroundWord { get; set; }
        public string WordPic { get; set; }
        public string MenuButton { get; set; }
        public bool KeyboardOpen{ get; set; }
        private string _AnswerText=string.Empty;
        public ICommand TypeLetter { get; set; }

        public override string Name => nameof(LernEnWordsBoardVM);

        public LernEnWordsBoardVM()
        {
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.272;// 0.463
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.413;//0.491
            NotifyPropertyChanged(nameof(BoardWidth));
            NotifyPropertyChanged(nameof(BoardHeight));

            TypeLetter = new Common.RelayCommand(DoTypeLetter);
            AnswerBut = new Common.RelayCommand(DoAnswerBut);
        }

        private void DoTypeLetter(object obj)
        {           
            if (obj.ToString() == "0")
            {
                if (TextWords.Length >= 1)
                    TextWords = TextWords.Remove(TextWords.Length - 1, 1);
            }
            else
                TextWords += obj.ToString()[0];
            NotifyPropertyChanged(nameof(TextWords));
        }


        protected void DoAnswerBut(object obj)
        {
            if (Common.StaticVar.PlayMode)
                return;
            if (base.IsQuestionMode)
            {
                new Thread(new ThreadStart(() =>
                {
                    KeyboardOpen = false;
                    NotifyPropertyChanged(nameof(KeyboardOpen));
                    HappySmily = string.Empty;
                    NotifyPropertyChanged(nameof(HappySmily));
                    _logic.SetWord(obj);
                    PlayUrl(_logic.getWordPlay());
                    base.SwitchAnswerButton();
                    WordPic = _logic.GetBackground();
                     _AnswerText = TextWords = _logic.getWord();
                    BackgroundWord = "#FF41AD48"; 
                    AnswerText = String.Empty;
                    NotifyPropertyChanged(nameof(BackgroundWord));
                    NotifyPropertyChanged(nameof(WordPic));
                    NotifyPropertyChanged(nameof(TextWords));
                    NotifyPropertyChanged(nameof(AnswerText));
                    bool g = true; 
                    WhitTime((int)(1000.0 * (5.2 - Speed)), ref g);
                    BackgroundWord= TextWords = string.Empty;
                    NotifyPropertyChanged(nameof(BackgroundWord));
                    NotifyPropertyChanged(nameof(TextWords));
                    TextColor = "Green";
                    NotifyPropertyChanged(nameof(TextColor));
                    WhitTime(2000, ref g);
                    TextColor = "White";
                    NotifyPropertyChanged(nameof(TextColor));
                    KeyboardOpen = true;
                    NotifyPropertyChanged(nameof(KeyboardOpen));
                   
                })).Start();
            }
            else
            {
                base.SwitchAnswerButton();
                KeyboardOpen = false;
                    NotifyPropertyChanged(nameof(KeyboardOpen));
                AnswerText = _AnswerText;
                HappySmily = string.Format(@"{0}Resources\BS.Items\{1}Smily.png",
 System.AppDomain.CurrentDomain.BaseDirectory, TextWords == _AnswerText ? "Happy" : "Sad");
                NotifyPropertyChanged(nameof(HappySmily));
                NotifyPropertyChanged(nameof(AnswerText));
            }
        }
    }
}
