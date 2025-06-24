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

namespace CL.BS.ShapesVM.VM.Rect
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class RectMachVM : BaseShapesVM, IPageVM
    {
        private IRectManager _logic = (IRectManager)
SupportHandlerManager.Base.GetManager("RectManager");
        private int _rectIndex = 0;
        public string BackgroundPic{ get ;  set;}
        public override string Name
        {
            get
            {
                return "RectMachVM";
            }
        }

        public RectMachVM()
        {
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\Shapes\Rect\open2.jpg";
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
  @"Resources\Shapes\Rect\RectMQ" + _rectIndex + ".jpg";
                NotifyPropertyChanged("BackgroundPic");
                new Thread(new ThreadStart(() =>
                {
                PlayList(_logic.GetPlayList('m', _rectIndex));
                })).Start();
                if (!Common.StaticVar.inline.IsBoy)
                {
                    messagePic = System.AppDomain.CurrentDomain.BaseDirectory +
    @"Resources\Shapes\Rect\m" + _rectIndex + ".jpg";
                NotifyPropertyChanged("messagePic");
                }
            }
            else
            {
                BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
  @"Resources\Shapes\Rect\RectMA" + _rectIndex + ".jpg";
                NotifyPropertyChanged("BackgroundPic");
                _rectIndex = _rectIndex < 5 ? _rectIndex + 1 : 0;
            }
            base.SwitchAnswerButton();
        }
    }
}
