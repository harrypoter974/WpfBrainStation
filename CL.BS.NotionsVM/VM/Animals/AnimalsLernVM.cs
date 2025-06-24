
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

namespace CL.BS.NotionsVM.VM.Animals
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class AnimalsLernVM : BaseItemPage, IPageVM
    {
        public override string Name
        {
            get
            {
                return "AnimalsLernVM";
            }
        }
        public string BackgroundPic { get; set; }
        public ICommand ChangBackground { get; set; }
        private IAnimalsManager _logic = (IAnimalsManager)
          SupportHandlerManager.Base.GetManager("AnimalsManager");

        public AnimalsLernVM()
        {
            ChangBackground = new RelayCommand(DoChangBackground);
            ShowItem = new RelayCommand(DoShowAnimals);
            SwitchLanguage = new RelayCommand(DoSwitchLanguage);
            for (int i = 0; i < Items.Length; i++)
                Items[i] = new ItemObject() { ItemsVisible = Visibility.Visible };
      
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


            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
         @"Resources\Notions\Animals\Animals" + Common.StaticVar.inline.AnimalsLern + ".jpg";
            NotifyPropertyChanged("BackgroundPic");
            base.Settings();
            ListWordVisible();
            if (!Common.StaticVar.inline.IsBoy)
            {
                messagePic = System.AppDomain.CurrentDomain.BaseDirectory +
                   @"Resources\Notions\Animals\message.png";
            }
            else
                messagePic = string.Empty;
            NotifyPropertyChanged("messagePic");
            UrlPlay = string.Empty;
            Clear();
            if (Common.StaticVar.inline.AnimalsLernWord >-1)
                DoShowAnimals(Common.StaticVar.inline.AnimalsLernWord);
        }

        private void DoSwitchLanguage(object obj)
        {
            int i = int.Parse(obj.ToString());
            LanguageBut[i].Background = LanguageBut[i].Background != string.Empty ? string.Empty 
                : System.AppDomain.CurrentDomain.BaseDirectory +
             @"Resources\Notions\Animals\AnimalStitle" + i + ".png";
            NotifyPropertyChanged("LanguageBut" + i);
            for (i = 0; i < Items.Length; i++)
            {
                Items[i].ItemsVisible = Visibility.Visible;
                NotifyPropertyChanged("Item" + i);
            }
            Clear();
        }

        private void DoChangBackground(object odj)
        {
            if (Common.StaticVar.PlayMode)
                return;
            Common.StaticVar.inline.AnimalsLern = Common.StaticVar.inline.AnimalsLern == 0 ? 1 : 0;
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
   @"Resources\Notions\Animals\Animals" + Common.StaticVar.inline.AnimalsLern + ".jpg";
            NotifyPropertyChanged("BackgroundPic");
            Clear();
        }

        private void Clear()
        {
            for (int i = 0; i < Items.Length; i++)
            {
                Items[i].ItemsVisible = Visibility.Visible;
                NotifyPropertyChanged("Item" + i);
            }
        }

        private void DoShowAnimals(object animals)
        {
            if (Common.StaticVar.PlayMode)
                return;

            new Thread(new ThreadStart(() =>
            {
                Common.StaticVar.inline.AnimalsLernWord = int.Parse(animals.ToString());
                Items[Common.StaticVar.inline.AnimalsLernWord].ItemsVisible = Visibility.Hidden;
                NotifyPropertyChanged("Item" + Common.StaticVar.inline.AnimalsLernWord);
                for (int l = 0; l < 3; l++)
                {
                    if (LanguageBut[l].Background.Contains("AnimalStitle"))
                    {
                        PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory +
            _logic.PlayAnimals(l, Common.StaticVar.inline.AnimalsLern, Common.StaticVar.inline.AnimalsLernWord));
                        WhitAntilPlayStop(ref Common.StaticVar.PlayMode);
                    }
                }
            })).Start();
        }
    }
}
