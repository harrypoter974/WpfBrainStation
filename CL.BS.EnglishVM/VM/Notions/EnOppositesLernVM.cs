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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CL.BS.EnglishVM.Notions
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class EnOppositesLernVM : BaseLernPage, IPageVM
    {
        public ICommand ShowOpposit { get; set; }
        public ICommand SwichPage { get; set; }
        public string BackgroundPic { get; set; }
        public Visibility Rect0 { get { return _lrect[0].ItemsVisible; } set { _lrect[0].ItemsVisible = value; } }
        public Visibility Rect1 { get { return _lrect[1].ItemsVisible; } set { _lrect[1].ItemsVisible = value; } }
        private ItemObject[] _lrect = new ItemObject[2];
        private IEnOppositesManager _logic = (IEnOppositesManager)
SupportHandlerManager.Base.GetManager("EnOppositesManager");
        public override string Name
        {
            get
            {
                return nameof(EnOppositesLernVM);
            }
        }

        public EnOppositesLernVM()
        {
            ShowOpposit = new RelayCommand(DoShowOpposit);
            SwichPage = new RelayCommand(DoSwichPage);
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\Lang\En\Opposites\l0.jpg";
            NotifyPropertyChanged(nameof(BackgroundPic));
            for (int i = 0; i < _lrect.Length; i++)
            {
                _lrect[i] = new ItemObject() { ItemsVisible = Visibility.Visible };
            }
        }

        void IPageVM.load()
        {
            base.Settings();
            _logic.load();
            if (!Common.StaticVar.inline.IsBoy)
            {
                messagePic = System.AppDomain.CurrentDomain.BaseDirectory
                 + @"Resources\Lang\En\Opposites\message.png";
            }
            else
                messagePic = string.Empty;
            NotifyPropertyChanged(nameof(messagePic));
            DoSwichPage(_logic.GetIndex());
            Common.StaticVar.PlayMode = false;
        }

        void IPageVM.disload()
        {
            Clear();
        }

        private void DoSwichPage(object index)
        {
            if (Common.StaticVar.PlayMode)
                return;
            _logic.SetIndex(index);
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
                 @"Resources\Lang\En\Opposites\l" + index + ".jpg";
            NotifyPropertyChanged(nameof(BackgroundPic));
            Clear();
        }

        private void Clear()
        {
            for (int i = 0; i < _lrect.Length; i++)
            {
                _lrect[i].ItemsVisible = Visibility.Visible;
                NotifyPropertyChanged("Rect"+i);
            }
        }

        public void DoShowOpposit(object obj)
        {
            if (Common.StaticVar.PlayMode)
                return;
            int i = int.Parse(obj.ToString());
            string[] play = _logic.GetOppositPlay(i);
            base.PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory + play[i]);
            _lrect[i].ItemsVisible = Visibility.Hidden;
            NotifyPropertyChanged("Rect" + i);

        }
    }
}
