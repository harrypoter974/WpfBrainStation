using CL.BS.MEF;
using CL.BS.VMCommon;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;

namespace BS.Items.VM
{
    internal class WinSettingsTriviaVM: INotifyPropertyChanged
    {
        public string Topic1 { get { return TopicList[0].Background; } set { TopicList[0].Background = value; } }
        public string Topic2 { get { return TopicList[1].Background; } set { TopicList[1].Background = value; } }
        public string Topic3 { get { return TopicList[2].Background; } set { TopicList[2].Background = value; } }
        public string Topic4 { get { return TopicList[3].Background; } set { TopicList[3].Background = value; } }

        protected ViewObject[] TopicList = new ViewObject[4];
        public ICommand Clear { get; set; }
        public ICommand TopicType { get; set; }

        public WinSettingsTriviaVM()
        {
            for (int i = 0; i < TopicList.Length; i++)
                TopicList[i] = new ViewObject() { Background = SetBackgroundTopic(i + 1) };
            TopicType = new RelayCommand(DoTopicType);
            Clear = new RelayCommand(DoClear);
        }

        private string SetBackgroundTopic(int v)
        {
           return CL.BS.Common.StaticVar.GardenTriviaTopic.Contains(v)? System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Notions\Trivia\Topic" + v+".jpg":string.Empty;
        }

        private void DoTopicType(object obj)
        {
            int i = int.Parse(obj.ToString());
            if (CL.BS.Common.StaticVar.GardenTriviaTopic.Contains(i))
                CL.BS.Common.StaticVar.GardenTriviaTopic.Remove(i);
            else
                CL.BS.Common.StaticVar.GardenTriviaTopic.Add(i);
            TopicList[i - 1].Background = SetBackgroundTopic(i);
            NotifyPropertyChanged("Topic" + i);
        }

        private void DoClear(object obj)
        {
            CL.BS.Common.StaticVar.GardenTriviaTopic.Clear();
            for (int i = 0; i < TopicList.Length; i++)
            {
                TopicList[i].Background = string.Empty;
                NotifyPropertyChanged("Topic" +( i+1));
            }
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