using CL.BS.Common;
using CL.BS.Contract;
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
    public class  BoardMeasurementVM: BaseBoardShape, IPageVM
    {
        public override string Name => "BoardMeasurementVM";
        private Common.GeneralFunctions _logic = new Common.GeneralFunctions();
        string[] _PicList = new string[] {"h0","l0","w0", "h1","l1","w1"};
        string[] _AnswerList = new string[] { "7", "10", "6", "7", "19", "5" };
        public string NumText { get; set; }
        public BoardMeasurementVM()
        {
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.424;
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.473;
            NotifyPropertyChanged(nameof(BoardWidth));
            NotifyPropertyChanged(nameof(BoardHeight));
            BackgroundPic = string.Format(@"{0}Resources\Shapes\Concepts\{1}.png"
, System.AppDomain.CurrentDomain.BaseDirectory, _PicList[_index]);
            NotifyPropertyChanged(nameof(BackgroundPic));
            TypeNum = new RelayCommand(DoTypeNum);
            AnswerBut = new RelayCommand(DoAnswerBut);
        }

        private void DoTypeNum(object obj)
        {
            if (!base.IsQuestionMode)
            {
                string ns = NumText;
                string nl = obj.ToString();
                if (nl == "d")
                {
                    ns = string.Empty;
                    for (int i = 0; i < NumText.Length - 1; i++)
                        ns += NumText[i];
                    NumText = ns;
                }
                else
                    ns += nl;
                NumText = ns;
                NotifyPropertyChanged(nameof(NumText));
            }
        }
        private void DoAnswerBut(object obj)
        {
            if (base.IsQuestionMode)
            { 
                NumText= HappySmily = string.Empty;
                BackgroundPic = string.Format(@"{0}Resources\Shapes\Concepts\{1}.png"
, System.AppDomain.CurrentDomain.BaseDirectory, _PicList[_index]);
                NotifyPropertyChanged(nameof(BackgroundPic));
                NotifyPropertyChanged(nameof(NumText));
            }
            else
            {
                HappySmily = string.Format(@"{0}\Resources\BS.Items\{1}Smily.png"
, System.AppDomain.CurrentDomain.BaseDirectory,
_AnswerList[_index] == NumText ? "Happy" : "Sad");
                _index = _logic.GetIndex(_PicList.Length - 1);

            }
            NotifyPropertyChanged(nameof(HappySmily));
            base.SwitchAnswerButton();
        }

    }
}
