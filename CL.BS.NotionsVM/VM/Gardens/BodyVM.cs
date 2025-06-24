using CL.BS.Contract;
using CL.BS.Database;
using CL.BS.MEF;
using CL.BS.NotionsManager.Interface;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CL.BS.NotionsVM.VM.Gardens
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class BodyVM : BaseItemPage, IPageVM
    {// 
        private bool _isBack = true;
        public Visibility LooksForward { get; set; }
        public Visibility LooksBack { get; set; }
        public string BackgroundPic { get; set; }
        public ICommand SwitchPage { get; set; }
        private IBodyManager _logic = (IBodyManager)
SupportHandlerManager.Base.GetManager("BodyManager");
        public override string Name =>nameof(BodyVM) ; 

        public BodyVM()
        {
            SwitchPage = new RelayCommand(DoSwitchPage);
            ShowItem = new RelayCommand(DoShowItem);
            HideLine = new RelayCommand(doHideLine);
            SwitchLanguage = new RelayCommand(doSwitchLanguage);
        }

        private void doSwitchLanguage(object obj)
        {
            int l = int.Parse(obj.ToString());
            LanguageBut[l].Background = LanguageBut[l].Background != string.Empty ? string.Empty 
                : System.AppDomain.CurrentDomain.BaseDirectory +
             @"Resources\Notions\Animals\AnimalStitle" + l + ".png";
            NotifyPropertyChanged("LanguageBut" + l);
            for (int i = 0; i < Items.Length; i++)
            {
                Items[i].ItemsVisible = (_isBack ? i > 4 : i < 5) ? Visibility.Collapsed : Visibility.Visible;
                NotifyPropertyChanged("Item" + i);
            }
        }

        void IPageVM.load()
        {          
            ListWordVisible();
            DoSwitchPage(0);
        }
        void IPageVM.disload()
        {
            DatabaseManager.Inline.SaveActivity(4,_startTime,DateTime.Now, Name, "LERM", "", GetLanguage(), 0);
        }

        private  void doHideLine(object obj)
        {
            base.DoHideLine(obj);
            for (int i = 0; i < Items.Length; i++)
            {
                Items[i].ItemsVisible = (_isBack ? i > 4 : i < 5) ? Visibility.Collapsed : Visibility.Visible;
                NotifyPropertyChanged("Item" + i);
            }
            if (!string.IsNullOrEmpty(Items[0].Button)&&! string.IsNullOrEmpty(Items[1].Button))
            {
                BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
          @"Resources\Notions\Body\BodyForward2.jpg";
            }
            else if (string.IsNullOrEmpty(Items[0].Button) && string.IsNullOrEmpty(Items[1].Button))
            {
                BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
     @"Resources\Notions\Body\BodyForward.jpg";
            }
            else if (!string.IsNullOrEmpty(Items[0].Button) && string.IsNullOrEmpty(Items[1].Button))
            {
                BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
     @"Resources\Notions\Body\BodyForward1.jpg";
            }
            else if (string.IsNullOrEmpty(Items[0].Button) &&! string.IsNullOrEmpty(Items[1].Button))
            {
                BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
     @"Resources\Notions\Body\BodyForward0.jpg";
            }
            NotifyPropertyChanged(nameof(BackgroundPic));
        }

        private void DoShowItem(object obj)
        {
            lock (this)
            {
                if (Common.StaticVar.PlayMode)
                    return;
                new Thread(new ThreadStart(() =>
                {
                    int boody = int.Parse(obj.ToString());

                    Items[boody].ItemsVisible = Visibility.Hidden;
                    NotifyPropertyChanged("Item" + boody);
                    for (int l = 0; l < 3; l++)
                    {
                        if (LanguageBut[l].Background.Contains("AnimalStitle"))
                        {
                            PlayUrl(_logic.PlayClothings(boody, l));
                            WhitAntilPlayStop(ref Common.StaticVar.PlayMode);
                        }
                    }
                })).Start();
            }
        }

        private void DoSwitchPage(object obj)
        {
            _isBack = !_isBack;
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
                   @"Resources\Notions\Body\Body" + (_isBack ? "Back" : "Forward") + ".jpg";
            NotifyPropertyChanged(nameof(BackgroundPic));
            for (int i = 0; i < Items.Length; i++)
            {
                Items[i].ItemsVisible = (_isBack ? i > 4 : i < 5) ? Visibility.Collapsed : Visibility.Visible;
                NotifyPropertyChanged("Item" + i);
            }
            if (_isBack)
            {
                LooksForward = Visibility.Collapsed;
                LooksBack = Visibility.Visible;
            }
            else
            {
                LooksForward = Visibility.Visible;
                LooksBack = Visibility.Collapsed;
            }
            for (int i = 0; i < 4; i++)
            {
                Items[i].IsHideLine = true;
                Items[i].LineVisible =Visibility.Collapsed;
                NotifyPropertyChanged("LineItem" + i);
            }
            NotifyPropertyChanged(nameof(LooksForward) );
            NotifyPropertyChanged(nameof(LooksBack));
        }
    }
}
