using CL.BS.Contract;
using CL.BS.EnglishManager.Interface.Text;
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

namespace CL.BS.EnglishVM.Text
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class EnWriteLetterVM : BaseLernPage, IPageVM
    {
        private bool _isWriting = false;
        private int _indexLetter = 0;
        public ICommand SwitchLetter { get; set; }
        public ICommand ToBig { get; set; }
        public ICommand ToSmall { get; set; }
        private IEnWriteLetterManager _logic = (IEnWriteLetterManager)
   SupportHandlerManager.Base.GetManager("EnWriteLetterManager");
        public int Column { get; set; }
        public int Row { get; set; }
        public int ColumnSpan { get; set; }
        public int RowSpan { get; set; }
        public string ImageLetterSize { get; set; }
        public string LettersLine { get; set; }
        public string UrlLetter { get; set; }
        public double Speed { get; set; }
        public override string Name
        {
            get
            {
                return nameof(EnWriteLetterVM);
            }
        }

        public EnWriteLetterVM()
        {
            AnswerBut = new RelayCommand(DoAnswerBut);
            SwitchLetter = new RelayCommand(DoSwitchLetter);
            ToSmall = new RelayCommand(DoToSmall);
            ToBig = new RelayCommand(DoToBig);  
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
            NotifyPropertyChanged(nameof(messagePic));
            LettersLine = System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\Lang\En\LettersLine\" + _logic.GetLetter() + ".png";
            NotifyPropertyChanged(nameof(LettersLine));
            DoToBig(0);
            if (!base.IsQuestionMode)
                base.SwitchAnswerButton();
        }

        void IPageVM.disload()
        {
            _isWriting = false;
            UrlLetter = string.Empty;
            NotifyPropertyChanged(nameof(UrlLetter));
        }

        private void DoAnswerBut(object obj)
        {
            if (Common.StaticVar.PlayMode)
                return;
            if (base.IsQuestionMode)
            {
                   _indexLetter = 0;
                new Thread(new ThreadStart(() =>
                {
                    base.SwitchAnswerButton();
                    Common.GlobalLog.Write("EN start Write ");
                    PlayList(new string[] { Common.StaticVar.inline.PlayName(),
Common.StaticVar.inline.IsBoy?@"Resources\Audio\He\General\כתוב.wav":@"Resources\Audio\He\General\כתבי.wav",
                     @"Resources\Audio\En\Letters\" + _logic.GetLetter() +  ".wav" });
                    Common.GlobalLog.Write("EN Play Write  ");
                    bool isFerst = true;
                    _isWriting = true;
                    while (_isWriting)
                    {
                        string url = System.AppDomain.CurrentDomain.BaseDirectory +
                     @"Resources\Lang\En\LettersMovie\" + _logic.GetLetter() + "\\" + _indexLetter + ".png";
                        if (!File.Exists(url)|| base.IsQuestionMode)
                        {
                            UrlLetter = System.AppDomain.CurrentDomain.BaseDirectory +
                 @"Resources\BS.Items\LineBoard.jpg";
                            NotifyPropertyChanged(nameof(UrlLetter));
                            _isWriting = false;
                            break;
                        }
                        UrlLetter = url;
                        NotifyPropertyChanged(nameof(UrlLetter));
                        WhitTime((int)(50.0 * (9.5 - Speed)), ref _isWriting);                  
                        if (isFerst&& _indexLetter==1)
                        {
                            WhitAntilPlayStop(ref Common.StaticVar.PlayMode);
                            isFerst = false;

                        }
                        if (_indexLetter == _logic.EndLetter())
                            WhitTime(1000, ref _isWriting);
                        _indexLetter++;
                        Common.GlobalLog.Write("EN end set Pic Write  ");
                    }
                    if (!base.IsQuestionMode)
                        base.SwitchAnswerButton();
                })).Start();
            }
         }
      
        private void DoToSmall(object obj)
        {
            ImageLetterSize = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\Lang\En\LettersLine\" + _logic.GetLetter() + "Small.png";
            NotifyPropertyChanged(nameof(ImageLetterSize));
            Row= 10;
            Column=22;
            ColumnSpan= 5;
            RowSpan=4;
            SetSize();
        }

        private void DoToBig(object obj)
        {
            ImageLetterSize = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\Lang\En\LettersLine\" + _logic.GetLetter() + "Big.png";
            NotifyPropertyChanged(nameof(ImageLetterSize));
            Column = 9;
            Row = 5;
            ColumnSpan = 34;
            RowSpan = 10;
            SetSize();
        }

        private void DoSwitchLetter(object letter)
        {
            if (Common.StaticVar.PlayMode)
                return;
            _isWriting = false;
            _indexLetter = 0;
            _logic.SetLetter(letter);
            LettersLine = System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\Lang\En\LettersLine\" + letter + ".png";
            NotifyPropertyChanged(nameof(LettersLine));
            ImageLetterSize = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\Lang\En\LettersLine\" + letter + (Column==9?"Big": "Small") +".png";
            NotifyPropertyChanged(nameof(ImageLetterSize));
        }

        private void SetSize()
        {
            NotifyPropertyChanged(nameof(Column));
            NotifyPropertyChanged(nameof(Row));
            NotifyPropertyChanged(nameof(ColumnSpan));
            NotifyPropertyChanged(nameof(RowSpan));
        }
    }
}
