using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BS.BingoBoard.VM
{
    public class VisualMemoryBoardVM : BaseBingoBoardVM
    {
        public override string Name => "VisualMemoryBoardVM";
        public string TBArrow0 { get { return _items[0].Background; } set { _items[0].Background = value; } }
        public string TBArrow1 { get { return _items[1].Background; } set { _items[1].Background = value; } }
        public string TBArrow2 { get { return _items[2].Background; } set { _items[2].Background = value; } }
        public string TBArrow3 { get { return _items[3].Background; } set { _items[3].Background = value; } }
        public string TBArrow4 { get { return _items[4].Background; } set { _items[4].Background = value; } }

        private SoldierObject[] _items = new SoldierObject[5]; 

        public Visibility VisibilityGrid0 { get { return _Grids[0].LineVisible; } set { _Grids[0].LineVisible = value; } }
        public Visibility VisibilityGrid1 { get { return _Grids[1].LineVisible; } set { _Grids[1].LineVisible = value; } }
        public Visibility VisibilityGrid2 { get { return _Grids[2].LineVisible; } set { _Grids[2].LineVisible = value; } }
        private ItemObject[] _Grids = new ItemObject[3];
        public ICommand BeginDromLine { get; set; }
        public ICommand EndDromLine { get; set; }
        public ICommand MouseMove { get; set; }
        public ICommand Delete { get; set; }
        public ICommand DeleteAll { get; set; }
        public string DeleteBut { get; set; }
        public string ColorBall00 { get { return _asterisks[0].Background; } set { _asterisks[0].Background = value; } }
        public string ColorBall01 { get { return _asterisks[1].Background; } set { _asterisks[1].Background = value; } }
        public string ColorBall02 { get { return _asterisks[2].Background; } set { _asterisks[2].Background = value; } }
        public string ColorBall03 { get { return _asterisks[3].Background; } set { _asterisks[3].Background = value; } }
        public string ColorBall04 { get { return _asterisks[4].Background; } set { _asterisks[4].Background = value; } }
        public string ColorBall05 { get { return _asterisks[5].Background; } set { _asterisks[5].Background = value; } }
        public string ColorBall10 { get { return _asterisks[6].Background; } set { _asterisks[6].Background = value; } }
        public string ColorBall11 { get { return _asterisks[7].Background; } set { _asterisks[7].Background = value; } }
        public string ColorBall12 { get { return _asterisks[8].Background; } set { _asterisks[8].Background = value; } }
        public string ColorBall13 { get { return _asterisks[9].Background; } set { _asterisks[9].Background = value; } }
        public string ColorBall14 { get { return _asterisks[10].Background; } set { _asterisks[10].Background = value; } }
        public string ColorBall15 { get { return _asterisks[11].Background; } set { _asterisks[11].Background = value; } }
        public string ColorBall20 { get { return _asterisks[12].Background; } set { _asterisks[12].Background = value; } }
        public string ColorBall21 { get { return _asterisks[13].Background; } set { _asterisks[13].Background = value; } }
        public string ColorBall22 { get { return _asterisks[14].Background; } set { _asterisks[14].Background = value; } }
        public string ColorBall23 { get { return _asterisks[15].Background; } set { _asterisks[15].Background = value; } }
        public string ColorBall24 { get { return _asterisks[16].Background; } set { _asterisks[16].Background = value; } }
        public string ColorBall25 { get { return _asterisks[17].Background; } set { _asterisks[17].Background = value; } }
        public string ColorBall30 { get { return _asterisks[18].Background; } set { _asterisks[18].Background = value; } }
        public string ColorBall31 { get { return _asterisks[19].Background; } set { _asterisks[19].Background = value; } }
        public string ColorBall32 { get { return _asterisks[20].Background; } set { _asterisks[20].Background = value; } }
        public string ColorBall33 { get { return _asterisks[21].Background; } set { _asterisks[21].Background = value; } }
        public string ColorBall34 { get { return _asterisks[22].Background; } set { _asterisks[22].Background = value; } }
        public string ColorBall35 { get { return _asterisks[23].Background; } set { _asterisks[23].Background = value; } }
        public string ColorBall40 { get { return _asterisks[24].Background; } set { _asterisks[24].Background = value; } }
        public string ColorBall41 { get { return _asterisks[25].Background; } set { _asterisks[25].Background = value; } }
        public string ColorBall42 { get { return _asterisks[26].Background; } set { _asterisks[26].Background = value; } }
        public string ColorBall43 { get { return _asterisks[27].Background; } set { _asterisks[27].Background = value; } }
        public string ColorBall44 { get { return _asterisks[28].Background; } set { _asterisks[28].Background = value; } }
        public string ColorBall45 { get { return _asterisks[29].Background; } set { _asterisks[29].Background = value; } }

        public string ColorBall50 { get { return _asterisks[30].Background; } set { _asterisks[30].Background = value; } }
        public string ColorBall51 { get { return _asterisks[31].Background; } set { _asterisks[31].Background = value; } }
        public string ColorBall52 { get { return _asterisks[32].Background; } set { _asterisks[32].Background = value; } }
        public string ColorBall53 { get { return _asterisks[33].Background; } set { _asterisks[33].Background = value; } }
        public string ColorBall54 { get { return _asterisks[34].Background; } set { _asterisks[34].Background = value; } }
        public string ColorBall55 { get { return _asterisks[35].Background; } set { _asterisks[35].Background = value; } }

        protected SoldierObject[] _asterisks = new SoldierObject[36];
        private int[] _point;
        private string _answer;  
        private int _arrowPosition;
        public string LinePoints { get; set; }
        public string LinePointTemporary { get; set; }
        private Dictionary<string, int[]> _points = new Dictionary<string, int[]>();
        public VisualMemoryBoardVM()
        {
            for (int i = 0; i < _items.Length; i++)
                _items[i] = new SoldierObject();
            for (int i = 0; i < _Grids.Length; i++) { 
                _Grids[i] = new ItemObject() { LineVisible =i==0? Visibility.Visible : Visibility.Collapsed};
                NotifyPropertyChanged("VisibilityGrid" + i);
            }

            for (int i = 0; i < _asterisks.Length; i++)
            {
                _asterisks[i] = new SoldierObject() { Background = "Black" };
                _points.Add((i % 6).ToString() + (i / 6), new int[] { i % 6, i / 6 });
            }
            LinePoints = String.Empty;
            NotifyPropertyChanged("LinePoints");
            DeleteBut = String.Format(@"{0}\Resources\BS.Items\DeleteBut.png", System.AppDomain.CurrentDomain.BaseDirectory);
            NotifyPropertyChanged("DeleteBut");
            BeginDromLine = new RelayCommand(DoBeginDromLine);
            EndDromLine = new RelayCommand(DoEndDromLine);
            MouseMove = new RelayCommand(DoMouseMove);
            DeleteAll = new RelayCommand(DoDeleteAll);
            Delete = new RelayCommand(DoDelete);
            DoDeleteAll(null);
        }

        private void DoDelete(object obj)
        {
            string []l=LinePoints.Split(' ');
            string nl = string.Empty;
            for (int i = 0; i < l.Length-2; i++)
            {
                nl+=l[i]+' ';
            }
            LinePoints = nl;
            NotifyPropertyChanged("LinePoints");
        }

        private void DoDeleteAll(object obj)
        {
            DeleteBut = String.Format(@"{0}\Resources\BS.Items\DeleteBut.png", System.AppDomain.CurrentDomain.BaseDirectory);
            NotifyPropertyChanged("DeleteBut");
            LinePoints = String.Empty;
            NotifyPropertyChanged("LinePoints");
            for (int i = 0; i < _asterisks.Length; i++)
            {
                int i0 = i / 6;
                int i1 = i % 6;
                _asterisks[i].Background = "Black";
                NotifyPropertyChanged("ColorBall" + i0 + i1);
            }
        }

        private void DoMouseMove(object obj)
        {
            //if (_point == null)
            //    return;
            //Point mousePos = Mouse.GetPosition((IInputElement)obj);
            //double x = mousePos.X - 25;
            //double y = mousePos.Y - 50;
            //LinePointTemporary = string.Format("{0},{1} {2},{3}",
            //    _point[0] * 90 + 40, _point[1] * 100 + 40, x, y);
            //NotifyPropertyChanged("LinePointTemporary");
        }

        private void DoEndDromLine(object obj)
        {
            if (_point == null)
                return;

            string n = obj.ToString();
            int i = int.Parse(n);
            _point = _points[n];
            if (_Grids[0].LineVisible == Visibility.Visible)
            {
                LinePoints += string.Format(" {0},{1}", _point[1] * 100 + 50, _point[0] * 100 + 50);
            }
            else
            {
                LinePoints += string.Format(" {0},{1}", _point[1] * 50 + 25, _point[0] * 50 + 30);
            }
            LinePointTemporary = String.Empty;
            NotifyPropertyChanged("LinePointTemporary");
            NotifyPropertyChanged("LinePoints");
            int i0 = int.Parse(n[0].ToString());
            int i1 = int.Parse(n[1].ToString());
            _asterisks[i0 + i1 * 6].Background = "Olive";
            NotifyPropertyChanged("ColorBall" + n);
            _point = null;
            DeleteBut = String.Format(@"{0}\Resources\BS.Items\DeleteButBlue.png", System.AppDomain.CurrentDomain.BaseDirectory);
            NotifyPropertyChanged("DeleteBut");
        }

        private void DoBeginDromLine(object obj)
        {
            string n = obj.ToString();
            int i0 = int.Parse(n[0].ToString());
            int i1 = int.Parse(n[1].ToString());
            _asterisks[i0 + i1 * 6].Background = "Olive";
            NotifyPropertyChanged("ColorBall" + n);
            _point = _points[n];

            if (_Grids[0].LineVisible == Visibility.Visible)
            {
                LinePoints += string.Format(" {0},{1}", _point[1] *100 + 50, _point[0] * 100 + 50);
            }
            else
            {
                LinePoints += string.Format(" {0},{1}",_point[1] * 50 + 25, _point[0] *50 + 30 );
            }
            NotifyPropertyChanged("LinePoints"); 
        }
        public override void SetNumLetterLimit(int v)
        {
            for (int i = 0; i < _Grids.Length; i++) {
                _Grids[i].LineVisible = i == v ? Visibility.Visible : Visibility.Collapsed ;
                NotifyPropertyChanged("VisibilityGrid" + i);
            }
        }

        public override void SetQuestion(string q)
        {
           _answer= LinePoints = q;
            NotifyPropertyChanged("LinePoints");
        }

        public override bool GetIsFirst()
        {
            return false;
        }

        public override bool QuestionIsAnswer()
        {
            return false;
        }

        public override void SetBoard(List<GameObject> list)
        {
        }

        public override bool CheckBoard(string answer)
        {
           if(CheckAnswer(answer))
            {
                if (SetSoldierPosition())
                    SetSoldierPosition(true);
            }
            return _arrowPosition >= 4;
        }

        public override void SetAnswer(string question)
        {
        }

        public override void ClearQuestion()
        {
            LinePoints = String.Empty;
            NotifyPropertyChanged(nameof(LinePoints)); 
            DeleteBut = String.Format(@"{0}\Resources\BS.Items\DeleteBut.png", System.AppDomain.CurrentDomain.BaseDirectory);
            NotifyPropertyChanged(nameof(DeleteBut) );
            for (int i = 0; i < _asterisks.Length; i++)
            {
                int i0 = i / 6;
                int i1 = i % 6;
                _asterisks[i].Background = "Black";
                NotifyPropertyChanged("ColorBall" + i0 + i1);
            }
        }

        public override void Clear()
        {
            _items[_arrowPosition].Background = string.Empty;
            NotifyPropertyChanged("TBArrow" + _arrowPosition);
            _arrowPosition = 0;
            _items[_arrowPosition].Background = System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\Pion\Arrow" + Rotation + ".png";
            NotifyPropertyChanged("TBArrow" + _arrowPosition);
            ClearQuestion();
        }

        public override void RestartClear()
        {
            SetSoldierPosition(false);
            Clear();
        }

        public override void GameWin()
        {
            BaseWinBlink = System.Windows.Visibility.Visible;
            NotifyPropertyChanged("BaseWinBlink");
            Thread.Sleep(base.BlinkTime * (Is5Position() ? 2 : 1));
            BaseWinBlink = System.Windows.Visibility.Hidden;
            NotifyPropertyChanged("BaseWinBlink");
            base.PlayWin(); ;
        }

        public override bool CheckAnswer(string answer)
        {
            string[] ca = _answer.Split(' ');
            bool b = true;
            for (int i = 0; i < ca.Length&&b; i++)
            {
                b = LinePoints.Contains(ca[i]);
            }
            return b;
        }
        private bool SetSoldierPosition()
        {
            _items[_arrowPosition].Background = string.Empty;
            NotifyPropertyChanged("TBArrow" + _arrowPosition++);
            _items[_arrowPosition].Background = System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\Pion\Arrow" + Rotation + ".png";
            NotifyPropertyChanged("TBArrow" + _arrowPosition);
            return _arrowPosition == 4;
        }
    }
}
