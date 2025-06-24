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
    public class BoardLengthVM : BaseBoardShape, IPageVM
    {
        private static Random _ran = new Random(DateTime.Now.Millisecond);
        private Common.GeneralFunctions _logic = new Common.GeneralFunctions();
        public int Lengt { get; set; }
        private int _lengt;
        private const double CM = 27.51;
        public override string Name => "BoardLengthVM";
        public BoardLengthVM()
        {
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.424;
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.473;
            NotifyPropertyChanged(nameof(BoardWidth));
            NotifyPropertyChanged(nameof(BoardHeight));
            TypeNum = new RelayCommand(DoTypeNum);
            AnswerBut = new RelayCommand(DoAnswerBut);
            Lengt = 86;
            NotifyPropertyChanged(nameof(Lengt));
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
                    for (int i = 0; i < BackgroundPic.Length - 1; i++)
                        ns += BackgroundPic[i];
                    BackgroundPic = ns;
                }
                else
                    ns += nl;
                BackgroundPic = ns;
                NotifyPropertyChanged(nameof(BackgroundPic));
            }
        }
        private void DoAnswerBut(object obj)
        {
            if (base.IsQuestionMode)
            {
                _lengt = _logic.GetIndex(13)+2;
                Lengt = (int)(_lengt * CM)+ 86;
                BackgroundPic = HappySmily = string.Empty;
                NotifyPropertyChanged(nameof(BackgroundPic));
                NotifyPropertyChanged(nameof(Lengt));
            }
            else
            {
                HappySmily = string.Format(@"{0}\Resources\BS.Items\{1}Smily.png"
, System.AppDomain.CurrentDomain.BaseDirectory,
_lengt.ToString() == BackgroundPic ? "Happy" : "Sad");

            }
            NotifyPropertyChanged(nameof(HappySmily));
            base.SwitchAnswerButton();
        }
    }
}
