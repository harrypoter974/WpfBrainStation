using CL.BS.Common;
using CL.BS.Contract;
using CL.BS.MathLearningManager.Interface.Recognaz;
using CL.BS.MEF;
using CL.BS.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.MathLearningVM.VM.Recognaz
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class BoardMathExRecognaz10VM : VMCommon.BaseLernPage, IPageVM
    {
        public override string Name => "BoardMathExRecognaz10VM";
        //private IMathExRecognaz10Manager _logic = (IMathExRecognaz10Manager)SupportHandlerManager.Base.GetManager("MathExRecognaz10Manager");
        public ICommand MouseDown { get; set; }
        public ICommand MouseUp { get; set; }
        public string HappySmily { get; set; }
        public string SadSmily { get; set; }
        public int Column { get; set; }
        public int Row { get; set; }
        public double BoardHeight { get; set; }
        public double BoardWidth { get; set; }
        public string TAnswer1 { get; set; }
        public string TAnswer0 { get; set; }
        protected Random _ran = new Random(DateTime.Now.Millisecond);
        private int _num = 0;
        private string[] _items = new string[] { "boat", "boll", "cake", "tomato" };
        public ObservableCollection<SoldierObject> ListBall { get; set; }
        public BoardMathExRecognaz10VM()
        {
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.434;// 0.463
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.466;//0.491
            NotifyPropertyChanged(nameof(BoardWidth));
            NotifyPropertyChanged(nameof(BoardHeight));
            AnswerBut = new RelayCommand(DoAnswerBut);
            MouseUp = new RelayCommand(DoMouseUp);
            MouseDown = new RelayCommand(DoMouseDown);
            MouseMove = new RelayCommand(DoMouseMove);
            HappySmily = SadSmily = string.Empty;
            NotifyPropertyChanged(nameof(HappySmily));
            NotifyPropertyChanged(nameof(SadSmily));
        }

        private void DoAnswerBut(object obj)
        {
            if (base.IsQuestionMode)
            {
                _num = Common.StaticVar.inline.ArrayDomain == 0? _ran.Next(11, 31): _ran.Next(10, 67);
                int n1, n0,nItem=_ran.Next(_items.Length);
                n1 = _num / 10;
                n0 = _num % 10;

                SoldierObject[] l = new SoldierObject[n1+n0 ];
                for (int i = 0; i < n1; i++)
                    l[i] = new SoldierObject() { Background = String.Format(@"{0}Resources\Math\Recognaz\{1}10.png", System.AppDomain.CurrentDomain.BaseDirectory,_items[nItem]) };
                for (int i = 0; i < n0; i++)
                    l[n1+ i] = new SoldierObject() { Background = String.Format(@"{0}Resources\Math\Recognaz\{1}.png", System.AppDomain.CurrentDomain.BaseDirectory, _items[nItem]) };
                this.ListBall = new ObservableCollection<SoldierObject>(l);
                NotifyPropertyChanged(nameof(ListBall));
                TAnswer1 = TAnswer0 = TextCard = string.Empty;
                NotifyPropertyChanged(nameof(TextCard));
                NotifyPropertyChanged(nameof(TAnswer0));
                NotifyPropertyChanged(nameof(TAnswer1));
                HappySmily = SadSmily = string.Empty;
                NotifyPropertyChanged(nameof(HappySmily));
                NotifyPropertyChanged(nameof(SadSmily));
            }
            else
            {

                bool b = _num.ToString() == TAnswer1+TAnswer0;
                HappySmily = b ? string.Format(@"{0}\Resources\BS.Items\HappySmily.png"
    , System.AppDomain.CurrentDomain.BaseDirectory) : string.Empty;
                SadSmily = b ? string.Empty : string.Format(@"{0}\Resources\BS.Items\SadSmily.png"
    , System.AppDomain.CurrentDomain.BaseDirectory);
                NotifyPropertyChanged(nameof(HappySmily));
                NotifyPropertyChanged(nameof(SadSmily));
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
            TextCard = n[2];
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
                string n=obj.ToString();
                if (n=="0")
                    TAnswer0 = TextCard; 
                else 
                    TAnswer1 = TextCard;
                TextCard = string.Empty;
                NotifyPropertyChanged("TAnswer" + n);
                NotifyPropertyChanged(nameof(TextCard));
                VisibilityCard = "Collapsed";
                NotifyPropertyChanged(nameof(VisibilityCard));    
            }
        }
    }
}
