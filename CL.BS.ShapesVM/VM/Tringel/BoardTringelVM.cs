using CL.BS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.ShapesVM.VM.Tringel
{
    public class BoardTringelVM :BaseBoardShape
    {
        public override string Name => nameof(BoardTringelVM);
        Common.GeneralFunctions _ligic = new Common.GeneralFunctions();

        private int _indexPage;
        public BoardTringelVM()
        {
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.429;
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.44;
            NotifyPropertyChanged(nameof(BoardWidth));
            NotifyPropertyChanged(nameof(BoardHeight));
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
    @"Resources\Shapes\Tringel\blank.png";
            NotifyPropertyChanged(nameof(BackgroundPic));
            AnswerBut = new RelayCommand(DoAnswerBut);
        }

        private void DoAnswerBut(object obj)
        {
            if (base.IsQuestionMode)
            {
                _indexPage = _ligic.GetIndex(4);
                BackgroundPic = String.Format(@"{0}Resources\Shapes\Tringel\TringelAQ{1}.png"
        , System.AppDomain.CurrentDomain.BaseDirectory, _indexPage);
                NotifyPropertyChanged(nameof(BackgroundPic));
            }
            else
            {
                BackgroundPic = String.Format(@"{0}Resources\Shapes\Tringel\TringelAA{1}.png"
, System.AppDomain.CurrentDomain.BaseDirectory, _indexPage);
                NotifyPropertyChanged(nameof(BackgroundPic));
                NotifyPropertyChanged(nameof(BackgroundPic));
            }
            base.SwitchAnswerButton();
        }
    }
}
