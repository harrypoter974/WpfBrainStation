using CL.BS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.ShapesVM.VM.Circles
{
    public class BoardCirclesVM : BaseBoardShape
    {
        public override string Name => nameof(BoardCirclesVM);
        private int _indexPage;
        Common.GeneralFunctions _ligic = new Common.GeneralFunctions();
        public BoardCirclesVM()
        {
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.386;
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.458;
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
                BackgroundPic = String.Format(@"{0}Resources\Shapes\Circles\CircleQ{1}.png"
, System.AppDomain.CurrentDomain.BaseDirectory, _indexPage);
            }
            else
            {
                BackgroundPic = String.Format(@"{0}Resources\Shapes\Circles\CircleA{1}.png"
, System.AppDomain.CurrentDomain.BaseDirectory, _indexPage);
                _indexPage = _ligic.GetIndex(2);
            }
            NotifyPropertyChanged(nameof(BackgroundPic));
            base.SwitchAnswerButton();
        }
    }
}
