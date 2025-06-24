using CL.BS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.ShapesVM.VM.Shape
{
    public class BoardShapeVM : BaseBoardShape
    {
        public override string Name => nameof(BoardShapeVM);
        private int _indexPage;
        Common.GeneralFunctions _ligic = new Common.GeneralFunctions();
        public BoardShapeVM()
        {
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.385;
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.47;
            NotifyPropertyChanged(nameof(BoardWidth));
            NotifyPropertyChanged(nameof(BoardHeight));
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
    @"Resources\Shapes\Rect\open1.png";
            NotifyPropertyChanged(nameof(BackgroundPic));
            AnswerBut = new RelayCommand(DoAnswerBut);
        }
        private void DoAnswerBut(object obj)
        {
            if (base.IsQuestionMode)
            {
                _indexPage = _ligic.GetIndex(7);
                BackgroundPic = String.Format(@"{0}Resources\Shapes\Shape\ShapesQ{1}.png"
, System.AppDomain.CurrentDomain.BaseDirectory, _indexPage);
                NotifyPropertyChanged(nameof(BackgroundPic));
            }
            else
            {
                BackgroundPic = String.Format(@"{0}Resources\Shapes\Shape\ShapesA{1}.png"
, System.AppDomain.CurrentDomain.BaseDirectory, _indexPage);
                NotifyPropertyChanged(nameof(BackgroundPic));
                NotifyPropertyChanged(nameof(BackgroundPic));
            }
            base.SwitchAnswerButton();
        }
    }
}
