using CL.BS.Contract;
using CL.BS.MEF;
using CL.BS.ShapesManager.Interface;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.ShapesVM.VM.Tringel
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class TringelMachVM : BaseStepVM, IPageVM
    {
        ITringelManager logic = (ITringelManager)
SupportHandlerManager.Base.GetManager("TringelManager");
        private int tringelIndex = 0;
        public TringelMachVM() {
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\Shapes\Tringel\open2.jpg";
            NotifyPropertyChanged("BackgroundPic");
            AnswerBut = new RelayCommand(DoAnswerBut);
        }

        private void DoAnswerBut(object obj)
        {
            if (base.IsQuestionMode)
            {
                BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
  @"Resources\Shapes\Tringel\TringelMQ" + tringelIndex + ".jpg";
                NotifyPropertyChanged("BackgroundPic");
                PlayList(logic.GetPlayList('m', tringelIndex));
            }
            else
            {
                BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
  @"Resources\Shapes\Tringel\TringelMA" + tringelIndex + ".jpg";
                NotifyPropertyChanged("BackgroundPic");
                tringelIndex = tringelIndex < 2 ? tringelIndex + 1 : 0;
            }
            base.SwitchAnswerButton();
        }
        private string m_BackgroundPic;
        public string BackgroundPic
        {
            get { return m_BackgroundPic; }
            set { m_BackgroundPic = value; }
        }
        public override string Name
        {
            get
            {
                return "TringelMachVM";
            }
        }
    }
}

