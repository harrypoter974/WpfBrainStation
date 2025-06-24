using CL.BS.Contract;
using CL.BS.MathLearningManager.Interface.Recognaz;
using CL.BS.MEF;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.MathLearningVM.Recognaz
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class BordMathRecognaz2VM : VMCommon.BaseLernPage, IPageVM
    {
        public override string Name => "BordMathRecognaz2VM";
        private IMathExRecognaz2Manager _logic = (IMathExRecognaz2Manager)
SupportHandlerManager.Base.GetManager("MathExRecognaz2Manager");
        public ICommand MouseDown { get; set; }
        public ICommand MouseUp { get; set; }
        public string HappySmily { get; set; }
        public string SadSmily { get; set; }
        public int Column { get; set; }
        public int Row { get; set; }
        public double BoardHeight { get; set; }
        public double BoardWidth { get; set; }
        private int _num = 0;
        protected Random _ran = new Random(DateTime.Now.Millisecond);
        public ObservableCollection<SoldierObject> ListBall { get; set; }
        public string AnswerText { get; set; }
        public BordMathRecognaz2VM()
        {
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.434;// 0.463
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.466;//0.491
            NotifyPropertyChanged(nameof(BoardWidth));
            NotifyPropertyChanged(nameof(BoardHeight));
            AnswerBut = new RelayCommand(DoAnswerBut);
            MouseUp = new RelayCommand(DoMouseUp);
            MouseDown = new RelayCommand(DoMouseDown);
            MouseMove = new RelayCommand(DoMouseMove);
            HappySmily = SadSmily = string.Empty;
            NotifyPropertyChanged(nameof(HappySmily));
            NotifyPropertyChanged(nameof(SadSmily));
        }

        private void DoAnswerBut(object obj)
        {
            if (base.IsQuestionMode)
            {
                _num = _ran.Next(1, 10);
                this.ListBall = new ObservableCollection<SoldierObject>(new SoldierObject[_num]);
                NotifyPropertyChanged(nameof(ListBall));
                AnswerText = TextCard = string.Empty;
                NotifyPropertyChanged(nameof(TextCard));
                NotifyPropertyChanged(nameof(AnswerText));
                HappySmily = SadSmily = string.Empty;
                NotifyPropertyChanged(nameof(HappySmily));
                NotifyPropertyChanged(nameof(SadSmily));
            }
            else
            {
                bool b = _num.ToString() == AnswerText;
                HappySmily = b ? string.Format(@"{0}\Resources\BS.Items\HappySmily.png"
    , System.AppDomain.CurrentDomain.BaseDirectory) : string.Empty;
                SadSmily = b ? string.Empty : string.Format(@"{0}\Resources\BS.Items\SadSmily.png"
    , System.AppDomain.CurrentDomain.BaseDirectory);
                NotifyPropertyChanged(nameof(HappySmily));
                NotifyPropertyChanged(nameof(SadSmily));
            }
            base.SwitchAnswerButton();
        }

        private void DoMouseMove(object obj)
        {
            string[] n = obj.ToString().Split('_');
            Row = int.Parse(n[1]);
            Column = int.Parse(n[0]);
            NotifyPropertyChanged(nameof(Row));
            NotifyPropertyChanged(nameof(Column));
        }
        private void DoMouseDown(object obj)
        {
            if (!base.IsQuestionMode)
            {
                string[] n = obj.ToString().Split('_');
                Row = int.Parse(n[1]);
                Column = int.Parse(n[0]);
                TextCard = (int.Parse(n[2]) + 1).ToString();
                NotifyPropertyChanged(nameof(Row));
                NotifyPropertyChanged(nameof(Column));
                NotifyPropertyChanged(nameof(TextCard));
                VisibilityCard = "Visible";
                NotifyPropertyChanged(nameof(VisibilityCard));
            }
        }
        private void DoMouseUp(object obj)
        {
            if (!base.IsQuestionMode)
            {
                AnswerText = TextCard;
                TextCard = string.Empty;
                NotifyPropertyChanged(nameof(AnswerText));
                NotifyPropertyChanged(nameof(TextCard));
                VisibilityCard = "Collapsed";
                NotifyPropertyChanged(nameof(VisibilityCard));
            }
        }
    }
}
