using CL.BS.Contract;
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

namespace CL.BS.ShapesVM.VM.Rect
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class RectExerciseVM : BaseShapesVM, IPageVM
    {
        private IRectManager _logic = (IRectManager)
SupportHandlerManager.Base.GetManager("RectManager");
        private int _rectIndex = 0;
        private bool _isLevel1 = true;
        public ICommand ChangLevel { get; set; }
        public string BackgroundPic {get ;set; }
        public override string Name
        {
            get
            {
                return "RectExerciseVM";
            }
        }

        public RectExerciseVM()
        {
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\Shapes\Rect\open1.jpg";
            NotifyPropertyChanged("BackgroundPic");
            AnswerBut = new RelayCommand(DoAnswerBut);
            ChangLevel = new RelayCommand(DoChangLevel);
        }

        void IPageVM.load()
        {
            base.Settings();
            if (Common.StaticVar.inline.IsBoy)
            {
                messagePic = string.Empty;
                NotifyPropertyChanged("messagePic");
            }
        }

        private void DoChangLevel(object level)
        {
            if (Common.StaticVar.PlayMode)
                return;
            BackgroundShapes = "Transparent";
            NotifyPropertyChanged("BackgroundShapes");
            _isLevel1 = !_isLevel1;
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
  @"Resources\Shapes\Rect\Rect" + (_isLevel1 ? 'A' : 'B') + "Q" + _rectIndex + ".jpg";
            NotifyPropertyChanged("BackgroundPic");
    
            if (!base.IsQuestionMode)
                base.SwitchAnswerButton();
        }
      
        private void DoAnswerBut(object obj)
        {
            if (Common.StaticVar.PlayMode)
                return;
            BackgroundShapes = "Transparent";
            NotifyPropertyChanged("BackgroundShapes");
            if (base.IsQuestionMode)
            {
                BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
  @"Resources\Shapes\Rect\Rect" + (_isLevel1 ? 'A' : 'B') + "Q" + _rectIndex + ".jpg";
                NotifyPropertyChanged("BackgroundPic");
                new Thread(new ThreadStart(() =>
                {
                PlayList(_logic.GetPlayList('a', _rectIndex));
                })).Start();
                if (!Common.StaticVar.inline.IsBoy)
                {
                    messagePic = System.AppDomain.CurrentDomain.BaseDirectory +
        @"Resources\Shapes\Rect\message" + _rectIndex + ".png";
                    NotifyPropertyChanged("messagePic");
                }
            }
            else
            {
                BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
  @"Resources\Shapes\Rect\Rect" + (_isLevel1 ? 'A' : 'B') + "A" + _rectIndex + ".jpg";
                NotifyPropertyChanged("BackgroundPic");
                _rectIndex = _rectIndex <5 ? _rectIndex + 1 : 0;
            }
            base.SwitchAnswerButton();
        }
    }
}
