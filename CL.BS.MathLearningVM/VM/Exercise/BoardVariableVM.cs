using CL.BS.Contract;
using CL.BS.MathLearningManager.Interface.Exercise;
using CL.BS.MEF;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CL.BS.MathLearningVM.VM.Exercise
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class BoardVariableVM : BaseLernPage, IPageVM
    {
        public override string Name =>nameof(BoardVariableVM);
        private int _variableNum = 1;
        private int _enterIndex = 0;
        private Random _ran = new Random(DateTime.Now.Millisecond);
        public string Rect0 { get { return _result[0].Uid; } set { _result[0].Uid = value; } }
        public string Rect1 { get { return _result[1].Uid; } set { _result[1].Uid = value; } }
        public string Rect2 { get { return _result[2].Uid; } set { _result[2].Uid = value; } }
        public string Result0 { get { return _result[0].Text; } set { _result[0].Text = value; } }
        public string Result1 { get { return _result[1].Text; } set { _result[1].Text = value; } }
        public string Result2 { get { return _result[2].Text; } set { _result[2].Text = value; } }
        public string Switch0 { get { return _result[0].Background; } set { _result[0].Background = value; } }
        public string Switch1 { get { return _result[1].Background; } set { _result[1].Background = value; } }
        public string Switch2 { get { return _result[2].Background; } set { _result[2].Background = value; } }
        public Visibility blueBalloon0 { get {  return _result[0].visibility;} set { _result[0].visibility = value; } }
        public Visibility blueBalloon1 { get { return _result[1].visibility; } set { _result[1].visibility = value; } }
        public Visibility blueBalloon2 { get { return _result[2].visibility; } set { _result[2].visibility = value; } }
        private LetterObject[] _result = new LetterObject[3];
        public List<LetterObject> LstProduct0 { get{ return ListProduct[0]; } set { ListProduct[0] = value; } }
        public List<LetterObject> LstProduct1 { get{ return ListProduct[1]; } set { ListProduct[1] = value; } }
        public List<LetterObject> LstProduct2 { get { return ListProduct[2]; } set { ListProduct[2] = value; } }
        List<LetterObject>[] ListProduct=new List<LetterObject>[3]; 
        public ICommand Switch1Or2 { get; set; }
        public ICommand TypeNum { get; set; }
        public ICommand TypeEnter { get; set; }
        public string HappySmily { get; set; }
        public double BoardHeight { get; set; }
        public double BoardWidth { get; set; }
        private IMathVariableManager _logic = (IMathVariableManager)
    SupportHandlerManager.Base.GetManager("MathVariableManager");
        int[] _Answer;
        public BoardVariableVM()
        {
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.45;// 0.463
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.473;//0.491
            NotifyPropertyChanged(nameof(BoardWidth));
            NotifyPropertyChanged(nameof(BoardHeight));
            Switch1Or2 = new RelayCommand(DoSwitch1Or2);
            AnswerBut = new RelayCommand(DoAnswerBut);
            for (int i = 0; i < _result.Length; i++)
                _result[i] = new LetterObject();
            TypeNum = new RelayCommand(DoTypeNum);
            TypeEnter = new RelayCommand(DoTypeEnter);
            for (int i = 0; i < _result.Length; i++)
            {
                _result[i]=new LetterObject { visibility = Visibility.Collapsed,Uid= "Collapsed" };    
                NotifyPropertyChanged("blueBalloon" + i);
                NotifyPropertyChanged("Rect" + i);
            }
            DoSwitch1Or2(1);
        }

        private void DoTypeEnter(object obj)
        {
            _result[_enterIndex].visibility = Visibility.Collapsed;
            NotifyPropertyChanged("blueBalloon" + _enterIndex);
            _enterIndex = int.Parse(obj.ToString());
            _result[_enterIndex].visibility = Visibility.Visible;
            NotifyPropertyChanged("blueBalloon" + _enterIndex);
        }

        private void DoTypeNum(object num)
        {
            string nl = num.ToString();
            if (nl == "d")
            {
                string ns = string.Empty;
                for (int i = 0; i < _result[_enterIndex].Text.Length - 1; i++)
                    if (_result[_enterIndex].Text[i] != ' ')
                        ns += _result[_enterIndex].Text[i];
                _result[_enterIndex].Text = ns;
            }
            else
            {
                _result[_enterIndex].Text = Common.GeneralFunctions.SplitText(
                    _result[_enterIndex].Text + nl, string.Empty);
            }
            NotifyPropertyChanged("Result" + _enterIndex);
        }

        private void DoSwitch1Or2(object obj)
        {
            _variableNum = int.Parse(obj.ToString());
      _logic.Switch1Or2(_variableNum+1 );
            for (int i = 0; i < _result.Length; i++)
                _result[i].Background = String.Empty;
            _result[_variableNum].Background = String.Format(@"{0}Resources\Number\{1}b.png",
 System.AppDomain.CurrentDomain.BaseDirectory, _variableNum + 1  );
       
            //switch (_variableNum)
            //{
            //    case 0:
            //        Rect0 = "Visible";
            //        Rect1 = "Collapsed";
            //        Rect2 = "Visible";
                
            //        break;
            //    case 1:
            //        Rect0 = "Collapsed";
            //        Rect1 = "Visible";
            //        Rect2 = "Collapsed";
            //        break;
            //    case 2:
            //        Rect0 = "Collapsed";
            //        Rect1 = "Collapsed";
            //        Rect2 = "Collapsed";
            //        break;
            //    default:
            //        break;
            //}
            for (int i = 0; i < _result.Length; i++)
            {
                _result[i].Uid =i<= _variableNum? "Collapsed": "Visible";
                NotifyPropertyChanged("Rect" + i);
                NotifyPropertyChanged("blueBalloon" + i);
                NotifyPropertyChanged("Switch" + i);
            }
        }

        private void DoAnswerBut(object obj)
        {
            if (base.IsQuestionMode)
            {
                Clear();
                ListProduct = _logic.getQuestion(_variableNum + 1);
                _Answer =(int[]) _logic.GetAnswer().Clone();
                for (int i = 0; i < ListProduct.Length; i++)
                    NotifyPropertyChanged("LstProduct" + i); 
                HappySmily = string.Empty;
                NotifyPropertyChanged(nameof(HappySmily));
            }
            else
            {
                bool isWin = true;
                for (int i = 0; i <= _variableNum; i++)
                {
                    if (isWin&&i<=_variableNum)
                        isWin = _result[i].Text == Common.GeneralFunctions.SplitText(_Answer[i].ToString(), string.Empty);
                    //_result[i].Text = i < _variableNum ? a[i].ToString() : string.Empty;
                    _result[i].Text= _Answer[i].ToString();
                    NotifyPropertyChanged("Result" + i);
                }
                HappySmily = string.Format(@"{0}\Resources\BS.Items\{1}Smily.png"
  , System.AppDomain.CurrentDomain.BaseDirectory, isWin ? "Happy" : "Sad");
                NotifyPropertyChanged(nameof(HappySmily));
            }
            base.SwitchAnswerButton();
        }

        private void Clear()
        {
            for (int i = 0; i < _result.Length; i++)
            {
                _result[i].Text = string.Empty;
                NotifyPropertyChanged("Result" + i);
            }
            for (int i = 0; i < ListProduct.Length; i++)
            {
                ListProduct[i] = new List<LetterObject>();
                NotifyPropertyChanged("LstProduct" + i);
            }
            _result[_enterIndex].visibility = Visibility.Collapsed;
            NotifyPropertyChanged("blueBalloon" + _enterIndex);
            _enterIndex = 0;
            _result[_enterIndex].visibility = Visibility.Visible;
            NotifyPropertyChanged("blueBalloon" + _enterIndex);
        }
    }
}
