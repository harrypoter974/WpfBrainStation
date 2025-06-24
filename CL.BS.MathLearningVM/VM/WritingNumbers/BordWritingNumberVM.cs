using CL.BS.Contract;
using CL.BS.MathLearningManager.Interface.WritingNumbers;
using CL.BS.MEF;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.MathLearningVM.WritingNumbers
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class BordWritingNumberVM : BaseLernPage, IPageVM
    {
        public override string Name
        {
            get
            {
                return "WritingNumVM";
            }
        }
        public string Num0 { get { return NumList[ 0].Background; } set { NumList[ 0].Background = value; } }
        public string Num1 { get { return NumList[ 1].Background; } set { NumList[ 1].Background = value; } }
        public string Num2 { get { return NumList[ 2].Background; } set { NumList[ 2].Background = value; } }
        public string Num3 { get { return NumList[ 3].Background; } set { NumList[ 3].Background = value; } }
        public string Num4 { get { return NumList[ 4].Background; } set { NumList[ 4].Background = value; } }
        public string Num5 { get { return NumList[ 5].Background; } set { NumList[ 5].Background = value; } }
        public string Num6 { get { return NumList[ 6].Background; } set { NumList[ 6].Background = value; } }
        public string Num7 { get { return NumList[ 7].Background; } set { NumList[ 7].Background = value; } }
        public string Num8 { get { return NumList[ 8].Background; } set { NumList[ 8].Background = value; } }
        public string Num9 { get { return NumList[9].Background; } set { NumList[ 9].Background = value; } }
        public double BoardHeight { get; set; }
        public double BoardWidth { get; set; }
        public string UrlNum { get; set; }
        public double Speed { get; set; }
        private SoldierObject[] NumList = new SoldierObject[10];
        public ICommand SetNum { get; set; }
        private bool _isWriting = false;
        private int _index = 0;
        private string _num="0";
        private IWritingNumManager _logic = (IWritingNumManager)
SupportHandlerManager.Base.GetManager("WritingNumManager");
        public BordWritingNumberVM()
        {
            for (int i = 0; i < NumList.Length; i++)
                NumList[i] = new SoldierObject();
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.365;// 0.463
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.46;//0.491
            NotifyPropertyChanged(nameof( BoardWidth));
            NotifyPropertyChanged(nameof(BoardHeight));
            SetNum = new RelayCommand(DoSetNum);
        }
        private void DoSetNum(object obj)
        {
            _logic.SetNum(obj);
            _index = 0;
            if (base.IsQuestionMode)
            {
                _index = 0;
                new Thread(new ThreadStart(() =>
                {
                    base.SwitchAnswerButton();
                    int n=int.Parse(_num);
                    NumList[n].Background = String.Empty;
                    NotifyPropertyChanged("Num" + n);
                    _isWriting = true;
                    _num = _logic.GetNum();
                     n=int.Parse(_num);
                    NumList[n].Background = String.Format(@"{0}Resources\Number\{1}b.png"
, System.AppDomain.CurrentDomain.BaseDirectory, n);
                    NotifyPropertyChanged("Num" + n);
                    while (_isWriting)
                    {
                        string url = System.AppDomain.CurrentDomain.BaseDirectory +
                     @"Resources\Math\NumMovie\" +_num + "\\" + _index + ".jpg";
                        if (!File.Exists(url))
                        {
                            UrlNum = System.AppDomain.CurrentDomain.BaseDirectory +
                 @"Resources\BS.Items\LineBoard.jpg";
                            NotifyPropertyChanged(nameof(UrlNum));
                            _isWriting = false;
                            break;
                        }
                        UrlNum = url;
                        NotifyPropertyChanged(nameof(UrlNum));
                        WhitTime((int)(50.0 * (9.5 - Speed)), ref _isWriting);
                        _index++;
                    }
                    base.SwitchAnswerButton();
                })).Start();
            }
        }
    }
}
