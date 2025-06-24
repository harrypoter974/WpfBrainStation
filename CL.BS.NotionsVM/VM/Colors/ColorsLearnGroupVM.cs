using CL.BS.Contract;
using CL.BS.MEF;
using CL.BS.Model;
using CL.BS.NotionsManager.Interface;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CL.BS.NotionsVM.VM.Colors
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class ColorsLearnGroupVM : BaseLernPage, IPageVM
    {
        public ICommand ShowColor { get; set; }
        public ICommand SwitchPage { get; set; }
        public ICommand GoToExercise { get; set; }
        public ICommand SwitchLanguage { get; set; }
        public ICommand PlayAll { get; set; }
        private bool _isPlay = false;
        private IColorsManager _logic = (IColorsManager)
   SupportHandlerManager.Base.GetManager("ColorsManager");
        public Visibility Color0 { get { return _list1[0].visibility; } set {_list1[0].visibility = value; } }
        public Visibility Color1 { get { return _list1[1].visibility; } set {_list1[1].visibility = value; } }
        public Visibility Color2 { get { return _list1[2].visibility; } set {_list1[2].visibility = value; } }
        public Visibility Color3 { get { return _list1[3].visibility; } set {_list1[3].visibility = value; } }
        public Visibility Color4 { get { return _list1[4].visibility; } set {_list1[4].visibility = value; } }
        public Visibility Color5 { get { return _list1[5].visibility; } set { _list1[5].visibility = value; } }
        private List<LetterObject> _list1;
        public string LanguageBut0 { get { return LanguageBut[0].Background; } set { LanguageBut[0].Background = value; } }
        public string LanguageBut1 { get { return LanguageBut[1].Background; } set { LanguageBut[1].Background = value; } }
        public string LanguageBut2 { get { return LanguageBut[2].Background; } set { LanguageBut[2].Background = value; } }
        protected SoldierObject[] LanguageBut = new SoldierObject[3];
        public string BackgroundPic {get;set;  }
        public string PlayAllBut { get;set;  }
        public override string Name
        {
            get
            {
                return "ColorsLearnGroupVM";
            }
        }

        public ColorsLearnGroupVM()
        {
        
            _list1 = new List<LetterObject>();
            for (int i = 0; i < 6; i++)
                _list1.Add(new LetterObject() { visibility = Visibility.Visible });     
            ShowColor = new RelayCommand(DoShowColor);
            SwitchPage = new RelayCommand(DoSwitchPage);
            GoToExercise = new RelayCommand(DoGoToExercise);
           PlayAll = new RelayCommand(DoPlayAll);
            SwitchLanguage = new RelayCommand(DoSwitchLanguage);
            for (int i = 0; i < LanguageBut.Length; i++)
                LanguageBut[i] = new SoldierObject() { Background = string.Empty };
            }

        private void DoSwitchLanguage(object obj)
        {
            int l = int.Parse(obj.ToString());
            if (!Common.StaticVar.inline.Languages[l])
                return;
            LanguageBut[l].Background = LanguageBut[l].Background != string.Empty ?
                string.Empty : System.AppDomain.CurrentDomain.BaseDirectory +
             @"Resources\Notions\Animals\AnimalStitle" + l + ".png";
            NotifyPropertyChanged("LanguageBut" + l);
            for (int i = 0; i < _list1.Count; i++)
            {
                _list1[i].visibility = Visibility.Visible;
                NotifyPropertyChanged("Color" + i);
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

            base.Settings();
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\Notions\Colors\ColorsGroup"+_logic.GetGrope()+".jpg";
            NotifyPropertyChanged("BackgroundPic");
            if (!Common.StaticVar.inline.IsBoy)
            {
                messagePic = System.AppDomain.CurrentDomain.BaseDirectory +
                   @"Resources\Notions\Colors\message.png";
            }
            else
                messagePic = string.Empty;
            PlayAllBut =string.Empty;
            NotifyPropertyChanged("messagePic");
            NotifyPropertyChanged("PlayAllBut");
        }

        void IPageVM.disload()
        {
            Clear();
        }

        private void DoPlayAll(object obj)
        {
            if (Common.StaticVar.PlayMode || _isPlay)
            {
                if (_isPlay)
                {
                    _isPlay = false;
                    PlayAllBut = System.AppDomain.CurrentDomain.BaseDirectory +
            @"Resources\Notions\Colors\StopPlayAllBut.png";
                    NotifyPropertyChanged("PlayAllBut");
                }
                return;
            }
            PlayAllBut = System.AppDomain.CurrentDomain.BaseDirectory +
          @"Resources\Notions\Colors\PlayAllBut.png";
            NotifyPropertyChanged("PlayAllBut");
            new Thread(new ThreadStart(() =>
            {
                _isPlay = true;
                for (int i = 0; i < _list1.Count() && _isPlay; i++)
                {
                    _list1[i].visibility = Visibility.Hidden;
                    NotifyPropertyChanged("Color" + i);
                    for (int l = 0; l < LanguageBut.Length; l++)
                    {
                        if (LanguageBut[l].Background.Contains("AnimalStitle"))
                        {
                            PlayUrl(_logic.PlayColor(i, l));
                            WhitAntilPlayStop(ref _isPlay);
                        }
                    }
                }
                _isPlay = false;
            })).Start();
        }

        private void DoShowColor(object colorIndex)
        {
            if (Common.StaticVar.PlayMode || _isPlay)
                return;
            int i = int.Parse((string)colorIndex);
            _list1[i].visibility = Visibility.Hidden;
            NotifyPropertyChanged("Color" + i);
            new Thread(new ThreadStart(() =>
            {
                _isPlay = true;
                for (int l = 0; l < LanguageBut.Length; l++)
                {
                    if (LanguageBut[l].Background.Contains("AnimalStitle"))
                    {
                        PlayUrl(_logic.PlayColor(i, l));
                        WhitAntilPlayStop(ref _isPlay);
                    }
                }
                _isPlay = false;
            })).Start();
        }

        private void DoSwitchPage(object obj)
        {
            if (Common.StaticVar.PlayMode)
                return;
            _logic.setGrope(_logic.GetGrope() == 1 ? 0: 1);
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\Notions\Colors\ColorsGroup" + _logic.GetGrope() + ".jpg";
            NotifyPropertyChanged("BackgroundPic");
            Clear();
        }

        private void DoGoToExercise(object gropeIndex)
        {
            if (Common.StaticVar.PlayMode)
                return;
            _logic.setGrope(gropeIndex);
            DoGoToPage("ExerciseGroupColorsVM");
        }

        private void Clear()
        {
            _isPlay = false;
            for (int i = 0; i < _list1.Count; i++)
            {
                _list1[i].visibility = Visibility.Visible;
                NotifyPropertyChanged("Color" + i);
            }
        }
    }
}
