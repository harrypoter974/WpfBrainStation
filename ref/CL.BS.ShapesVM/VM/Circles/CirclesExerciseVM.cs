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

namespace CL.BS.ShapesVM.VM.Circles
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class CirclesExerciseVM : BaseStepVM, IPageVM
    {
        ICirclesManager logic = (ICirclesManager)
        SupportHandlerManager.Base.GetManager("CirclesManager");
        private int CircleIndex = 0;
        public CirclesExerciseVM()
        {
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\Shapes\Circles\open.jpg";
            NotifyPropertyChanged("BackgroundPic");
            AnswerBut = new RelayCommand(DoAnswerBut);
        }

        private void DoAnswerBut(object obj)
        {
            if (base.IsQuestionMode)
            {
                BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
  @"Resources\Shapes\Circles\CircleQ" + CircleIndex + ".jpg";
                NotifyPropertyChanged("BackgroundPic");
                PlayList(logic.GetPlayList( CircleIndex));
            }
            else
            {
                BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
  @"Resources\Shapes\Circles\CircleA" + CircleIndex + ".jpg";
                NotifyPropertyChanged("BackgroundPic");
                CircleIndex = CircleIndex <1 ? CircleIndex + 1 : 0;
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
                return "CirclesExerciseVM";
            }
        }
    }
}
