using CL.BS.Contract;
using CL.BS.MEF;
using CL.BS.ShapesManager.Interface;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.ShapesVM.VM.Line
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class LineMachVM : BaseStepVM, IPageVM
    {
        ILineManager logic = (ILineManager)
SupportHandlerManager.Base.GetManager("LineManager");
        private int lineIndex = 0;
        public LineMachVM()
        {
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\Shapes\Line\open2.jpg";
            NotifyPropertyChanged("BackgroundPic");
            AnswerBut = new RelayCommand(DoAnswerBut);
        }

        private void DoAnswerBut(object obj)
        {
            if (base.IsQuestionMode)
            {
                BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
  @"Resources\Shapes\Line\LineMQ" + lineIndex + ".jpg";
                NotifyPropertyChanged("BackgroundPic");
                PlayList(logic.GetPlayList('m', lineIndex));
            }
            else
            {
                BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
  @"Resources\Shapes\Line\LineMA" + lineIndex + ".jpg";
                NotifyPropertyChanged("BackgroundPic");
                lineIndex = lineIndex < 3 ? lineIndex + 1 : 0;
            }
            base.SwitchAnswerButton();
        }
        public override string Name
        {
            get
            {
                return "LineMachVM";
            }
        }
        private string m_BackgroundPic;
        public string BackgroundPic
        {
            get { return m_BackgroundPic; }
            set { m_BackgroundPic = value; }
        }
    }
}
