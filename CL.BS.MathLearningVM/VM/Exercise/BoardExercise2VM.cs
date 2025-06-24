using CL.BS.MathLearningManager.Interface.Exercise;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningVM.VM.Exercise
{
    public class BoardExercise2VM : BoardExercise1VM
    {
        public override string Name => nameof(BoardExercise2VM);
        public string FieldOfCalculation { get; set; }
        public BoardExercise2VM(IMathComplexManager logic) : base(logic)
        {
            _limit = new string[] { "99", "999", "9999" };
            FieldOfCalculation = string.Format(@"{0}\Resources\Math\Exercise\FieldOfCalculation.png"
   , System.AppDomain.CurrentDomain.BaseDirectory);
            NotifyPropertyChanged(nameof(FieldOfCalculation));
            TypeNum = new RelayCommand(DoTypeNum);
            ChangeLimit = new RelayCommand(DoChangeLimit);
            DoChangeLimit(0);
        }
        private void DoChangeLimit(object obj)
        {
            LevelButs[LimitIndex].Background = string.Empty;
            NotifyPropertyChanged("LevelBut" + LimitIndex);
            string num = obj.ToString();
            LimitIndex = int.Parse(num);
            LevelButs[LimitIndex].Background = System.AppDomain.CurrentDomain.BaseDirectory
                   + @"Resources\Number\" + _limit[LimitIndex] + "b.png";
            NotifyPropertyChanged("LevelBut" + num);
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
                        LstProduct[i].FontSize = 48;
                        LstProduct[i].Uid = "Black";
                        LstProduct[i].Text =Result;
                    }
                    newlist.Add(LstProduct[i]);
                }
                LstProduct.Clear();
                LstProduct = newlist;
                NotifyPropertyChanged("LstProduct");
            }
        }

    }
}
