using CL.BS.Common;
using CL.BS.MathLearningManager.Interface.Exercise;
using CL.BS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.MathLearningVM.VM.Exercise
{
    public class BoardExercise1VM : VMCommon.BaseLernPage
    {     
        public override string Name => nameof(BoardExercise1VM); 
        protected string[] _limit = new string[] { "10", "30", "100" };
        private Random _ran = new Random(DateTime.Now.Millisecond);
        protected LetterObject[] LevelButs = new LetterObject[3];
        protected int ResultLength = 2;
        protected string Result = string.Empty;
        public string LevelBut0 { get { return LevelButs[0].Background; } set { LevelButs[0].Background = value; } }
        public string LevelBut1 { get { return LevelButs[1].Background; } set { LevelButs[1].Background = value; } }

        public string HappySmily { get; set; }
        public string LevelBut2 { get { return LevelButs[2].Background; } set { LevelButs[2].Background = value; } }
        public ICommand ChangeLimit { get; set; }
        public ICommand TypeNum { get; set; }
        public int LimitIndex { get; set; }
        public List<LetterObject> LstProduct { get; set; }
        public string LevelPic0 { get; set; }
        public string LevelPic1 { get; set; }
        protected IMathComplexManager _logic;
        protected List<LetterObject> _Answer;
        public BoardExercise1VM(IMathComplexManager logic)
        {
            _logic = logic;
            ChangeLimit = new RelayCommand(DoChangeLimit);
            TypeNum = new RelayCommand(DoTypeNum);
            AnswerBut = new RelayCommand(DoAnswerBut);
            for (int i = 0; i < LevelButs.Length; i++)
                LevelButs[i] = new LetterObject();
            KeyboardVisibility = System.Windows.Visibility.Collapsed;
            NotifyPropertyChanged(nameof(KeyboardVisibility));
        }

        internal void SetLimitTo1()
        {
            if(!(this is BoardExercise2VM))
                DoChangeLimit(0);
        }

        private void DoTypeNum(object obj)
        {
            if (!base.IsQuestionMode)
            {
                string nl = obj.ToString();
                if (nl == "d")
                {
                    string ns = string.Empty;
                    for (int i = 0; i < Result.Length - 1; i++)
                        ns += Result[i];
                    Result = ns;
                }
                else if (Result.Length < ResultLength)
                {
                    Result += nl;
                }
                List<LetterObject> newlist = new List<LetterObject>();
                for (int i = 0; i < LstProduct.Count(); i++)
                {
                    if (LstProduct[i].Background != null)
                    {
                        LstProduct[i] = LstProduct[i].Duplicate();
                        LstProduct[i].FontSize = 70;
                        LstProduct[i].Uid = "Black";
                        LstProduct[i].Text = Common.GeneralFunctions.SplitText(Result, " ");
                    }
                    newlist.Add(LstProduct[i]);
                }
                LstProduct.Clear();
                LstProduct = newlist;
                NotifyPropertyChanged("LstProduct");
            }
        }

        internal void CheckResult()
        {
            for (int i = 0; i < LstProduct.Count(); i++)
            {
                if (LstProduct[i].Background != null)
                {
                    int num = i;                
                    HappySmily = string.Format(@"{0}\Resources\BS.Items\{1}Smily.png"
   , System.AppDomain.CurrentDomain.BaseDirectory,
   Common.GeneralFunctions.Trim(LstProduct[num].Text) ==Result  ? "Happy" : "Sad");
                    NotifyPropertyChanged(nameof(HappySmily));
                    Result = string.Empty;
                }
            }
        }

        internal List<LetterObject> SetTypeNum(object obj)
        {
            string nl = obj.ToString();
            if (nl == "d")
            {
                string ns = string.Empty;
                for (int i = 0; i < Result.Length - 1; i++)
                    ns += Result[i];
                Result = ns;
            }
            else if (Result.Length < ResultLength)
            {
                Result += nl;
            }
            List<LetterObject> newlist = new List<LetterObject>();
            for (int i = 0; i < LstProduct.Count(); i++)
            {
                if (LstProduct[i].Background != null)
                {
                    LstProduct[i].Uid = "Black";
                    LstProduct[i] = LstProduct[i].Duplicate();
                    LstProduct[i].FontSize = 70;
                    LstProduct[i].Text = Common.GeneralFunctions.SplitText(Result, " ");
                }
                newlist.Add(LstProduct[i]);
            }
            return newlist;
        }

        private void DoChangeLimit(object obj)
        {
            LevelButs[LimitIndex].Background = string.Empty;
            NotifyPropertyChanged("LevelBut" + LimitIndex);
            string num = obj.ToString();
            LimitIndex = int.Parse(num);  
            LevelButs[LimitIndex].Background = System.AppDomain.CurrentDomain.BaseDirectory
                   + @"Resources\Number\m" + _limit[LimitIndex] + ".png";
            NotifyPropertyChanged("LevelBut" + num);
        }

        private void DoAnswerBut(object obj)
        {
            if (base.IsQuestionMode)
            {
                HappySmily = String.Empty;
                NotifyPropertyChanged(nameof(HappySmily));
                LstProduct = _logic.GetQuestion(LimitIndex);
                ResultLength = _logic.GetResultLength();
                _Answer = _logic.GetAnswer();

            }
            else
            {
                LstProduct =_Answer ;
                CheckResult();
            }
            base.SwitchAnswerButton();
            NotifyPropertyChanged("LstProduct");
        }
    }
}
