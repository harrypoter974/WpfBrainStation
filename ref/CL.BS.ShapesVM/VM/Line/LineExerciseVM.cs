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

namespace CL.BS.ShapesVM.VM.Line
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class LineExerciseVM : BaseStepVM, IPageVM
    {
        ILineManager logic = (ILineManager)
     SupportHandlerManager.Base.GetManager("LineManager");
        private bool IsLevel1 = true;
        private int lineIndex = 0;
        public LineExerciseVM()
        {
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\Shapes\Line\open1.jpg";
            NotifyPropertyChanged("BackgroundPic");
            AnswerBut = new RelayCommand(DoAnswerBut);
            ChangLevel = new RelayCommand(DoChangLevel);
        }
        private void DoChangLevel(object level)
        {
            IsLevel1 = !IsLevel1;
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
           @"Resources\Shapes\Line\Line" + (IsLevel1 ? 'A' : 'B') + "Q" + lineIndex + ".jpg";
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
  @"Resources\Shapes\Line\Line" + (IsLevel1 ? 'A' : 'B') + "Q" + lineIndex + ".jpg";
                NotifyPropertyChanged("BackgroundPic");
                PlayList(logic.GetPlayList('a', lineIndex));
            }
            else
            {
                BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
  @"Resources\Shapes\Line\Line" + (IsLevel1 ? 'A' : 'B') + "A" + lineIndex + ".jpg";
                NotifyPropertyChanged("BackgroundPic");
                lineIndex = lineIndex < 4 ? lineIndex + 1 : 0;
            }
            base.SwitchAnswerButton();
        }
        public override string Name
        {
            get
            {
                return "LineExerciseVM";
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
