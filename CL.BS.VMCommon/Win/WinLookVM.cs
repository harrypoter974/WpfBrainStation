using CL.BS.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.VMCommon
{
  internal  class WinLookVM : INotifyPropertyChanged
    {
        public WinLookVM(ref bool openLook)
        {
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory
       + @"Resources\BS.Items\WinLook\WinLook0.png";
            NotifyPropertyChanged("BackgroundPic");
            this._openLook =openLook;
            SetState = new RelayCommand(DoSetState);
        }

        private void DoSetState(object obj)
        {
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory
+ @"Resources\BS.Items\WinLook\WinLook"+obj+".png";
            NotifyPropertyChanged("BackgroundPic");
            _openLook = obj.ToString() == "2";
        }

        public ICommand SetState { get; set; }
        private bool _openLook = true;
        public string BackgroundPic { get; set; }
      
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        internal bool GetState()
        {
            return this._openLook;
        }

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
