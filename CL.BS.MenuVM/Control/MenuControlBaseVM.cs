using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.MenuVM.Control
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public  class MenuControlBaseVM : BaseMenuVM, IPageVM
    {
        public override string Name
        {
            get
            {
                return "MenuControlBaseVM";
            }
        }
        public ICommand AddPage { get; set; }
        public ICommand RemovePage { get; set; }
        public ICommand GoToControl { get; set; }
        protected string[] PagesControl;

        protected string[][] MenuControl;
        public MenuControlBaseVM()
        {
            AddPage = new RelayCommand(DoAddPage);
            RemovePage = new RelayCommand(DoRemovePage);
            GoToControl = new RelayCommand(DoGoToControl);
        }
        private void DoGoToControl(object obj)
        {
            string[] p = obj.ToString().Split(',');
            if(BackgroundBut[int.Parse( p[0])].Background!= System.AppDomain.CurrentDomain.BaseDirectory+ @"Resources\BS.Items\redBorderBut.png")
                DoGoToPage(p[1]);
        }

        private void DoAddPage(object obj)
        {
            string p=obj.ToString();
            if (p.Contains(','))
            {
                string[] pl = p.Split(',');
                for (int i = 0; i < pl.Length; i++)
                    if (!Common.StaticVar.inline.LimitingPages.Contains(pl[i]))
                        Common.StaticVar.inline.LimitingPages.Add(pl[i]);
            }
            else if(!Common.StaticVar.inline.LimitingPages.Contains(p))
                Common.StaticVar.inline.LimitingPages.Add(p);
            ShowPagePermissions();

        }

        private void DoRemovePage(object obj)
        {
            string p = obj.ToString();
            if (p.Contains(','))
            {
                string[] pl = p.Split(',');
                for (int i = 0; i < pl.Length; i++)
                    Common.StaticVar.inline.LimitingPages.Remove(pl[i]);
            }
            else
                Common.StaticVar.inline.LimitingPages.Remove(p);
            if (!string.IsNullOrEmpty(this.ToString()))
                Common.StaticVar.inline.LimitingPages.Remove(this.ToString());
            ShowPagePermissions();
        }


        public void ShowPagePermissions()
        {
            bool b;
            for (int i = 0; i < Pages.Length; i++)
            {
                b = Common.StaticVar.inline.LimitingPages.Count() == 0;
                if (!b)
                {
                    b = !Common.StaticVar.inline.LimitingPages.Contains(Pages[i]);
                }
                BackgroundBut[i].Background = System.AppDomain.CurrentDomain.BaseDirectory
               + @"Resources\BS.Items\" + (b ? "green" : "red") + "BorderBut.png";
                NotifyPropertyChanged("BackgroundBut" + i);
            }
            if (MenuControl!=null)
            {
                for (int i = 0; i < MenuControl.Length; i++)
                {
                    if (BackgroundBut[i].Background.Contains("green"))
                    {
                        bool  close = false;
                        for (int j = 0; j < MenuControl[i].Length&& !close; j++)
                        {
                            close = Common.StaticVar.inline.LimitingPages.Contains(MenuControl[i][j]);
                        }
                        if (close)
                        {
                            BackgroundBut[i].Background = System.AppDomain.CurrentDomain.BaseDirectory
         + @"Resources\BS.Items\PartialFrameBut.png";
                            NotifyPropertyChanged("BackgroundBut" + i);
                        }
                    }
                }
            }
        }
        void IPageVM.load()
        {
            base.Settings();
            ShowPagePermissions();
        }
    }
}
