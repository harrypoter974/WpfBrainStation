using CL.BS.Contract;
using CL.BS.MathLearningVM.Comper;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CL.BS.MathLearningVM.Comper
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class MathComperVM3: BaseMathComperVM,IPageVM
    {
        public override string Name => "MathComperVM3";
        public Visibility StarsR0 { get { return _listStars[0].visibility; } set { _listStars[0].visibility = value; } }
        public Visibility StarsR1 { get { return _listStars[1].visibility; } set { _listStars[1].visibility = value; } }
        public Visibility StarsR2 { get { return _listStars[2].visibility; } set { _listStars[2].visibility = value; } }
        public Visibility StarsR3 { get { return _listStars[3].visibility; } set { _listStars[3].visibility = value; } }
        public Visibility StarsR4 { get { return _listStars[4].visibility; } set { _listStars[4].visibility = value; } }
        public Visibility StarsR5 { get { return _listStars[5].visibility; } set { _listStars[5].visibility = value; } }
        public Visibility StarsR6 { get { return _listStars[6].visibility; } set { _listStars[6].visibility = value; } }
        public Visibility StarsR7 { get { return _listStars[7].visibility; } set { _listStars[7].visibility = value; } }
        public Visibility StarsR8 { get { return _listStars[8].visibility; } set { _listStars[8].visibility = value; } }
        public Visibility StarsR9 { get { return _listStars[9].visibility; } set { _listStars[9].visibility = value; } }
        public Visibility StarsL0 { get { return _listStars[10].visibility; } set { _listStars[10].visibility = value; } }
        public Visibility StarsL1 { get { return _listStars[11].visibility; } set { _listStars[11].visibility = value; } }
        public Visibility StarsL2 { get { return _listStars[12].visibility; } set { _listStars[12].visibility = value; } }
        public Visibility StarsL3 { get { return _listStars[13].visibility; } set { _listStars[13].visibility = value; } }
        public Visibility StarsL4 { get { return _listStars[14].visibility; } set { _listStars[14].visibility = value; } }
        public Visibility StarsL5 { get { return _listStars[15].visibility; } set { _listStars[15].visibility = value; } }
        public Visibility StarsL6 { get { return _listStars[16].visibility; } set { _listStars[16].visibility = value; } }
        public Visibility StarsL7 { get { return _listStars[17].visibility; } set { _listStars[17].visibility = value; } }
        public Visibility StarsL8 { get { return _listStars[18].visibility; } set { _listStars[18].visibility = value; } }
        public Visibility StarsL9 { get { return _listStars[19].visibility; } set { _listStars[19].visibility = value; } }
        private List<LetterObject> _listStars;

        void IPageVM.load()
        {
            for (int i = 0; i < _listStars.Count(); i++)
            {
                _listStars[i].visibility = Visibility.Visible;
                NotifyPropertyChanged("Stars" + (i<10?'R':'L')+ (i%10));
            }
            base.ComperLoad();
        }

        public MathComperVM3()
        {
            _listStars = new List<LetterObject>();
            for (int i = 0; i < 20; i++)
                _listStars.Add(new LetterObject() { visibility = Visibility.Visible });
        }

        public override void AskQuestion()
        {
            if (Common.StaticVar.PlayMode)
                return;
            if (base.IsQuestionMode)
            {
                if (GoNext())
                    return;
                QuestionPlay();
                bool[] starsList = _logic.GetStars();
                TextResult = string.Empty;
                for (int i = 0; i < starsList.Length; i++)
                {
                    _listStars[i].visibility = starsList[i] ? Visibility.Visible : Visibility.Hidden;
                    NotifyPropertyChanged("Stars" + ("RL"[(i / 10)]) + i % 10);
                }
            }
            else
            {
                TextResult = _logic.GetStarsAns();

            }
            NotifyPropertyChanged("TextResult");
            base.SwitchAnswerButton();
        }
    }
}
