using CL.BS.Contract;
using CL.BS.MEF;
using CL.BS.ShapesManager.Interface;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.ShapesVM.VM.Angle
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
  public  class AngleLineVM : BaseStepVM, IPageVM
    {
        IAngleManager logic = (IAngleManager)
       SupportHandlerManager.Base.GetManager("AngleManager");
        private int AngleIndex = 0;
        private bool IsLevel1 = true;
        public AngleLineVM()
        {
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
                     @"Resources\Shapes\Angle\AngleAQ0.jpg";
            NotifyPropertyChanged("BackgroundPic");
            AnswerBut = new RelayCommand(DoAnswerBut);
            ChangLevel=new RelayCommand(DoChangLevel);
        }
        private void DoChangLevel(object level)
        {
            IsLevel1 = !IsLevel1;
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
              @"Resources\Shapes\Angle\Angle" + (IsLevel1 ? 'A' : 'B') + "Q" + AngleIndex + ".jpg";           
            NotifyPropertyChanged("BackgroundPic");
            if (!base.IsQuestionMode)
                base.SwitchAnswerButton();
        }
        public ICommand ChangLevel { get; set; }
        private void DoAnswerBut(object obj)
        {
            if (base.IsQuestionMode)
            {
                BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
  @"Resources\Shapes\Angle\Angle"+(IsLevel1?'A':'B')+"Q"+AngleIndex+".jpg";
                NotifyPropertyChanged("BackgroundPic");
                PlayList(logic.GetPlayList('a', AngleIndex));
            }
            else
            {
                BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
  @"Resources\Shapes\Angle\Angle" + (IsLevel1 ? 'A' : 'B') + "A" + AngleIndex + ".jpg";
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
                return "AngleLineVM";
            }
        }
    }
}
