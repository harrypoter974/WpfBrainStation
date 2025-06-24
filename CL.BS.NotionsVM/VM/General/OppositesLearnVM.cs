using CL.BS.Contract;
using CL.BS.MEF;
using CL.BS.Model;
using CL.BS.NotionsManager.Interface;
using CL.BS.VMCommon;
using System;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace CL.BS.NotionsVM.VM.General
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class OppositesLearnVM : BaseLernPage, IPageVM
    {
        public ICommand ShowOpposit { get; set; }
        public ICommand SwichPage { get; set; }
        public string BackgroundPic { get; set; }
        public string LanguageBut0 { get { return LanguageBut[0].Background; } set { LanguageBut[0].Background = value; } }
        public string LanguageBut1 { get { return LanguageBut[1].Background; } set { LanguageBut[1].Background = value; } }
        public string LanguageBut2 { get { return LanguageBut[2].Background; } set { LanguageBut[2].Background = value; } }
        protected SoldierObject[] LanguageBut = new SoldierObject[3];
        public Visibility Rect0 { get { return _lrect[0].ItemsVisible; } set { _lrect[0].ItemsVisible = value; } }
        public Visibility Rect1 { get { return _lrect[1].ItemsVisible; } set { _lrect[1].ItemsVisible = value; } }
        private ItemObject[] _lrect = new ItemObject[2];
        private int _index = 0;
        private bool _playRun;
        public ICommand SwitchLanguage { get; set; }
        private IHeOppositesManager _logic = (IHeOppositesManager)
SupportHandlerManager.Base.GetManager("HeOppositesManager");
        //IOppositesManager
        public override string Name => nameof(OppositesLearnVM);

        public OppositesLearnVM()
        {
            for (int i = 0; i < LanguageBut.Length; i++)
                LanguageBut[i] = new SoldierObject() { Background=string.Empty};
            LanguageBut[0].Background = System.AppDomain.CurrentDomain.BaseDirectory +
           @"Resources\Notions\Animals\AnimalStitle0.png";
            NotifyPropertyChanged( nameof(LanguageBut0) );
            ShowOpposit = new RelayCommand(DoShowOpposit);
            SwichPage = new RelayCommand(DoSwichPage);
            SwitchLanguage = new RelayCommand(DoSwitchLanguage);
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\Notions\Opposites\l0.jpg";
            NotifyPropertyChanged(nameof(BackgroundPic));
            for (int i = 0; i < _lrect.Length; i++)
            {
                _lrect[i] = new ItemObject() { ItemsVisible = Visibility.Visible };
            }
        }

        void IPageVM.load()
        {
            bool f = true;
            for (int i = 0; i < LanguageBut.Length; i++)
            {
                if (Common.StaticVar.inline.Languages[i] && f)
                {
                    LanguageBut[i].Background = string.Format(@"{0}Resources\Notions\Animals\AnimalStitle{1}.png",
                        System.AppDomain.CurrentDomain.BaseDirectory, i);
                    NotifyPropertyChanged("LanguageBut" + i);
                    f = false;
                }
                else if (!Common.StaticVar.inline.Languages[i])
                {
                    LanguageBut[i].Background = string.Format(@"{0}Resources\Notions\Animals\language{1}.png",
       System.AppDomain.CurrentDomain.BaseDirectory, i);
                    NotifyPropertyChanged("LanguageBut" + i);
                }
            }
            _logic.load();
            base.Settings();
            if (!Common.StaticVar.inline.IsBoy)
            {
                messagePic = System.AppDomain.CurrentDomain.BaseDirectory
                 + @"Resources\Notions\Opposites\message.png";
            }
            else
                messagePic = string.Empty;
            NotifyPropertyChanged(nameof(messagePic) );
            _index = 0;
            DoSwichPage(_index);
        }

        void IPageVM.disload()
        {
            Clear();
            Database.DatabaseManager.Inline.SaveActivity(4,_startTime, System.DateTime.Now,
  Name, "LERM", "", Common.GeneralFunctions.GetLanguage(LanguageBut),0);
        }

        private void DoSwitchLanguage(object obj)
        {
            int i = int.Parse(obj.ToString());
            if (!Common.StaticVar.inline.Languages[i])
                return;
            int is1 = 0;
            for (int j = 0; j < LanguageBut.Length; j++)
            {
                if (!string.IsNullOrEmpty(LanguageBut[j].Background))
                    if (LanguageBut[j].Background.Contains("AnimalStitle"))
                        is1++;
            }
            if (is1 == 1 && !string.IsNullOrEmpty(LanguageBut[i].Background))
                return;
            LanguageBut[i].Background = LanguageBut[i].Background != string.Empty ?
                string.Empty : System.AppDomain.CurrentDomain.BaseDirectory +
             @"Resources\Notions\Animals\AnimalStitle" + i + ".png";
            NotifyPropertyChanged("LanguageBut" + i);
        }
     
        private void DoSwichPage(object index)
        {
            lock (this)
            {
                if (Common.StaticVar.PlayMode)
                    return;
                _playRun = false;
                BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
                     @"Resources\Notions\Opposites\l" + index + ".jpg";
                NotifyPropertyChanged( nameof(BackgroundPic));
                _index = int.Parse(index.ToString());
                _logic.SetIndex(index);
                Clear();
            }
        }

        private void Clear()
        {
            for (int i = 0; i < _lrect.Length; i++)
            {
                _lrect[i].ItemsVisible = Visibility.Visible;
                NotifyPropertyChanged("Rect" + i);
            }
        }

        public void DoShowOpposit(object obj)
        {
            lock (this)
            {
                if (Common.StaticVar.PlayMode)
                    return;
                _playRun = false;
                int i = int.Parse(obj.ToString());
                _lrect[i].ItemsVisible = Visibility.Hidden;
                NotifyPropertyChanged("Rect" + i);
                new Thread(new ThreadStart(() =>
                {
                    _playRun = true;
                    for (int l = 0; l < LanguageBut.Length && _playRun; l++)
                    {
                        if (LanguageBut[l].Background.Contains("AnimalStitle"))
                        {
                            _logic.SwitchLanguage(l);
                            string[] play = _logic.GetOppositPlay(i);
                            PlayUrl(play[0]);
                            WhitAntilPlayStop(ref _playRun);
                            WhitTime(600, ref _playRun);
                        }
                    }
                    _playRun = false;
                })).Start();

            }
        }
    }
}
