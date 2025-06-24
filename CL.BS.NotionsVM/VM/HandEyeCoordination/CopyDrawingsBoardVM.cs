using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.NotionsVM.VM.HandEyeCoordination
{
    public class CopyDrawingsBoardVM : BaseLernPage
    {
        public override string Name => nameof(CopyDrawingsBoardVM);
        public string BackgroundPic { get; set; }
        private int _pageIndex = 0;
        public double BoardHeight { get; set; }
        public double BoardWidth { get; set; }
        public CopyDrawingsBoardVM()
        {

            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.415;// 0.463
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.453;//0.491
            NotifyPropertyChanged(nameof(BoardWidth));
            NotifyPropertyChanged(nameof(BoardHeight));
            AnswerBut = new RelayCommand(DoAnswerBut);
            BackgroundPic = String.Empty;
            NotifyPropertyChanged("BackgroundPic");
            if (!base.IsQuestionMode)
                base.SwitchAnswerButton();
        }
        private void DoAnswerBut(object obj)
        {
            if (base.IsQuestionMode)
            {
                _pageIndex = _pageIndex == 2 ? 0 : _pageIndex+1;
                BackgroundPic =   String.Format(@"{0}Resources\Notions\CopyDrawings\Answer{1}.png"
, System.AppDomain.CurrentDomain.BaseDirectory, _pageIndex);
            }
            else
            {
                BackgroundPic =  String.Format( @"{0}Resources\Notions\CopyDrawings\Question{1}.png"
,System.AppDomain.CurrentDomain.BaseDirectory,_pageIndex) ;
            }
            NotifyPropertyChanged("BackgroundPic");
            base.SwitchAnswerButton();
        }
    }
}
