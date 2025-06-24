using CL.BS.Contract;
using CL.BS.MEF;
using CL.BS.ShapesManager.Interface;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.ShapesVM.VM.Angle
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
   public class AngleMachVM : BaseStepVM, IPageVM
    {
        IAngleManager logic = (IAngleManager)
        SupportHandlerManager.Base.GetManager("AngleManager");
        private int AngleIndex = 0;
        public AngleMachVM()
        {
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
                     @"Resources\Shapes\Angle\AngleMQ0.jpg";
            NotifyPropertyChanged("BackgroundPic");
            AnswerBut = new RelayCommand(DoAnswerBut);
        }

        private void DoAnswerBut(object obj)
        {
            if (base.IsQuestionMode)
            {
                BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
  @"Resources\Shapes\Angle\AngleMQ" + AngleIndex + ".jpg";
                NotifyPropertyChanged("BackgroundPic");
                PlayList(logic.GetPlayList('m', AngleIndex));
            }
            else
            {
                BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
  @"Resources\Shapes\Angle\AngleMA" + AngleIndex + ".jpg";
                NotifyPropertyChanged("BackgroundPic");
                AngleIndex = AngleIndex < 2 ? AngleIndex + 1 : 0;
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
                return "AngleMachVM";
            }
        }
    }
}
