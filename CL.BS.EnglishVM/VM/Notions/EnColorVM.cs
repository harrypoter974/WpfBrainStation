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
    public class EnColorVM : BaseLernPage, IPageVM
    {
        private bool _isPlay = false;
        public ICommand PlayAll { get; set; }
        public ICommand SwitchColor { get; set; }
        public ICommand ShowColor { get; set; }
        public string BackgroundPic { get; set; }
        public string PlayAllBut { get; set; }
        public Visibility Color0 { get { return _color[0].ItemsVisible; } set { _color[0].ItemsVisible = value; } }
        public Visibility Color1 { get { return _color[1].ItemsVisible; } set { _color[1].ItemsVisible = value; } }
        public Visibility Color2 { get { return _color[2].ItemsVisible; } set { _color[2].ItemsVisible = value; } }
        public Visibility Color3 { get { return _color[3].ItemsVisible; } set { _color[3].ItemsVisible = value; } }
        public Visibility Color4 { get { return _color[4].ItemsVisible; } set { _color[4].ItemsVisible = value; } }
        public Visibility Color5 { get { return _color[5].ItemsVisible; } set { _color[5].ItemsVisible = value; } }
        private ItemObject[] _color = new ItemObject[6];
        public override string Name
        {
            get
            {
                return nameof(EnColorVM);
            }
        }
        IEnColorManager _logic = (IEnColorManager)
SupportHandlerManager.Base.GetManager("EnColorManager");

        public EnColorVM()
        {
            ShowColor = new RelayCommand(DoShowColor);
            SwitchColor = new RelayCommand(DoSwitchColor);
            PlayAll = new RelayCommand(DoPlayAll);
            for (int i = 0; i < _color.Length; i++)
            {
                _color[i] = new ItemObject();
            }
        }

        private void DoPlayAll(object obj)
        {
            if (Common.StaticVar.PlayMode || _isPlay) {
                if (_isPlay)
                {
                    _isPlay = false;
                    PlayAllBut = System.AppDomain.CurrentDomain.BaseDirectory +
         @"Resources\Notions\Colors\StopPlayAllBut.png";
                    NotifyPropertyChanged(nameof(PlayAllBut));
                }
                return;
            }
            _isPlay = true;
            PlayAllBut = System.AppDomain.CurrentDomain.BaseDirectory +
          @"Resources\Notions\Colors\PlayAllBut.png";
            NotifyPropertyChanged(nameof(PlayAllBut));
            new Thread(new ThreadStart(() =>
            {
                for (int i = 0; i < _color.Count() && _isPlay; i++)
                {
                    PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory +
                     @"Resources\Audio\En\Colors\" + _logic.GetColorWord(i) + ".wav");
                    _color[i].ItemsVisible = Visibility.Hidden;
                    NotifyPropertyChanged("Color" + i);
                }
            })).Start();
        }

        void IPageVM.load()
        {
            base.Settings();
            if (!Common.StaticVar.inline.IsBoy)
            {
                messagePic = System.AppDomain.CurrentDomain.BaseDirectory
                 + @"Resources\Notions\Colors\message.png";
            }
            else
                messagePic = string.Empty;
            PlayAllBut = string.Empty;
            NotifyPropertyChanged(nameof(messagePic));
            NotifyPropertyChanged(nameof(PlayAllBut));
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\Lang\En\Color\Color" + _logic.GetColorIndex() + ".jpg";
        }

        void IPageVM.disload()
        {
            Clear();
        }

        public void DoShowColor(object obj)
        {
            if (Common.StaticVar.PlayMode)
                return;
            //new Thread(new ThreadStart(() =>
            //{ })).Start();
                PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory +
                    @"Resources\Audio\En\Colors\" + _logic.GetColorWord(obj) + ".wav");
                int i = int.Parse(obj.ToString());
                _color[i].ItemsVisible = Visibility.Hidden;
                NotifyPropertyChanged("Color" + i);
           
        }

        public void DoSwitchColor(object obj)
        {
            if (Common.StaticVar.PlayMode)
                return;
            Clear();
            _logic.SetColorIndex(obj);
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
         @"Resources\Lang\En\Color\Color" + obj + ".jpg";
            NotifyPropertyChanged(nameof(BackgroundPic));
        }

        private void Clear()
        {
            _isPlay = false;
            for (int i = 0; i < _color.Length; i++)
            {
                _color[i].ItemsVisible   = Visibility.Visible;
                NotifyPropertyChanged("Color" + i);
            }
        }
    }
}
