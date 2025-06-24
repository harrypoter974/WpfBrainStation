using CL.BS.Contract;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.NotionsVM.VM.Economy
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class BalanceVM : BaseLernPage, IPageVM
    {
        public string BackgroundPic { get; set; }
        public string AnswerButBackground { get; set; }
        public string HappySmily { get; set; }
        public string WeightText { get; set; }
        public string LevelBut0 { get; set; }
        public string LevelBut1 { get; set; }
        public int Column { get; set; }
        public int Row { get; set; }
        public int BoxRow { get; set; }
        public int ListRow { get; set; }
        public List<SoldierObject> LstProduct { get; set; }
        public ICommand MouseDown { get; set; }
        public ICommand ChangeLevel { get; set; }
        public ICommand MouseUp { get; set; }
        protected Random _ran = new Random(DateTime.Now.Millisecond);
        private int _Answer = 0, _SumWeight = 0, _lastWeight=0;
        private int[] _WeightList = new int[] {50,100,200,250,500,1000,2000,5000 };
        Common.GeneralFunctions _ligic0 = new Common.GeneralFunctions();
        Common.GeneralFunctions _ligic1 = new Common.GeneralFunctions();
        public override string Name => nameof(BalanceVM);
        public BalanceVM()
        {
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory
                             + @"Resources\Notions\Economy\balance1.jpg";
            NotifyPropertyChanged(nameof(BackgroundPic));
            AnswerBut = new RelayCommand(DoAnswerBut);
            MouseUp = new RelayCommand(DoMouseUp);
            MouseDown = new RelayCommand(DoMouseDown);
            MouseMove = new RelayCommand(DoMouseMove);
            ChangeLevel = new RelayCommand(DoChangeLevel);

            LstProduct = new List<SoldierObject>(); 
            ListRow= BoxRow = 11; 
            NotifyPropertyChanged(nameof(BoxRow));
            NotifyPropertyChanged(nameof(ListRow));
            DoChangeLevel(0);
        }

        private void DoChangeLevel(object obj)
        {
            if (obj.ToString()=="0")
            {
                LevelBut0 = System.AppDomain.CurrentDomain.BaseDirectory
                       + @"Resources\BS.Items\Easy.png";
                LevelBut1 = String.Empty;
            }
            else
            {
                LevelBut0 = String.Empty;
                LevelBut1 = System.AppDomain.CurrentDomain.BaseDirectory
                        + @"Resources\BS.Items\Hard.png";
            }
            NotifyPropertyChanged(nameof(LevelBut0));  
            NotifyPropertyChanged(nameof(LevelBut1));  
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
            _lastWeight= _WeightList[int.Parse(n[2])];
            PicCard =String.Format(@"{0}Resources\Notions\Economy\{1}.png",
                System.AppDomain.CurrentDomain.BaseDirectory, _lastWeight);
            NotifyPropertyChanged(nameof(Row));
            NotifyPropertyChanged(nameof(Column));
            NotifyPropertyChanged(nameof(PicCard));
            VisibilityCard = "Visible";
            NotifyPropertyChanged(nameof(VisibilityCard));
        }

        private void DoMouseUp(object obj)
        {
            if (!base.IsQuestionMode)
            {
                if (string.IsNullOrEmpty(PicCard))
                {
                    if (LstProduct.Count > 0)
                    {
                        LstProduct.RemoveAt(LstProduct.Count - 1);
                        _SumWeight -= _lastWeight;
                        if (LstProduct.Count >= 1)
                        {
                            string[] n = LstProduct[LstProduct.Count - 1].Background.Split('\\');
                            _lastWeight = int.Parse(n[n.Length - 1].Split('.')[0]);
                        }
                        else
                            _lastWeight = 0;
                    }
                }
                else
                {
                    LstProduct.Add(new SoldierObject()
                    { Background = PicCard });
                    _SumWeight += _lastWeight;
                }
                LstProduct = new List<SoldierObject>(LstProduct);
                PicCard = string.Empty;
                NotifyPropertyChanged(nameof(PicCard));
                VisibilityCard = "Collapsed";
                NotifyPropertyChanged(nameof(VisibilityCard));
                NotifyPropertyChanged(nameof(LstProduct));
            }
        }

        private void DoAnswerBut(object obj)
        {
            if (base.IsQuestionMode)
            {
                if (LevelBut1 == String.Empty) {
                    int k = _ligic0.GetIndex(9)+1;
                    _Answer = k* 1000;
                    WeightText = String.Format(@"{0}Resources\Notions\Economy\{1}K.png"
, System.AppDomain.CurrentDomain.BaseDirectory,k);
                }
                else
                {
                    _Answer = 
new int[] { 350, 650, 1500, 3050, 3600, 7900, 8950, 9350 }[_ligic1.GetIndex(5)];//8
                    WeightText = String.Format(@"{0}Resources\Notions\Economy\{1}g.png"
     , System.AppDomain.CurrentDomain.BaseDirectory, _Answer);
                }
                _lastWeight = _SumWeight = 0;
                BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory
                          + @"Resources\Notions\Economy\balance1.jpg";
                NotifyPropertyChanged(nameof(BackgroundPic));
                ListRow = BoxRow = 11;
                NotifyPropertyChanged(nameof(BoxRow));
                NotifyPropertyChanged(nameof(ListRow));
                LstProduct = new List<SoldierObject>();
                NotifyPropertyChanged(nameof(LstProduct));
                HappySmily = string.Empty;
                NotifyPropertyChanged(nameof(WeightText));
                AnswerButBackground = string.Format(@"{0}\Resources\BS.Items\ButtonV.png"
, System.AppDomain.CurrentDomain.BaseDirectory);
            }
            else
            {
                if (_SumWeight == _Answer)
                {
                    HappySmily = string.Format(@"{0}\Resources\BS.Items\HappySmily.png"
, System.AppDomain.CurrentDomain.BaseDirectory);
                }
                else
                {
                    HappySmily = string.Format(@"{0}\Resources\BS.Items\SadSmily.png"
, System.AppDomain.CurrentDomain.BaseDirectory);
                    bool b = _SumWeight > _Answer;
                    BackgroundPic = string.Format(@"{0}Resources\Notions\Economy\balance{1}.jpg",
 System.AppDomain.CurrentDomain.BaseDirectory, b ? 0 : 2);
                    NotifyPropertyChanged(nameof(BackgroundPic));
                    ListRow = b ? 12 : 10;
                    BoxRow = b ? 10 : 12;
                    NotifyPropertyChanged(nameof(BoxRow));
                    NotifyPropertyChanged(nameof(ListRow));
                }
                AnswerButBackground = string.Empty;
            }
                NotifyPropertyChanged(nameof(HappySmily));
                NotifyPropertyChanged(nameof(AnswerButBackground));
            base.SwitchAnswerButton();
        }
    }
}
