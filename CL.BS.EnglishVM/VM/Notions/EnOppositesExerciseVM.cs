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
    public class EnOppositesExerciseVM : BaseLernPage, IPageVM
    {
        private Random _ran = new Random(DateTime.Now.Millisecond);
        private bool _timeToSwichPage = false;
        private int _perJocker = -1;
        public ICommand RePlay { get; set; }
        public ICommand SwichPage { get; set; }
        public string BackgroundPic { get; set; }
        private string[] _playList = new string[0];
        IEnOppositesManager _logic = (IEnOppositesManager)
SupportHandlerManager.Base.GetManager("EnOppositesManager");
        public string Rect0 { get { return _lrect[0].Background; } set { _lrect[0].Background = value; } }
        public string Rect1 { get { return _lrect[1].Background; } set { _lrect[1].Background = value; } }
        private ItemObject[] _lrect = new ItemObject[2];
        public override string Name
        {
            get
            {
                return nameof(EnOppositesExerciseVM);
            }
        }

        public EnOppositesExerciseVM()
        {
            SwichPage = new RelayCommand(DoSwichPage);           
            AnswerBut = new RelayCommand(DoAnswerBut);
            RePlay = new RelayCommand(DoRePlay);
            for (int i = 0; i < _lrect.Length; i++)
                _lrect[i] = new ItemObject();
        }

        void IPageVM.load()
        {
            base.Settings();
            Clear();
            _logic.load();
            if (!Common.StaticVar.inline.IsBoy)
            {
                messagePic = System.AppDomain.CurrentDomain.BaseDirectory
                 + @"Resources\Lang\En\Opposites\messageJocker.png";
            }
            else
                messagePic = string.Empty;
            NotifyPropertyChanged(nameof(messagePic));
        }

        private void Clear()
        {
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
           @"Resources\Lang\En\Opposites\x" + _logic.GetIndex() + ".jpg";
            NotifyPropertyChanged(nameof(BackgroundPic));
            for (int i = 0; i < _lrect.Length; i++)
            {
                _lrect[i].Background = string.Empty;
                NotifyPropertyChanged("Rect" + i);
            }
        }

        private void DoAnswerBut(object obj)
        {
            if (Common.StaticVar.PlayMode)
                return;
            if (_timeToSwichPage)
            {
                _timeToSwichPage = false;
                DoSwichPage(_ran.Next(6));
                return;
            }
            if (base.IsQuestionMode)
            {
                _playList =   _logic.GetQuestion();
                new Thread(new ThreadStart(() =>
                {
                PlayList(_playList);
                })).Start();
                if (_perJocker!=-1)
                {
                    _lrect[_perJocker].Background =string.Empty;
                    NotifyPropertyChanged("Rect" + _perJocker);
                }
            }
            else
            {
                object[] ol = _logic.GetAnswer();
                _perJocker=(int)ol[0];
                _lrect[_perJocker].Background = (string)ol[1];
                NotifyPropertyChanged("Rect"+ol[0]);
                _timeToSwichPage = true;
            }
            base.SwitchAnswerButton();
        }

        private void DoRePlay(object obj)
        {
            PlayList(_playList);
        }

        private void DoSwichPage(object index)
        {
            if (Common.StaticVar.PlayMode)
                return;
            _logic.SetIndex(index);
            Clear();
        }
    }
}
