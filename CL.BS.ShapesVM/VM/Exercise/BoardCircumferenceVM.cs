using CL.BS.Common;
using CL.BS.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.ShapesVM.VM.Exercise
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class BoardCircumferenceVM : BaseBoardShape, IPageVM
    {
        public string NumText { get; set; }
        private Common.GeneralFunctions _logic = new Common.GeneralFunctions();
        private string[] _AnswerList = new string[] { "32", "40", "36", "40", "40"};
        public BoardCircumferenceVM() {
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.424;
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.473;
            NotifyPropertyChanged(nameof(BoardWidth));
            NotifyPropertyChanged(nameof(BoardHeight));
            AnswerBut = new RelayCommand(DoAnswerBut);
            TypeNum = new RelayCommand(DoTypeNum); BackgroundPic = string.Format(
                @"{0}Resources\Shapes\Circumference\c.png"
, System.AppDomain.CurrentDomain.BaseDirectory);
            NotifyPropertyChanged(nameof(BackgroundPic));
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
                NumText = HappySmily = string.Empty;
                BackgroundPic = string.Format(@"{0}Resources\Shapes\Circumference\c{1}.png"
, System.AppDomain.CurrentDomain.BaseDirectory, _index);
                NotifyPropertyChanged(nameof(BackgroundPic));
                NotifyPropertyChanged(nameof(NumText));
            }
            else
            {
                HappySmily = string.Format(@"{0}\Resources\BS.Items\{1}Smily.png"
, System.AppDomain.CurrentDomain.BaseDirectory,
_AnswerList[_index] == NumText ? "Happy" : "Sad");
                _index = _logic.GetIndex(5);

            }
            NotifyPropertyChanged(nameof(HappySmily));
            base.SwitchAnswerButton();
        }    
    }
}
