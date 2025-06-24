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

namespace CL.BS.ShapesVM.VM.Tringel
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class TringelMachVM : BaseShapesVM, IPageVM
    {
        public string BackgroundPic { get ;set;}
        private ITringelManager _logic = (ITringelManager)
SupportHandlerManager.Base.GetManager("TringelManager");
        private int _tringelIndex = 0;
        public override string Name
        {
            get
            {
                return "TringelMachVM";
            }
        }

        public TringelMachVM() {
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\Shapes\Tringel\open2.jpg";
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
  @"Resources\Shapes\Tringel\TringelMQ" + _tringelIndex + ".jpg";
                NotifyPropertyChanged("BackgroundPic");
           
                new Thread(new ThreadStart(() =>
                {
                PlayList(_logic.GetPlayList('m', _tringelIndex));
                })).Start();
                if (!Common.StaticVar.inline.IsBoy)
                {
                    messagePic = System.AppDomain.CurrentDomain.BaseDirectory +
        @"Resources\Shapes\Tringel\message" + _tringelIndex + ".png";
                NotifyPropertyChanged("messagePic");
                }
            }
            else
            {
                BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
  @"Resources\Shapes\Tringel\TringelMA" + _tringelIndex + ".jpg";
                NotifyPropertyChanged("BackgroundPic");
                _tringelIndex = _tringelIndex < 2 ? _tringelIndex + 1 : 0;
            }
            base.SwitchAnswerButton();
        }
    }
}

