using CL.BS.Common;
using CL.BS.Contract;
using CL.BS.MathLearningManager.Interface.Comper;
using CL.BS.MEF;
using CL.BS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CL.BS.MathLearningVM.VM.Comper
{

    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class BordComperVM : VMCommon.BaseLernPage, IPageVM
    {
        public override string Name => "BordComperVM";
        private int _indexPage =1;
        protected IMathComperManager _logic = (IMathComperManager)
 SupportHandlerManager.Base.GetManager("MathComperManager");
        private Random _ran = new Random(DateTime.Now.Millisecond);
        public string BackgroundPic { get; set; }
        public string Grid0 { get { return _listItems[0].Background; } set { _listItems[0].Background = value; } }
        public string Grid1 { get { return _listItems[1].Background; } set { _listItems[1].Background = value; } }
        public string Grid2 { get { return _listItems[2].Background; } set { _listItems[2].Background = value; } }
        public Visibility ItemR0 { get { return _listItems[0].visibility; } set { _listItems[0].visibility = value; } }
        public Visibility ItemR1 { get { return _listItems[1].visibility; } set { _listItems[1].visibility = value; } }
        public Visibility ItemR2 { get { return _listItems[2].visibility; } set { _listItems[2].visibility = value; } }
        public Visibility ItemR3 { get { return _listItems[3].visibility; } set { _listItems[3].visibility = value; } }
        public Visibility ItemR4 { get { return _listItems[4].visibility; } set { _listItems[4].visibility = value; } }
        public Visibility ItemR5 { get { return _listItems[5].visibility; } set { _listItems[5].visibility = value; } }
        public Visibility ItemR6 { get { return _listItems[6].visibility; } set { _listItems[6].visibility = value; } }
        public Visibility ItemR7 { get { return _listItems[7].visibility; } set { _listItems[7].visibility = value; } }
        public Visibility ItemR8 { get { return _listItems[8].visibility; } set { _listItems[8].visibility = value; } }
        public Visibility ItemR9 { get { return _listItems[9].visibility; } set { _listItems[9].visibility = value; } }
        public Visibility ItemL0 { get { return _listItems[10].visibility; } set {_listItems[10].visibility = value; } }
        public Visibility ItemL1 { get { return _listItems[11].visibility; } set {_listItems[11].visibility = value; } }
        public Visibility ItemL2 { get { return _listItems[12].visibility; } set {_listItems[12].visibility = value; } }
        public Visibility ItemL3 { get { return _listItems[13].visibility; } set {_listItems[13].visibility = value; } }
        public Visibility ItemL4 { get { return _listItems[14].visibility; } set {_listItems[14].visibility = value; } }
        public Visibility ItemL5 { get { return _listItems[15].visibility; } set {_listItems[15].visibility = value; } }
        public Visibility ItemL6 { get { return _listItems[16].visibility; } set {_listItems[16].visibility = value; } }
        public Visibility ItemL7 { get { return _listItems[17].visibility; } set {_listItems[17].visibility = value; } }
        public Visibility ItemL8 { get { return _listItems[18].visibility; } set {_listItems[18].visibility = value; } }
        public Visibility ItemL9 { get { return _listItems[19].visibility; } set { _listItems[19].visibility = value; } }
        private LetterObject[] _listItems = new LetterObject[20];
        public double BoardHeight { get; set; }
        public double BoardWidth { get; set; }
        public ICommand MouseDown { get; set; }
        public ICommand MouseUp { get; set; }
        public string HappySmily { get; set; }
        public int Column { get; set; }
        public int Row { get; set; }
        public string LText { get; set; }
        public string RText { get; set; }
        public string _Result;
        public BordComperVM()
        {
            for (int i = 0; i < _listItems.Length; i++)
                _listItems[i] = new LetterObject() { visibility = System.Windows.Visibility.Visible, Text = String.Empty };
            AnswerBut = new RelayCommand(DoAnswerBut);
            MouseUp = new RelayCommand(DoMouseUp);
            MouseDown = new RelayCommand(DoMouseDown);
            MouseMove = new RelayCommand(DoMouseMove);
            HappySmily = string.Empty;
            NotifyPropertyChanged(nameof(HappySmily));
            Grid1 = "Visible";
            Grid2 = Grid0 = "Collapsed";
            for (int i = 0; i < 3; i++)
                NotifyPropertyChanged("Grid" + i);
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.339;// 0.463
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.369;//0.491
            NotifyPropertyChanged(nameof(BoardWidth));
            NotifyPropertyChanged(nameof(BoardHeight));
        }
        private void DoAnswerBut(object obj)
        {
            if (base.IsQuestionMode)
            {

                _listItems[_indexPage].Background = "Collapsed";
                NotifyPropertyChanged("Grid"+_indexPage);
                _indexPage = _ran.Next(3);
                _listItems[_indexPage].Background = "Visible";
                NotifyPropertyChanged("Grid" + _indexPage);
              TextResult =   HappySmily = string.Empty;
                NotifyPropertyChanged(nameof(HappySmily));
                NotifyPropertyChanged(nameof(TextResult));
                if (_indexPage==0)
                {
                    bool[] fishList = _logic.GetFish();
                    TextResult = string.Empty;
                    for (int i = 0; i < fishList.Length; i++)
                    {
                        _listItems[i].visibility = fishList[i] ? Visibility.Visible : Visibility.Hidden;
                        NotifyPropertyChanged("ItemR" + i);
                    }
                    _Result=_logic.GetFishAns();
                }
                else if (_indexPage == 1)
                {
                    string[] q = _logic.GetNum();
                    LText = q[0];
                    RText = q[1];
                    NotifyPropertyChanged(nameof(LText));
                    NotifyPropertyChanged(nameof(RText));
                    _Result= _logic.GetNumAns();
                }
                else if (_indexPage == 2)
                {
                    bool[] starsList = _logic.GetStars();
                    TextResult = string.Empty;
                    for (int i = 0; i < starsList.Length; i++)
                    {
                        _listItems[i].visibility = starsList[i] ? Visibility.Visible : Visibility.Hidden;
                        NotifyPropertyChanged("Item" + ("RL"[(i / 10)]) + i % 10);
                    }
                    _Result=_logic.GetStarsAns();
                }
            }
            else
            {
                bool b = true;
                if (_indexPage == 0)
                    b = TextResult == _Result;
                else if (_indexPage == 1)
                    b = TextResult == _Result;
                else if (_indexPage == 2)
                    b = TextResult == _Result;
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
            if (!base.IsQuestionMode)
            {
                string[] n = obj.ToString().Split('_');
                Row = int.Parse(n[1]);
                Column = int.Parse(n[0]);
                TextCard = ">=<"[int.Parse(n[2])].ToString();
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
                TextResult = TextCard;
                NotifyPropertyChanged(nameof(TextResult));
                TextCard = string.Empty;
                NotifyPropertyChanged(nameof(TextCard));
                VisibilityCard = "Collapsed";
                NotifyPropertyChanged(nameof(VisibilityCard));
            }
        }
    }
}
