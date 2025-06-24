using CL.BS.Contract;
using CL.BS.MathLearningManager.Interface.WritingNumbers;
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

namespace CL.BS.MathLearningVM.WritingNumbers
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class WritingNumVM : BaseLernPage,  IPageVM
    {
        public override string Name
        {
            get
            {
                return "WritingNumVM";
            }
        }
        private IWritingNumManager _logic = (IWritingNumManager)
SupportHandlerManager.Base.GetManager("WritingNumManager");
        private bool _isWriting = false;
        private int _index = 0;
        public double Speed { get; set; }
        public string UrlNum { get; set; }
        public int Column { get; set; }
        public int Row { get; set; }
        public int ColumnSpan { get; set; }
        public int RowSpan { get; set; }
        public string ImageLetterSize { get; set; }
        public ICommand SetNum { get; set; }
        public ICommand ToBig { get; set; }
        public ICommand ToSmall { get; set; }
        public string NumText { get; set; }
        public string BackgroundPic { get; set; }

        void IPageVM.disload()
        {
            _isWriting = false;
            UrlNum = string.Empty;
            NotifyPropertyChanged("UrlNum");
        }

        void IPageVM.load()
        {
            _isWriting = false;
            base.Settings();
            if (!Common.StaticVar.inline.IsBoy)
            {
                messagePic = System.AppDomain.CurrentDomain.BaseDirectory +
                   @"Resources\Math\Writing\numMessage.png";
            }
            else
                messagePic = string.Empty;
            NotifyPropertyChanged("messagePic");
            ImageLetterSize = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\BS.Items\LettersBig.png";
            NotifyPropertyChanged("ImageLetterSize");
            SetBackground();
            Row =         7;
            Column =     10;
            ColumnSpan = 18;
            RowSpan =    10;
            NumText = _logic.GetNum();
            NotifyPropertyChanged("NumText");
            SetSize();
            if(!base.IsQuestionMode)
                base.SwitchAnswerButton();
        }

        public WritingNumVM()
        {
            Speed = 0.5;
            NotifyPropertyChanged("Speed");
               AnswerBut = new RelayCommand(DoAnswerBut);
            SetNum = new RelayCommand(DoSetNum);
            ToSmall = new RelayCommand(DoToSmall);
            ToBig = new RelayCommand(DoToBig);
        }

        private void DoSetNum(object obj)
        {
            _isWriting = false;
            _logic.SetNum(obj);
            SetBackground();
            NumText = _logic.GetNum();
            NotifyPropertyChanged("NumText");
            _index = 0;
        }

        private void DoAnswerBut(object obj)
        {
            if (Common.StaticVar.PlayMode)
                return;
            if (base.IsQuestionMode)
            {
                _index = 0;
                new Thread(new ThreadStart(() =>
                {
                    base.SwitchAnswerButton();
                    _isWriting = true;
                    while (_isWriting)
                    {
                        string url = System.AppDomain.CurrentDomain.BaseDirectory +
                     @"Resources\Math\NumMovie\" + _logic.GetNum() + "\\" + _index + ".jpg";
                        if (!File.Exists(url))
                        {
                            UrlNum = System.AppDomain.CurrentDomain.BaseDirectory +
                 @"Resources\BS.Items\LineBoard.jpg";
                            NotifyPropertyChanged("UrlNum");
                            _isWriting = false;
                            break;
                        }
                        UrlNum = url;
                        NotifyPropertyChanged("UrlNum");
                        WhitTime((int)(50.0 * (9.5 - Speed)), ref _isWriting);
                       // Thread.Sleep((int)(300.0 * (9.5 - Speed)));
                        if (_index == 1)
                        {
                            string num=string.Empty;
                            switch (_logic.GetNum())
                            {
                                case "0":num = "0"; break;
                                case "2":num = "two"; break;
                                default:
                                    num = "n" + _logic.GetNum();
                                    break;
                            }
                            PlayList(new string[] { Common.StaticVar.inline.PlayName(),
                         Common.StaticVar.inline.IsBoy?@"Resources\Audio\He\General\Write.wav":
                         @"Resources\Audio\He\General\written.wav",@"Resources\Audio\He\Num\"
                          +  num + ".wav"});
                            WhitAntilPlayStop(ref _isWriting);
                        }
                        _index++;
                    }
                    base.SwitchAnswerButton();
                })).Start();
            }
            else
            {
                _isWriting = false;
                base.SwitchAnswerButton();
            }
        }

        private void DoToSmall(object obj)
        {
            ImageLetterSize = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\BS.Items\LettersSmall.png";
            NotifyPropertyChanged("ImageLetterSize");
          Row= 12;
           Column= 18;
           ColumnSpan= 5;
          RowSpan= 4;
            SetSize();
        }

        private void DoToBig(object obj)
        {
            ImageLetterSize = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\BS.Items\LettersBig.png";
            NotifyPropertyChanged("ImageLetterSize");
            Row = 7;
            Column = 10;
            ColumnSpan = 18;
            RowSpan = 10;
            SetSize();
        }

        private void SetBackground()
        {
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
     @"Resources\Math\Writing\B" + _logic.GetNum() + ".jpg";
            NotifyPropertyChanged("BackgroundPic");
        }

        private void SetSize()
        {
            NotifyPropertyChanged("Column");
            NotifyPropertyChanged("Row");
            NotifyPropertyChanged("ColumnSpan");
            NotifyPropertyChanged("RowSpan");
        }
    }
}
