using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace   CL.BS.ShapesVM.VM.Exercise
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class ConceptsLengthDrawingVM : BaseLernPage, IPageVM
    {
        private Common.GeneralFunctions _logic = new Common.GeneralFunctions();
        public string BackgroundPic { get; set; }
        public override string Name => "ConceptsLengthDrawingVM";

        public ConceptsLengthDrawingVM()
        {
            AnswerBut = new RelayCommand(DoAnswerBut);
        }
      
        void IPageVM.load()
        {
            base.Settings();
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
                 @"Resources\Shapes\Concepts\drawingLengthOpen.jpg";
            NotifyPropertyChanged("BackgroundPic");
        }

        private void DoAnswerBut(object obj)
        {
            if (base.IsQuestionMode)
            {
                _index = _logic.GetIndex(3);
                BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
                         @"Resources\Shapes\Concepts\QdrawingLength" + _index + ".jpg";

            }
            else
            {
                BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
                         @"Resources\Shapes\Concepts\AdrawingLength" + _index + ".jpg";
            }
            NotifyPropertyChanged("BackgroundPic");
            base.SwitchAnswerButton();
        }
    }
}
