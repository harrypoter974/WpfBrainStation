using CL.BS.Contract;
using CL.BS.EnglishManager.Interface.Notions;
using CL.BS.EnglishManager.Manager.Notions;
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
    public class EnPrepositionsLernVM : BaseLernPage, IPageVM
    {
        public ICommand ShowAnimals { get; set; }
        public ICommand SwichPage { get; set; }
        public string BackgroundPic { get; set; }
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
        private ItemObject _lAnimal10
, _lAnimal11, _lAnimal12, _lAnimal13, _lAnimal20, _lAnimal21, _lAnimal22, _lAnimal30, _lAnimal31, _lAnimal32
, _lAnimal40, _lAnimal41, _lAnimal42;
        private List<ItemObject> _list1;
        private IEnPrepositionsManager _logic = new EnPrepositionsManager();
        public override string Name
        {
            get
            {
                return nameof(EnPrepositionsLernVM);
            }
        }

        public EnPrepositionsLernVM()
        {
            ShowAnimals = new RelayCommand(DoShowAnimals);
            SwichPage = new RelayCommand(DoSwichPage);
            _lAnimal10=new ItemObject(){ItemsVisible=Visibility.Visible,Uid="10"};
            _lAnimal11=new ItemObject(){ItemsVisible=Visibility.Visible,Uid="11"};
            _lAnimal12=new ItemObject(){ItemsVisible=Visibility.Visible, Uid = "12" };
            _lAnimal13=new ItemObject(){ItemsVisible = Visibility.Visible, Uid = "13" };
            _lAnimal20=new ItemObject(){ItemsVisible = Visibility.Collapsed,  Uid = "20" };
            _lAnimal21=new ItemObject(){ItemsVisible = Visibility.Collapsed ,Uid="21"};
            _lAnimal22=new ItemObject(){ItemsVisible = Visibility.Collapsed ,Uid="22"};
            _lAnimal30=new ItemObject(){ItemsVisible = Visibility.Collapsed ,Uid="30"};
            _lAnimal31=new ItemObject(){ItemsVisible = Visibility.Collapsed ,Uid="31"};
            _lAnimal32=new ItemObject(){ItemsVisible = Visibility.Collapsed ,Uid="32"};
            _lAnimal40=new ItemObject(){ItemsVisible = Visibility.Collapsed ,Uid="40"};
            _lAnimal41=new ItemObject(){ItemsVisible = Visibility.Collapsed ,Uid="41"};
            _lAnimal42=new ItemObject(){ ItemsVisible = Visibility.Collapsed ,Uid="42"};
          _list1 = new List<ItemObject>() {_lAnimal10,_lAnimal11,_lAnimal12,_lAnimal13,
_lAnimal20,_lAnimal21,_lAnimal22,_lAnimal30,_lAnimal31,_lAnimal32,_lAnimal40,_lAnimal41,_lAnimal42 };
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\Lang\En\Prepositions\p1.jpg";
            NotifyPropertyChanged(nameof(BackgroundPic));
        }
        void IPageVM.load()
        {
            base.Settings();
            if (!Common.StaticVar.inline.IsBoy)
            {
                messagePic = System.AppDomain.CurrentDomain.BaseDirectory
                 + @"Resources\Lang\En\Prepositions\message.png";
            }
            else
                messagePic = string.Empty;
            NotifyPropertyChanged(nameof(messagePic));
            DoSwichPage(_logic.GetIndex());
            Common.StaticVar.PlayMode = false;
        }

        private void DoSwichPage(object index)
        {
            if (Common.StaticVar.PlayMode)
                return;
            _logic.SetIndex(index);
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
                 @"Resources\Lang\En\Prepositions\p" + index + ".jpg";
            NotifyPropertyChanged(nameof(BackgroundPic));
            string id =index.ToString();
            for (int i = 0; i < _list1.Count; i++)
            {
                if (_list1[i].Uid[0] == id[0])
                    _list1[i].ItemsVisible = Visibility.Visible;
                else
                    _list1[i].ItemsVisible = Visibility.Collapsed;
               NotifyPropertyChanged("LAnimal"+_list1[i].Uid);
            }
        }

        public void DoShowAnimals(object obj)
        {
            if (Common.StaticVar.PlayMode)
                return;
            base.PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory + _logic.GetPlay(obj)); 
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
                 @"Resources\Lang\En\Prepositions\p" + obj + ".jpg";
            NotifyPropertyChanged(nameof(BackgroundPic));
            
        }
    }
}
