using CL.BS.Contract;
using CL.BS.MathLearningManager.Interface.Recognaz;
using CL.BS.MEF;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.MathLearningVM.Recognaz
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class NumberStructureExerciseVM : VMCommon.BaseLernPage, IPageVM
    {
        public ICommand SwitchGroup { get; set; }
        public string TBRes0 { get {return  _resList[0].Background;}  set { _resList[0].Background=value;} }
        public string TBRes1 { get {return  _resList[1].Background;}  set { _resList[1].Background=value;} }
        public string TBRes2 { get {return  _resList[2].Background;}  set { _resList[2].Background = value; } }
        public string TBRes3 { get { return _resList[3].Background; } set { _resList[3].Background = value; } }

        public string TBNum1 { get; set; }
        public string TBNum2 { get; set; }
        public string TBNum3 { get; set; }
        protected SoldierObject[] _resList = new SoldierObject[4];
        public string BackgroundPic { get; set; }
        public string KeyboardVisibility { get; set; }
        public string RectVisibility0 { get; set; }
        public string RectVisibility1 { get; set; }
        public string HappySmily { get; set; }
        public ICommand SubCake { get; set; }
        public ICommand AddCake { get; set; }
        public ICommand TypeNum { get; set; }
        public string cake00 { get { return Cakes[0].Background; } set { Cakes[0].Background =value; } }
        public string cake01 { get { return Cakes[1].Background; } set { Cakes[1].Background = value; } }
        public string cake02 { get { return Cakes[2].Background; } set { Cakes[2].Background = value; } }
        public string cake03 { get { return Cakes[3].Background; } set { Cakes[3].Background = value; } }
        public string cake04 { get { return Cakes[4].Background; } set { Cakes[4].Background = value; } }
        public string cake05 { get { return Cakes[5].Background; } set { Cakes[5].Background = value; } }
        public string cake06 { get { return Cakes[6].Background; } set { Cakes[6].Background = value; } }
        public string cake07 { get { return Cakes[7].Background; } set { Cakes[7].Background = value; } }
        public string cake08 { get { return Cakes[8].Background; } set { Cakes[8].Background = value; } }
        public string cake09 { get { return Cakes[9].Background; } set { Cakes[9].Background = value; } }
        public string cake10 { get { return Cakes[10].Background; } set {Cakes[10].Background = value; } }
        public string cake11 { get { return Cakes[11].Background; } set {Cakes[11].Background = value; } }
        public string cake12 { get { return Cakes[12].Background; } set {Cakes[12].Background = value; } }
        public string cake13 { get { return Cakes[13].Background; } set {Cakes[13].Background = value; } }
        public string cake14 { get { return Cakes[14].Background; } set {Cakes[14].Background = value; } }
        public string cake15 { get { return Cakes[15].Background; } set {Cakes[15].Background = value; } }
        public string cake16 { get { return Cakes[16].Background; } set {Cakes[16].Background = value; } }
        public string cake17 { get { return Cakes[17].Background; } set {Cakes[17].Background = value; } }
        public string cake18 { get { return Cakes[18].Background; } set {Cakes[18].Background = value; } }
        public string cake19 { get { return Cakes[19].Background; } set {Cakes[19].Background = value; } }
        public string cake20 { get { return Cakes[20].Background; } set { Cakes[20].Background = value; } }
        public string cake21 { get { return Cakes[21].Background; } set { Cakes[21].Background = value; } }
        public string cake22 { get { return Cakes[22].Background; } set { Cakes[22].Background = value; } }
        public string cake23 { get { return Cakes[23].Background; } set { Cakes[23].Background = value; } }
        public string cake24 { get { return Cakes[24].Background; } set { Cakes[24].Background = value; } }
        public string cake25 { get { return Cakes[25].Background; } set { Cakes[25].Background = value; } }
        public string cake26 { get { return Cakes[26].Background; } set { Cakes[26].Background = value; } }
        public string cake27 { get { return Cakes[27].Background; } set { Cakes[27].Background = value; } }
        public string cake28 { get { return Cakes[28].Background; } set { Cakes[28].Background = value; } }
        public string cake29 { get { return Cakes[29].Background; } set { Cakes[29].Background = value; } }
        protected string Result;
        protected int  [] cakesNum =new int[] {0,0,0};
        protected  bool _lockCack = false;
        protected SoldierObject[] Cakes = new SoldierObject[30];
        protected INumberStructureExerciseManager _logic = (INumberStructureExerciseManager)
    SupportHandlerManager.Base.GetManager("NumberStructureExerciseManager");
        public override string Name => "NumberStructureExerciseVM";

        void IPageVM.disload()
        {
            _logic.disload();
        }

        void IPageVM.load()
        {
            UrlPlay = string.Empty;
            base.Settings();
            if (!Common.StaticVar.inline.IsBoy)
            {
                messagePic = System.AppDomain.CurrentDomain.BaseDirectory +
                   @"Resources\Math\NumberStructure\messageExercise.png";
            }
            else
                messagePic = string.Empty;
            NotifyPropertyChanged("messagePic");
            SetBackground();
            new Thread(new ThreadStart(() =>
            {
                PlayList(new string[] { Common.StaticVar.inline.PlayName(),
(Common.StaticVar.inline.IsBoy ? @"Resources\Audio\He\Sentences\A21.wav": @"Resources\Audio\He\Sentences\A22.wav")});
            })).Start();
            if (!base.IsQuestionMode)
                base.SwitchAnswerButton();
        }

        public NumberStructureExerciseVM()
        {
            SwitchGroup = new RelayCommand(DoSwitchGroup);
            AnswerBut = new RelayCommand(DoAnswerBut);
            SubCake = new RelayCommand(DoSubCake);
            AddCake = new RelayCommand(DoAddCak);
            TypeNum = new RelayCommand(DoTypeNum);
            for (int i = 0; i < _resList.Length; i++)
                _resList[i] = new SoldierObject();
            for (int i = 0; i < Cakes.Length; i++)
                Cakes[i] = new SoldierObject();
            KeyboardVisibility= RectVisibility1 = RectVisibility0 = "Collapsed";
            NotifyPropertyChanged(nameof(RectVisibility0));
            NotifyPropertyChanged(nameof(RectVisibility1));
            NotifyPropertyChanged(nameof(KeyboardVisibility));
        }

        private void DoTypeNum(object obj)
        {
            string nl = obj.ToString();
            if (nl == "d")
            {
                string ns = string.Empty;
                for (int i = 0; i < Result.Length - 1; i++)
                    ns += Result[i];
                Result = ns;               
            }
            else
            {
                Result += nl;
            }
            for (int i = 1; i<_resList.Length - (_logic.IsGroup100() ? 0 : 1); i++)
            {
                if (i <= Result.Length)
                    _resList[i+( _logic.IsGroup100()?0:1)].Background = Result[i - 1].ToString();
                else
                    _resList[i + (_logic.IsGroup100() ? 0 : 1)].Background = String.Empty;
            }
            for (int i = 0; i < _resList.Length; i++)
                NotifyPropertyChanged("TBRes"+i);
        }

        protected void DoSubCake(object obj)
        {
            if (!base.IsQuestionMode)
            {
               int i=int.Parse(obj.ToString());
                if (cakesNum[i] > 0)
                {
                    cakesNum[i]--;
                    int n = i * 10 + cakesNum[i];
                    Cakes[n].Background = String.Empty;
                    string tn = n < 10 ? "0" + n : n.ToString();
                    NotifyPropertyChanged("cake" + tn);
                }

            }
        }
        protected void DoAddCak(object obj)
        {
            if (_lockCack)
                return;
            UrlPlay = String.Empty;
            UrlPlay =String.Format(@"{0}\Resources\Audio\Music\do.wav", System.AppDomain.CurrentDomain.BaseDirectory);
            if (!base.IsQuestionMode)
            {
                int i = int.Parse(obj.ToString());
                if (!_logic.IsGroup100() && i == 2)
                    return;
                if (cakesNum[i] <9||(i==2&& cakesNum[i] < 10))
                {
                    int n = i * 10 + cakesNum[i];
                    string tn = n < 10 ? "0" + n : n.ToString();
                    Cakes[n].Background = String.Format(@"{0}Resources\Math\NumberStructure\bull{1}.png"
, System.AppDomain.CurrentDomain.BaseDirectory, i);
                    NotifyPropertyChanged("cake" + tn);
                    cakesNum[i]++;
                }
                else if (i < 2 && cakesNum[i + 1] < 10)
                {  
                    new Thread(new ThreadStart(() =>
                    {
                        RectVisibility0 = "Visible";
                        if (_logic.IsGroup100())
                        {
                            RectVisibility1 = "Visible";
                            NotifyPropertyChanged(nameof(RectVisibility1));
                        }
                        NotifyPropertyChanged(nameof(RectVisibility0));
                        _lockCack = true;
                        int n = i * 10 + cakesNum[i];
                        string tn = n < 10 ? "0" + n : n.ToString();
                        Cakes[n].Background = String.Format(@"{0}Resources\Math\NumberStructure\bull{1}.png"
    , System.AppDomain.CurrentDomain.BaseDirectory, i);
                        NotifyPropertyChanged("cake" + tn);
                        cakesNum[i]++;
                        Thread.Sleep(1000);
                        for (int l = 0; l < 10; l++)
                            DoSubCake(i);
                        _lockCack = false;
                        DoAddCak(i + 1);
                        RectVisibility1 = RectVisibility0 = "Collapsed";
                        NotifyPropertyChanged(nameof(RectVisibility0));
                        NotifyPropertyChanged(nameof(RectVisibility1));
                    })).Start();
                }
            }
        }

      
        protected void DoAnswerBut(object obj)
        {
            if (base.IsQuestionMode)
            {
                string[] res = _logic.SetQuestion();
                TBNum1 = res[0];
                if (_logic.IsGroup100())
                    TBNum3 = res[2];
                else
                    TBNum2 = res[1];
                for (int i = 0; i < _resList.Length; i++)
                    _resList[i].Background = String.Empty;
                Notify();
                Result= HappySmily = string.Empty;
                NotifyPropertyChanged(nameof(HappySmily));
                for (int i = 0; i < Cakes.Length; i++)
                {
                    Cakes[i].Background = String.Empty;
                    string tn = i < 10 ? "0" + i : i.ToString();
                    NotifyPropertyChanged("cake" + tn);
                }
                cakesNum = new int[] { 0, 0, 0 };
            }
            else
            {
                string[] res = _logic.GetResolt();
                CheckAnswer(res);
                TBRes0 = res[0];
                TBRes1 = res[1];
                TBRes2 = res[2];
                TBRes3 = res[3];
                NotifyPropertyChanged(nameof(TBRes0));
                NotifyPropertyChanged(nameof(TBRes1));
                NotifyPropertyChanged(nameof(TBRes2));
                NotifyPropertyChanged(nameof(TBRes3));
            }
            base.SwitchAnswerButton();
        }

        protected void CheckAnswer(string[] res)
        {
            bool r = true;
            for (int i = 0; i < _resList.Length&&r; i++)
            {
                if(res[i]!= null)
                    r = res[i] == _resList[i].Background;            
            }
            HappySmily = string.Format(@"{0}\Resources\BS.Items\{1}Smily.png"
, System.AppDomain.CurrentDomain.BaseDirectory, r ? "Happy" : "Sad");
            NotifyPropertyChanged(nameof(HappySmily));
        }

        private void DoSwitchGroup(object obj)
        {
            if (base.IsQuestionMode)
            {
                _logic.SetGroup(obj);
                SetBackground();
            }
        }

        private void SetBackground()
        {
            if (_logic.GetBackground() != string.Empty)
            {
                BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory
                    + _logic.GetBackground();
                for (int i = 0; i < _resList.Length; i++)
                    _resList[i].Background = String.Empty;
                TBNum1 = TBNum2 = TBNum3 = string.Empty;
                Notify();
                NotifyPropertyChanged(nameof(BackgroundPic));
            }
        }

        protected void Notify()
        {
            NotifyPropertyChanged(nameof(TBRes0));
            NotifyPropertyChanged(nameof(TBRes1));
            NotifyPropertyChanged(nameof(TBRes2));
            NotifyPropertyChanged(nameof(TBRes3));
            NotifyPropertyChanged(nameof(TBNum1));
            NotifyPropertyChanged(nameof(TBNum2));
            NotifyPropertyChanged(nameof(TBNum3));
        }
    }
}
