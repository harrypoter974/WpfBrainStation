using CL.BS.Contract;
using CL.BS.EnglishManager.Interface.Notions;
using CL.BS.MEF;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace CL.BS.EnglishVM.Notions
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class EnPrepositionsExerciseVM : BaseLernPage, IPageVM
    {
        private IEnPrepositionsManager _logic = (IEnPrepositionsManager)
SupportHandlerManager.Base.GetManager("EnPrepositionsManager");
        private string[] _playList = new string[0];
        public ICommand SwichPage { get; set; }
        public string BackgroundPic { get; set; }
        public ICommand RePlay { get; set; }
        public string Image00 { get { return _image00.Background; } set { _image00.Background = value; } }
        public string Image01 { get { return _image01.Background; } set { _image01.Background = value; } }
        public string Image02 { get { return _image02.Background; } set { _image02.Background = value; } }
        public string Image03 { get { return _image03.Background; } set { _image03.Background = value; } }
        public string Image10 { get { return _image10.Background; } set { _image10.Background = value; } }
        public string Image11 { get { return _image11.Background; } set { _image11.Background = value; } }
        public string Image12 { get { return _image12.Background; } set { _image12.Background = value; } }
        public string Image20 { get { return _image20.Background; } set { _image20.Background = value; } }
        public string Image21 { get { return _image21.Background; } set { _image21.Background = value; } }
        public string Image22 { get { return _image22.Background; } set { _image22.Background = value; } }
        public string Image30 { get { return _image30.Background; } set { _image30.Background = value; } }
        public string Image31 { get { return _image31.Background; } set { _image31.Background = value; } }
        public string Image32 { get { return _image32.Background; } set { _image32.Background = value; } }
        private ItemObject _image00, _image01, _image02, _image03, _image10, _image11, _image12
      , _image20, _image21, _image22, _image30, _image31, _image32;
        private ItemObject[,] _card;
        private int[] _perJocker;
        private bool _timeToSwichPage = false;
        private Random _ran = new Random(DateTime.Now.Millisecond);
        public override string Name
        {
            get
            {
                return nameof(EnPrepositionsExerciseVM);
            }
        }

        public EnPrepositionsExerciseVM()
        {
            AnswerBut = new RelayCommand(DoAnswerBut);
            SwichPage = new RelayCommand(DoSwichPage);
            RePlay = new RelayCommand(DoRePlay);
            _image00 = new ItemObject() { Uid = "00" };
            _image01 = new ItemObject() { Uid = "01" };
            _image02 = new ItemObject() { Uid = "02" };
            _image03 = new ItemObject() { Uid = "03" };
            _image10 = new ItemObject() { Uid = "10" };
            _image11 = new ItemObject() { Uid = "11" };
            _image12 = new ItemObject() { Uid = "12" };
            _image20 = new ItemObject() { Uid = "20" };
            _image21 = new ItemObject() { Uid = "21" };
            _image22 = new ItemObject() { Uid = "22" };
            _image30 = new ItemObject() { Uid = "30" };
            _image31 = new ItemObject() { Uid = "31" };
            _image32 = new ItemObject() { Uid = "32" };
            _card =     new ItemObject[,] {
                {_image00,_image01,_image02,_image03 }
               ,{_image10,_image11,_image12 ,_image12   }
               ,{_image20,_image21,_image22 ,_image22    }
               ,{_image30,_image31,_image32 ,_image32   } };
        }

        private void DoAnswerBut(object obj)
        {
            if (Common.StaticVar.PlayMode)
                return;
            if (_timeToSwichPage)
            {
                SetBackground();
                _timeToSwichPage = false;
                return;
            }
            if (base.IsQuestionMode)
            {
                _playList = _logic.GetQuestion(_logic.GetIndex());
                new Thread(new ThreadStart(() =>
                {
                    PlayList(_playList);
                })).Start();
                if (_perJocker != null)
                {
                    _card[_perJocker[0],_perJocker[1]].Background = string.Empty;
                    NotifyPropertyChanged("Image" + (_perJocker[0] ) + _perJocker[1]);
                }
            }
            else
            {
                object[] ol = _logic.GetAnswer(_logic.GetIndex());
                _perJocker = new int[] { _logic.GetIndex() - 1, (int)ol[0] };
                _card[_perJocker[0] ,_perJocker[1]].Background = (string)ol[1];
                NotifyPropertyChanged("Image" + (_perJocker[0])+ _perJocker[1]);
                _timeToSwichPage = true;
            }
            base.SwitchAnswerButton();
        }

        private void DoSwichPage(object index)
        {
            if (Common.StaticVar.PlayMode)
                return;
            _logic.SetIndex( index);         
            SetBackground();
        }

        void IPageVM.load()
        {
            base.Settings();
            if (!Common.StaticVar.inline.IsBoy)
            {
                messagePic = System.AppDomain.CurrentDomain.BaseDirectory
                 + @"Resources\Lang\En\Prepositions\messageJocker.png";
            }
            else
                messagePic = string.Empty;
            NotifyPropertyChanged(nameof(messagePic));
            SetBackground();
        }

        private void SetBackground()
        {
            int pageIndex = _ran.Next(1, 5);
            _logic.load(pageIndex);
            _logic.SetIndex(pageIndex);
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
                 @"Resources\Lang\En\Prepositions\x" + pageIndex + ".jpg";
            NotifyPropertyChanged(nameof(BackgroundPic));
            if (!base.IsQuestionMode)
                base.SwitchAnswerButton();    
            for (int i = 0; i < _card.GetLength(0); i++)
            {
                for (int j = 0; j < _card.GetLength(1); j++)
                {
                    _card[j, i].Background = string.Empty;
                    NotifyPropertyChanged("Image" + _card[j, i].Uid);
                }
            }
        }

        public void DoRePlay(object odj)
        {
            PlayList(_playList);
        }
    }
}
