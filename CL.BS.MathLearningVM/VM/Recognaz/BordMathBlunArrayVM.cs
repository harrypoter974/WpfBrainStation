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
    public class  BordMathBlunArrayVM : VMCommon.BaseLernPage, IPageVM
    {
        public override string Name => "BordMathBlunArrayVM";
        private  LetterObject[] _numList;
        private LetterObject[] _NumList = new LetterObject[10];
        private LetterObject[] _NumText = new LetterObject[10];
        public Visibility Num0 { get { return _NumList[0].visibility; } set { _NumList[0].visibility = value; } }
        public Visibility Num1 { get { return _NumList[1].visibility; } set { _NumList[1].visibility = value; } }
        public Visibility Num2 { get { return _NumList[2].visibility; } set { _NumList[2].visibility = value; } }
        public Visibility Num3 { get { return _NumList[3].visibility; } set { _NumList[3].visibility = value; } }
        public Visibility Num4 { get { return _NumList[4].visibility; } set { _NumList[4].visibility = value; } }
        public Visibility Num5 { get { return _NumList[5].visibility; } set { _NumList[5].visibility = value; } }
        public Visibility Num6 { get { return _NumList[6].visibility; } set { _NumList[6].visibility = value; } }
        public Visibility Num7 { get { return _NumList[7].visibility; } set { _NumList[7].visibility = value; } }
        public Visibility Num8 { get { return _NumList[8].visibility; } set { _NumList[8].visibility = value; } }
        public Visibility Num9 { get { return _NumList[9].visibility; } set { _NumList[9].visibility = value; } }
        public string NumText0 { get { return _NumText[0].Text; } set { _NumText[0].Text = value; } }
        public string NumText1 { get { return _NumText[1].Text; } set { _NumText[1].Text = value; } }
        public string NumText2 { get { return _NumText[2].Text; } set { _NumText[2].Text = value; } }
        public string NumText3 { get { return _NumText[3].Text; } set { _NumText[3].Text = value; } }
        public string NumText4 { get { return _NumText[4].Text; } set { _NumText[4].Text = value; } }
        public string NumText5 { get { return _NumText[5].Text; } set { _NumText[5].Text = value; } }
        public string NumText6 { get { return _NumText[6].Text; } set { _NumText[6].Text = value; } }
        public string NumText7 { get { return _NumText[7].Text; } set { _NumText[7].Text = value; } }
        public string NumText8 { get { return _NumText[8].Text; } set { _NumText[8].Text = value; } }
        public string NumText9 { get { return _NumText[9].Text; } set { _NumText[9].Text = value; } }
        private IMathBlunArrayManager _logic = (IMathBlunArrayManager)
SupportHandlerManager.Base.GetManager("MathBlunArrayManager");
        public double BoardHeight { get; set; }
        public double BoardWidth { get; set; }
        public int Column { get; set; }
        public int Row { get; set; }
        public string HappySmily { get; set; }
        public ICommand MouseDown { get; set; }
        public ICommand MouseUp { get; set; }
        public BordMathBlunArrayVM()
        {
            for (int i = 0; i < _NumList.Length; i++)
            {
                _NumList[i] = new LetterObject() { visibility = System.Windows.Visibility.Visible };
                _NumText[i] = new LetterObject() { Text = string.Empty };
            }
            AnswerBut = new RelayCommand(DoAnswerBut);
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.421;// 0.463
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.439;//0.491
            NotifyPropertyChanged(nameof(BoardWidth));
            NotifyPropertyChanged(nameof(BoardHeight));
            MouseUp = new RelayCommand(DoMouseUp);
            MouseDown = new RelayCommand(DoMouseDown);
            MouseMove = new RelayCommand(DoMouseMove);
            HappySmily = string.Empty;
            NotifyPropertyChanged(nameof(HappySmily));
        }

        private void DoAnswerBut(object obj)
        {
            if (base.IsQuestionMode)
            {
                string s = "B";
                _numList = _logic.GetQuestion(ref s);
                for (int i = 0; i < _NumList.Length; i++)
                {
                    _NumList[i].visibility = _numList[i].visibility;
                    NotifyPropertyChanged("Num" + i);
                    _NumText[i].Text = _numList[i].Text;
                    NotifyPropertyChanged("NumText" + i);
                }
            }
            else
            {

                bool b = true;
                for (int i = 0; i < _NumText.Length && b; i++)
                {
                    b = _NumText[i].Text == (i + 1).ToString();
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
                if (_numList[n].visibility == System.Windows.Visibility.Visible)
                    return;
                _NumText[n].Text = TextCard;
                VisibilityCard = "Collapsed";
                NotifyPropertyChanged(nameof(VisibilityCard));
                NotifyPropertyChanged("NumText" + n);
                TextCard = string.Empty;
                NotifyPropertyChanged(nameof(TextCard));
            }
        }
    }
}
