using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.EnglishVM.VM.Text
{
    public class BoardEnWritingLetterVM : BaseLernPage
    {
        public double BoardHeight { get; set; }
        public double BoardWidth { get; set; }
        private int _indexLetter = 0;
        private bool _isWriting = false;  
        public ICommand TypeLetter { get; set; }
        public string ButtonFont { get; set; }
        public int Column { get; set; }
        public int Row { get; set; }
        public int ColumnSpan { get; set; }
        public int RowSpan { get; set; }
        public double Speed { get; set; }
        public string UrlLetter { get; set; }
        public string ImageLetterSize { get; set; }
        public string _Letter;

        public override string Name => "";

        public BoardEnWritingLetterVM()
        {
            TypeLetter = new RelayCommand(DoSwitchLetter);
            NotifyPropertyChanged(nameof(ButtonFont));

            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.404;
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.467;
            NotifyPropertyChanged(nameof(BoardWidth));
            NotifyPropertyChanged(nameof(BoardHeight));
        }

        private void DoSwitchLetter(object letter)
        {
            if (letter.ToString() == "0")
            {
                _isWriting = false;
                   UrlLetter = String.Empty;
                NotifyPropertyChanged(nameof(UrlLetter));
                return;
            }
            _Letter = letter.ToString();
            _indexLetter = 0;
            new Thread(new ThreadStart(() =>
            {
                base.SwitchAnswerButton();
                _isWriting = true;
                while (_isWriting)
                {
                    string url = System.AppDomain.CurrentDomain.BaseDirectory +
                 @"Resources\Lang\En\LettersMovie\" + _Letter + "\\" + _indexLetter + ".png" ;
                    if (!File.Exists(url))
                    {
                        UrlLetter = System.AppDomain.CurrentDomain.BaseDirectory +
             @"Resources\BS.Items\LineBoard.jpg";
                        NotifyPropertyChanged(nameof(UrlLetter));
                        _isWriting = false;
                        break;
                    }
                    UrlLetter = url;
                    NotifyPropertyChanged(nameof(UrlLetter));

                    _indexLetter++;
                    WhitTime((int)(50.0 * (9.5 - Speed)), ref _isWriting);
                }
                base.SwitchAnswerButton();
            })).Start();

        }
     
    }
}
