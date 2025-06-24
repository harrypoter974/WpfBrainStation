using CL.BS.Common;
using CL.BS.Contract;
using CL.BS.MathLearningManager.Interface.Recognaz;
using CL.BS.MEF;
using CL.BS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CL.BS.MathLearningVM.VM.Recognaz
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class BoardMathArray2VM : VMCommon.BaseLernPage, IPageVM
    {
        public override string Name => "BoardMathArray2VM";
        private IMathArray3Manager _logic = (IMathArray3Manager)SupportHandlerManager.Base.GetManager("MathArray3Manager");
        private LetterObject[] _numList = new LetterObject[10];
        public Visibility Num0 { get { return _numList[0].visibility; } set { _numList[0].visibility = value; } }
        public Visibility Num1 { get { return _numList[1].visibility; } set { _numList[1].visibility = value; } }
        public Visibility Num2 { get { return _numList[2].visibility; } set { _numList[2].visibility = value; } }
        public Visibility Num3 { get { return _numList[3].visibility; } set { _numList[3].visibility = value; } }
        public Visibility Num4 { get { return _numList[4].visibility; } set { _numList[4].visibility = value; } }
        public Visibility Num5 { get { return _numList[5].visibility; } set { _numList[5].visibility = value; } }
        public Visibility Num6 { get { return _numList[6].visibility; } set { _numList[6].visibility = value; } }
        public Visibility Num7 { get { return _numList[7].visibility; } set { _numList[7].visibility = value; } }
        public Visibility Num8 { get { return _numList[8].visibility; } set { _numList[8].visibility = value; } }
        public Visibility Num9 { get { return _numList[9].visibility; } set { _numList[9].visibility = value; } }
        public string TAnswer0 { get { return _numList[0].Text; } set { _numList[0].Text = value; } }
        public string TAnswer1 { get { return _numList[1].Text; } set { _numList[1].Text = value; } }
        public string TAnswer2 { get { return _numList[2].Text; } set { _numList[2].Text = value; } }
        public string TAnswer3 { get { return _numList[3].Text; } set { _numList[3].Text = value; } }
        public string TAnswer4 { get { return _numList[4].Text; } set { _numList[4].Text = value; } }
        public string TAnswer5 { get { return _numList[5].Text; } set { _numList[5].Text = value; } }
        public string TAnswer6 { get { return _numList[6].Text; } set { _numList[6].Text = value; } }
        public string TAnswer7 { get { return _numList[7].Text; } set { _numList[7].Text = value; } }
        public string TAnswer8 { get { return _numList[8].Text; } set { _numList[8].Text = value; } }
        public string TAnswer9 { get { return _numList[9].Text; } set { _numList[9].Text = value; } }
        public double BoardHeight { get; set; }
        public double BoardWidth { get; set; }
        public ICommand MouseDown { get; set; }
        public ICommand MouseUp { get; set; }
        public string HappySmily { get; set; }
        public int Column { get; set; }
        public int Row { get; set; }
        string[] _Num_List=new string[0];
        public BoardMathArray2VM()
        {
            for (int i = 0; i < _numList.Length; i++)
                _numList[i] = new LetterObject() { visibility = System.Windows.Visibility.Visible, Text = String.Empty };
            AnswerBut = new RelayCommand(DoAnswerBut);
            MouseUp = new RelayCommand(DoMouseUp);
            MouseDown = new RelayCommand(DoMouseDown);
            MouseMove = new RelayCommand(DoMouseMove);
            HappySmily = string.Empty;
            NotifyPropertyChanged(nameof(HappySmily));
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.426;// 0.463
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.388;//0.491
            NotifyPropertyChanged(nameof(BoardWidth));
            NotifyPropertyChanged(nameof(BoardHeight));
        }
        private void DoAnswerBut(object obj)
        {
            if (base.IsQuestionMode)
            {
                string s = "";
                _Num_List = _logic.SetQuestion();
            string[]nl =(string[])_logic.GetAnswer().Clone();
                for (int i = 0; i < _Num_List.Length; i++)
                {
                    _numList[i].Text = _Num_List[i];
                    NotifyPropertyChanged("TAnswer" + i);
                }

                HappySmily = string.Empty;
                NotifyPropertyChanged(nameof(HappySmily));
                _Num_List = nl;
            }
            else
            {
                bool b = true;
                for (int i = 0; i < _Num_List.Length && b; i++)
                {
                    b = _numList[i].Text == _Num_List[i];
                }
                HappySmily = string.Format(@"{0}\Resources\BS.Items\{1}Smily.png"
    , System.AppDomain.CurrentDomain.BaseDirectory, b ? "Happy" : "Sad");
                NotifyPropertyChanged(nameof(HappySmily));
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
            string[] n = obj.ToString().Split('_');
            Row = int.Parse(n[1]);
            Column = int.Parse(n[0]);
            TextCard = n[2];
            NotifyPropertyChanged(nameof(Row));
            NotifyPropertyChanged(nameof(Column));
            NotifyPropertyChanged(nameof(TextCard));
            VisibilityCard = "Visible";
            NotifyPropertyChanged(nameof(VisibilityCard));
        }
        private void DoMouseUp(object obj)
        {
            if (!base.IsQuestionMode)
            {
                int n = int.Parse(obj.ToString());
                if (_numList[n].visibility == System.Windows.Visibility.Hidden)
                    return;
                _numList[n].Text = TextCard;
                TextCard = string.Empty;
                NotifyPropertyChanged(nameof(TextCard));
                VisibilityCard = "Collapsed";
                NotifyPropertyChanged(nameof(VisibilityCard));
                NotifyPropertyChanged("TAnswer" + n);
            }
        }
    }
}
