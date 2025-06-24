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
    class KillMiceVM : INotifyPropertyChanged
    {
        /// <summary>
        /// chose which mice to cntinu work 
        /// </summary>
        public ICommand KillMice { get; set; }

        public KillMiceVM()
        {
            KillMice = new CL.BS.VMCommon.RelayCommand(DoKillMice);
            MiceKiller.SetMainMices( 0);
        }

        private void DoKillMice(object obj)
        {
            MiceKiller.SetMainMices(obj);
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
