using CL.BS.Common;
using CL.BS.Contract;
using CL.BS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.MathLearningVM.VM.Recognaz
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class BoardPairExerciseVM : VMCommon.BaseLernPage, IPageVM
    {
        public override string Name => "BoardPairExerciseVM"; 
        public string Bird0 { get { return _birds[0].Background; } set { _birds[0].Background = value; } }
        public string Bird1 { get { return _birds[1].Background; } set { _birds[1].Background = value; } }
        public string Bird2 { get { return _birds[2].Background; } set { _birds[2].Background = value; } }
        public string Bird3 { get { return _birds[3].Background; } set { _birds[3].Background = value; } }
        public string Bird4 { get { return _birds[4].Background; } set { _birds[4].Background = value; } }
        public string Bird5 { get { return _birds[5].Background; } set { _birds[5].Background = value; } }
        public string Bird6 { get { return _birds[6].Background; } set { _birds[6].Background = value; } }
        public string Bird7 { get { return _birds[7].Background; } set { _birds[7].Background = value; } }
        private SoldierObject[] _birds = new SoldierObject[8];
        private Random _ran = new Random(DateTime.Now.Millisecond);
        private List<int> _questionNum = new List<int>();
        public string PairNum { get; set; }
        public string HappySmily { get; set; }
        public string PairBut { get; set; }
        private bool _isPair = false;
        public double BoardHeight { get; set; }
        public double BoardWidth { get; set; }
        public int Column { get; set; }
        public int Row { get; set; }
        public ICommand SetAnswer { get; set; }
        public ICommand MouseDown { get; set; }
        public ICommand MouseUp { get; set; }
        public BoardPairExerciseVM()
        {
            for (int i = 0; i < _birds.Length; i++)
                _birds[i] = new SoldierObject();
            AnswerBut = new RelayCommand(DoAnswerBut);
            SetAnswer = new RelayCommand(DoSetAnswer);
            MouseUp = new RelayCommand(DoMouseUp);
            MouseDown = new RelayCommand(DoMouseDown);
            MouseMove = new RelayCommand(DoMouseMove);
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.446;// 0.463
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.414;//0.491
            NotifyPropertyChanged(nameof(BoardWidth));
            NotifyPropertyChanged(nameof(BoardHeight));
        }

        private void DoSetAnswer(object obj)
        {
            _isPair = "2" == obj.ToString();
            PairBut = System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\Math\Recognaz\" + (_isPair ? "double" : "Odd") + "But.png";
            NotifyPropertyChanged("PairBut");
        }

        private void DoAnswerBut(object obj)
        {
            if (base.IsQuestionMode)
            {
                if (_questionNum.Count() == 0)
                {
                    _questionNum = Common.GeneralFunctions.ShuffleList<int>
                        (new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 });
                }
                PairNum = _questionNum[0].ToString();
                _questionNum.RemoveAt(0);
                NotifyPropertyChanged("PairNum");
                PairBut = string.Empty;
                NotifyPropertyChanged("PairBut");
                HappySmily = string.Empty;
                NotifyPropertyChanged(nameof(HappySmily));
                for (int i = 0; i < _birds.Length; i++)
                {
                    _birds[i].Background = String.Empty;
                    NotifyPropertyChanged("Bird" + i);
                }
            }
            else if (int.Parse(PairNum) > 0 && !string.IsNullOrEmpty(PairBut))
            {
                bool b = (int.Parse(PairNum) % 2 == 0) == _isPair;
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
            PicCard = string.Format(@"{0}\Resources\Math\Recognaz\Pigeon.png"
    , System.AppDomain.CurrentDomain.BaseDirectory);
            NotifyPropertyChanged(nameof(Row));
            NotifyPropertyChanged(nameof(Column));
            NotifyPropertyChanged(nameof(PicCard));
            VisibilityCard = "Visible";
            NotifyPropertyChanged(nameof(VisibilityCard));
        }
        private void DoMouseUp(object obj)
        {
            int n = int.Parse(obj.ToString());
            _birds[n].Background = PicCard;
            NotifyPropertyChanged("Bird" + n);
            PicCard = string.Empty;
            NotifyPropertyChanged(nameof(PicCard));
            VisibilityCard = "Collapsed";
            NotifyPropertyChanged(nameof(VisibilityCard));
        }
        void IPageVM.load()
        {
            for (int i = 0; i < _birds.Length; i++)
            {
                _birds[i].Background = String.Empty;
                NotifyPropertyChanged("Bird" + i);
            }
            HappySmily = PairNum = string.Empty;
            NotifyPropertyChanged(nameof(HappySmily));
            NotifyPropertyChanged(nameof(PairNum));
            base.Settings();
        }
    }
}
