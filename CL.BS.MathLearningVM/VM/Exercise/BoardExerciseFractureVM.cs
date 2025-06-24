using CL.BS.MathLearningManager.Interface.Exercise;
using CL.BS.MEF;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CL.BS.MathLearningVM.VM.Exercise
{
    public class BoardExerciseFractureVM : BoardExercise1VM
    {
        public string LNum1 { get; set; }
        public string LNumFMone1 { get; set; }
        public string LNumFMechane1 { get; set; }
        public Visibility Line1 { get; set; }
        public string LOperator { get; set; }
        public string LNum2 { get; set; }
        public string LNumFMone2 { get; set; }
        public string LNumFMechane2 { get; set; }
        public Visibility Line2 { get; set; }
        public string LNum { get; set; }
        public string LNumMone { get; set; }
        public string LNumMachne { get; set; }
        private string _taxtQes;
        //private readonly string _pathNum = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Math\NumLetters\";
        private IMathFractureManager _logic;
     protected   float _Answer;
        private string Operator = "+";
        public BoardExerciseFractureVM(IMathComplexManager logic) : base(logic)
        {
            TypeNum = new RelayCommand(DoTypeNum);
            AnswerBut = new RelayCommand(DoAnswerBut);
            Line2 = Line1 = Visibility.Collapsed;
            NotifyPropertyChanged("Line2");
            NotifyPropertyChanged("Line1");
        }

        private void DoTypeNum(object obj)
        {
            string nl = obj.ToString();
            if (nl == "d")
            {
                string ns = string.Empty;
                for (int i = 0; i < Result.Length - 1; i++)
                    ns += Result[i];
                Result = ns;
            }
            else if (Result.Length < 3)
            {
                Result += nl;
            }
            if (Result.Length == 3)
            {
                LNum = Result[0].ToString();
                LNumMone = Result[1].ToString();
                LNumMachne = Result[2].ToString();
            }
            else if (Result.Length == 2)
            {
                LNum = Result[0].ToString();
                LNumMone = Result[1].ToString();
                LNumMachne = string.Empty;
            }
            else if (Result.Length == 1)
            {
                LNum = Result[0].ToString();
                LNumMone = LNumMachne = string.Empty;
            }
            else
            {
                LNum = LNumMone = LNumMachne = string.Empty;
            }
            NotifyPropertyChanged("LNum");
            NotifyPropertyChanged("LNumMone");
            NotifyPropertyChanged("LNumMachne");
        }

        private void DoAnswerBut(object obj)
        {
            if (base.IsQuestionMode)
            {
                SetQuestion(_logic.SetQuestion());
                _Answer = _logic.GetTAnswer();
                SetAnswer(-1);
                HappySmily = string.Empty;
                NotifyPropertyChanged(nameof(HappySmily));
            }
            else {
                string []r= _Answer.ToString().Split('.');
                bool b = r[0] == LNum;
                if (b&&r.Length>1)
                {
                    switch (r[1])
                    {
                        case "75":b= LNumMone+LNumMachne== "34"; break;
                        case "5": b= LNumMone+LNumMachne=="12"; break;
                        case "25":b= LNumMone + LNumMachne == "14"; break;
                        default:
                            break;
                    }
                }
                HappySmily = string.Format(@"{0}\Resources\BS.Items\{1}Smily.png", 
                    System.AppDomain.CurrentDomain.BaseDirectory, b ? "Happy" : "Sad");
                NotifyPropertyChanged(nameof(HappySmily));
                SetAnswer(_Answer);
            }
            base.SwitchAnswerButton();
        }
        internal void SetQuestion(float[] num)
        {
            Result = LNum1 = LNumFMone1 = LNumFMechane1 = string.Empty;
            NotifyPropertyChanged("LNum1");
            NotifyPropertyChanged("LNumFMone1");
            NotifyPropertyChanged("LNumFMechane1");
            //
            _taxtQes = num[0] + Operator + num[1];
            string[] stringNum = num[0].ToString().Split('.');

            if (num[0] >= 1)
            {
                LNum1 =  stringNum[0];
            }
            else
                LNum1 = string.Empty;
            Line1 = Visibility.Visible;
            if (stringNum.Length > 1)
            {
                string numFMone1;
                switch (stringNum[1])
                {//
                    case "25": numFMone1 = "14"; ; break;
                    case "5": numFMone1 = "12"; ; break;
                    case "75": numFMone1 = "34"; ; break;
                    default:
                        numFMone1 = string.Empty;
                        Line1 = Visibility.Collapsed;
                        break;
                }
                if (numFMone1 != string.Empty)
                {
                    LNumFMone1    =  numFMone1[0].ToString();
                    LNumFMechane1 =  numFMone1[1].ToString();
                }

            }
            else
            {
                Line1 = Visibility.Collapsed;
                LNumFMone1 = LNumFMechane1 = string.Empty;
            }
            LOperator = Operator ;
            stringNum = num[1].ToString().Split('.');
            if (num[1] >= 1)
            {
                LNum2 =  stringNum[0] ;
            }
            else
                LNum2 = string.Empty;
            if (stringNum.Length > 1)
            {
                string numFMone2;
                Line2 = Visibility.Visible;
                switch (stringNum[1])
                {//
                    case "25": numFMone2 = "14"; break;
                    case "5": numFMone2 = "12"; break;
                    case "75": numFMone2 = "34"; break;
                    default:
                        numFMone2 = string.Empty;
                        break;
                }
                if (numFMone2 != string.Empty)
                {
                    LNumFMone2 = numFMone2[0].ToString();
                    LNumFMechane2 = numFMone2[1].ToString();
                }
            }
            else
            {
                Line2 = Visibility.Collapsed;
                LNumFMone2 = LNumFMechane2 = string.Empty;
            }
            NotifyPropertyChanged("LNum1");
            NotifyPropertyChanged("LNumFMone1");
            NotifyPropertyChanged("LNumFMechane1");
            NotifyPropertyChanged("Line1");
            NotifyPropertyChanged("LOperator");
            NotifyPropertyChanged("LNum2");
            NotifyPropertyChanged("LNumFMone2");
            NotifyPropertyChanged("LNumFMechane2");
            NotifyPropertyChanged("Line2");

        }

        protected void SetAnswer(float answer)
        {
            if (answer == -1)
            {
                LNum = LNumMone = LNumMachne = string.Empty;
            }
            else
            {
                string[] r = answer.ToString().Split('.');
                if (r.Length == 1)
                {
                    r = new string[] { r[0], string.Empty };
                }
                else
                {
                    switch (r[1])
                    {
                        case "75": r[1] = "34"; break;
                        case "5": r[1] = "12"; break;
                        case "25": r[1] = "14"; break;
                        default:
                            break;
                    }
                }
                string[] a = answer.ToString().Split('.');
                if (answer >= 1)
                {
                    LNum = a[0].ToString();
                }
                else
                    LNum = string.Empty;
                if (a.Length > 1)
                {
                    string numFMone;
                    switch (a[1])
                    {//
                        case "25": numFMone = "14"; ; break;
                        case "5": numFMone = "12"; ; break;
                        case "75": numFMone = "34"; ; break;
                        default:
                            numFMone = string.Empty;
                            Line1 = Visibility.Collapsed;
                            break;
                    }
                    if (numFMone != string.Empty)
                    {
                        LNumMone = numFMone[0].ToString();
                        LNumMachne = numFMone[1].ToString();
                    }

                }
                else
                {
                    LNumMone = LNumMachne = string.Empty;
                }
            }
            NotifyPropertyChanged("LNum");
            NotifyPropertyChanged(nameof(  LNumMone));
            NotifyPropertyChanged(nameof(LNumMachne));
        }

        internal void SetOperator(string o)
        {
            Operator = o;
            switch (Operator)
            {
                case "+":
                    _logic = (IMathFractureManager)
     SupportHandlerManager.Base.GetManager("MathAddFractureManger"); break;
                case "-":
                    _logic = (IMathFractureManager)
     SupportHandlerManager.Base.GetManager("MathSubFractureManager"); break;
                case ":":
                    _logic = (IMathFractureManager)
SupportHandlerManager.Base.GetManager("MathSpliteFractureManager"); break;
                case "x":
                    _logic = (IMathFractureManager)
SupportHandlerManager.Base.GetManager("MathMoltipolFractureManager"); break;
                default:
                    break;
            }
        }
        public override string Name => nameof(BoardExerciseFractureVM);
    }
}
