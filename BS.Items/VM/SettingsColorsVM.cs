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
    class SettingsColorsVM: INotifyPropertyChanged
    {
        public string Color0 { get { return ColorList[0].Background; } set { ColorList[0].Background = value; } }
        public string Color1 { get { return ColorList[1].Background; } set { ColorList[1].Background = value; } }
        public string Color2 { get { return ColorList[2].Background; } set { ColorList[2].Background = value; } }
        public string Color3 { get { return ColorList[3].Background; } set { ColorList[3].Background = value; } }
        public string Color4 { get { return ColorList[4].Background; } set { ColorList[4].Background = value; } }
        public string Color5 { get { return ColorList[5].Background; } set { ColorList[5].Background = value; } }
        public string Color6 { get { return ColorList[6].Background; } set { ColorList[6].Background = value; } }
        public string Color7 { get { return ColorList[7].Background; } set { ColorList[7].Background = value; } }
        public string Color8 { get { return ColorList[8].Background; } set { ColorList[8].Background = value; } }
        public string Color9 { get { return ColorList[9].Background; } set { ColorList[9].Background = value; } }
        public string Color10 { get { return ColorList[10].Background; } set { ColorList[10].Background = value; } }
        public string Color11 { get { return ColorList[11].Background; } set { ColorList[11].Background = value; } }
        protected ViewObject[] ColorList = new ViewObject[CL.BS.Common.StaticVar.ColorsText.Length];
        public ICommand Clear { get; set; }
        public ICommand ColorType { get; set; }

        public SettingsColorsVM()
        {
            for (int i = 0; i < ColorList.Length; i++)
            {
                ColorList[i] = new ViewObject();
                if (StaticVar.inline._ColorsIndex.Contains(i.ToString()))
                {
                    ColorList[i].Background = StaticVar.Green;
                    NotifyPropertyChanged("Color" + i);
                }
            }
            Clear = new CL.BS.VMCommon.RelayCommand(DoClear);
            ColorType= new CL.BS.VMCommon.RelayCommand(DoColorType);
        }

        private void DoColorType(object obj)
        {
            int i = int.Parse(obj.ToString());
            if (StaticVar.inline._ColorsIndex.Contains(obj.ToString()))
            {
                StaticVar.inline._ColorsIndex.Replace(obj.ToString(), string.Empty);
                ColorList[i].Background = "Transparent";
            }
            else
            {
                StaticVar.inline._ColorsIndex += obj;
                ColorList[i].Background = StaticVar.Green;
            }
            NotifyPropertyChanged("Color" + i);
        }

        private void DoClear(object obj)
        {
            for (int i = 0; i < ColorList.Length; i++)
            {
                ColorList[i].Background = "Transparent";
                NotifyPropertyChanged("Color" + i);
            }
            StaticVar.inline._ColorsIndex = string.Empty;
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
