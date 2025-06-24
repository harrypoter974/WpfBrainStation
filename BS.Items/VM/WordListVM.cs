using CL.BS.Common;
using CL.BS.Model;
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
    internal class WordListVM : INotifyPropertyChanged
    {
        public List<ItemObject> MyList { get; set; }
        public WordListVM(List<ItemObject> lstWords)
        {
            MyList = lstWords;
            NotifyPropertyChanged(nameof(MyList));
        }
        internal void DoSelectionOfWord(int index)
        {
            bool Contains = MyList[index].Background.Contains("UCCheckBoxOn.jpg");
            MyList[index].Background = String.Format(@"{0}Resources\BS.Items\UCCheckBox{1}.jpg"
, System.AppDomain.CurrentDomain.BaseDirectory,    Contains ? "Off" :"On" );
            MyList = new List<ItemObject>(MyList);
            NotifyPropertyChanged(nameof(MyList));
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
