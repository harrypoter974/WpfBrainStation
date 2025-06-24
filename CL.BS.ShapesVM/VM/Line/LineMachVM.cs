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

namespace CL.BS.ShapesVM.VM.Line
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class LineMachVM : BaseShapesVM, IPageVM
    {
        public string BackgroundPic{get ;set; }
        private ILineManager _logic = (ILineManager)
SupportHandlerManager.Base.GetManager("LineManager");
        private int _lineIndex = 0;
        public override string Name
        {
            get
            {
                return "LineMachVM";
            }
        }

        public LineMachVM()
        {
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\Shapes\Line\open2.jpg";
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
  @"Resources\Shapes\Line\LineMQ" + _lineIndex + ".jpg";
                NotifyPropertyChanged("BackgroundPic");
                new Thread(new ThreadStart(() =>
                {
                PlayList(_logic.GetPlayList('m', _lineIndex));
                })).Start();
                if (!Common.StaticVar.inline.IsBoy)
                {
                messagePic = System.AppDomain.CurrentDomain.BaseDirectory +
 @"Resources\Shapes\Line\m" + _lineIndex + ".png";
                NotifyPropertyChanged("messagePic");
                }
            }
            else
            {
                BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
  @"Resources\Shapes\Line\LineMA" + _lineIndex + ".jpg";
                NotifyPropertyChanged("BackgroundPic");
                _lineIndex = _lineIndex < 3 ? _lineIndex + 1 : 0;
            }
            base.SwitchAnswerButton();
        }
    }
}
