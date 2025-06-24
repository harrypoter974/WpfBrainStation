using CL.BS.Common;
using CL.BS.Contract;
using CL.BS.MathLearningManager.Interface.Recognaz;
using CL.BS.MEF;
using CL.BS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CL.BS.MathLearningVM.VM.Recognaz
{

    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class BordMathArray1VM : VMCommon.BaseLernPage, IPageVM
    {
        public override string Name => "BordMathArray1VM";
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
        public string NumText0 { get { return _numList[0].Text; } set { _numList[0].Text = value; } }
        public string NumText1 { get { return _numList[1].Text; } set { _numList[1].Text = value; } }
        public string NumText2 { get { return _numList[2].Text; } set { _numList[2].Text = value; } }
        public string NumText3 { get { return _numList[3].Text; } set { _numList[3].Text = value; } }
        public string NumText4 { get { return _numList[4].Text; } set { _numList[4].Text = value; } }
        public string NumText5 { get { return _numList[5].Text; } set { _numList[5].Text = value; } }
        public string NumText6 { get { return _numList[6].Text; } set { _numList[6].Text = value; } }
        public string NumText7 { get { return _numList[7].Text; } set { _numList[7].Text = value; } }
        public string NumText8 { get { return _numList[8].Text; } set { _numList[8].Text = value; } }
        public string NumText9 { get { return _numList[9].Text; } set { _numList[9].Text = value; } }
        public double BoardHeight { get; set; }
        public double BoardWidth { get; set; }
        public ICommand MouseDown { get; set; }
        public ICommand MouseUp { get; set; }
        public string HappySmily { get; set; }
        public int Column { get; set; }
        public int Row { get; set; }

        private IMathArray1Manager _logic = (IMathArray1Manager)
SupportHandlerManager.Base.GetManager("MathArray1Manager");
        public BordMathArray1VM()
        {
            for (int i = 0; i < _numList.Length; i++)
                _numList[i] = new LetterObject() { visibility = System.Windows.Visibility.Visible ,Text=String.Empty };
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
                string s="";
                LetterObject[] numList = _logic.GetQuestion(ref s);
                for (int i = 0; i < _numList.Length; i++)
                {
                    _numList[i].visibility = numList[i].visibility;
                    _numList[i].Text = numList[i].Text;
                    NotifyPropertyChanged("Num" + i);
                    NotifyPropertyChanged("NumText" + i);
                }

                HappySmily = string.Empty;
                NotifyPropertyChanged(nameof(HappySmily));
            }
            else
            {
                bool b = true;
                for (int i = 0; i < _numList.Length && b; i++)
                {
                    b = _numList[i].Text == (i + 1).ToString();
                }
                HappySmily = string.Format(@"{0}\Resources\BS.Items\{1}Smily.png"
    , System.AppDomain.CurrentDomain.BaseDirectory,b ? "Happy" : "Sad") ;
                NotifyPropertyChanged(nameof(HappySmily));
            }
            base.SwitchAnswerButton();
        }
        private void DoMouseMove(object obj)
        {
            string[] n = obj.ToString().Split('_');
            Row = int.Parse(n[0]);
            Column = int.Parse(n[1]);
            NotifyPropertyChanged(nameof(Row));
            NotifyPropertyChanged(nameof(Column));
        }
        private void DoMouseDown(object obj)
        {
            string[] n = obj.ToString().Split('_');
            Row = int.Parse(n[0]);
            Column = int.Parse(n[1]);
            TextCard = (int.Parse(n[2]) + 1).ToString();
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
                if (_numList[n].visibility== System.Windows.Visibility.Hidden)
                    return;
                _numList[n].Text = TextCard;
                TextCard = string.Empty;
                NotifyPropertyChanged(nameof(TextCard));
                VisibilityCard = "Collapsed";
                NotifyPropertyChanged(nameof(VisibilityCard));
                NotifyPropertyChanged("NumText" + n);
            }
        }
    }
}
