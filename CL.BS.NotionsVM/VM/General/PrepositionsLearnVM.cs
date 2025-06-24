using CL.BS.Contract;
using CL.BS.MEF;
using CL.BS.Model;
using CL.BS.NotionsManager.Interface;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace CL.BS.NotionsVM.VM.General
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class PrepositionsLearnVM : BaseLernPage, IPageVM
    {
        public ICommand ShowAnimals { get; set; }
        public ICommand SwichPage { get; set; }
        public string BackgroundPic { get; set; }
        public string LanguageBut0 { get { return LanguageBut[0].Background; } set { LanguageBut[0].Background = value; } }
        public string LanguageBut1 { get { return LanguageBut[1].Background; } set { LanguageBut[1].Background = value; } }
        public string LanguageBut2 { get { return LanguageBut[2].Background; } set { LanguageBut[2].Background = value; } }
        protected SoldierObject[] LanguageBut = new SoldierObject[3];
        public ICommand SwitchLanguage { get; set; }
        public Visibility LAnimal10 { get { return _lAnimal10.ItemsVisible; } set { _lAnimal10.ItemsVisible = value; } }
        public Visibility LAnimal11 { get { return _lAnimal11.ItemsVisible; } set { _lAnimal11.ItemsVisible = value; } }
        public Visibility LAnimal12 { get { return _lAnimal12.ItemsVisible; } set { _lAnimal12.ItemsVisible = value; } }
        public Visibility LAnimal13 { get { return _lAnimal13.ItemsVisible; } set { _lAnimal13.ItemsVisible = value; } }
        public Visibility LAnimal20 { get { return _lAnimal20.ItemsVisible; } set { _lAnimal20.ItemsVisible = value; } }
        public Visibility LAnimal21 { get { return _lAnimal21.ItemsVisible; } set { _lAnimal21.ItemsVisible = value; } }
        public Visibility LAnimal22 { get { return _lAnimal22.ItemsVisible; } set { _lAnimal22.ItemsVisible = value; } }
        public Visibility LAnimal30 { get { return _lAnimal30.ItemsVisible; } set { _lAnimal30.ItemsVisible = value; } }
        public Visibility LAnimal31 { get { return _lAnimal31.ItemsVisible; } set { _lAnimal31.ItemsVisible = value; } }
        public Visibility LAnimal32 { get { return _lAnimal32.ItemsVisible; } set { _lAnimal32.ItemsVisible = value; } }
        public Visibility LAnimal40 { get { return _lAnimal40.ItemsVisible; } set { _lAnimal40.ItemsVisible = value; } }
        public Visibility LAnimal41 { get { return _lAnimal41.ItemsVisible; } set { _lAnimal41.ItemsVisible = value; } }
        public Visibility LAnimal42 { get { return _lAnimal42.ItemsVisible; } set { _lAnimal42.ItemsVisible = value; } }
        private bool _playRun;
        private int _index = 0;
        private ItemObject _lAnimal10
        , _lAnimal11, _lAnimal12, _lAnimal13, _lAnimal20, _lAnimal21, _lAnimal22, _lAnimal30, _lAnimal31, _lAnimal32
        , _lAnimal40, _lAnimal41, _lAnimal42;
        private List<ItemObject> List1;
        private IHePrepositionsManager _logic = (IHePrepositionsManager)
SupportHandlerManager.Base.GetManager("HePrepositionsManager");
        public override string Name => nameof(PrepositionsLearnVM);

        public PrepositionsLearnVM()
        {
            for (int i = 0; i < LanguageBut.Length; i++)
                LanguageBut[i] = new SoldierObject() { Background=string.Empty};
            ShowAnimals = new RelayCommand(DoShowAnimals);
            SwichPage = new RelayCommand(DoSwichPage);
            SwitchLanguage = new RelayCommand(DoSwitchLanguage);
            _lAnimal10 = new ItemObject() { ItemsVisible = Visibility.Visible, Uid = "10" };
            _lAnimal11 = new ItemObject() { ItemsVisible = Visibility.Visible, Uid = "11" };
            _lAnimal12 = new ItemObject() { ItemsVisible = Visibility.Visible, Uid = "12" };
            _lAnimal13 = new ItemObject() { ItemsVisible = Visibility.Visible, Uid = "13" };
            _lAnimal20 = new ItemObject() { ItemsVisible = Visibility.Collapsed, Uid = "20" };
            _lAnimal21 = new ItemObject() { ItemsVisible = Visibility.Collapsed, Uid = "21" };
            _lAnimal22 = new ItemObject() { ItemsVisible = Visibility.Collapsed, Uid = "22" };
            _lAnimal30 = new ItemObject() { ItemsVisible = Visibility.Collapsed, Uid = "30" };
            _lAnimal31 = new ItemObject() { ItemsVisible = Visibility.Collapsed, Uid = "31" };
            _lAnimal32 = new ItemObject() { ItemsVisible = Visibility.Collapsed, Uid = "32" };
            _lAnimal40 = new ItemObject() { ItemsVisible = Visibility.Collapsed, Uid = "40" };
            _lAnimal41 = new ItemObject() { ItemsVisible = Visibility.Collapsed, Uid = "41" };
            _lAnimal42 = new ItemObject() { ItemsVisible = Visibility.Collapsed, Uid = "42" };
            List1 = new List<ItemObject>() {_lAnimal10,_lAnimal11,_lAnimal12,_lAnimal13,
_lAnimal20,_lAnimal21,_lAnimal22,_lAnimal30,_lAnimal31,_lAnimal32,_lAnimal40,_lAnimal41,_lAnimal42
    };
          
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
                        @"Resources\Notions\Prepositions\p1.jpg";
            NotifyPropertyChanged(nameof(BackgroundPic) );
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
            if (!Common.StaticVar.inline.IsBoy)
            {
                messagePic = System.AppDomain.CurrentDomain.BaseDirectory
                 + @"Resources\Notions\Prepositions\messageAnimals.png";
            }
            else
                messagePic = string.Empty;
            NotifyPropertyChanged(nameof(messagePic) );
            _index = 0;
            DoSwichPage(_index + 1);
        }
        void IPageVM.disload()
        {
            Database.DatabaseManager.Inline.SaveActivity(4,_startTime, System.DateTime.Now,
  Name, "LERM", "", Common.GeneralFunctions.GetLanguage(LanguageBut),0);
        }

        private void DoSwitchLanguage(object obj)
        {
            if (Common.StaticVar.PlayMode)
                return;

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

            //int i = int.Parse(obj.ToString());
            //int is1 = 0;
            //for (int j = 0; j < LanguageBut.Length; j++)
            //{
            //    if (!string.IsNullOrEmpty(LanguageBut[j].Background))
            //        is1++;
            //}
            //if (is1 == 1 && !string.IsNullOrEmpty(LanguageBut[i].Background))
            //    return;
            //LanguageBut[i].Background = LanguageBut[i].Background != string.Empty ? string.Empty :
            //    System.AppDomain.CurrentDomain.BaseDirectory +   @"Resources\Notions\Animals\AnimalStitle" + i + ".png";
            //NotifyPropertyChanged("LanguageBut" + i);

            DoSwichPage(_index);
        }
   
        private void DoSwichPage(object obj)
        {
            if (Common.StaticVar.PlayMode)
                return;
            object index = obj;
            //PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory +
            //     @"Resources\Audio\He\Prepositions\" + PlaySentens[index] + ".wav");
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
                 @"Resources\Notions\Prepositions\p" + index + ".jpg";
            NotifyPropertyChanged(nameof(BackgroundPic) );
            string id = index.ToString();
            for (int i = 0; i < List1.Count; i++)
            {
                if (List1[i].Uid[0] == id[0])
                    List1[i].ItemsVisible = Visibility.Visible;
                else
                    List1[i].ItemsVisible = Visibility.Collapsed;
                NotifyPropertyChanged("LAnimal" + List1[i].Uid);
            }
            _index = int.Parse(id);
        }

        public void DoShowAnimals(object obj)
        {
            if (Common.StaticVar.PlayMode)
                return;
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
                 @"Resources\Notions\Prepositions\p" + obj + ".jpg";
            NotifyPropertyChanged(nameof(BackgroundPic) );
            new Thread(new ThreadStart(() =>
            {
                _playRun = true;
                for (int l = 0; l < LanguageBut.Length; l++)
                {
                    if (LanguageBut[l].Background.Contains("AnimalStitle"))
                    {
                        _logic.SwitchLanguage(l);
                        PlayUrl(_logic.GetPlay(obj));
                        //WhitAntilPlayStop(ref _playRun);
                        //WhitTime(3000, ref _playRun);
                        while (Common.StaticVar.PlayMode)
                            Thread.Sleep(100);
                    }
                }
                _playRun = false;
            })).Start();
        }
    }
}
