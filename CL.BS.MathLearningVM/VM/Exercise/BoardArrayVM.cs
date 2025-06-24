using CL.BS.MathLearningManager.Interface.Exercise;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.MathLearningVM.VM.Exercise
{
    public class BoardArrayVM : BoardExercise1VM
    {
        public override string Name => nameof(BoardArrayVM);

        public BoardArrayVM(IMathComplexManager logic) : base(logic)
        {
            ChangeLimit = new RelayCommand(DoSetLevel);
            TypeNum = new RelayCommand(DoTypeNum);
            AnswerBut = new RelayCommand(DoAnswerBut);
            DoSetLevel(0);
        }
        private List<LetterObject>  _LstAnswer;
        private string _result = string.Empty;
        private int _resultAnswer;
        private Random _ran = new Random(DateTime.Now.Millisecond);
        private void DoTypeNum(object obj)
        {
            if (!base.IsQuestionMode)
            {
                string nl = obj.ToString();
                if (nl == "d")
                {
                    string ns = string.Empty;
                    for (int i = 0; i < _result.Length - 1; i++)
                        ns += _result[i];
                    _result = ns;
                }
                else if (_result.Length < 2)
                {
                    _result += nl;
                }
                List<LetterObject> newlist = new List<LetterObject>();
                for (int i = 0; i < LstProduct.Count(); i++)
                {
                    if (LstProduct[i].Background != null)
                    {
                        LstProduct[i] = LstProduct[i].Duplicate();
                        LstProduct[i].FontSize = 70;
                        LstProduct[i].Uid = "Black";
                        LstProduct[i].Text = Common.GeneralFunctions.SplitText(_result, " ");
                    }
                    newlist.Add(LstProduct[i]);
                }
                LstProduct.Clear();
                LstProduct = newlist;
                NotifyPropertyChanged(nameof(LstProduct));
            }
        }
        private void DoAnswerBut(object obj)
        {
            if (base.IsQuestionMode)
            {
                _logic.SetLevel(LevelPic1 == "0" ?1 : 2);
                LstProduct = _logic.GetQuestion(0);
                _LstAnswer =new List<LetterObject>( _logic.GetAnswer());
                _resultAnswer = _logic.GetResultLength();
                HappySmily = string.Empty;
                NotifyPropertyChanged(nameof(HappySmily));
            }
            else
            {
                LstProduct = _LstAnswer;
                HappySmily = string.Format(@"{0}\Resources\BS.Items\{1}Smily.png"
, System.AppDomain.CurrentDomain.BaseDirectory, _resultAnswer.ToString() == _result ? "Happy" : "Sad");
                NotifyPropertyChanged(nameof(HappySmily));
                _result = string.Empty;
                // new Thread(new ThreadStart(() =>
                //{})).Start();
            }
            base.SwitchAnswerButton();
            NotifyPropertyChanged(nameof(LstProduct) );
        }
        private void DoSetLevel(object level)
        {
            string b = level.ToString();
            if (level.ToString() == "1")
            {
                LevelPic0 = b;
                LevelPic1 =String.Format(@"{0}Resources\BS.Items\Hard.png",
                    System.AppDomain.CurrentDomain.BaseDirectory); 

            }
            else
            {
                LevelPic0 = String.Format(@"{0}Resources\BS.Items\Easy.png",
                    System.AppDomain.CurrentDomain.BaseDirectory);
                LevelPic1 = b;
            }
            NotifyPropertyChanged(nameof(LevelPic0));
            NotifyPropertyChanged(nameof(LevelPic1));
        }
    }
}
