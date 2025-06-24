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

namespace CL.BS.ShapesVM.VM.Shape
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class ShapeExerciseVM : BaseShapesVM, IPageVM
    {
        public string BackgroundPic {get ;set; }
        public int RowSpanMeseg { get ;set; }
        private IShapeManager _logic = (IShapeManager)
SupportHandlerManager.Base.GetManager("ShapeManager");
        private int _shapeIndex = 0;
        public override string Name
        {
            get
            {
                return "ShapeExerciseVM";
            }
        }

        public ShapeExerciseVM()
        {
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\Shapes\Shape\open.jpg";
            NotifyPropertyChanged("BackgroundPic");
            AnswerBut = new RelayCommand(DoAnswerBut);
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

        private void DoAnswerBut(object obj)
        {
            if (Common.StaticVar.PlayMode)
                return;
            BackgroundShapes = "Transparent";
            NotifyPropertyChanged("BackgroundShapes");
            if (base.IsQuestionMode)
            {
                BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
  @"Resources\Shapes\Shape\ShapesQ" + _shapeIndex + ".jpg";
                NotifyPropertyChanged("BackgroundPic");
                new Thread(new ThreadStart(() =>
                {
                    PlayList(_logic.GetPlayList(_shapeIndex));
                })).Start();
                if (!Common.StaticVar.inline.IsBoy )
                {
                    messagePic = System.AppDomain.CurrentDomain.BaseDirectory +
        @"Resources\Shapes\Shape\message" + _shapeIndex + ".png";
                    RowSpanMeseg = _shapeIndex < 3 ? 4 : 3;
                    NotifyPropertyChanged("messagePic");
                    NotifyPropertyChanged("RowSpanMeseg");
                }
            }
            else
            {
                BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
  @"Resources\Shapes\Shape\ShapesA" + _shapeIndex + ".jpg";
                NotifyPropertyChanged("BackgroundPic");
                _shapeIndex = _shapeIndex < 7 ? _shapeIndex + 1 : 0;
            }
            base.SwitchAnswerButton();
        }
    }
}
