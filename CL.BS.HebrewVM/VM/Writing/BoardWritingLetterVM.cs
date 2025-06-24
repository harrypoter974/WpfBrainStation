using CL.BS.HebrewManager.Interface.Writing;
using CL.BS.MEF;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Input;

namespace CL.BS.HebrewVM.VM.Writing
{
    public class BoardWritingLetterVM : BaseLernPage
    {
        public override string Name => nameof(BoardWritingLetterVM);
        public double BoardHeight { get; set; }
        public double BoardWidth { get; set; }
        private bool _isWriting = false, _IsCard;
        private int _indexLetter = 0;
        private IWritingLettersManager _logic = (IWritingLettersManager)
SupportHandlerManager.Base.GetManager("WritingLettersManager");
        public ICommand TypeLetter { get; set; }
        public ICommand SwitchFont { get; set; }
        public string ButtonFont { get; set; }
        public int Column { get; set; }
        public int Row { get; set; }
        public int ColumnSpan { get; set; }
        public int RowSpan { get; set; }
        public double Speed { get; set; }
        public string UrlLetter { get; set; }
        public string ImageLetterSize { get; set; }
        public string _Letter;

        public BoardWritingLetterVM()
        {
            TypeLetter = new RelayCommand(DoSwitchLetter);
            SwitchFont = new RelayCommand(DoSwitchFont);
            _isWriting = false;
            ButtonFont = _logic.SwitchFontButton();
            NotifyPropertyChanged("ButtonFont");

            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.467;// 0.463
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.404;//0.491
            NotifyPropertyChanged("BoardWidth");
            NotifyPropertyChanged("BoardHeight");
            DoSwitchLetter(0);
        }
        private void DoSwitchFont(object obj)
        {
            _IsCard=!_IsCard;
            ButtonFont = System.AppDomain.CurrentDomain.BaseDirectory +
            @"Resources\BS.Items\Button" +
            (_IsCard ? "Card" : "Writing") + ".png"; ;
            NotifyPropertyChanged("ButtonFont");
        }

        private void DoSwitchLetter(object letter)
        {
            if (letter.ToString() == "0")
            {
                _isWriting = false;
                UrlLetter = String.Empty;
                NotifyPropertyChanged("UrlLetter");
                return;
            }
            _Letter=letter.ToString();
            _indexLetter = 0;
            new Thread(new ThreadStart(() =>
            {
                base.SwitchAnswerButton();
                _isWriting = true;
                while (_isWriting)
                {
                    string url = System.AppDomain.CurrentDomain.BaseDirectory +
                 @"Resources\Lang\He\Writing\" + _Letter + "\\" + _indexLetter +
                 (_IsCard ? ".png" : ".jpg");
                    if (!File.Exists(url))
                    {
                        UrlLetter = System.AppDomain.CurrentDomain.BaseDirectory +
             @"Resources\BS.Items\LineBoard.jpg";
                        NotifyPropertyChanged("UrlLetter");
                        _isWriting = false;
                        break;
                    }
                    UrlLetter = url;
                    NotifyPropertyChanged("UrlLetter");

                    _indexLetter++;
                    WhitTime((int)(50.0 * (9.5 - Speed)), ref _isWriting);
                }
                base.SwitchAnswerButton();
            })).Start();
        }
    }
}
