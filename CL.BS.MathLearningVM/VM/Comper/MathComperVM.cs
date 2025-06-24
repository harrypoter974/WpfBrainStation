
using CL.BS.Contract;
using CL.BS.MathLearningManager.Interface.Comper;
using CL.BS.MEF;
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

namespace CL.BS.MathLearningVM.Comper
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public  class MathComperVM : BaseLernPage,  IPageVM
    {
        public ICommand SetFish { get; set; }
        public ICommand SetStars { get; set; }
        public ICommand SetNum { get; set; }
        public Visibility Fish0 { get { return _listFishs[0].visibility; } set { _listFishs[0].visibility = value; } }
        public Visibility Fish1 { get { return _listFishs[1].visibility; } set { _listFishs[1].visibility = value; } }
        public Visibility Fish2 { get { return _listFishs[2].visibility; } set { _listFishs[2].visibility = value; } }
        public Visibility Fish3 { get { return _listFishs[3].visibility; } set { _listFishs[3].visibility = value; } }
        public Visibility Fish4 { get { return _listFishs[4].visibility; } set { _listFishs[4].visibility = value; } }
        public Visibility Fish5 { get { return _listFishs[5].visibility; } set { _listFishs[5].visibility = value; } }
        public Visibility Fish6 { get { return _listFishs[6].visibility; } set { _listFishs[6].visibility = value; } }
        public Visibility Fish7 { get { return _listFishs[7].visibility; } set { _listFishs[7].visibility = value; } }
        public Visibility Fish8 { get { return _listFishs[8].visibility; } set { _listFishs[8].visibility = value; } }
        public Visibility Fish9 { get { return _listFishs[9].visibility; } set { _listFishs[9].visibility = value; } }

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
        private List<LetterObject> _listFishs;
        public string LText { get; set; }
        public string RText { get; set; }
        public string AnsFish { get; set; }
        public string AnsStars { get; set; }
        public string AnsNum { get; set; }
        public string ButFish { get; set; }
        public string ButStars { get; set; }
        public string ButNum { get; set; }
        private bool _isQuestionFish, _isQuestionStars, _isQuestionNum;
        private IMathComperManager _logic = (IMathComperManager)
SupportHandlerManager.Base.GetManager("MathComperManager");
        public override string Name
        {
            get
            {
                return "MathComperVM";
            }
        }

        void IPageVM.load()
        {
            base.Settings();
            if (Common.StaticVar.inline.IsBoy)
            {
                messagePic = "Visible";
            }
            else
                messagePic = "Hidden";
            NotifyPropertyChanged("messagePic");
            for (int i = 0; i < _listStars.Count; i++)
            {
                _listStars[i].visibility = Visibility.Hidden;
                NotifyPropertyChanged("Stars" + ("RL"[(i / 10)]) + i % 10);
            }
            for (int i = 0; i < _listFishs.Count; i++)
            {
                _listFishs[i].visibility = Visibility.Visible;
                NotifyPropertyChanged("Fish" + i);
            }

            _isQuestionFish = _isQuestionStars = _isQuestionNum = true;
            ButStars = ButFish = ButNum = System.AppDomain.CurrentDomain.BaseDirectory
              + @"Resources\BS.Items\ButtonG.png";
            AnsFish = AnsStars = AnsNum = LText = RText = string.Empty;
            NotifyPropertyChanged(nameof(ButNum));
            NotifyPropertyChanged(nameof(LText));
            NotifyPropertyChanged(nameof(RText));
            NotifyPropertyChanged(nameof(AnsFish));
            NotifyPropertyChanged(nameof(AnsStars));
            NotifyPropertyChanged(nameof(AnsNum));
            NotifyPropertyChanged(nameof(ButFish));
            NotifyPropertyChanged(nameof(ButStars));
            NotifyPropertyChanged(nameof( ButNum));
        }

        public MathComperVM()
        {
            _listStars = new List<LetterObject>();
            for (int i = 0; i < 20; i++)
                _listStars.Add(new LetterObject() { visibility = Visibility.Visible });
            _listFishs = new List<LetterObject>();
            for (int i = 0; i < 10; i++)
                _listFishs.Add(new LetterObject() { visibility = Visibility.Visible });
            SetFish = new RelayCommand(DoSetFish);
            SetStars = new RelayCommand(DoSetStars);
            SetNum = new RelayCommand(DoSetNum);         
        }
        
        private void DoSetFish (object obj)
        {
            if (Common.StaticVar.PlayMode)
                return;
            if (_isQuestionFish)
            {
                QuestionPlay();
                bool[] fishList = _logic.GetFish();
                AnsFish = string.Empty;
                for (int i = 0; i < fishList.Length; i++)
                {
                    _listFishs[i].visibility = fishList[i] ? Visibility.Visible : Visibility.Hidden;
                    NotifyPropertyChanged("Fish"+i);
                }
            }
            else
            {
                AnsFish =   _logic.GetFishAns();
             
            }
            _isQuestionFish = !_isQuestionFish;
            ButFish = System.AppDomain.CurrentDomain.BaseDirectory
                          + @"Resources\BS.Items\Button" + (_isQuestionFish ? "G" : "V") + ".png";
            NotifyPropertyChanged("ButFish");
            NotifyPropertyChanged("AnsFish");
        }

        private void DoSetStars(object obj)
        {
            if (Common.StaticVar.PlayMode)
                return;
            if (_isQuestionStars)
            {
                QuestionPlay();
                bool[] starsList = _logic.GetStars();
                AnsStars = string.Empty;
                for (int i = 0; i < starsList.Length; i++)
                {
                    _listStars[i].visibility = starsList[i] ? Visibility.Visible : Visibility.Hidden;
                    NotifyPropertyChanged("Stars" +("RL"[(i/10)]) +i%10);
                }
            }
            else
            {          
                AnsStars =   _logic.GetStarsAns();                
            }
            NotifyPropertyChanged("AnsStars");
            _isQuestionStars = !_isQuestionStars;
            ButStars = System.AppDomain.CurrentDomain.BaseDirectory
                    + @"Resources\BS.Items\Button" + (_isQuestionStars ? "G" : "V") + ".png";
            NotifyPropertyChanged("ButStars");
        }

        private void DoSetNum  (object obj)
        {
            if (Common.StaticVar.PlayMode)
                return;
            if (_isQuestionNum)
            {
                QuestionPlay();
                string[] q = _logic.GetNum();
                LText = q[0];
                RText = q[1];
                AnsNum = string.Empty;               
                NotifyPropertyChanged("LText");
                NotifyPropertyChanged("RText");
            }
            else
            {
                AnsNum = _logic.GetNumAns();
            }
            NotifyPropertyChanged("AnsNum");
            _isQuestionNum = !_isQuestionNum;
            ButNum = System.AppDomain.CurrentDomain.BaseDirectory
                    + @"Resources\BS.Items\Button" + (_isQuestionNum ? "G" : "V") + ".png";
            NotifyPropertyChanged("ButNum");
        }

        private void QuestionPlay()
        {
            new Thread(new ThreadStart(() =>
            {
                PlayList(new string[] { Common.StaticVar.inline.PlayName(),
                         Common.StaticVar.inline.IsBoy?@"Resources\Audio\He\General\putItDown.wav":
                        @"Resources\Audio\He\General\put_it_down.wav",
@"Resources\Audio\He\General\card.wav",@"Resources\Audio\He\General\big.wav" ,
@"Resources\Audio\He\General\Equal.wav" ,@"Resources\Audio\He\General\or.wav"
,@"Resources\Audio\He\General\small.wav"   });
            })).Start();
        }
         
    }
}
