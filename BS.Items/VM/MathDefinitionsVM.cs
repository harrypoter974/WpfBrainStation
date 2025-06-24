using CL.BS.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BS.Items.VM
{
    class MathDefinitionsVM : INotifyPropertyChanged
    {
        public string DomainPic { get; set; }
        public string EnterTypePic { get; set; }
        public ICommand SetDomain { get; set; }
        public ICommand EnterType { get; set; }
        private string _type;
        private string[] _size = new string[] { "LOW", "MED", "HIGH" };

        public  MathDefinitionsVM(object Type)
        {
            this._type = Type.ToString();
          SetDomain=  new RelayCommand(DoSetDomain);
            EnterType = new RelayCommand(DoEnterType);
          ;
            DomainPic = System.AppDomain.CurrentDomain.BaseDirectory
                 + @"Resources\BS.Items\levels_" + _size[StaticVar.inline.DomainNumIndex] + ".png"; ;
            NotifyPropertyChanged("DomainPic");
            EnterTypePic = System.AppDomain.CurrentDomain.BaseDirectory
              + @"Resources\BS.Items\hazana_" + StaticVar.inline.enterType + ".png";
            NotifyPropertyChanged("EnterTypePic");
        }

        private void DoSetDomain(object obj)
        {
             StaticVar.inline.DomainNumIndex =int.Parse(obj.ToString()) ;         
            DomainPic = System.AppDomain.CurrentDomain.BaseDirectory
               + @"Resources\BS.Items\levels_" + _size[int.Parse( obj.ToString())] + ".png"; 
            NotifyPropertyChanged("DomainPic");
        }

        private void DoEnterType(object obj)
        {
          StaticVar.inline.enterType = GlobalVar.EnterTypeList[ int.Parse(obj.ToString())];
            EnterTypePic = System.AppDomain.CurrentDomain.BaseDirectory
               + @"Resources\BS.Items\hazana_" + StaticVar.inline.enterType + ".png";
            NotifyPropertyChanged("EnterTypePic");
        }
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;



        protected void NotifyPropertyChanged(string propertyName)
        {
            VerifyPropertyName(propertyName);
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        [Conditional("DEBUG")]
        private void VerifyPropertyName(string propertyName)
        {
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
                throw new ArgumentNullException(GetType().Name + " does not contain property: " + propertyName);
        }
        #endregion
    }
}
