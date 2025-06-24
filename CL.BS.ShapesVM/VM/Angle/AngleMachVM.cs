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

namespace CL.BS.ShapesVM.VM.Angle
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
   public class AngleMachVM : BaseShapesVM, IPageVM
    {
        private IAngleManager _logic = (IAngleManager)
        SupportHandlerManager.Base.GetManager("AngleManager");
        private int _angleIndex = 0;
        public string BackgroundPic  { get ;set;}
        public override string Name
        {
            get
            {
                return "AngleMachVM";
            }
        }

        public AngleMachVM()
        {
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
                     @"Resources\Shapes\Angle\AngleMQ0.jpg";
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
  @"Resources\Shapes\Angle\AngleMQ" + _angleIndex + ".jpg";
                NotifyPropertyChanged("BackgroundPic");
                new Thread(new ThreadStart(() =>
                { 
                PlayList(_logic.GetPlayList('m', _angleIndex));
                })).Start();
                if (!Common.StaticVar.inline.IsBoy)
                {
                    messagePic = System.AppDomain.CurrentDomain.BaseDirectory +
                       @"Resources\Shapes\Angle\m" + _angleIndex + ".png";
                    NotifyPropertyChanged("messagePic");
                }
            }
            else
            {
                BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
  @"Resources\Shapes\Angle\AngleMA" + _angleIndex + ".jpg";
                NotifyPropertyChanged("BackgroundPic");
                _angleIndex = _angleIndex < 2 ? _angleIndex + 1 : 0;
            }
            base.SwitchAnswerButton();
        }
    }
}
