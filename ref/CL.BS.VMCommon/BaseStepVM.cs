using CL.BS.Contract;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.VMCommon
{
    public abstract class BaseStepVM : INotifyPropertyChanged, IPageVM
    {
        public BaseStepVM()
        {
            BackgroundAnswerButton = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\BS.Items\ButtonG.png";
            NotifyPropertyChanged("BackgroundAnswerButton");
            GoTo1 = new RelayCommand(GoToPage);            
        }

        public Action<BaseStepVM, string> GoHome { get; set; }

        public abstract string Name { get; }

        Action<IPageVM, string> IPageVM.GoToAction
        {
            set => Console.WriteLine();            
        }

        void IPageVM.disload() { }
        void IPageVM.load() { }
        public void GoToPage(object obj)
        {           
            GoHome(this, obj.ToString());
        }
        private ICommand m_goTo;
        public ICommand GoTo1
        {
            get { return m_goTo; }
            set { m_goTo = value; }
        }
        public ICommand AnswerBut   {   get ; set;}
        private string _playUrl;
        public string Url
        {
            get { return _playUrl; }
            set
            {
                if (_playUrl == value) return;
                _playUrl = value;
                NotifyPropertyChanged("Url");
            }
        }
        public bool IsQuestionMode = true;
        private string   _BackgroundAnswerButton;
        public string BackgroundAnswerButton
        {
            get  { return _BackgroundAnswerButton; }
            set { _BackgroundAnswerButton = value; }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        protected void NotifyPropertyChanged(string propertyName)
        {
            VerifyPropertyName(propertyName);
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void NotifyPropertyChanged(int propertyValue)
        {
            VerifyPropertyName(propertyValue);
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyValue.ToString()));
        }

        [Conditional("DEBUG")]
        private void VerifyPropertyName(string propertyName)
        {
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
                throw new ArgumentNullException(GetType().Name + " does not contain property: " + propertyName);
        }

        [Conditional("DEBUG")]
        private void VerifyPropertyName(int propertyValue)
        {
            if (TypeDescriptor.GetProperties(this)[propertyValue] == null)
                throw new ArgumentNullException(GetType().Name + " does not contain property: " + propertyValue);
        }
           public void PlayList( string[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                string url=System.AppDomain.CurrentDomain.BaseDirectory + list[i];
                if (!File.Exists(url))
                    continue;
                Url = url;
                WaveFileReader fill = new WaveFileReader(Url);
                Thread.Sleep(fill.TotalTime.Milliseconds+800);
            }
        }
        public void SwitchAnswerButton()
        {
            IsQuestionMode = !IsQuestionMode;
            if (IsQuestionMode)
                BackgroundAnswerButton = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\BS.Items\ButtonG.png";
            else
                BackgroundAnswerButton = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\BS.Items\ButtonV.png";
            NotifyPropertyChanged("BackgroundAnswerButton");
        }
    }
}
