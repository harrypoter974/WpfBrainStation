using CL.BS.HebrewManager.Interface.Writing;
using CL.BS.MEF;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.HebrewVM.VM.Writing
{
    public class LernWordsBoardVM : BaseLernPage
    {
        public override string Name => nameof(LernWordsBoardVM);
        private ILernWordsManager _logic = (ILernWordsManager)
SupportHandlerManager.Base.GetManager("LernWordsManager");
        public double BoardHeight { get; set; }
        public double BoardWidth { get; set; }
        public string HappySmily { get; set; }
        public string TextWords { get; set; }
        public string AnswerText { get; set; }
        public double Speed { get; set; }
        public string BackgroundPic { get; set; }
        public string BackgroundWord { get; set; }
        public string WordPic { get; set; }
        public string MenuButton { get; set; }
        public bool KeyboardOpen { get; set; }
        public ICommand TypeLetter { get; set; }
        private string _AnswerText = string.Empty;
        public LernWordsBoardVM()
        {

            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.249;// 0.463
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.414;//0.491
            NotifyPropertyChanged(nameof(BoardWidth) );
            NotifyPropertyChanged(nameof(BoardHeight) );
            TypeLetter = new RelayCommand(DoTypeLetter);
            AnswerBut = new RelayCommand(DoAnswerBut);
        }

        private void DoTypeLetter(object obj)
        {
            int i = 0;
            string num = obj.ToString();
            if (num == "0")
            {
                if (TextWords.Length >= 1)
                    TextWords = TextWords.Remove(TextWords.Length - 1, 1);
            }
            else
            {
                for (; i < CL.BS.Common.StaticVar.HeLeters.Length; i++)
                {
                    if (CL.BS.Common.StaticVar.HeLeters[i] == num)
                        break;
                }
                char l = "אבגדהוזחטיכלמנסעפצקרשתךםןףץ"[i];
                TextWords += l;
            }
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
                   _AnswerText =  TextWords = _logic.getWord();
                    BackgroundWord = "#FF41AD48";
                    AnswerText = String.Empty;
                    NotifyPropertyChanged(nameof(BackgroundWord));
                    NotifyPropertyChanged(nameof(WordPic));
                    NotifyPropertyChanged(nameof(TextWords));
                    NotifyPropertyChanged(nameof(AnswerText));
                    bool g = true; ;
                    WhitTime((int)(1000.0 * (5.2 - Speed)), ref g);
                    BackgroundWord = TextWords = string.Empty;
                    NotifyPropertyChanged(nameof(TextWords));
                    NotifyPropertyChanged(nameof(BackgroundWord));
                    KeyboardOpen = true;
                    NotifyPropertyChanged(nameof(KeyboardOpen)); 
                })).Start();
            }
            else
            {
                base.SwitchAnswerButton();
                KeyboardOpen = false;
                AnswerText = _AnswerText;
                NotifyPropertyChanged(nameof(KeyboardOpen));
                NotifyPropertyChanged(nameof(AnswerText));
                HappySmily = string.Format(@"{0}Resources\BS.Items\{1}Smily.png",
 System.AppDomain.CurrentDomain.BaseDirectory, TextWords == _AnswerText ? "Happy" : "Sad");
                NotifyPropertyChanged(nameof(HappySmily));
            }
        }
    }
}
