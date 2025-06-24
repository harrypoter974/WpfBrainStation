using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.ShapesVM.VM.Exercise
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class BoardConceptsAngle : BaseBoardShape, IPageVM
    {
        public override string Name => "ConceptsAngleDrawingVM";
        private Common.GeneralFunctions _logic = new Common.GeneralFunctions();

        int[] AngleList = new int[] { 140, 70, 150, 90, 110, 30, 45, 60, 80 };
        public int Angle { get; set; }
        public BoardConceptsAngle()
        {
            AnswerBut = new RelayCommand(DoAnswerBut);
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.424;
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.473;
            NotifyPropertyChanged(nameof(BoardWidth));
            NotifyPropertyChanged(nameof(BoardHeight));
            TypeNum = new RelayCommand(DoTypeNum);
        }

        private void DoTypeNum(object obj)
        {
            if (!base.IsQuestionMode)
            {
                string ns = BackgroundPic;
                string nl = obj.ToString();
                if (nl == "d")
                {
                     ns = string.Empty;
                    for (int i = 0; i < BackgroundPic.Length -1; i++)
                            ns += BackgroundPic[i];
                    BackgroundPic = ns;
                }
                else
                    ns +=nl;
                BackgroundPic = ns;
                NotifyPropertyChanged(nameof(BackgroundPic));
            }
        }
        private void DoAnswerBut(object obj)
        {
            if (base.IsQuestionMode)
            {
                Angle = AngleList[  _index];
                NotifyPropertyChanged(nameof(Angle));
                HappySmily= BackgroundPic = string.Empty;
                NotifyPropertyChanged(nameof(BackgroundPic));
            }
            else
            {
                HappySmily = string.Format(@"{0}\Resources\BS.Items\{1}Smily.png"
, System.AppDomain.CurrentDomain.BaseDirectory,
(AngleList[_index]).ToString() == BackgroundPic ? "Happy" : "Sad");
                _index = _logic.GetIndex( AngleList.Length-1);

            }
                NotifyPropertyChanged(nameof(HappySmily));
            base.SwitchAnswerButton();
        }
    }
}
