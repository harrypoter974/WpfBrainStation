using CL.BS.MEF;
using CL.BS.ShapesManager.Interface;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.ShapesVM.VM.Line
{
    public class BoardLineVM : BaseBoardShape 
    {
        public override string Name => nameof(BoardLineVM);
        bool _isMach = false;
        Common.GeneralFunctions _ligic =new Common.GeneralFunctions();
        public ICommand ChangeMode { get; set; }
        private int _pageIndex;
        public BoardLineVM()
        {
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.503;
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.392;
            NotifyPropertyChanged(nameof(BoardWidth));
            NotifyPropertyChanged(nameof(BoardHeight));
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
    @"Resources\Shapes\Line\blank.png";
            NotifyPropertyChanged(nameof(BackgroundPic) );
            AnswerBut = new RelayCommand(DoAnswerBut);
            ChangeMode = new RelayCommand(DoChangeMode);
        }

        private void DoChangeMode(object obj)
        {
            _isMach = !_isMach;
            BackgroundPic = String.Format(@"{0}Resources\Shapes\Line\Line{1}{2}{3}.png"
, System.AppDomain.CurrentDomain.BaseDirectory, _isMach ? 'M' : 'A', base.IsQuestionMode? 'Q' : 'A', _pageIndex);
            NotifyPropertyChanged(nameof(BackgroundPic));
        }
        private void DoAnswerBut(object obj)
        {
            if (base.IsQuestionMode)
            {
                _pageIndex = _ligic.GetIndex(4);
                BackgroundPic =String.Format(@"{0}Resources\Shapes\Line\Line{1}Q{2}.png"
, System.AppDomain.CurrentDomain.BaseDirectory ,_isMach ?'M':'A', _pageIndex);
                NotifyPropertyChanged(nameof(BackgroundPic));
            }
            else
            {
                BackgroundPic = String.Format(@"{0}Resources\Shapes\Line\Line{1}A{2}.png"
, System.AppDomain.CurrentDomain.BaseDirectory, _isMach ? 'M' : 'A', _pageIndex);
                NotifyPropertyChanged(nameof(BackgroundPic));
                NotifyPropertyChanged(nameof(BackgroundPic));
            }
            base.SwitchAnswerButton();
        }
    }
}
