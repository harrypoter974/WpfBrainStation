using CL.BS.Contract;
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
    public class EnFamilyVM : BaseLernPage, IPageVM
    {
        public ICommand ShowPerson { get; set; }
        public Visibility Person0 { get { return _person[0].ItemsVisible; } set { _person[0].ItemsVisible = value; } }
        public Visibility Person1 { get { return _person[1].ItemsVisible; } set { _person[1].ItemsVisible = value; } }
        public Visibility Person2 { get { return _person[2].ItemsVisible; } set { _person[2].ItemsVisible = value; } }
        public Visibility Person3 { get { return _person[3].ItemsVisible; } set { _person[3].ItemsVisible = value; } }
        public Visibility Person4 { get { return _person[4].ItemsVisible; } set { _person[4].ItemsVisible = value; } }
        public Visibility Person5 { get { return _person[5].ItemsVisible; } set { _person[5].ItemsVisible = value; } }
        private ItemObject[] _person = new ItemObject[6];
        private List<string> _personList = new List<string>()
        { "Mother","Father","Grandmother","Grandfather","Daughter","Son"   };
        public override string Name
        {
            get
            {
                return nameof(EnFamilyVM);
            }
        }

        public EnFamilyVM()
        {
            ShowPerson = new RelayCommand(DoPlayPerson);
            for (int i = 0; i < _person.Length; i++)
            {
                _person[i] = new ItemObject() { ItemsVisible = Visibility.Hidden };
            }
        }

        void IPageVM.load()
        {
            base.Settings();
            if (!Common.StaticVar.inline.IsBoy)
            {
                messagePic = System.AppDomain.CurrentDomain.BaseDirectory
                 + @"Resources\BS.Items\tapMessage.png";
            }
            else
                messagePic = string.Empty;
            NotifyPropertyChanged(nameof(messagePic));
        }

        void IPageVM.disload()
        {
            for (int i = 0; i < _person.Length; i++)
            {
                _person[i].ItemsVisible = Visibility.Hidden;
                NotifyPropertyChanged("Person" + i);
            }
        }

        public void DoPlayPerson(object obj)
        {
            if (Common.StaticVar.PlayMode)
                return;
            //new Thread(new ThreadStart(() =>
            //{ })).Start();
                int i = int.Parse(obj.ToString());
                PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory +
                    @"Resources\Audio\En\Family\" + _personList[i] + ".wav");
                _person[i].ItemsVisible = Visibility.Visible;
                NotifyPropertyChanged("Person" + i);
           
        }
    }
}
