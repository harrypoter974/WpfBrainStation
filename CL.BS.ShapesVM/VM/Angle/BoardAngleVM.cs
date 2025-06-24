using CL.BS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.ShapesVM.VM.Angle
{
    public class BoardAngleVM : BaseBoardShape
    {
        public override string Name => nameof(BoardAngleVM);
        private int _indexPage;
        Common.GeneralFunctions _ligic = new Common.GeneralFunctions();
        public BoardAngleVM()
        {
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.428;
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.445;
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
                _indexPage = _ligic.GetIndex(3);
                BackgroundPic = String.Format(@"{0}Resources\Shapes\Angle\AngleAQ{1}.png"
, System.AppDomain.CurrentDomain.BaseDirectory, _indexPage);
                NotifyPropertyChanged(nameof(BackgroundPic));
            }
            else
            {
                BackgroundPic = String.Format(@"{0}Resources\Shapes\Angle\AngleAA{1}.png"
, System.AppDomain.CurrentDomain.BaseDirectory, _indexPage);
                NotifyPropertyChanged(nameof(BackgroundPic));
                NotifyPropertyChanged(nameof(BackgroundPic));
            }
            base.SwitchAnswerButton();
        }
    }
}
